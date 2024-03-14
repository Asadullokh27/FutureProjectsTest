using AutoMapper;
using FutureProjects.Application.Abstractions;
using FutureProjects.Application.Abstractions.IServices;
using FutureProjects.Domain.Entities.DTOs;
using FutureProjects.Domain.Entities.Models;
using FutureProjects.Domain.Entities.ViewModels;
using System.Data;
using System.Linq.Expressions;

namespace FutureProjects.Application.Services.UserServices
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<User> Create(UserDTO userDTO)
        {
            //var user = new User()
            //{
            //    Name = userDTO.Name,
            //    Email = userDTO.Email,
            //    Login = userDTO.Login,
            //    Password = userDTO.Password,
            //    Role = userDTO.Role,
            //};

            var user = _mapper.Map<User>(userDTO);

            var result = await _userRepository.Create(user);

            return result;
        }

        public async Task<bool> Delete(int id)
        {
            var result = await _userRepository.Delete(x=>x.Id==id);

            return result;
        }

        public async Task<IEnumerable<UserViewModel>> GetAll()
        {
            var users = await _userRepository.GetAll();

            var result = users.Select(model => new UserViewModel
            {
                Name = model.Name,
                Email = model.Email,
                Role = model.Role,
            });

            return result;
        }

        public async Task<User> GetByAny(Expression<Func<User, bool>> expression)
        {
            var result = await _userRepository.GetByAny(expression);

            return result;
        }

        public async Task<User> GetByEmail(string email)
        {
            var result = await _userRepository.GetByAny(x => x.Email == email);
            return result;
        }

        public async Task<User> GetById(int Id)
        {
            var result = await _userRepository.GetByAny(x => x.Id == Id);
            return result;
        }

        public async Task<User> GetByLogin(string login)
        {
            var reult = await _userRepository.GetByAny(y => y.Login == login);
            return reult;
        }

        public async Task<User> GetByName(string name)
        {
            var result = await _userRepository.GetByAny(d => d.Name == name);
            return result;
        }

        public async Task<User> Update(int Id, UserDTO userDTO)
        {
            var res = await _userRepository.GetByAny(x => x.Id == Id);

            if (res != null)
            {

                res.Name = userDTO.Name;
                res.Email = userDTO.Email;
                res.Login = userDTO.Login;
                res.Password = userDTO.Password;
                res.Role = userDTO.Role;

                // auto mapper

                //var user = _mapper.Map<User>(userDTO);

                var result = await _userRepository.Update(res);

                return result;
            }
            return new User();

        }
    }
}
