using System.Threading;
using System.Threading.Tasks;
using CqrsSample.Core.Events;
using Microsoft.Extensions.Logging;

namespace CqrsSample.Application.Events.Handlers
{
    public class ExampleCreatedHandler : IDomainEventHandler<ExampleCreated>
    {
        private readonly ILogger<ExampleCreatedHandler> _logger;

        public ExampleCreatedHandler(ILogger<ExampleCreatedHandler> logger)
        {
            _logger = logger;
        }

        public Task Handle(ExampleCreated notification, CancellationToken cancellationToken)
        {
           _logger.Log(LogLevel.Information,$">>>>{notification.CreatedExample.Id} event handled. Content {notification.CreatedExample.Content}");
           return Task.CompletedTask;
        }
    }
}