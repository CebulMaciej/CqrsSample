using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CqrsSample.Application.Dtos;
using CqrsSample.Application.Queries;
using CqrsSample.Infrastructure.Mongo.Abstract;
using CqrsSample.Infrastructure.Mongo.Documents;
using MediatR;
using MongoDB.Driver;

namespace CqrsSample.Infrastructure.Mongo.Queries.Handlers
{
    internal class GetExamplesHandler : IRequestHandler<GetExamples, IEnumerable<ExampleDto>>
    {
        private readonly IMongoCollectionProvider _mongoCollectionProvider;

        public GetExamplesHandler(IMongoCollectionProvider mongoCollectionProvider)
        {
            _mongoCollectionProvider = mongoCollectionProvider;
        }
        public async Task<IEnumerable<ExampleDto>> Handle(GetExamples request, CancellationToken cancellationToken)
        {
            IMongoCollection<ExampleDocument> collection =
                _mongoCollectionProvider.GetMongoDocumentCollection<ExampleDocument>();

            IList<ExampleDocument> result = await collection
                .Find(x => true)
                .ToListAsync(cancellationToken);

            return result.Select((x) => 
            new ExampleDto{
                Content = x.Content
            });
        }
    }
}