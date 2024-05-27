
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Project_ASP.NET_NinjaTurtles.Models
{
    public class Product
    {
        [Key]
        [DisplayName("Product ID")]
        public Guid ProductId { get; set; }
        [Required]
        [StringLength(100)]
        [DisplayName("Product name")]
        public string ProductName { get; set; }
        [DisplayName("Price")]
        [Required]
        public decimal ProductPrice { get; set; }
        [Required]
        [StringLength(200)]
        [DisplayName("Description")]
        public string ProductDescription { get; set; }
        [DisplayName("Quantity")]
        public int ProductQuantity { get; set; }
    
        [DisplayName("Orders")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public ICollection<Order>? Orders { get; set; }
        [DisplayName("Image")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? ImgPath { get; set; }
    }
}
