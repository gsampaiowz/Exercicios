using APIparaTESTE.Domains;
using APIparaTESTE.Interfaces;
using APIparaTESTE.Repositories;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace APIparaTESTE.Controllers
    {
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class ProductController : ControllerBase
        {
        private readonly IProductRepository _productRepository;

        public ProductController()
            {
            _productRepository = new ProductRepository();
            }

        // GET: api/<ProductController>
        [HttpGet]
        public IActionResult Get()
            {
            try
                {
                var listaDeProdutos = _productRepository.Get();
                return Ok(listaDeProdutos);
                }
            catch (Exception e)
                {
                return BadRequest(e.Message);
                }
            }

        // GET api/<ProductController>/5
        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
            {
            try
                {
                var produtoBuscado = _productRepository.Get(id);
                return Ok(produtoBuscado);

                }
            catch (Exception e)
                {

                return BadRequest(e.Message);
                }
            }

        // POST api/<ProductController>
        [HttpPost]
        public IActionResult Post(Product product)
            {
            try
                {
                _productRepository.Post(product);
                return Ok("Cadastrado!");
                }
            catch (Exception e)
                {

                return BadRequest(e.Message);
                }
            }

        // PUT api/<ProductController>/5
        [HttpPut("{id}")]
        public IActionResult Put(Guid id, Product product)
            {
            try
                {
                _productRepository.Put(product, id);
                return Ok(product);
                }
            catch (Exception e)
                {

                return BadRequest(e.Message);
                }
            }

        // DELETE api/<ProductController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
            {
            try
                {
                _productRepository.Delete(id);
                return NoContent();
                }
            catch (Exception e)
                {

                return BadRequest(e.Message);
                }
            }
        }
    }
