namespace OkeMotor.Models.Entities
{
    public class Motor:BaseModel
    {
        public string Brand { get; set; }
        public string Type { get; set; }
        public string Name { get; set; }
        public string PoliceNumber { get; set; }
        public string Quality { get; set; }
        public Motor() { }
    }
}
