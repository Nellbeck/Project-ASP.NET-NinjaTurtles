using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Project_ASP.NET_NinjaTurtles.Models
{
    public class Product
    {
        [Key]
        public Guid ProductId { get; set; }
        [Required]
        [StringLength(100)]
        public string ProductName { get; set; }
        [Required]
        public decimal ProductPrice { get; set; }
        [Required]
        [StringLength(200)]
        public string ProductDescription { get; set; }
        public int ProductQuantity { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public ICollection<Order> Orders { get; set; }

    }
}
