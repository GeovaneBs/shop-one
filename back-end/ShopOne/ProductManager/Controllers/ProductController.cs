using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using ProductManager.Models;
using ProductManager.Persistence;

namespace ProductManager.Controllers
{
    [Route("api/[Controller]")]
    public class ProductController : Controller
    {
        private readonly ProductManagerDbContext _ProductManagerDbContext;

        public ProductController(ProductManagerDbContext ProductManagerDbContext)
        {
            _ProductManagerDbContext = ProductManagerDbContext;
        }

        // GET: ProductController
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductModel>>> GetAllProducts()
        {
            return await _ProductManagerDbContext.Products.ToListAsync();
        }

        [HttpGet("{id}")]       
        public IActionResult GetById(int id)
        {
            var product = _ProductManagerDbContext.Products.SingleOrDefault(p => p.Id == id);

            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        // GET: ProductController/Create
        [HttpPost]
        public IActionResult CreateProduct([FromBody] ProductInputModel Product)
        {
            if (Product == null)
                return BadRequest("Produto inválido");

            var newProduct = new ProductModel(Product.Name, Product.Description, Product.Price);

            _ProductManagerDbContext.Products.Add(newProduct);
            _ProductManagerDbContext.SaveChanges();

            return CreatedAtAction(nameof(GetById), new { id = newProduct.Id }, newProduct);
        }
    }
}
