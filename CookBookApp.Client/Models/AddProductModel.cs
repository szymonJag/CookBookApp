using System.ComponentModel.DataAnnotations;

namespace CookBookApp.Client.Models
{
    public class AddProductModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public int Kcal { get; set; }
        [Required]
        public int ProductTypeId { get; set; }
    }
}
