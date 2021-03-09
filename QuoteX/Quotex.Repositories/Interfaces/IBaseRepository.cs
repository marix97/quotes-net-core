using Quotex.DomainModels;
using Quotex.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Quotex.Repositories.Interfaces
{
    public interface IBaseRepository<TEntity, TModel>
        where TEntity : BaseEntity
        where TModel : BaseModel
    {
        Task<TModel> GetByIdAsync(int id);
        Task<bool> UpdateAsync(int id, TModel model);
        Task<bool> AddAsync(TModel model);
        Task<bool> DeleteAsync(int id);
    }
}
