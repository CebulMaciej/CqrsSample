using System.Threading;
using System.Threading.Tasks;
using CqrsSample.Application.Dtos;
using CqrsSample.Application.Queries;
using CqrsSample.Application.Services;
using CqrsSample.Core.Entities;
using MediatR;

namespace CqrsSample.Infrastructure.Queries.Handlers
{
    public class GetExampleHandler : IRequestHandler<GetExample,ExampleDto>
    {
        private readonly IExampleRepository _exampleRepository;

        public GetExampleHandler(IExampleRepository exampleRepository)
        {
            _exampleRepository = exampleRepository;
        }

        public async Task<ExampleDto> Handle(GetExample request, CancellationToken cancellationToken)
        {
            Example example = await _exampleRepository.GetExample(request.Id);

            return example is null ? null : new ExampleDto{ Content = example.Content };
        }
    }
}