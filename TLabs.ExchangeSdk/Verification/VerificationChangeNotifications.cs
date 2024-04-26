namespace Stock.Verification.Models
{
    public class VerificationChangeNotifications
    {
        public bool Enabled { get; set; } = false;
        public string Queue { get; set; }
        public bool OnVerificationUserStatusChange { get; set; } = false;
        public bool OnVerificationCardStatusChange { get; set; } = false;
    }
}
