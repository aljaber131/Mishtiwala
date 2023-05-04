using BLL.DTOs;
using DAL;
using DAL.Models;
using DAL.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class UserService
    {
        private readonly IRepository<User> _userRepository;

        public UserService()
        {
            _userRepository = DataAccessFactory.UserData();
        }

        public UserDTO GetUserById(int id)
        {
            var data =  _userRepository.GetById(id);
            return new UserDTO{
                Id= data.Id,
                FirstName = data.FirstName,
                LastName = data.LastName,
                Email = data.Email,
                Password= data.Password,
                Address= data.Address,
                Role= data.Role, 
            };
        }

        public dynamic GetAllUsers()
        {
            return _userRepository.GetAll();
        }

        public void CreateUser(UserDTO user)
        {
            _userRepository.Add(new User
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Password= user.Password,
                Address= user.Address,
                Role= user.Role,
                Phone= user.Phone,
            });
        }

        public void UpdateUser(UserDTO user)
        {
            _userRepository.Update(new User
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Password = user.Password,
                Address = user.Address,
                Role = user.Role,
            });
        }

        public void DeleteUser(UserDTO user)
        {
            _userRepository.Delete(new User
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Password = user.Password,
                Address = user.Address,
                Role = user.Role,
            });
        }
    }
}
