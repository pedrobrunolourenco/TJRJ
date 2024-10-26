namespace TJRJ.Domain.Core.Messages.CommonMessages
{
    public class DomainEvent : Event
    {
        public DomainEvent(int aggregateId)
        {
            AggregateId = aggregateId;
        }
    }
}
