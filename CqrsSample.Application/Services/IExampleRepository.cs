using System;
using System.Threading.Tasks;
using CqrsSample.Core.Entities;

namespace CqrsSample.Application.Services
{
    public interface IExampleRepository
    {
        Task<Example> GetExample(Guid id);

        Task Add(Example example);
    }
}