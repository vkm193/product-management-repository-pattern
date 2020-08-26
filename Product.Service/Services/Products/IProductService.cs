using Product.Service.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Product.Service.Services.Products
{
    public interface IProductService
    {
        ProductModel GetById(Guid id);
        List<ProductModel> GetAll();
        List<ProductModel> GetAll(string keyword);
        void Save(ProductModel product);
        void Edit(ProductModel product);
        void UpdatePrice(Guid id, Decimal price);
        void Delete(Guid id);
    }
}
