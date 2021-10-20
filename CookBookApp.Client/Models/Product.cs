namespace CookBookApp.Client.Models
{
    public class Product : ModelBase
    {
        public string Name { get; set; }
        public int Kcal { get; set; }
        public string ProductType { get; set; }
        public string Author { get; set; }
        public int ProductTypeId { get; set; }
        public bool IsAcceptedByAdmin { get; set; }
    }
}
