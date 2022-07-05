using BusinessLogic.Repos;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace UnitTests
{
    [TestClass]
    public class ProductRepoTest
    {
        [TestMethod]
        public void TestRead()
        {
            //Assert
            var productRepo = new ProductRepo();
            var expected = false;
            var isCollectionEmpty = false;

            //Act
            var products = productRepo.Read().ToList();

            if(products.Count == 0)
            {
                isCollectionEmpty = true;
            }

            foreach(var product in products)
            {
                Console.WriteLine($"{product.ProductName} {product.Price}");
            }

            //Assert
            Assert.AreEqual(expected, isCollectionEmpty);
        }

        [TestMethod]
        public void TestReadById()
        {
            //Assert
            var productRepo = new ProductRepo();
            var expected = false;
            var isNull = false;

            //Act
            var product = productRepo.Read(2);

            if (product == null)
            {
                isNull = true;
            }

            Console.WriteLine($"{product.ProductName} {product.Price}");
            
            //Assert
            Assert.AreEqual(expected, isNull);
        }
    }
}
