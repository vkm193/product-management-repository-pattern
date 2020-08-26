using Product.Service.ViewModels;
using System;
using System.Collections.Generic;
using Product.Data.Models;
using System.Text;
using Product.Data.Repositories.IRepository;

namespace Product.Service.Services.Products
{
    public class ProductService : IProductService
    {
        protected IProductRepository productRepository;
        public ProductService(IProductRepository _productRepository)
        {
            productRepository = _productRepository;
        }
        public ProductModel GetById(Guid id)
        {
            Data.Models.Products product = productRepository.GetById(id);            
            return MapProductToProductModel(product);
        }
        public List<ProductModel> GetAll()
        {
            List<Data.Models.Products> productList = productRepository.GetAll();
            List<ProductModel> prodList = new List<ProductModel>();
            foreach (var product in productList)
            {
                prodList.Add(MapProductToProductModel(product));
            }
            
            return prodList;
        }
        public List<ProductModel> GetAll(string keyword)
        {
            List<Data.Models.Products> productList = productRepository.GetAll(keyword);
            List<ProductModel> prodList = new List<ProductModel>();
            foreach (var product in productList)
            {
                prodList.Add(MapProductToProductModel(product));
            }
            return prodList;
        }
        public void Save(ProductModel product)
        {
            productRepository.Save(MapProductModelToProduct(product));
        }
        public void Edit(ProductModel product)
        {
            productRepository.Edit(MapProductModelToProduct(product, false));
        }
        public void UpdatePrice(Guid id, Decimal price)
        {
            Data.Models.Products product = productRepository.GetById(id);
            product.Price = price;
            product.SalePrice = price + ((price * 10) / 100);
            productRepository.Edit(product);
        }
        public void Delete(Guid id)
        {
            productRepository.Delete(id);
        }

        private ProductModel MapProductToProductModel(Data.Models.Products product)
        {
            ProductModel prod = new ProductModel();
            prod.Id = product.Id;
            prod.Name = product.Name;
            prod.Description = product.Description;
            prod.Price = product.Price;
            prod.SalePrice = product.SalePrice;
            prod.ImageUrl = product.ImageUrl;
            prod.CreatedBy = product.CreatedBy;
            prod.CreatedOn = product.CreatedOn;
            prod.UpdatedBy = product.UpdatedBy;
            prod.UpdatedOn = product.UpdatedOn;
            prod.IsActive = product.IsActive;
            return prod;
        }

        private Data.Models.Products MapProductModelToProduct(ProductModel product, bool isAdd = true)
        {
            Data.Models.Products productEntity = new Data.Models.Products();
            productEntity.Id = product.Id;
            productEntity.Name = product.Name;
            productEntity.Description = product.Description;
            productEntity.Price = product.Price;
            productEntity.SalePrice = product.Price + ((product.Price * 10) / 100);
            productEntity.ImageUrl = product.ImageUrl;    
            productEntity.UpdatedBy = product.UpdatedBy;
            productEntity.UpdatedOn = DateTime.Now;
            productEntity.IsActive = product.IsActive;
            if (isAdd)
            {
                productEntity.CreatedBy = product.CreatedBy;
                productEntity.CreatedOn = DateTime.Now;                
            }
            else 
            {
                productEntity.CreatedBy = product.CreatedBy;
                productEntity.CreatedOn = product.CreatedOn;                
            }
            return productEntity;
        }
    }
}
