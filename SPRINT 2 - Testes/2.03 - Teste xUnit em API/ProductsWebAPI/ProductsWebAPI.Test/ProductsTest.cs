using Moq;
using ProductsWebAPI.Domains;
using ProductsWebAPI.Interfaces;

namespace ProductsWebAPI.Test
{
    public class ProductsTest
    {
        [Fact]
        public void Get()
        {
            List<Products> list = new List<Products>
            {
                new Products {Id = Guid.NewGuid(), Name = "Produto", Price = 20 },
                new Products {Id = Guid.NewGuid(), Name = "Produto", Price = 40 },
                new Products {Id = Guid.NewGuid(), Name = "Produto", Price = 35 },
            };

            var mockRep = new Mock<IProductsRepository>();
            mockRep.Setup(x => x.Get()).Returns(list);

            var result = mockRep.Object.Get();

            Assert.Equal(3, result.Count);
        }
        [Fact]
        public void GetById()
        {
            List<Products> list = new List<Products>
            {
                new Products {Id = Guid.NewGuid(), Name = "Produto", Price = 20 },
                new Products {Id = Guid.NewGuid(), Name = "Produto", Price = 40 },
                new Products {Id = Guid.NewGuid(), Name = "Produto", Price = 35 },
            };

            var mockRep = new Mock<IProductsRepository>();
            mockRep.Setup(x => x.GetById(list[0].Id)).Returns(list[0]);
            var result = mockRep.Object.GetById(list[0].Id);

            Assert.Equal(list[0], result);
        }

        [Fact]
        public void Delete()
        {
            Products prod = new Products
            { Id = Guid.NewGuid(), Name = "Produto", Price = 25 };
            List<Products> list =
            [
                new Products {Id = Guid.NewGuid(), Name = "Produto", Price = 20 },
                new Products {Id = Guid.NewGuid(), Name = "Produto", Price = 40 },
                new Products {Id = Guid.NewGuid(), Name = "Produto", Price = 35 },
                prod,
            ];

            var mockRep = new Mock<IProductsRepository>();
            mockRep.Setup(x => x.Delete(prod.Id)).Callback<Guid>(x =>
            {
                var product = list.Where(x => x.Id == prod.Id).FirstOrDefault();
                if (product != null)
                {
                    list.Remove(product);
                }
            });
            mockRep.Object.Delete(prod.Id);

            Assert.DoesNotContain(prod, list);
        }

        [Fact]
        public void Put()
        {
            List<Products> list = new List<Products>
            {
                new Products {Id = Guid.NewGuid(), Name = "Produto", Price = 20 },
                new Products {Id = Guid.NewGuid(), Name = "Produto", Price = 40 },
                new Products {Id = Guid.NewGuid(), Name = "Produto", Price = 35 },
            };
            Products prod = new Products
            { Id = list[0].Id, Name = "Produto", Price = 25 };

            var mockRep = new Mock<IProductsRepository>();
            mockRep.Setup(x => x.Put(prod)).Callback<Products>(x => x = list[0]);
            mockRep.Object.Put(prod);

            Assert.DoesNotContain(prod, list);
        }

        [Fact]
        public void Post()
        {
            Products prod = new Products
            { Id = Guid.NewGuid(), Name = "Produto", Price = 25 };

            List<Products> list = new List<Products>();

            var mockRep = new Mock<IProductsRepository>();

            mockRep.Setup(x => x.Post(prod)).Callback<Products>(x => list.Add(prod));
            mockRep.Object.Post(prod);

            Assert.Contains(prod, list);
        }
    }
}