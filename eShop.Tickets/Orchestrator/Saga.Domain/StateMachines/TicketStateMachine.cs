using MassTransit;
using Saga.Domain.Entities;
using Saga.Domain.Events;

#nullable disable

namespace Saga.Domain.StateMachines
{
    public class TicketStateMachine : MassTransitStateMachine<TicketState>
    {
        public TicketStateMachine()
        {
            InstanceState(x => x.CurrentState);

            Event(() => TicketSubmitted, x => x.CorrelateById(m => m.Message.CorrelationId));
            Event(() => TicketAccepted, x => x.CorrelateById(m => m.Message.CorrelationId));
            Event(() => TicketRejected, x => x.CorrelateById(m => m.Message.CorrelationId));

            Initially(
                When(TicketSubmitted)
                    .Then(context => context.Saga.LastUpdatedDate = context.Message.CreationDate)
                        .TransitionTo(Submitted));

            During(Submitted,
                When(TicketAccepted)
                    .Then(context => context.Saga.LastUpdatedDate = context.Message.CreationDate)
                        .TransitionTo(Accepted),
                When(TicketRejected)
                    .Then(context => context.Saga.LastUpdatedDate = context.Message.CreationDate)
                        .TransitionTo(Rejected));
        }

        public State Submitted { get; private set; }
        public State Accepted { get; private set; }
        public State Rejected { get; private set; }

        public Event<TicketSubmitted> TicketSubmitted { get; private set; }
        public Event<TicketAccepted> TicketAccepted { get; private set; }
        public Event<TicketRejected> TicketRejected { get; private set; }
    }
}
