using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PruebaTecnica.Data;
using PruebaTecnica.Entidades;

namespace PruebaTecnica.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly PTContext _context;

        public ProductController(PTContext context)
        {
            _context = context;
        }

        [HttpGet("{Id}")]   
        public ActionResult<Product> Get(int Id)
        {
            var result = _context.Products.FirstOrDefault(x => x.Id == Id);

            if(result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
        [HttpPost]
        public ActionResult Post([FromBody]Product product)
        {
            if (product == null)
            {
                return BadRequest();
            }
            _context.Products.Add(product);
            _context.SaveChanges();
            return CreatedAtAction(nameof(Get), new { id = product.Id }, product);
        }

        [HttpPut("{Id}")]
        public ActionResult Put(int Id, [FromBody] Product product)
        {
            if (Id != product.Id)
            {
                return BadRequest();
            }
            var result = _context.Products.FirstOrDefault(x => x.Id == Id);
            if (result == null)
            {
                return NotFound();
            }
            result.Name = product.Name;
            result.Price = product.Price;
            result.Stock = product.Stock;

            _context.SaveChanges();
            return NoContent();
        }   

        [HttpDelete("{Id}")]
        public ActionResult Delete (int Id)
        {
            var result = _context.Products.FirstOrDefault(x => x.Id == Id);
          
            if(result == null)
            {
                return NotFound();
            }   
            _context.Products.Remove(result);
            _context.SaveChanges();
            return NoContent();
        }   
    }
}
