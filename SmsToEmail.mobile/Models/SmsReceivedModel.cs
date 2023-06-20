namespace SmsToEmail.mobile.Models
{
    public class SmsReceivedModel : EventArgs
    {
        public string PhoneNumber { get; set; }

        public string Message { get; set; }
    }
}
