using System;
using System.Threading;
using System.Threading.Tasks;
using CqrsSample.Application.Services;
using CqrsSample.Core.Entities;
using MediatR;

namespace CqrsSample.Application.Command.Handlers
{
    public class CreateExampleHandler : IRequestHandler<CreateExample,Guid>
    {
        private readonly IExampleRepository _exampleRepository;
        private readonly IEventProcessor _eventProcessor;

        public CreateExampleHandler(IExampleRepository exampleRepository,IEventProcessor eventProcessor)
        {
            _exampleRepository = exampleRepository;
            _eventProcessor = eventProcessor;
        }

        public async Task<Guid> Handle(CreateExample request, CancellationToken cancellationToken)
        {
            Guid id = Guid.NewGuid();
            Example example = Example.Create(id, request.Content);

            await _exampleRepository.Add(example);

            await _eventProcessor.Process(example.Events);
            
            return id;
        }
    }
}