using Quotex.DomainModels;
using Quotex.Entities;
using Quotex.Repositories;
using System.Threading.Tasks;

namespace Quotex.Domain.Interfaces
{
    public interface IUserService : IBaseService<User, UserModel, UserRepository>
    {
        Task<UserModel> GetUserByUsernameAsync(string username);
        Task<UserModel> GetUserByUsernameAndPasswordAsync(string username, string password);
    }
}
