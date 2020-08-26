using Product.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Product.Data.Repositories.IRepository
{
    public interface IUserRepository
    {
        Users GetById(Guid id);
        List<Users> GetAll();
        void Save(Users user);
        void Delete(Guid id);
        Users GetUserByEmail(string email);
    }
}
