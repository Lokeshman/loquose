using Lokesh.Infrastructure.DbFactory;
using Lokesh.Infrastructure.Repository;
using Lokesh.Repository;
using Lokesh.Repository.DbFactories;
using Lokesh.Repository.Initializer;
using Lokesh.Repository.UnitOfWork;
using System;
using Xunit;

namespace XUnitTestDAL
{
    public class TestRef
    {
        public TestRef()
        {

        }

        public TestRef(Product p)
        {
            product = p;
        }

        private Product product;

        public Product GetProduct()
        {
            return product;
        }

        public Product Getproduct
        {
            get { return product; }
        }
    }
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            var product = new Product { ProductId = Guid.NewGuid().ToString(), Name = "lstion", Price = 0, Quantity = 10 };

            IDbFactory _factory = new SqlDbFactory(new DefaultDappererSettings());

            using (IDPUnitOfWork uow = new DPUnitOfWork(_factory))
            {
                IRepository<Product> productRepository = new Repository<Product>(uow);
                IRepository<Product> productRepository1 = new Repository<Product>(uow);
                productRepository.Add(product);
                product = new Product { ProductId = Guid.NewGuid().ToString(), Name = "lstion", Price = 0, Quantity = 10 };
                productRepository1.Add(product);
                var ps = productRepository1.FindAll();
                productRepository1.UnitOfWork.Commit();
                uow.Commit();
            }

        }
    }

}
