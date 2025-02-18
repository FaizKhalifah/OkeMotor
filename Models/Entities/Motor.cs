using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OkeMotor.Models.Entities
{
    public class Motor:BaseModel
    {
        public string Brand { get; set; }
        public string Type { get; set; }
        public string Name { get; set; }
        public string PoliceNumber { get; set; }
        public string Quality { get; set; }
        public decimal Price { get; set; }

        [Required]
        public string SellerId { get; set; }

        [ForeignKey("SellerId")]
        public ApplicationUser Seller { get; set; }
        public Motor() { }
    }
}
