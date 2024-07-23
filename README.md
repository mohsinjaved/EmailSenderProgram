# Overview
This console application is designed to send different types of emails, such as welcome emails and comeback emails, using an SMTP email service, it is designed in a flexible manner so that it would be easy to add further types of emails.
The application includes functionalities for rendering email templates, making it easy to manage and customize the email content.
Built with extensibility and maintainability in mind, the application is built in accordance with SOLID principles.

## Features
-	**Send Emails**: Send different types of customized emails (Like Welcome email, Comeback Email).
-	**Template Rendering**: Utilize templating for dynamic and rich content creation.
-	**SMTP Email Service**: Configurable SMTP service for sending emails.
-	**Extensible Architecture**: Easily add new types of email senders.
## Main Components
  **Email Senders**
-	**ComebackEmailSender.c**: Handles sending "Comeback" emails.
-	**WelcomeEmailSender.cs**: Handles sending "Welcome" emails.
  **Base Email Sender**
-	**BaseEmailSender.cs**: Abstract class providing common email-sending functionality.
  **Email Sender Factory**
-	**EmailSenderFactory.cs**: Factory class for creating instances of specific email senders based on the email type.
  **SMTP Email Service**
-	**SmtpEmailService.cs**: Responsible to send smtp emails.
  **Template Service**
-	TemplateService.cs: Service for rendering dynamic contents.
 **Program Entry Point**
-	**Program.cs**: The main entry point of the application, setting up dependencies and executing the email sending logic.

# Setup and Usage
## Prerequisites
-	**.NET Framework 4.5**
-	**SMTP server details** (host, port, username, password)
- **Configuration**
Before running the application, configure the SMTP server details in app.config file or you can enable “IsDebugMode” to just log the emails on console.
Running the Application
- 1.	Clone the repository.
- 2.	Open the project in your preferred IDE.
- 3.	Build the project.
- 4.	Run the application.
## Things to Improve
-	**Enhanced Logging**: Integrate with a logging framework (e.g., Serilog) for better logging behaviour.
-	**Dependency Injection**: Using built in services to inject dependency.
-	**Email Saving**: Keeping record of emails sent and failed.
-	**Retry Mechanism**: Adding a service for retry failed email.


