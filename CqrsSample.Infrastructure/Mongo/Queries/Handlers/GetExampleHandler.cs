using System.Threading;
using System.Threading.Tasks;
using CqrsSample.Application.Dtos;
using CqrsSample.Application.Queries;
using CqrsSample.Application.Services;
using CqrsSample.Core.Entities;
using CqrsSample.Infrastructure.Mongo.Abstract;
using CqrsSample.Infrastructure.Mongo.Documents;
using MediatR;
using MongoDB.Driver;

namespace CqrsSample.Infrastructure.Mongo.Queries.Handlers
{
    internal class GetExampleHandler : IRequestHandler<GetExample, ExampleDto>
    {
        private readonly IMongoCollectionProvider _mongoCollectionProvider;

        public GetExampleHandler(IMongoCollectionProvider mongoCollectionProvider)
        {
            _mongoCollectionProvider = mongoCollectionProvider;
        }

        public async Task<ExampleDto> Handle(GetExample request, CancellationToken cancellationToken)
        {
            IMongoCollection<ExampleDocument> collection =
                _mongoCollectionProvider.GetMongoDocumentCollection<ExampleDocument>();

            ExampleDocument result = await collection
                    .Find(x => x.Id == request.Id)
                    .FirstOrDefaultAsync(cancellationToken);

            if (result is null) return null;

            return new ExampleDto
            {
                Id = result.Id,
                Content = result.Content
            };
        }
    }
}