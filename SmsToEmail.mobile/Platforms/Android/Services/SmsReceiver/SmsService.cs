using Android.App;
using Android.Content;
using Android.OS;

namespace SmsToEmail.mobile.Platforms.Android.Services.SmsReceiver
{
    [Service]
    public class SmsService : Service
    {
        public const int SERVICE_RUNNING_NOTIFICATION_ID = 10001;
        public override IBinder OnBind(Intent intent)
        {
            return null;
        }

        public override StartCommandResult OnStartCommand(Intent intent, StartCommandFlags flags, int startId)
        {
            Notification notification = new NotificationHelper().GetServiceStartedNotification();
            StartForeground(SERVICE_RUNNING_NOTIFICATION_ID, notification);

            var smsListener = new SmsListener();
            var smsFilter = new
                IntentFilter("android.provider.Telephony.SMS_RECEIVED")
                {
                    Priority =
                        (int)IntentFilterPriority.HighPriority
                };
            RegisterReceiver(smsListener, smsFilter);
            return base.OnStartCommand(intent, flags, startId);
        }


    }
}
