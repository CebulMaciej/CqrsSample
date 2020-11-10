using System;
using MediatR;

namespace CqrsSample.Application.Command
{
    public class CreateExample : IRequest<Guid>
    {
        public CreateExample(string content)
        {
            Content = content;
        }

        public string Content { get; }
    }
}