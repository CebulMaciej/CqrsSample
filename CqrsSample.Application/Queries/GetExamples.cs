using System.Collections.Generic;
using CqrsSample.Application.Dtos;
using MediatR;

namespace CqrsSample.Application.Queries
{
    public class GetExamples : IRequest<IEnumerable<ExampleDto>>
    {
        
    }
}