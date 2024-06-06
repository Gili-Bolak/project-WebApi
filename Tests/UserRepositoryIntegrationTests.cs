using Entities;
using Microsoft.EntityFrameworkCore.Storage;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestProject;

namespace Tests
{
    public class UserRepositoryIntegrationTests:IClassFixture<DatabaseFixture>
    {
        private readonly Shop214662124Context _dbcontext;
        private readonly UserRepository _userRepository;

        public UserRepositoryIntegrationTests(DatabaseFixture databaseFixture)
        {
            _dbcontext = databaseFixture.Context;
            _userRepository = new UserRepository(_dbcontext);
        }

        [Fact]

        public async Task Login_ValidCredentials_ReturnUser()
        {
            var email = "test@gmail.com";
            var password = "password";
            var userToCreateInDB = new User { Email = email, Password = password, FirstName = "test firstName", LastName = "test lastName" };
            await _dbcontext.Users.AddAsync(userToCreateInDB);
            await _dbcontext.SaveChangesAsync();


            var userToLoginWith = new User { Email = email, Password = password };

            var result = await _userRepository.Login(userToLoginWith);

            Assert.NotNull(result);
        }

        [Fact]

        public async Task Login_InvalidCredentials_ReturnNull()
        {
            var userToCreateInDB = new User { Email = "test@gmail.com", Password = "1324", FirstName = "test firstName", LastName = "test lastName" };
            await _dbcontext.Users.AddAsync(userToCreateInDB);
            await _dbcontext.SaveChangesAsync();


            var userToLoginWith = new User { Email = "invalidUser@gmail.com", Password = "1234" };

            var result = await _userRepository.Login(userToLoginWith);

            Assert.Null(result);
        }


        [Fact]

        public async Task Register_ValidCredentials_ReturnUser()
        {

            var userToCreateInDB = new User { Email = "test@gmail.com", Password = "1324", FirstName = "test firstName", LastName = "test lastName" };

            var result = await _userRepository.Register(userToCreateInDB);

            Assert.NotNull(result);
        }


    }
}
