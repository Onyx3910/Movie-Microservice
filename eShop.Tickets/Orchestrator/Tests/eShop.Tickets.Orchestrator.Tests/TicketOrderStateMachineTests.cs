using Microsoft.Extensions.DependencyInjection;
using MassTransit;
using MassTransit.Testing;
using Saga.Domain.Entities;
using Saga.Domain.StateMachines;
using Saga.Domain.Events;
using eShop.Tickets.Domain;
using eShop.Tickets.Domain.Models;

namespace eShop.Tickets.Orchestrator.Tests
{
    [TestClass]
    public class TicketOrderStateMachineTests : BaseTest
    {

        [TestMethod]
        public async Task OrderCreatedEvent_ShouldTransitionTo_SelectingSeatsState()
        {
            var theaterId = NewId.NextGuid();
            var movieId = NewId.NextGuid();
            var showTime = DateTime.Now;

            var message = new TicketOrderCreated(CorrelationId, theaterId, movieId, showTime, DateTime.Now);

            await TestThatEventLeadsToState(sm => sm.TicketOrderSelectingSeatsState, CorrelationId, message);
        }

        [TestMethod]
        public async Task SeatsSelectedEvent_ShouldTransitionTo_WaitingOnPaymentState()
        {
            await OrderCreatedEvent_ShouldTransitionTo_SelectingSeatsState();

            var seats = "A1";
            var lastUpdatedDate = DateTime.Now;

            var message = new TicketOrderSeatsSelected(CorrelationId, seats, lastUpdatedDate);

            await TestThatEventLeadsToState(sm => sm.TicketOrderWaitingOnPaymentState, CorrelationId, message);
        }

        [TestMethod]
        public async Task SeatsExpiredEvent_ShouldTransitionTo_SelectingSeatsState()
        {
            await SeatsSelectedEvent_ShouldTransitionTo_WaitingOnPaymentState();

            var message = new TicketOrderSeatsExpired(CorrelationId, DateTime.Now);

            await TestThatEventLeadsToState(sm => sm.TicketOrderSelectingSeatsState, CorrelationId, message);
        }

        [TestMethod]
        public async Task PaymentSubmittedEvent_ShouldTransitionTo_ProcessingPaymentState()
        {
            await SeatsSelectedEvent_ShouldTransitionTo_WaitingOnPaymentState();

            var amount = 10;
            var address = new Address("123 My Street", "My City", "ST", "11111", "US");
            var creditCardPayment = new CreditCardPayment(string.Empty, string.Empty, DateOnly.Parse("12/12/2022"), 123, address);

            var message = new TicketOrderPaymentSubmitted(CorrelationId, DateTime.Now, amount, creditCardPayment);

            await TestThatEventLeadsToState(sm => sm.TicketOrderProcessingPaymentState, CorrelationId, message);
        }

        [TestMethod]
        public async Task PaymentRejectedEvent_ShouldTransitionTo_WaitingOnPaymentState()
        {
            await PaymentSubmittedEvent_ShouldTransitionTo_ProcessingPaymentState();

            var message = new TicketOrderPaymentRejected(CorrelationId, DateTime.Now);

            await TestThatEventLeadsToState(sm => sm.TicketOrderWaitingOnPaymentState, CorrelationId, message);
        }

        [TestMethod]
        public async Task PaymentAcceptedEvent_ShouldTransitionTo_CompletedState()
        {
            await PaymentSubmittedEvent_ShouldTransitionTo_ProcessingPaymentState();

            var message = new TicketOrderPaymentAccepted(CorrelationId, DateTime.Now);

            await Harness.Bus.Publish(message);
            await Task.Delay(250);
            Assert.IsTrue(await Harness.Consumed.Any<TicketOrderPaymentAccepted>());
            var sagaHarness = Harness.GetSagaStateMachineHarness<TicketOrderStateMachine, TicketOrderState>();
            Assert.IsTrue(await sagaHarness.Consumed.Any<TicketOrderPaymentAccepted>());
            Assert.IsTrue(await sagaHarness.Created.Any(saga => saga.CorrelationId == CorrelationId));
            Assert.IsFalse(await sagaHarness.Sagas.Any(saga => saga.CorrelationId == CorrelationId));
        }
    }
}