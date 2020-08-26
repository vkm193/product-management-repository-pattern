using Product.Data.Models;
using Product.Data.Repositories.IRepository;
using Product.Service.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Product.Service.Services.User
{
    public class UserService : IUserService
    {
        protected IUserRepository userRepository;
        protected IUserRolesRepository userRolesRepository;
        public UserService(IUserRepository _userRepository, IUserRolesRepository _userRolesRepository)
        {
            userRepository = _userRepository;
            userRolesRepository = _userRolesRepository;
        }

        public void Save(RegisterModel newUser)
        {
            Users user = new Users();
            user.FirstName = newUser.FirstName;
            user.LastName = newUser.LastName;
            user.Mobile = newUser.Mobile;
            user.Address = newUser.Address;
            user.Email = newUser.Email;
            user.CreatedOn = DateTime.Now;
            user.UpdatedOn = DateTime.Now;
            user.Password = newUser.Password;
            user.UserRoleId = userRolesRepository.GetRoleIdByRole("User");
            userRepository.Save(user);
        }

    }
}
