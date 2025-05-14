using System.ComponentModel.DataAnnotations;

namespace PruebaTecnica.Entidades
{
    public class Order
    {
        [Key]
        public int Id { get; set; } 
        public string CustomerName { get; set; }    
        public DateTime Date { get; set; } = DateTime.Now;
        public List<OrderItem> OrderItems { get; set; } 
    }
}
