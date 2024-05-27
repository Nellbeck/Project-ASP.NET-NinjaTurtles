
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Project_ASP.NET_NinjaTurtles.Models
{
    public class Order
    {
        [Key]
        [DisplayName("Order ID")]
        public Guid OrderId { get; set; }
        [ForeignKey("Customer")]
        [DisplayName("Customer ID")]
        public Guid? FKCustomerId { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public Customer? Customer { get; set; }
        [DisplayName("Orderdate")]
        public DateTime OrderDate { get; set; }
        [DisplayName("Orderquantity")]
        public int OrderQuantity { get; set; }
        [ForeignKey("Product")]
        [DisplayName("Product ID")]
        public Guid FKProductId { get; set; }
        public Product? Product { get; set; }
        public ICollection<OrderProduct> OrderProducts { get; set; } = [];

    }
}
