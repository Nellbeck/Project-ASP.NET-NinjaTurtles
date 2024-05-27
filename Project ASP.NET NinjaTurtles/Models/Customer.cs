using Microsoft.Extensions.DependencyModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Project_ASP.NET_NinjaTurtles.Models
{
    public class Customer
    {
        [Key]
        [DisplayName("Customer ID")]
        public Guid CustomerId { get; set; }
        [Required]
        [StringLength(maximumLength: 60, MinimumLength =5)]
        [DisplayName("Name")]
        public string CustomerName { get; set; }
        [Required]
        [StringLength(120)]
        [DisplayName("Email")]
        public string CustomerEmail { get; set; }
        [Required]
        [StringLength(20)]
        [DisplayName("Phone")]
        public string CustomerPhone { get; set; }
        [Required]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        [DisplayName("Birth date")]
        public DateTime CustomerBirthDate { get; set; }
        [Required]
        [StringLength(50)]
        [DisplayName("Address")]
        public string CustomerAddress {  get; set; }
        [Required]
        [Range(0,100000)]
        [DisplayName("Zip")]
        public int CustomerZipCode { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [DisplayName("Orders")]
        public ICollection<Order>? Orders { get; set; }
    }
}
