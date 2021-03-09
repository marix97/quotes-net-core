using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Quotex.DomainModels;
using Quotex.Entities;
using Quotex.Repositories.Interfaces;
using QuoteX.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Quotex.Repositories
{
    public abstract class BaseRepository<TEntity, TModel>
        : IBaseRepository<TEntity, TModel>
        where TEntity : BaseEntity
        where TModel : BaseModel
    {
        protected QuotexDBContext _context;
        protected IMapper _mapper;

        public BaseRepository(QuotexDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<bool> AddAsync(TModel model)
        {
            var entity = _mapper.Map<TEntity>(model);

            try
            {
                await _context.AddAsync(entity);
                await _context.SaveChangesAsync();

                return true;
            }
            catch (DbUpdateException ex)
            {
                //An exception occured when trying to create a new record
                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entityToDelete = await _context.FindAsync<TEntity>(id);

            if(!(entityToDelete is null))
            {
                //Delete
                _context.Remove(entityToDelete);
                await _context.SaveChangesAsync();

                //Indicates that record has successfully been deleted
                return true;
            }

            return false;
        }

        public async Task<TModel> GetByIdAsync(int id)
        {
            var entity = await _context.FindAsync<TEntity>(id);

            return _mapper.Map<TModel>(entity);
        }

        public async Task<bool> UpdateAsync(int id, TModel model)
        {
            var entity = await _context.Set<TEntity>().FindAsync(id);

            if (entity is null)
            {
                return false; ;
            }

            try
            {
                _context.Entry(entity).CurrentValues.SetValues(model);
                await _context.SaveChangesAsync();

                return true;
            }
            catch (DbUpdateException)
            {
                //An exception occured when trying to update to the database
                return false;
            }
        }
    }
}
