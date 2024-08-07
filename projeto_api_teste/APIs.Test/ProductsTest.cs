using APIparaTESTE.Domains;
using APIparaTESTE.Interfaces;
using Moq;

namespace APIs.Test
    {
    public class ProductsTest
        {
        [Fact]
        public void Get()
            {
            //Arrange

            var products = new List<Product>
            {
                new() {IdProduct =Guid.NewGuid(), Name = "produto1", Price = 90},
                new() {IdProduct =Guid.NewGuid(), Name = "produto2", Price = 60},
                new() {IdProduct =Guid.NewGuid(), Name = "produto3", Price = 30}
            };

            products.Remove(products.FirstOrDefault(x => x.Name == "produto1")!);

            //cria um objeto de simulação do tipo ProductRepositoru
            var mockRepository = new Mock<IProductRepository>();

            //configura o método de listar todos para que quando for acionado retorne a lista mockada
            mockRepository.Setup(x => x.Get()).Returns(products);

            //Act
            var result = mockRepository.Object.Get();

            var productsNames = result.Select(p => p.Name).ToList();

            //Assert
            mockRepository.Verify(x => x.Get(), Times.Once);
            Assert.Equal(2, result.Count);
            Assert.Contains("produto2", productsNames);
            }

        [Fact]
        public void Post()
            {
            var products = new List<Product>();

            var novoProduto = new Product { IdProduct = Guid.NewGuid(), Name = "Carro", Price = 100000 };

            var mockRepository = new Mock<IProductRepository>();

            mockRepository.Setup(x => x.Post(novoProduto)).Callback<Product>(x => products.Add(novoProduto));

            mockRepository.Object.Post(novoProduto);

            Assert.Contains(novoProduto, products);
            }

        [Fact]
        public void Delete()
            {

            var products = new List<Product>
            {
                new() {IdProduct =Guid.NewGuid(), Name = "produto1", Price = 90},
                new() {IdProduct =Guid.NewGuid(), Name = "produto2", Price = 60},
                new() {IdProduct =Guid.NewGuid(), Name = "produto3", Price = 30}
            };

            var produtoBuscado = products.FirstOrDefault(x => x.Name == "produto3");

            var mockRepository = new Mock<IProductRepository>();

            mockRepository.Setup(x => x.Delete(produtoBuscado!.IdProduct)).Callback(() => products.Remove(produtoBuscado!));

            mockRepository.Object.Delete(produtoBuscado!.IdProduct);

            Assert.DoesNotContain(produtoBuscado, products);

            }

        [Fact]
        public void GetById()
            {
            var products = new List<Product>
            {
                new() {IdProduct =Guid.NewGuid(), Name = "produto1", Price = 90},
                new() {IdProduct =Guid.NewGuid(), Name = "produto2", Price = 60},
                new() {IdProduct =Guid.NewGuid(), Name = "produto3", Price = 30}
            };

            var produtoBuscado = products.FirstOrDefault(x => x.Name == "produto2");

            var mockRepository = new Mock<IProductRepository>();

            mockRepository.Setup(x => x.Get(produtoBuscado!.IdProduct)).Returns(produtoBuscado!);

            var result = mockRepository.Object.Get(produtoBuscado!.IdProduct);

            Assert.True(result == produtoBuscado);
            }

        [Fact]
        public void Update()
            {
            var products = new List<Product>
            {
                new() {IdProduct =Guid.NewGuid(), Name = "produto1", Price = 90},
                new() {IdProduct =Guid.NewGuid(), Name = "produto2", Price = 60},
                new() {IdProduct =Guid.NewGuid(), Name = "produto3", Price = 30}
            };


            var produtoBuscado = products.FirstOrDefault(x => x.Name == "produto2");

            var mockRepository = new Mock<IProductRepository>();

            mockRepository.Setup(x => x.Put(produtoBuscado!, produtoBuscado!.IdProduct)).Callback<Product, Guid>((p, id) =>
            {
                if (produtoBuscado != null)
                    {

                    p.IdProduct = produtoBuscado!.IdProduct;
                    p.Name = "produto editado";
                    p.Price = produtoBuscado.Price;
                    products.Remove(produtoBuscado);
                    products.Add(p);
                    }

            });

            var produtoEditado = new Product()
                {
                IdProduct = produtoBuscado!.IdProduct,
                Name = "produto editado",
                Price = produtoBuscado.Price
                };

            mockRepository.Object.Put(produtoEditado, produtoBuscado.IdProduct);

            Assert.Equal(3, products.Count);
            Assert.NotNull(products.FirstOrDefault(x => x.Name == "produto2"));
            }
        }
    }