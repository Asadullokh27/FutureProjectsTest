using AutoMapper;
using FutureProjects.API.Controllers;
using FutureProjects.Application.Abstractions.IServices;
using FutureProjects.Application.Mappers;
using FutureProjects.Domain.Entities.DTOs;
using FutureProjects.Domain.Entities.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace FutureProjects.Application.Tests.Services.UserServices
{
    public class UserServiceTests
    {
        private readonly Mock<IUserService> _userservice = new Mock<IUserService>();
        MapperConfiguration? mockMapepr = new MapperConfiguration(conf =>
        {
            conf.AddProfile(new AutoMapperProfile());
        });

        public static IEnumerable<object[]> GetUserFromDataGenerator()
        {
            yield return new object[]
            {
                new UserDTO()
                {
                    Name = "Test Product 1",
                    Email = "komilov@gmail.com",
                    Password = "123",
                    Login = "tes123",
                    Role = "Admin"
                },
                new User()
                {
                    Name = "Test Product 34",
                    Email = "komilov@gmail.com",
                    Password = "123",
                    Login = "tes123",
                    Role = "Admin"
                }
            };

            yield return new object[]
            {
                new UserDTO()
                {
                    Name = "Test Product 2",
                    Email = "komilov@gmail.com",
                    Password = "123",
                    Login = "tes123",
                    Role = "Admin"
                },
                new User()
                {
                    Name = "Test Product 2",
                    Email = "komilov@gmail.com",
                    Password = "123",
                    Login = "tes123",
                    Role = "Admin"
                }
            };

            yield return new object[]
            {
                new UserDTO()
                {
                    Name = "Test Product 3",
                    Email = "komilov@gmail.com",
                    Password = "123",
                    Login = "tes123",
                    Role = "Admin"
                },
                new User()
                {
                    Name = "Test Product 311",
                    Email = "komilov@gmail.com",
                    Password = "123",
                    Login = "tes123",
                    Role = "Admin"
                }
            };

            yield return new object[]
            {
                new UserDTO()
                {
                    Name = "Test Product 4",
                    Email = "komilov@gmail.com",
                    Password = "123",
                    Login = "tes123",
                    Role = "Admin"
                },
                new User()
                {
                    Name = "Test Product 4",
                    Email = "komilov@gmail.com",
                    Password = "123",
                    Login = "tes123",
                    Role = "Admin"
                }
            };

            yield return new object[]
            {
                new UserDTO()
                {
                    Name = "Test Product 5",
                    Email = "komilov@gmail.com",
                    Password = "123",
                    Login = "tes123",
                    Role = "Admin"
                },
                new User()
                {
                    Name = "Test Product 5",
                    Email = "komilov@gmail.com",
                    Password = "123",
                    Login = "tes123",
                    Role = "Admin"
                }
            };

            yield return new object[]
            {
                new UserDTO()
                {
                    Name = "Test Product 6",
                    Email = "komilov@gmail.com",
                    Password = "123",
                    Login = "tes123",
                    Role = "Admin"
                },
                new User()
                {
                    Name = "Test Product 6",
                    Email = "komilov@gmail.com",
                    Password = "123",
                    Login = "tes123",
                    Role = "Admin"
                }
            };

            yield return new object[]
            {
                new UserDTO()
                {
                    Name = "Test Product 7",
                    Email = "komilov@gmail.com",
                    Password = "123",
                    Login = "tes123",
                    Role = "Admin"
                },
                new User()
                {
                    Name = "Test Product 7",
                    Email = "komilov@gmail.com",
                    Password = "123",
                    Login = "tes123",
                    Role = "Admin"
                }
            };
        }

        // Create User Test
        [Theory]
        [MemberData(nameof(GetUserFromDataGenerator), MemberType = typeof(UserServiceTests))]
        public async void Create_User_Test(UserDTO inputUser, User expextedUser)
        {
             var myMapper = mockMapepr.CreateMapper();


            var result = myMapper.Map<User>(inputUser);
            // logic
            _userservice.Setup(x => x.Create(It.IsAny<UserDTO>()))
            .ReturnsAsync(result);

            var controller = new UsersController(_userservice.Object);

            
            // Act
            var createdUser = await controller.CreateUser(inputUser);

            // Assert
            Assert.NotNull(createdUser); // Verify a user object is returned

            Assert.True(CompareModels(expextedUser, createdUser));
        }

        public static bool CompareModels(User inputUser, User user)
        {
            if (inputUser.Name == user.Name && inputUser.Email == user.Email && inputUser.Password == user.Password
                && inputUser.Login == user.Login && inputUser.Role == user.Role)
            {
                return true;
            }

            return false;
        }

        
        // Get User Test
        [Fact]
        public async Task Get_User_ById_TestAsync()
        {
            // Arrange
            var user = new User()
            {
                Id = 6,
                Name = "Test Product 34",
                Email = "komilov@gmail.com",
                Password = "123",
                Login = "tes123",
                Role = "Admin"
            };

            _userservice.Setup(s => s.GetById(5)).ReturnsAsync(user);

            var controller = new UsersController(_userservice.Object);

            // Act
            var result = await controller.UserGetById(6);

            //// Assert
            //var okResult = Assert.IsType<OkObjectResult>(result);

            //var returnUser = Assert.IsType<User>(okResult.Value);

            Assert.True(CompareModels(result, user));
        }

        // Update
        [Fact]
        public async void Update_User_Test()
        {
            var _mapper = mockMapepr.CreateMapper();
            // Arrange
            int Id = 5;
            var user = new UserDTO()
            {
                Name = "Kamoliddin",
                Email = "kamol33@gmail.com",
                Password = "123",
                Login = "123ww",
                Role = "Teacher"
            };

            var result = _mapper.Map<User>(user);

            _userservice.Setup(x => x.Update(Id, user))
                .ReturnsAsync(result);

            var controller = new UsersController(_userservice.Object);

            var natija = await controller.UpdateUser(Id, user);

            

            Assert.True(CompareModels(natija, result));
           

        }



    }

}
