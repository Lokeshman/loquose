using Lokesh.Repository;
using System;
using Xunit;

namespace XUnitTestDAL
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            var products = new ProductRepository();
            var product = new Product { ProductId = "123114", Name = "lstion", Price = 0, Quantity = 10 };

            products.Add(product);
            var lstP = products.GetAll();
            lstP = products.GetAll();

        }
    }

}
