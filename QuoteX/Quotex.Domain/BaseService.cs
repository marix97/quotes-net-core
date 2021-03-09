using Quotex.Domain.Interfaces;
using Quotex.DomainModels;
using Quotex.Entities;
using Quotex.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Quotex.Domain
{
    public class BaseService<TEntity, TModel, TRepository> : IBaseService<TEntity, TModel, TRepository>
        where TEntity : BaseEntity
        where TModel : BaseModel
        where TRepository : IBaseRepository<TEntity, TModel>
    {
        protected TRepository _repository;

        public BaseService(TRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> AddAsync(TModel model)
        {
            return await _repository.AddAsync(model);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _repository.DeleteAsync(id);
        }

        public async Task<TModel> GetByIdIfExistsAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<bool> UpdateAsync(int id, TModel model)
        {
            return await _repository.UpdateAsync(id, model);
        }
    }
}
