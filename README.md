# MCP Email Server

A C# Model Context Protocol (MCP) server that provides email sending capabilities using SMTP.

## Prerequisites

- .NET 6.0 or later
- SMTP server credentials (e.g., Gmail, Office 365, or your own SMTP server)

## Setup

1. Clone the repository

2. Set the following environment variables for SMTP configuration:

   - `SMTP_SERVER` (e.g., `smtp.gmail.com`)
   - `SMTP_PORT` (e.g., `587`)
   - `SMTP_USERNAME` (your email address)
   - `SMTP_PASSWORD` (your app password)

Mcp Email Server can be run using the following command:

```json

 "mcp-email-server": {
      "type": "stdio",
      "command": "dotnet",
      "args": ["run", 
              "--project",
              "YOUR_PATH/smtp-dotnet-mcp-server/McpEmailServer.csproj"
            ],
      "env": {       
        "SMTP_SERVER": "localhost",
        "SMTP_PORT": "25",
        "SMTP_USERNAME": "",
        "SMTP_PASSWORD": ""
      }
    }

```
or

```json

 "mcp-email-server": {
      "type": "stdio",
      "command": "cmd",
      "args": ["/c",               
              "YOUR_PATH/smtp-dotnet-mcp-server/McpEmailServer.exe"
            ],
      "env": {       
        "SMTP_SERVER": "localhost",
        "SMTP_PORT": "25",
        "SMTP_USERNAME": "",
        "SMTP_PASSWORD": ""
      }
    }

```


### Gmail Setup (if using Gmail)

If you're using Gmail, you'll need to:
1. Enable 2-Step Verification in your Google Account
2. Generate an App Password:
   - Go to Google Account settings
   - Security
   - 2-Step Verification
   - App passwords
   - Generate a new app password for "Mail"

## Running the Server

```bash
dotnet run
```

## Available Tools

The server provides the following MCP tools:

1. `SendEmail`: Sends a plain text email
   - Parameters:
     - `to`: Recipient email address
     - `subject`: Email subject
     - `body`: Email body text

2. `SendHtmlEmail`: Sends an HTML email
   - Parameters:
     - `to`: Recipient email address
     - `subject`: Email subject
     - `htmlBody`: HTML content for the email body

## Features

- MCP server implementation with stdio transport
- SMTP email sending capabilities
- Support for both plain text and HTML emails
- Dependency injection for SMTP client and settings
- Configurable through appsettings.json
- Proper error handling and logging

## Security Notes

- Never commit your email credentials to source control
- The appsettings.json file should be added to .gitignore
- Use app passwords instead of your main password when possible
- Consider using environment variables or a secure configuration management system in production 

