using CqrsSample.Core.Events;
using MediatR;

namespace CqrsSample.Application.Events
{
    public interface IDomainEventHandler<in T> : INotificationHandler<T> where T : INotification
    {
        
    }
}