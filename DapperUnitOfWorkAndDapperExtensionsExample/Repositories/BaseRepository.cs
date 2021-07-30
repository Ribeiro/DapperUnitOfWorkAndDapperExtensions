using DapperExtensions.Predicate;
using DapperUnitOfWorkAndDapperExtensionsExample.Dapper;
using DapperUnitOfWorkAndDapperExtensionsExample.Models;
using DapperUnitOfWorkAndDapperExtensionsExample.UnitsOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DapperUnitOfWorkAndDapperExtensionsExample.Repositories
{
    public abstract class BaseRepository<T> where T : BasePoco
    {
        DapperExtensionsProxy dapperExtensionsProxy = null;

        public BaseRepository(IUnitOfWork unitOfWork)
        {
            dapperExtensionsProxy = new DapperExtensionsProxy(unitOfWork);
        }

        public async virtual Task<bool> ExistsAsync()
        {
            return (await GetCountAsync() == 0) ? false : true;
        }

        public async virtual Task<int> GetCountAsync()
        {
            var result = await dapperExtensionsProxy.CountAsync<T>(null);
            return result;
        }

        public async virtual Task<T> GetById(Guid id)
        {
            var result = await dapperExtensionsProxy.GetAsync<T>(id);
            return result;
        }
        public async virtual Task<T> GetById(string id)
        {
            var result = await dapperExtensionsProxy.GetAsync<T>(id);
            return result;
        }
        public async virtual Task<List<T>> GetList()
        {
            var result = await dapperExtensionsProxy.GetListAsync<T>(null);
            return result.ToList();
        }

        public async virtual Task<dynamic> InsertAsync(T poco)
        {
            return await dapperExtensionsProxy.InsertAsync(poco);
        }

        public async virtual Task<bool> UpdateAsync(T poco)
        {
            return await dapperExtensionsProxy.UpdateAsync(poco);
        }

        public async virtual Task<bool> DeleteAsync(T poco)
        {
            return await dapperExtensionsProxy.DeleteAsync(poco);
        }

        public async virtual Task<bool> DeleteByIdAsync(Guid id)
        {
            T poco = (T)Activator.CreateInstance(typeof(T));
            poco.SetDbId(id);
            return await dapperExtensionsProxy.DeleteAsync(poco);
        }

        public async virtual Task<bool> DeleteByIdAsync(string id)
        {
            T poco = (T)Activator.CreateInstance(typeof(T));
            poco.SetDbId(id);
            return await dapperExtensionsProxy.DeleteAsync(poco);
        }

        public async virtual Task<bool> DeleteAllAsync()
        {
            var predicateGroup = new PredicateGroup { Operator = GroupOperator.And, Predicates = new List<IPredicate>() };
            return await dapperExtensionsProxy.DeleteAsync<T>(predicateGroup);//Send empty predicateGroup to delete all records.
        }

    }

}