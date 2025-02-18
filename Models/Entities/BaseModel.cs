using System.ComponentModel.DataAnnotations;

namespace OkeMotor.Models.Entities
{
    public class BaseModel
    {
        [Key]
        public Guid Id { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedDate { get; set; } = DateTime.UtcNow;

        public BaseModel()
        {

        }
    }
}
