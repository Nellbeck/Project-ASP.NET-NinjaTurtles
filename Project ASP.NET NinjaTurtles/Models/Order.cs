using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project_ASP.NET_NinjaTurtles.Models
{
    public class Order
    {
        [Key]
        public Guid OrderId { get; set; }
        [ForeignKey("Customer")]
        public Guid FKCustomerId {  get; set; }
        public Customer? Customer { get; set; }
        [ForeignKey("Product")]
        public Guid FKProductId { get; set; }
        public ICollection<Product>? Product { get; set; }
        public DateTime OrderDate { get; set; }

    }
}
