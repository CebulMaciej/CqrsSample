using System;
using CqrsSample.Core.Events;

namespace CqrsSample.Core.Entities
{
    public class Example : AggregateRoot
    {
        public string Content { get; }

        public Example(Guid id, string content)
        {
            Id = id;
            Content = content;
        }

        public static Example Create(Guid id, string content)
        {
            Example example = new Example(id,content);
            
            example.AddEvent(new ExampleCreated(example));

            return example;
        }
    }
}