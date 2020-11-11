using CqrsSample.Core.Entities;
using MediatR;

namespace CqrsSample.Core.Events
{
    public class ExampleCreated : IDomainEvent
    {
        public Example CreatedExample { get; }

        public ExampleCreated(Example createdExample)
        {
            CreatedExample = createdExample;
        }
    }
}