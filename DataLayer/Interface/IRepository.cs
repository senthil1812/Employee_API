using BusinessModels;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Interface
{
    public interface IRepository<T>
    {
        Result<T> Create(T data);
        Result<T> Update(T data);
        Result<T> Delete(Int64 id);
        Result<T> Select(Int64 id);
        Result<List<T>> GetAll();

        Task<Result<T>> CreateAsync(T data);
        Result<T> GetByCondition(Expression<Func<T, bool>> predicate);
    }
}
