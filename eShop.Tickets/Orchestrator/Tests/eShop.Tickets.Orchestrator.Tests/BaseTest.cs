using MassTransit;
using MassTransit.Testing;
using Microsoft.Extensions.DependencyInjection;
using Saga.Domain.Entities;
using Saga.Domain.StateMachines;
using static MassTransit.Transports.ReceiveEndpoint;
using State = MassTransit.State;

#nullable disable

namespace eShop.Tickets.Orchestrator.Tests
{
    public class BaseTest
    {
        protected static Guid CorrelationId { get; private set; }
        protected ITestHarness Harness { get; private set; }

        private async Task DidHarnessReceive<T>() where T : class
        {
            Assert.IsTrue(await Harness.Consumed.Any<T>());
        }

        private async Task<ISagaStateMachineTestHarness<TicketOrderStateMachine, TicketOrderState>> DidSagaReceive<TEvent>(Guid correlationId) where TEvent : class
        {
            var sagaHarness = Harness.GetSagaStateMachineHarness<TicketOrderStateMachine, TicketOrderState>();
            Assert.IsTrue(await sagaHarness.Consumed.Any<TEvent>());
            Assert.IsTrue(await sagaHarness.Created.Any(saga => saga.CorrelationId == correlationId));
            return sagaHarness;
        }

        private static void IsSagaInState(ISagaStateMachineTestHarness<TicketOrderStateMachine, TicketOrderState> sagaHarness, State state, Guid correlationId)
        {
            var instance = sagaHarness.Created.ContainsInState(correlationId, sagaHarness.StateMachine, state);
            Assert.IsNotNull(instance);
        }

        private static async Task IsSagaWithIdInState(ISagaStateMachineTestHarness<TicketOrderStateMachine, TicketOrderState> sagaHarness, Guid correlationId, Func<TicketOrderStateMachine, State> state)
        {
            var existsId = await sagaHarness.Exists(correlationId, state);
            Assert.IsTrue(existsId.HasValue);
        }

        protected async Task TestThatEventLeadsToState<TEvent>(Func<TicketOrderStateMachine, State> state, Guid correlationId, TEvent message) where TEvent : class
        {
            await Harness.Bus.Publish(message);
            await Task.Delay(250);
            await DidHarnessReceive<TEvent>();
            var sagaHarness = await DidSagaReceive<TEvent>(correlationId);
            IsSagaInState(sagaHarness, state.Invoke(sagaHarness.StateMachine), correlationId);
            await IsSagaWithIdInState(sagaHarness, correlationId, state);
        }

        protected async Task TestThatEventLeadsToFinalization<TEvent>(TEvent message) where TEvent : class
        {
            await Harness.Bus.Publish(message);
            await Task.Delay(250);
            await DidHarnessReceive<TEvent>();
            var sagaHarness = await DidSagaReceive<TEvent>(CorrelationId);
            var notExistsId = await sagaHarness.NotExists(CorrelationId);
            Assert.IsFalse(notExistsId.HasValue);
        }

        [TestInitialize]
        public async Task Setup()
        {
            CorrelationId = NewId.NextGuid();
            var provider = new ServiceCollection()
                .AddMassTransitTestHarness(x =>
                {
                    x.AddSagaStateMachine<TicketOrderStateMachine, TicketOrderState>();
                })
                .BuildServiceProvider(true);

            Harness = provider.GetTestHarness();

            await Harness.Start();
        }

        [TestCleanup]   
        public async Task Cleanup()
        {
            await Harness.Stop();
        }
    }
}
