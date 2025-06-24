using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CaseStudy_Quitq.Models;

namespace CaseStudy_Quitq.Models
{
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }

        [Required]
        public string CustomerName { get; set; } 
        public string UserId { get; set; }
        [ForeignKey("UserId")]
       // public User? User { get; set; }

        public string Phone { get; set; }

        [MaxLength(200)]
        public string Address { get; set; }
        public string CustomerCity {  get; set; }
    }
}
