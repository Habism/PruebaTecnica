using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PruebaTecnica.Entidades
{
    public class OrderItem
    {
        [Key]
        public int OrderItemId { get; set; }           
        public Order Order { get; set; }

        [ForeignKey("Order")]
        public int OrderId { get; set; }    
        public Product Product{ get; set; }

        [ForeignKey("Product")]
        public int ProductId { get; set; }
        public int Quantity { get; set; }

        [Required(ErrorMessage = "El precio unitario es requerido")]
        [Range(0.01, double.MaxValue, ErrorMessage = "El precio unitario debe ser mayor que cero")]
        public decimal UnitPrice { get; set; }  
    }
}
