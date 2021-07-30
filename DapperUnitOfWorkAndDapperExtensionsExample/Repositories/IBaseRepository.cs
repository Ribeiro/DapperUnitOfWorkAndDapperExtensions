using DapperUnitOfWorkAndDapperExtensionsExample.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DapperUnitOfWorkAndDapperExtensionsExample.Repositories
{
    public interface IBaseRepository<T> where T : BasePoco
    {
        Task<bool>  ExistsAsync();
        Task<int> GetCountAsync();
        Task<T> GetById(Guid id);
        Task<T> GetById(string id);
        Task<List<T>> GetList();
        Task<dynamic> InsertAsync(T poco);
        Task<bool> UpdateAsync(T poco);
        Task<bool> DeleteAsync(T poco);
        Task<bool> DeleteByIdAsync(Guid id);
        Task<bool> DeleteByIdAsync(string id);
        Task<bool> DeleteAllAsync();
    }
}
