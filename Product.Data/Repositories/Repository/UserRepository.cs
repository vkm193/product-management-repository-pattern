using Microsoft.EntityFrameworkCore;
using Product.Data.Models;
using Product.Data.Repositories.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Product.Data.Repositories.Repository
{
    public class UserRepository : IUserRepository
    {
        protected ProductManagementContext productContext;
        protected DbSet<Users> dbset;
        public UserRepository(ProductManagementContext context)
        {
            productContext = context;
            dbset = context.Set<Users>();
        }
        public Users GetById(Guid id)
        {
            Users user = productContext.Users.Where(x => x.Id == id && x.IsActive).FirstOrDefault();
            return user;
        }
        public List<Users> GetAll()
        {
            List<Users> userList = productContext.Users.Where(x => x.IsActive).ToList();
            return userList;
        }

        public void Save(Users user)
        {
            productContext.Users.Add(user);
            productContext.SaveChanges();
        }

        public void Delete(Guid id)
        {
            Users userInDb = productContext.Users.Where(x => x.Id == id && x.IsActive).FirstOrDefault();
            userInDb.IsActive = false;
            productContext.SaveChanges();
        }

        public Users GetUserByEmail(string email)
        {
            return (productContext.Users.Where(x => x.Email == email && x.IsActive).FirstOrDefault());
        }

    }
}
