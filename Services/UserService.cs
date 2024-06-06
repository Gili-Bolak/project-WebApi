using Entities;
using Repositories;
using System.Diagnostics;
using System.Text.Json;

namespace Services
{
    public class UserService : IUserService
    {
        private IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }


        public async Task<User> GetUserById(int id)
        {
            return await _userRepository.GetUserById(id);
        }


        public int StrongPassword(string password)
        {
            return Zxcvbn.Core.EvaluatePassword(password).Score;
        }


        public async Task<User> Register(User user)
        {
            return await _userRepository.Register(user);
        }


        public async Task<User> Login(User user)
        {
            return await _userRepository.Login(user);
        }


        public async Task<User> UpdateUser(int id, User userToUpdate)
        {
            if (StrongPassword(userToUpdate.Password) >= 2)
                return await _userRepository.UpdateUser(id, userToUpdate);
            return null;
        }


    }
}
