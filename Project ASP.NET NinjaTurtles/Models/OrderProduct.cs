using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Project_ASP.NET_NinjaTurtles.Models
{
    public class OrderProduct
    {
        [Key]
        public Guid OrderProductId { get; set; }

        public Product? Product { get; set; }
        [ForeignKey("Product")]
        public Guid FKProductId { get; set; }

        public Order? Order { get; set; }
        [ForeignKey("Order")]
        public Guid FKOrderId { get; set; }
    }
}
