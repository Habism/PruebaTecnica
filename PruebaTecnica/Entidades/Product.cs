using System.ComponentModel.DataAnnotations;

namespace PruebaTecnica.Entidades
{
    public class Product
    {
        [Key]   
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre es requerido")]
        [StringLength(100, ErrorMessage = "El nombre no puede exceder los 100 caracteres")] 
        public string Name { get; set; }

        [Required(ErrorMessage = "El precio es requerido")]
        [Range(0.01, double.MaxValue, ErrorMessage = "El precio debe ser mayor que cero")]
        public decimal Price { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "El stock debe ser un número positivo")]
        public int Stock { get; set; }  

    }
}
