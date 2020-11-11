using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using CqrsSample.Core.Events;

namespace CqrsSample.Application.Services
{
    public interface IEventProcessor
    {
        Task Process(IEnumerable<IDomainEvent> events);
        Task Process(IDomainEvent events);
    }
}