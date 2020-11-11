using System.Collections.Generic;
using System.Threading.Tasks;
using CqrsSample.Application.Services;
using CqrsSample.Core.Events;
using MediatR;

namespace CqrsSample.Infrastructure.Services
{
    public class EventProcessor : IEventProcessor
    {
        private readonly IMediator _mediator;

        public EventProcessor(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task Process(IEnumerable<IDomainEvent> events)
        {
            foreach (IDomainEvent domainEvent in events)
            {
                await Process(domainEvent);
            }
        }

        public async Task Process(IDomainEvent @event)
        {
            await _mediator.Publish(@event);
            //TODO same way to propagate event on broker
        }
    }
}