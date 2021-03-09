using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Quotex.DomainModels;
using Quotex.Entities;
using Quotex.Repositories.Interfaces;
using QuoteX.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quotex.Repositories
{
    public class UserRepository : BaseRepository<User, UserModel>, IUserRepository
    {
        public UserRepository(QuotexDBContext context, IMapper mapper) : base(context, mapper)
        {

        }

        public async Task<UserModel> GetUserByNameAsync(string username)
        {
            var user = await _context.Users.AsNoTracking().FirstOrDefaultAsync(u => u.Username == username);

            if (user is null)
                return null;

            return _mapper.Map<UserModel>(user);
        }

        public async Task<UserModel> GetUserByNameAndPasswordAsync(string username, string password)
        {
            var user = await _context.Users.AsNoTracking().FirstOrDefaultAsync(u => u.Username == username && u.Password == password);

            if (user is null)
                return null;

            return _mapper.Map<UserModel>(user);
        }
    }
}
