using System.ComponentModel.DataAnnotations;

namespace CookBookApp.DataAccess.Entities
{
    public class Product : EntityBase
    {
        [Required]
        [MaxLength(20)]
        public string Name { get; set; }
        [Required]
        [Range(0, 1000)]
        public int Kcal { get; set; }
        public string Author { get; set; }
        public bool IsAcceptedByAdmin { get; set; }
        public int ProductTypeId { get; set; }
        public ProductType ProductType { get; set; }
    }
}
