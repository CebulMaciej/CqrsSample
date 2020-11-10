using System;
using CqrsSample.Application.Dtos;
using MediatR;

namespace CqrsSample.Application.Queries
{
    public class GetExample : IRequest<ExampleDto>
    {
        public Guid Id { get; set; }
    }
}