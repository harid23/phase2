using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CaseStudy_Quitq.Models;

namespace CaseStudy_Quitq.Models
{
    public class Seller
    {
        [Key]
        public int SellerId { get; set; }

        [Required]
        public string SellerName { get; set; }

      
        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public User? User { get; set; }
        public string? Contact { get; set; }

        public string CompanyName { get; set; }

        [MaxLength(100)]
        public string SellerAddress { get; set; }

        public string SellerCity { get; set; }

    }
}
