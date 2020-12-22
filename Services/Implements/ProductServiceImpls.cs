using EcomerceProject.Entities;
using EcomerceProject.Repositories;
using EcomerceProject.Services.Interfaces;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcomerceProject.Services.Implements
{
    public class ProductServiceImpls : IProductServices
    {
        private ApplicationContext context;
        private List<Product> products;
        public ProductServiceImpls(ApplicationContext context)
        {
            this.context = context;
            products = new List<Product>();
        }
        public void AddProduct(Product product)
        {
            context.Product.Add(product);
            context.SaveChanges();
        }

        public void DeleteProduct(int id)
        {
            var product = context.Product.SingleOrDefault(p => p.id == id);
            context.Product.Remove(product);
            context.SaveChanges();
        }

        public Product GetProduct(int id)
        {
            var product = context.Product.SingleOrDefault(p => p.id == id);
            return product;
        }

        public List<Product> GetProducts()
        {
            var products = context.Product.ToList();
            return products;
        }

        public void UpdateProduct(Product product)
        {
            context.Product.Update(product);
            context.SaveChanges();
        }
    }
}
