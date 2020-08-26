using Product.Data.Models;
using System;
using System.Collections.Generic;
using System.Reflection.PortableExecutable;
using System.Text;

namespace Product.Data.Repositories.IRepository
{
    public interface IProductRepository
    {
        Products GetById(Guid id);
        List<Products> GetAll();
        List<Products> GetAll(string keyword);
        void Save(Products product);
        void Edit(Products product);
        void Delete(Guid id);
    }
}
