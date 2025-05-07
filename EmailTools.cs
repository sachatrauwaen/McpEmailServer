using Microsoft.Extensions.Options;
using ModelContextProtocol.Server;
using System.ComponentModel;
using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;

namespace McpEmailServer;

[McpServerToolType]
public static class EmailTools
{
    [McpServerTool, Description("Sends an email using the configured SMTP server.")]
    public static async Task<string> SendEmail(
        IMcpServer thisServer,
        SmtpClient smtpClient,
        SmtpSettings settings,
        [Description("Recipient email address")] string to,
        [Description("Email subject")] string subject,
        [Description("Email body")] string body,
        CancellationToken cancellationToken)
    {
        try
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("MCP Server", settings.Username));
            message.To.Add(new MailboxAddress("", to));
            message.Subject = subject;
            
            var bodyBuilder = new BodyBuilder
            {
                TextBody = body
            };
            message.Body = bodyBuilder.ToMessageBody();

            await smtpClient.ConnectAsync(settings.Server, settings.Port, SecureSocketOptions.Auto, cancellationToken);
            await smtpClient.AuthenticateAsync(settings.Username, settings.Password, cancellationToken);
            await smtpClient.SendAsync(message, cancellationToken);
            await smtpClient.DisconnectAsync(true, cancellationToken);

            return "Email sent successfully!";
        }
        catch (Exception ex)
        {
            return $"Error sending email: {ex.Message}";
        }
    }

    [McpServerTool, Description("Sends an HTML email using the configured SMTP server.")]
    public static async Task<string> SendHtmlEmail(
        IMcpServer thisServer,
        SmtpClient smtpClient,
        SmtpSettings settings,
        [Description("Recipient email address")] string to,
        [Description("Email subject")] string subject,
        [Description("HTML email body")] string htmlBody,
        CancellationToken cancellationToken)
    {
        try
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("MCP Server", settings.Username));
            message.To.Add(new MailboxAddress("", to));
            message.Subject = subject;
            
            var bodyBuilder = new BodyBuilder
            {
                HtmlBody = htmlBody
            };
            message.Body = bodyBuilder.ToMessageBody();

            await smtpClient.ConnectAsync(settings.Server, settings.Port, SecureSocketOptions.Auto, cancellationToken);
            await smtpClient.AuthenticateAsync(settings.Username, settings.Password, cancellationToken);
            await smtpClient.SendAsync(message, cancellationToken);
            await smtpClient.DisconnectAsync(true, cancellationToken);

            return "HTML email sent successfully!";
        }
        catch (Exception ex)
        {
            return $"Error sending HTML email: {ex.Message}";
        }
    }
} 