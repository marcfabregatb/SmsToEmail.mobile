using SmsToEmail.mobile.Models;

namespace SmsToEmail.mobile.Services.Interfaces
{
    public interface ISendEmailService
    {
        void SendEmail(SmsReceivedModel smsEventArgs);
    }
}
