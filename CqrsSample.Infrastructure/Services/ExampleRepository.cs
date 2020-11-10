using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CqrsSample.Application.Services;
using CqrsSample.Core.Entities;

namespace CqrsSample.Infrastructure.Services
{
    public class ExampleRepository : IExampleRepository
    {

        private static readonly IList<Example> Storage = new List<Example>();
        
        public Task<Example> GetExample(Guid id)
        {
            return Task.FromResult(Storage.FirstOrDefault(x => x.Id == id));
        }

        public Task Add(Example example)
        {
            Storage.Add(example);
            return Task.CompletedTask;
        }
    }
}