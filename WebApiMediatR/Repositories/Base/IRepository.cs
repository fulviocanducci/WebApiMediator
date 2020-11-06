using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace WebApiMediatR.Repositories.Base
{
    public interface IRepository<T>
    {
        Task<T> AddAsync(T model);
        Task<bool> UpdateAsync(T model);
        Task<T> FindAsync(params object[] keys);
        Task<TResult> FindAsync<TResult>(Expression<Func<T, bool>> where, Expression<Func<T, TResult>> select);
        Task<IEnumerable<T>> GetAsync();
        Task<IEnumerable<TResult>> GetAsync<TResult>(Expression<Func<T, TResult>> select);
        Task<bool> DeleteAsync(params object[] keys);
    }
}
