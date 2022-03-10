using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using identityTable.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using productMicroservice.Classes;
using productMicroservice.Data;
using productMicroservice.Models;

namespace productMicroservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly productMicroserviceContext _context;

        public ProductsController(productMicroserviceContext context)
        {
            _context = context;
        }

        // GET: api/Products
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProduct()
        {
            return await _context.Product.ToListAsync();
        }

        // GET: api/Products/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            var product = await _context.Product.FindAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            return product;
        }

        // GET: api/Products/type
        [HttpGet("pages")]
        public async Task<ActionResult<IEnumerable<Product>>> GetProduct([FromQuery] QueryParameters queryParameters)
        {
            IQueryable<Product> products = _context.Product;
            products = products.Skip(queryParameters.Size * (queryParameters.Page - 1))
                 .Take(queryParameters.Size);
            return Ok(await products.ToArrayAsync());
        }
        // GET: api/Products/type
        [HttpGet("price")]
        public async Task<ActionResult<IEnumerable<Product>>> GetProduct([FromQuery] ProductQueryParameters queryParameters)
        {
            IQueryable<Product> products = _context.Product;

            if (queryParameters.MinPrice != null && queryParameters.MaxPrice != null)
            {
                products = products.Where(p => p.price >= queryParameters.MinPrice.Value &&
                p.price <= queryParameters.MaxPrice.Value);

            }
            if (queryParameters.catId > 0)
            {
                products = products.Where(p => p.CategoryId == queryParameters.catId);
            }


            return Ok(await products.ToArrayAsync());
        }

        [HttpGet("search")]
        public async Task<ActionResult<IEnumerable<Product>>> GetProduct([FromQuery] SearchQueryParameters queryParameters)
        {
            IQueryable<Product> products = _context.Product;

            if (!string.IsNullOrEmpty(queryParameters.searchTerm))
            {
                products = products.Where(p => p.name.ToLower().Contains(queryParameters.searchTerm.ToLower()) ||
                                               p.summary.ToLower().Contains(queryParameters.searchTerm.ToLower()));

            }
            return Ok(await products.ToArrayAsync());
        }

        // PUT: api/Products/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [Authorize(Roles = UserRoles.Admin)]
        public async Task<IActionResult> PutProduct(int id, Product product)
        {
            if (id != product.Id)
            {
                return BadRequest();
            }

            _context.Entry(product).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Products
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Authorize(Roles = UserRoles.Admin)]
        public async Task<ActionResult<Product>> PostProduct(Product product)
        {
            _context.Product.Add(product);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProduct", new { id = product.Id }, product);
        }

        // DELETE: api/Products/5
        [HttpDelete("{id}")]
         [Authorize(Roles = UserRoles.Admin)]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var product = await _context.Product.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            _context.Product.Remove(product);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProductExists(int id)
        {
            return _context.Product.Any(e => e.Id == id);
        }
    }
}
