namespace OkeMotor.Models.DTO
{
    public class MotorDTO:BaseDTO
    {
        public string Brand { get; set; }
        public string Type { get; set; }
        public string Name { get; set; }
        public string PoliceNumber { get; set; }
        public string Quality { get; set; }
        public decimal Price { get; set; }

    }
}
