using Microsoft.EntityFrameworkCore;
using Product.Data.Models;
using Product.Data.Repositories.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Product.Data.Repositories.Repository
{
    public class UserRolesRepository : IUserRolesRepository
    {
        protected ProductManagementContext productContext;
        protected DbSet<UserRoles> dbset;
        public UserRolesRepository(ProductManagementContext context)
        {
            productContext = context;
            dbset = context.Set<UserRoles>();
        }
        public Guid GetRoleIdByRole(string role)
        {
            Guid id = productContext.UserRoles.Where(x => x.RoleName.ToLower() == role.ToLower()).FirstOrDefault().Id;
            return id;
        }
    }
}
