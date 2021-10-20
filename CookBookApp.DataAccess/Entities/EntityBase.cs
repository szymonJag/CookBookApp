using System.ComponentModel.DataAnnotations;

namespace CookBookApp.DataAccess.Entities
{
    public abstract class EntityBase
    {
        [Key]
        public int Id { get; set; }
    }
}
