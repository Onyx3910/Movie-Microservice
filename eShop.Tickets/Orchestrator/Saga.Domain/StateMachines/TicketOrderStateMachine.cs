using MassTransit;
using Saga.Domain.Entities;
using Saga.Domain.Events;

#nullable disable

namespace Saga.Domain.StateMachines
{
    public class TicketOrderStateMachine : MassTransitStateMachine<TicketOrderState>
    {
        public TicketOrderStateMachine()
        {
            InstanceState(x => x.CurrentState);

            Event(() => TicketOrderCreatedEvent, x => x.CorrelateById(m => m.Message.CorrelationId));
            Event(() => TicketOrderSeatsSelectedEvent, x => x.CorrelateById(m => m.Message.CorrelationId));
            Event(() => TicketOrderPaymentSubmittedEvent, x => x.CorrelateById(m => m.Message.CorrelationId));
            Event(() => TicketOrderPaymentAcceptedEvent, x => x.CorrelateById(m => m.Message.CorrelationId));
            Event(() => TicketOrderSeatsExpiredEvent, x => x.CorrelateById(m => m.Message.CorrelationId));
            Event(() => TicketOrderCancelledEvent, x => x.CorrelateById(m => m.Message.CorrelationId));
            Event(() => TicketOrderPaymentRejectedEvent, x => x.CorrelateById(m => m.Message.CorrelationId));

            Initially(
                When(TicketOrderCreatedEvent)
                    .Then(InitializeState)
                        .TransitionTo(TicketOrderSelectingSeatsState));

            During(TicketOrderSelectingSeatsState,
                When(TicketOrderSeatsSelectedEvent)
                    .Then(UpdateStateWithSeatsSelected)
                        .TransitionTo(TicketOrderWaitingOnPaymentState),
                When(TicketOrderCancelledEvent)
                    .Then(UpdateStateWithCancelled)
                        .Finalize());

            During(TicketOrderWaitingOnPaymentState,
                When(TicketOrderSeatsExpiredEvent)
                    .Then(UpdateStateWithSeatsExpired)
                        .TransitionTo(TicketOrderSelectingSeatsState),
                When(TicketOrderPaymentSubmittedEvent)
                    .Then(UpdateStateWithPaymentSubmitted)
                        .TransitionTo(TicketOrderProcessingPaymentState),
                When(TicketOrderCancelledEvent)
                    .Then(UpdateStateWithCancelled)
                        .Finalize());

            During(TicketOrderProcessingPaymentState,
                When(TicketOrderPaymentRejectedEvent)
                    .Then(UpdateStateWithPaymentRejected)
                        .TransitionTo(TicketOrderWaitingOnPaymentState),
                When(TicketOrderPaymentAcceptedEvent)
                    .Then(UpdateStateWithPaymentAccepted)
                        .Finalize());

            SetCompletedWhenFinalized();
        }

        #region States

        public State TicketOrderSelectingSeatsState { get; private set; }
        public State TicketOrderWaitingOnPaymentState { get; private set; }
        public State TicketOrderProcessingPaymentState { get; private set; }

        #endregion

        #region Events

        public Event<TicketOrderCreated> TicketOrderCreatedEvent { get; private set; }
        public Event<TicketOrderSeatsSelected> TicketOrderSeatsSelectedEvent { get; private set; }
        public Event<TicketOrderPaymentSubmitted> TicketOrderPaymentSubmittedEvent { get; private set; }
        public Event<TicketOrderPaymentAccepted> TicketOrderPaymentAcceptedEvent { get; private set; }
        public Event<TicketOrderSeatsExpired> TicketOrderSeatsExpiredEvent { get; private set; }
        public Event<TicketOrderCancelled> TicketOrderCancelledEvent { get; private set; }
        public Event<TicketOrderPaymentRejected> TicketOrderPaymentRejectedEvent { get; private set; }

        #endregion

        private void InitializeState(BehaviorContext<TicketOrderState, TicketOrderCreated> context)
        {
            var message = context.Message;
            context.Saga.TheaterId = message.TheaterId;
            context.Saga.MovieId = message.MovieId;
            context.Saga.Showtime = message.Showtime;
            context.Saga.LastUpdatedDate = message.CreationDate;
            context.Saga.CreationDate = message.CreationDate;
        }

        private void UpdateStateWithSeatsSelected(BehaviorContext<TicketOrderState, TicketOrderSeatsSelected> context)
        {
            var message = context.Message;
            context.Saga.Seats = message.Seats;
            context.Saga.LastUpdatedDate = message.LastUpdatedDate;
        }

        private void UpdateStateWithPaymentSubmitted(BehaviorContext<TicketOrderState, TicketOrderPaymentSubmitted> context)
        {
            var message = context.Message;
            context.Saga.LastUpdatedDate = message.LastUpdatedDate;
        }

        private void UpdateStateWithPaymentAccepted(BehaviorContext<TicketOrderState, TicketOrderPaymentAccepted> context)
        {
            var message = context.Message;
            context.Saga.LastUpdatedDate = message.LastUpdatedDate;
        }

        private void UpdateStateWithPaymentRejected(BehaviorContext<TicketOrderState, TicketOrderPaymentRejected> context)
        {
            var message = context.Message;
            context.Saga.LastUpdatedDate = message.LastUpdatedDate;
        }

        private void UpdateStateWithSeatsExpired(BehaviorContext<TicketOrderState, TicketOrderSeatsExpired> context)
        {
            var message = context.Message;
            context.Saga.Seats = null;
            context.Saga.LastUpdatedDate = message.LastUpdatedDate;
        }

        private void UpdateStateWithCancelled(BehaviorContext<TicketOrderState, TicketOrderCancelled> context)
        {
            var message = context.Message;
            if(context.Saga.Seats is not null) { /*TO DO: Publish event to release seats*/ }
            context.Saga.LastUpdatedDate = message.LastUpdatedDate;
        }
    }
}
