using Project_ASP.NET_NinjaTurtles.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project_ASP.NET_NinjaTurtles.Models
{
    public class OrderProduct
    {
        [Key]
        public Guid OrderProductId { get; set; }


        [ForeignKey("Product")]
        public Guid FKProductId { get; set; }
        public Product Product { get; set; } = null!;


        [ForeignKey("Order")]
        public Guid FKOrderId { get; set; }
        public Order Order { get; set; } = null!;

    }
}
