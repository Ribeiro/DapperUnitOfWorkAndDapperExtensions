using DapperExtensions;
using DapperExtensions.Predicate;
using DapperUnitOfWorkAndDapperExtensionsExample.Models;
using DapperUnitOfWorkAndDapperExtensionsExample.UnitsOfWork;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace DapperUnitOfWorkAndDapperExtensionsExample.Dapper
{
    internal sealed class DapperExtensionsProxy
    {
        internal DapperExtensionsProxy(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        IUnitOfWork unitOfWork = null;

        internal async Task<int> CountAsync<T>(object predicate) where T : BasePoco
        {
            var result = await unitOfWork.Connection.CountAsync<T>(predicate, unitOfWork.Transaction);
            return result;
        }

        internal async Task<T> GetAsync<T>(object id) where T : BasePoco
        {
            var result = await unitOfWork.Connection.GetAsync<T>(id, unitOfWork.Transaction);
            return result;
        }

        internal async Task<IEnumerable<T>> GetListAsync<T>(object predicate, IList<ISort> sort = null, bool buffered = false) where T : BasePoco
        {
            var result = await unitOfWork.Connection.GetListAsync<T>(predicate, sort, unitOfWork.Transaction, null, buffered);
            return result;
        }

        internal async Task<IEnumerable<T>> GetPageAsync<T>(object predicate, int page, int resultsPerPage, IList<ISort> sort = null, bool buffered = false) where T : BasePoco
        {
            var result = await unitOfWork.Connection.GetPageAsync<T>(predicate, sort, page, resultsPerPage, unitOfWork.Transaction, null, buffered);
            return result;
        }

        internal async Task<dynamic> InsertAsync<T>(T poco) where T : BasePoco
        {
            var result = await unitOfWork.Connection.InsertAsync<T>(poco, unitOfWork.Transaction);
            return result;
        }

        internal async void InsertAsync<T>(IEnumerable<T> listPoco) where T : BasePoco
        {
            await unitOfWork.Connection.InsertAsync<T>(listPoco, unitOfWork.Transaction);
        }

        internal async Task<bool> UpdateAsync<T>(T poco) where T : BasePoco
        {
            var result = await unitOfWork.Connection.UpdateAsync<T>(poco, unitOfWork.Transaction);
            return result;
        }

        internal async Task<bool> DeleteAsync<T>(T poco) where T : BasePoco
        {
            var result = await unitOfWork.Connection.DeleteAsync<T>(poco, unitOfWork.Transaction);
            return result;
        }

        internal async Task<bool> DeleteAsync<T>(object predicate) where T : BasePoco
        {
            var result = await unitOfWork.Connection.DeleteAsync<T>(predicate, unitOfWork.Transaction);
            return result;
        }

    }

}