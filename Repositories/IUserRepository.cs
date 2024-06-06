using Entities;

namespace Repositories
{
    public interface IUserRepository
    {
        Task<User> GetUserById(int id);
        Task<User> Login(User user);
        Task<User> Register(User user);
        Task<User> UpdateUser(int id, User userToUpdate);
    }
}