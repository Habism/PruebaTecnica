using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PruebaTecnica.Data;
using PruebaTecnica.Entidades;

namespace PruebaTecnica.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly PTContext _context;

        public OrderController(PTContext context)
        {
            _context = context;
        }


        [HttpGet("{Id}")]
        public ActionResult<Order> Get(int Id)
        {
            var result = _context.Orders.FirstOrDefault(x => x.Id == Id);

            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
        [HttpPost]
        public ActionResult Post([FromBody] Order order)
        {
            if (order == null || order.OrderItems == null || !order.OrderItems.Any())
            {
                return BadRequest("Order y producto obligatorio.");
            }

            foreach (var item in order.OrderItems)
            {
                var product = _context.Products.FirstOrDefault(x => x.Id == item.ProductId);

                // Verificar si el producto existe  
                if (product == null)
                {
                    return BadRequest($"El producto con ID {item.ProductId} no existe.");
                }

                // Verificar si hay suficiente stock
                if (product.Stock < item.Quantity)
                {
                    return BadRequest($"No hay stock suficiente del siguiente producto {product.Name}");
                }       
            }

            //Una vez validado el stock, restar.
            foreach (var item in order.OrderItems)
            {
                var product = _context.Products.FirstOrDefault(x => x.Id == item.ProductId);
                product.Stock = product.Stock - item.Quantity;
            }

            _context.Orders.Add(order);
            _context.SaveChanges();
            return CreatedAtAction(nameof(Get), new { id = order.Id }, order);
        }

        [HttpGet("{Id}")]
        public ActionResult GetDetails(int Id)
        {
            var result = _context.Orders
                .Include(o => o.OrderItems)
                .ThenInclude(oi => oi.Product)
                .FirstOrDefault(x => x.Id == Id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
    }
}
