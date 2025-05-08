using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using ModelContextProtocol.Server;
using MailKit.Net.Smtp;
using Microsoft.Extensions.Configuration;
using McpEmailServer;

var builder = Host.CreateApplicationBuilder(args);
builder.Logging.AddConsole(consoleLogOptions =>
{
    consoleLogOptions.LogToStandardErrorThreshold = LogLevel.Trace;
});

builder.Configuration.AddEnvironmentVariables();

SmtpSettings config = LoadConfiguration(builder.Configuration);

builder.Services.AddSingleton(config);

builder.Services.AddSingleton<SmtpClient>();

builder.Services
    .AddMcpServer()
    .WithStdioServerTransport()
    .WithToolsFromAssembly();

await builder.Build().RunAsync();

static SmtpSettings LoadConfiguration(IConfiguration configuration)
{
    return new SmtpSettings
    {
        Server = configuration["SMTP_SERVER"] ?? "loacalhost",
        Port = int.TryParse(configuration["SMTP_PORT"], out var port) ? port : 25,
        Username = configuration["SMTP_USERNAME"] ?? "",
        Password = configuration["SMTP_PASSWORD"] ?? "",
        From = configuration["FROM_EMAIL"] ?? "email@example.com"
    };
}



