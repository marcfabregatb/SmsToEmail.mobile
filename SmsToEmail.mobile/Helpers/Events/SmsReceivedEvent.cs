using SmsToEmail.mobile.Models;

namespace SmsToEmail.mobile.Helpers.Events
{
    public class SmsReceivedEvent
    {
        public static event EventHandler<SmsReceivedModel> OnSmsReceived;
        public static void OnSMSReceived_Event(object sender, SmsReceivedModel sms)
        {
            OnSmsReceived?.Invoke(sender, sms);
        }
    }
}
