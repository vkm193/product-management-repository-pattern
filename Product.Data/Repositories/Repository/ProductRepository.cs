using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Product.Data.Models;
using Product.Data.Repositories.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Product.Data.Repositories.Repository
{
    public class ProductRepository : IProductRepository
    {
        protected ProductManagementContext productContext;
        protected DbSet<Products> dbset;
        public ProductRepository(ProductManagementContext context)
        {
            productContext = context;
            dbset = context.Set<Products>();
        }
        public Products GetById(Guid id)
        {
            Products product = productContext.Products.Where(x => x.Id == id && x.IsActive).FirstOrDefault();
            return product;
        }
        public List<Products> GetAll()
        {
            List<Products> productList = productContext.Products.Where(x => x.IsActive).ToList();
            return productList;
        }
        public List<Products> GetAll(string keyword)
        {
            List<Products> productList = productContext.Products.Where(x => (x.Name.Contains(keyword) || x.Description.Contains(keyword)) && x.IsActive).ToList();
            return productList;
        }
        public void Save(Products product)
        {
            productContext.Products.Add(product);
            productContext.SaveChanges();
        }
        public void Edit(Products product)
        {
            Products productInDb = productContext.Products.Where(x => x.Id == product.Id && x.IsActive).FirstOrDefault();
            productInDb.Name = product.Name;
            productInDb.Description = product.Description;
            productInDb.Price = product.Price;
            productInDb.SalePrice = product.SalePrice;
            productInDb.ImageUrl = product.ImageUrl;
            productInDb.CreatedBy = product.CreatedBy;
            productInDb.CreatedOn = product.CreatedOn;
            productInDb.UpdatedBy = product.UpdatedBy;
            productInDb.UpdatedOn = product.UpdatedOn;
            productInDb.IsActive = product.IsActive;
            productContext.SaveChanges();

        }
        public void Delete(Guid id)
        {
            Products productInDb = productContext.Products.Where(x => x.Id == id && x.IsActive).FirstOrDefault();
            productInDb.IsActive = false;
            productContext.SaveChanges();
        }
    }
}
