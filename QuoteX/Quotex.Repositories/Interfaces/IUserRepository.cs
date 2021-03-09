using Quotex.DomainModels;
using Quotex.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Quotex.Repositories.Interfaces
{
    public interface IUserRepository : IBaseRepository<User, UserModel>
    {
        Task<UserModel> GetUserByNameAsync(string username);
        Task<UserModel> GetUserByNameAndPasswordAsync(string username, string password);
    }
}
