using BusinessModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Interface
{
    public interface IBusiness<T>
    {
        Result<T> Create(T data);
        Result<T> Update(T data);
        Result<T> Delete(Int64 id);
        Result<T> Select(Int64 id);
        Result<List<T>> GetAll();

        Task<Result<T>> CreateAsync(T data);

    }
}
