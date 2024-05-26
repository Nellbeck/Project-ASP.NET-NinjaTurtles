
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Project_ASP.NET_NinjaTurtles.Models
{
    public class Order
    {
        [Key]
        public Guid OrderId { get; set; }
        [ForeignKey("Customer")]
        public Guid? FKCustomerId { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public Customer? Customer { get; set; }
        public DateTime OrderDate { get; set; }
        public int OrderQuantity { get; set; }
        [ForeignKey("Product")]
        public Guid FKProductId { get; set; }
        public Product? Product { get; set; }
        public ICollection<OrderProduct> OrderProducts { get; set; } = [];


    }
}
