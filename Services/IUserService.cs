using Entities;

namespace Services
{
    public interface IUserService
    {
        Task<User> GetUserById(int id);
        Task<User> Login(User user);
        Task<User> Register(User user);
        int StrongPassword(string password);
        Task<User> UpdateUser(int id, User userToUpdate);
    }
}