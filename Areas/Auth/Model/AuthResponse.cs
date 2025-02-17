namespace OkeMotor.Areas.Auth.Model
{
    public class AuthResponse
    {
        public bool Success { get; set; }
        public string Token { get; set; }
        public List<string> Errors { get; set; }
    }
}
