using DataAccess;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace BusinessLogic.Repos
{
    public class ProductRepo
    {
        InventoryDBContext dbContext;

        public ProductRepo()
        {
            dbContext = new InventoryDBContext();
        }

        public IEnumerable<Product> Read()
        {
            try
            {
                var result = dbContext.Products.OrderBy(p=>p.ProductName);

                return result;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                Debug.WriteLine(ex.StackTrace);

                return new List<Product>();
            }
        }

        public Product Read(int id)
        {
            try
            {
                var result = dbContext.Products.Find(id);

                return result;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                Debug.WriteLine(ex.StackTrace);

                return new Product();
            }
        }

        public void Update(Product input)
        {
            var product = Read(input.Id);

            product.ProductName = input.ProductName;

            product.Price = input.Price;

            dbContext.SaveChanges();
        }

        public void Delete(Product input)
        {
            var product = Read(input.Id);

            dbContext.Products.Remove(product);

            dbContext.SaveChanges();
        }
    }
}
