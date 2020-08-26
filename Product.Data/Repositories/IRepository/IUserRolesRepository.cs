using System;
using System.Collections.Generic;
using System.Text;

namespace Product.Data.Repositories.IRepository
{
    public interface IUserRolesRepository
    {
        Guid GetRoleIdByRole(string role);
    }
}
