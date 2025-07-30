using System.Text;


namespace AutomationTesting.Utils;


public class Config
{
    public string? Url { get; set; }
    public string? Browser { get; set; }
     public CredentialData? Credentials { get; set; }
}

 public class CredentialData
    {
        public string? Username { get; set; }
        public string? Password { get; set; }
    }

