using System.Net.Mail;
using SmsToEmail.mobile.Helpers.Constants;
using SmsToEmail.mobile.Models;
using SmsToEmail.mobile.Services.Interfaces;

namespace SmsToEmail.mobile.Services
{
    public class SendEmailService : ISendEmailService
    {
        public void SendEmail(SmsReceivedModel smsEventArgs)
        {

            var email = Preferences.Get(AppConstants.Configuration_Email, String.Empty);
            var sslEnabled = Preferences.Get(AppConstants.Configuration_SslEnabled, false);
            var smtpHost = Preferences.Get(AppConstants.Configuration_SmtpHost, String.Empty);
            var port = Preferences.Get(AppConstants.Configuration_Port, 0);
            var secondaryPort = Preferences.Get(AppConstants.Configuration_SecondaryPort, 0);
            var user = Preferences.Get(AppConstants.Configuration_User, String.Empty);
            var password = Preferences.Get(AppConstants.Configuration_Password, String.Empty);
            
            var emailMessage = new MailMessage();
            var smtpServer = new SmtpClient(smtpHost);

            emailMessage.From = new MailAddress(user);
            emailMessage.To.Add(email);
            emailMessage.Subject = "forwarded SMS";
            emailMessage.Body = $"{smsEventArgs.PhoneNumber} - {smsEventArgs.Message}";

            smtpServer.EnableSsl = sslEnabled;
            smtpServer.Port = port;
            smtpServer.UseDefaultCredentials = false;
            smtpServer.Credentials = new System.Net.NetworkCredential(user, password);

            smtpServer.Send(emailMessage);
        }
    }
}
