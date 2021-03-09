using Quotex.Domain.Interfaces;
using Quotex.DomainModels;
using Quotex.Entities;
using Quotex.Repositories;
using Quotex.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Quotex.Domain
{
    public class UserService : BaseService<User, UserModel, IUserRepository>, IUserService
    {
        public UserService(IUserRepository userRepository) : base(userRepository) { }

        public async Task<UserModel> GetUserByUsernameAndPasswordAsync(string username, string password)
        {
            return await _repository.GetUserByNameAndPasswordAsync(username, password);
        }

        public async Task<UserModel> GetUserByUsernameAsync(string username)
        {
            return await _repository.GetUserByNameAsync(username);
        }
    }
}
