using Product.Data.Repositories.IRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Product.Service.Services.UserRoles
{
    public class UserRolesService: IUserRolesService
    {
        protected IUserRolesRepository userRoleRepository;
        public UserRolesService(IUserRolesRepository _userRoleRepository)
        {
            userRoleRepository = _userRoleRepository;
        }

        public Guid GetRoleIdByRole(string role)
        {
            return userRoleRepository.GetRoleIdByRole(role);
        }
    }
}
