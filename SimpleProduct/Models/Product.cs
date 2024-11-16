using Microsoft.AspNetCore.Routing.Constraints;

namespace SimpleProduct.Models
{
    public class Product
    {
        public int ProductId    { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public int AvailableQuantify { get; set; }
        public float Price { get; set; }  
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
