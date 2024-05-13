using Microsoft.Extensions.DependencyModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Project_ASP.NET_NinjaTurtles.Models
{
    public class Customer
    {
        [Key]
        public Guid CustomerId { get; set; }
        [Required]
        [StringLength(maximumLength: 60, MinimumLength =5)]
        public string CustomerName { get; set; }
        [Required]
        [StringLength(120)]
        public string CustomerEmail { get; set; }
        [Required]
        [StringLength(20)]
        public string CustomerPhone { get; set; }
        [Required]
        [DisplayFormat(DataFormatString = "{0:dd/MM/YY}", ApplyFormatInEditMode = true)]
        public DateTime CustomerBirthDate { get; set; }
        [Required]
        [StringLength(50)]
        public string Address {  get; set; }
        [Required]
        [Range(0,100000)]
        public int ZipCode { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public ICollection<Order>? Orders { get; set; }
    }
}
