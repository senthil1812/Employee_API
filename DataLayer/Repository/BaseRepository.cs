using BusinessModels;
using DataLayer.DBContext;
using DataLayer.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repository
{
    public class BaseRepository<T> : IRepository<T> where T : class
    {
        private readonly RepositoryContext _repositoryContext;

        public BaseRepository(RepositoryContext repositoryContext)
        {
            _repositoryContext = repositoryContext;
        }

        public Result<List<T>> GetAll()
        {
            var result =  _repositoryContext.Set<T>().ToList();
            var resultModel = new Result<List<T>>
            {
                Data = result,
                IsSuccess = true,
                SuccessMessage = "Record Details List!!"

            };

            return resultModel;
        }


        public Result<T> Select(Int64 id)
        {
            var result = _repositoryContext.Set<T>().Find(id);
            var resultModel = new Result<T>
            {
                Data = result,
                IsSuccess = true,
                SuccessMessage = "Record Details!!"

            };

            return resultModel;
        }

        public Result<T> Create(T data)
        {
            _repositoryContext.Set<T>().Add(data);
            var result = _repositoryContext.SaveChangesAsync();
            
            var resultModel = new Result<T>
            {
                Data = null,
                IsSuccess = true,
                SuccessMessage = "Record Created Sucessfully!!"

            };

            return resultModel;
        }


        public async Task<Result<T>> CreateAsync(T data)
        {
            _repositoryContext.Set<T>().Add(data);
            var result = await _repositoryContext.SaveChangesAsync();

            var resultModel = new Result<T>
            {
                Data = data,
                IsSuccess = true,
                SuccessMessage = "Record Created Sucessfully!!"

            };

            return resultModel;
        }

        public Result<T> Update(T data)
        {
            _repositoryContext.Update(data);
            _repositoryContext.SaveChanges();
            var resultModel = new Result<T>
            {
                Data = data,
                IsSuccess = true,
                SuccessMessage = "Record Update Sucessfully!!"

            };

            return resultModel;
        }

        public Result<T> Delete(Int64 id)
        {
            var result = _repositoryContext.Set<T>().Find(id);
            _repositoryContext.Remove(result);
            _repositoryContext.SaveChanges();
            var resultModel = new Result<T>
            {
                Data = null,
                IsSuccess = true,
                SuccessMessage = "Record Deleted Successfully!!"

            };

            return resultModel;
        }

        public Result<T> GetByCondition(Expression<Func<T, bool>> predicate)
        {
            var result = _repositoryContext.Set<T>().Where(predicate).ToList().FirstOrDefault();
            var resultModel = new Result<T>
            {
                Data = result,
                IsSuccess = true,
                SuccessMessage = "Record Details!!"

            };

            return resultModel;
        }
    }
}
