using BusinessLayer.Interface;
using BusinessModels;
using DataLayer.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Class
{
    public class BaseBusiness<T> : IBusiness<T>
    {
        private readonly IRepository<T> _repository;

        public BaseBusiness(IRepository<T> baseRepository)
        {
            _repository = baseRepository;
        }

        public Result<List<T>> GetAll()
        {
            return _repository.GetAll();
        }

        public Result<T> Select(Int64 id)
        {
            return _repository.Select(id);
        }

        public Result<T> Create(T data)
        {
            return _repository.Create(data);
        }

        public async Task<Result<T>> CreateAsync(T data)
        {
            return await _repository.CreateAsync(data);
        }

        public Result<T> Update(T data)
        {
            return _repository.Update(data);
        }

        public Result<T> Delete(Int64 id)
        {
            return _repository.Delete(id);
        }
      
    }
}
