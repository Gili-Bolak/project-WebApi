using Entities;
using Microsoft.EntityFrameworkCore;
using System.Runtime.InteropServices;
using System.Text.Json;

namespace Repositories
{
    public class UserRepository : IUserRepository
    {
        private Shop214662124Context _context;
        public UserRepository(Shop214662124Context shop214662124Context)
        {
            _context = shop214662124Context;
        }


        public async Task<User> Register(User user)
        {
            var existUser = await _context.Users.FirstOrDefaultAsync(u => u.Email.Equals(user.Email));
            if(existUser!= null)
            {
                return null;
            }
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            return user;
        }


        public async Task<User> Login(User user)
        {
            return await _context.Users.Where(u => u.Email == user.Email && u.Password == user.Password).FirstOrDefaultAsync();
        }


        public async Task<User> GetUserById(int id)
        {
            return await _context.Users.FindAsync(id);
        }


        public async Task<User> UpdateUser(int id, User userToUpdate)
        {
            var existUser = await _context.Users.FirstOrDefaultAsync(u => u.Email.Equals(userToUpdate.Email) && u.UserId != id);
            if (existUser != null)
            {
                return null;
            }
            userToUpdate.UserId = id;
            _context.Users.Update(userToUpdate);
            await _context.SaveChangesAsync();
            return userToUpdate;
        }



    }
}
