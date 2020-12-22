using EcomerceProject.Entities;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcomerceProject.Services.Interfaces
{
    public interface IProductServices
    {
        List<Product> GetProducts();

        Product GetProduct(int id);

        void AddProduct(Product product);

        void DeleteProduct(int id);

        void UpdateProduct(Product product);
    }
}
