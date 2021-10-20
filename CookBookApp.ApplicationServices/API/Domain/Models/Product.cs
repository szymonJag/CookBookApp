namespace CookBookApp.ApplicationServices.API.Domain.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Kcal { get; set; }
        public string ProductType { get; set; }
        public string Author { get; set; }
        public bool IsAcceptedByAdmin { get; set; }
    }
}
