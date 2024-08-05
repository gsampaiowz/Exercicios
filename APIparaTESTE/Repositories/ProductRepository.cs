using APIparaTESTE.Contexts;
using APIparaTESTE.Domains;
using APIparaTESTE.Interfaces;

namespace APIparaTESTE.Repositories
    {
    public class ProductRepository : IProductRepository
        {
        private readonly Context ctx;

        public ProductRepository()
            {
            ctx = new Context();
            }
        public void Delete(Guid id)
            {
            try
                {
                var produtoBuscado = ctx.Produto.FirstOrDefault(x => x.IdProduct == id);
                ctx.Produto.Remove(produtoBuscado!);
                ctx.SaveChanges();
                }
            catch (Exception e)
                {

                throw new Exception(e.Message);
                }
            }

        public List<Product> Get()
            {
            try
                {
                var listaDeProdutos = ctx.Produto.ToList();
                return listaDeProdutos;

                }
            catch (Exception e)
                {

                throw new Exception(e.Message);
                }
            }

        public Product Get(Guid id)
            {
            try
                {
                var produtoBuscado = ctx.Produto.FirstOrDefault(x => x.IdProduct == id);
                return produtoBuscado ?? null!;
                
                }
            catch (Exception e)
                {

                throw new Exception(e.Message);
                }
            }

        public void Post(Product product)
            {
            try
                {
                ctx.Produto.Add(product);
                ctx.SaveChanges();
                }
            catch (Exception e)
                {

                throw new Exception(e.Message);
                }
            }

        public void Put(Product product, Guid id)
            {
            try
                {
                var produtoBuscado = ctx.Produto.FirstOrDefault(x => x.IdProduct == id);
                if (produtoBuscado != null)
                    {
                    produtoBuscado.Name = product.Name;
                    produtoBuscado.Price = product.Price;
        
                    ctx.Produto.Update(product);

                    ctx.SaveChanges();
                    };
                }
            catch (Exception e)
                {

                throw new Exception(e.Message);
                }
            }
        }
    }
