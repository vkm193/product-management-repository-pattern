using System;
using System.Collections.Generic;
using System.Text;

namespace Product.Service.Services.UserRoles
{
    public interface IUserRolesService
    {
        Guid GetRoleIdByRole(string role);
    }
}
