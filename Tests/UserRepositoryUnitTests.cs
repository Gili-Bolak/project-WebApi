using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks;
using Moq;
using Xunit;
using Microsoft.EntityFrameworkCore;
using Entities;
using Repositories;
using Moq.EntityFrameworkCore;

namespace Tests
{
    public class UserRepositoryUnitTests
    {
        [Fact]
        public async Task Login_ValidCredentials_ReturnUser()
        {
            var user = new User { Email = "test@gmail.com", Password = "1234", FirstName = "test firstName", LastName = "test lastName" };

            var mockContext = new Mock<Shop214662124Context>();
            var users = new List<User>() { user };
            mockContext.Setup(x => x.Users).ReturnsDbSet(users);

            var userRepository = new UserRepository(mockContext.Object);

            var result = await userRepository.Login(user);

            Assert.Equal(user, result);
        }


        [Fact]
        public async Task Login_InvalidCredentials_ReturnNull()
        {
            var user = new User { Email = "test@gmail.com", Password = "1234", FirstName = "test firstName", LastName = "test lastName" };

            var mockContext = new Mock<Shop214662124Context>();
            var users = new List<User>() { user };
            mockContext.Setup(x => x.Users).ReturnsDbSet(users);

            var userRepository = new UserRepository(mockContext.Object);

            var invalidUser = new User { Email = "invalidUser@gmail.com", Password = "1234", FirstName = "test firstName", LastName = "test lastName" };
            var result = await userRepository.Login(invalidUser);

            Assert.Null(result);
        }


        [Fact]
        public async Task Register_ValidCredentials_ReturnUser()
        {
            var user = new User { Email = "test@gmail.com", Password = "1234", FirstName = "test firstName", LastName = "test lastName" };

            var mockContext = new Mock<Shop214662124Context>();
            var users = new List<User>() {  };
            mockContext.Setup(x => x.Users).ReturnsDbSet(users);

            var userRepository = new UserRepository(mockContext.Object);

            var result = await userRepository.Register(user);

            Assert.Equal(user, result);
        }


        [Fact]
        public async Task Register_InvalidCredentials_ReturnNull()
        {
            var user = new User { Email = "test@gmail.com", Password = "1234", FirstName = "test firstName", LastName = "test lastName" };

            var mockContext = new Mock<Shop214662124Context>();
            var users = new List<User>() { user };
            mockContext.Setup(x => x.Users).ReturnsDbSet(users);

            var userRepository = new UserRepository(mockContext.Object);

            var invalidUser = new User { Email = "test@gmail.com", Password = "1234", FirstName = "test firstName", LastName = "test lastName" };
            var result = await userRepository.Register(invalidUser);

            Assert.Null(result);
        }


        [Fact]
        public async Task Update_InvaildCredentials_ReturnsNull()
        {
            var user = new User { UserId = 1, Email = "test@ttt.com", Password = "123", FirstName = "tamar", LastName = "lavi" };
            var user2 = new User { UserId = 2, Email = "test@ggg.com", Password = "123", FirstName = "tamar", LastName = "lavi" };

            var mockContext = new Mock<Shop214662124Context>();
            var users = new List<User>() { user, user2 };

            mockContext.Setup(x => x.Users).ReturnsDbSet(users);

            var userRepository = new UserRepository(mockContext.Object);

            var userUpdate = new User { Email = "test@ggg.com", Password = "123", FirstName = "tamar", LastName = "lavi" };
            var result = await userRepository.UpdateUser(user.UserId, userUpdate);

            Assert.Null(result);
        }

    }
}
