using CommunityToolkit.Mvvm.Messaging;
using SmsToEmail.mobile.Helpers.Events;
using SmsToEmail.mobile.Models;
using SmsToEmail.mobile.Services.Interfaces;

namespace SmsToEmail.mobile.Services
{
    public class SmsToEmailService : ISmsToEmailService
    {
        private readonly ISendEmailService _sendEmailService;

        public SmsToEmailService(ISendEmailService sendEmailService)
        {
            _sendEmailService = sendEmailService;
        }

        public void Initialize()
        {
            SmsReceivedEvent.OnSmsReceived += OnSmsReceived;
        }

        private void OnSmsReceived(object sender, SmsReceivedModel smsEventArgs)
        {
            _sendEmailService.SendEmail(smsEventArgs);
        }

        public void Start()
        {
            var startServiceMessage = new StartServiceMessage();
            WeakReferenceMessenger.Default.Send(startServiceMessage);
        }

        public void Stop()
        {
            var stopServiceMessage = new StopServiceMessage();
            WeakReferenceMessenger.Default.Send(stopServiceMessage);
        }
    }
}
