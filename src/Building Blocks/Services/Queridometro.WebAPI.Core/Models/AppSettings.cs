namespace Queridometro.WebAPI.Core.Models
{
    public class AppSettings
    {
        public string Secret { get; set; }
        public int ExpirationHours { get; set; }
        public string Origin { get; set; }
        public string ValidAt { get; set; }
    }
}
