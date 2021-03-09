using Quotex.DomainModels;
using Quotex.Entities;
using Quotex.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Quotex.Domain.Interfaces
{
    public interface IBaseService<TEntity, TModel, TRepository>
        where TEntity : BaseEntity
        where TModel : BaseModel
        where TRepository : IBaseRepository<TEntity, TModel>
    {
        Task<TModel> GetByIdIfExistsAsync(int id);
        Task<bool> AddAsync(TModel model);
        Task<bool> UpdateAsync(int id, TModel model);
        Task<bool> DeleteAsync(int id);
    }
}
