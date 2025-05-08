namespace McpEmailServer;

public class SmtpSettings
{
    public string Server { get; set; } = "localhost";
    public int Port { get; set; } = 25;
    public string Username { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;

    public string From { get; set; } = string.Empty;
}
