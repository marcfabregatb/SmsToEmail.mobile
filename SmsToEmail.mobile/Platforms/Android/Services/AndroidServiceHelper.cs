using Android.Content;
using Android.OS;
using SmsToEmail.mobile.Helpers;
using SmsToEmail.mobile.Platforms.Android.Services.SmsReceiver;

namespace SmsToEmail.mobile.Platforms.Android.Services
{

    public interface IAndroidServiceHelper
    {
        void StartService();

        void StopService();
    }

    internal class AndroidServiceHelper : IAndroidServiceHelper
    {
        private static Context context = global::Android.App.Application.Context;

        public void StartService()
        {
            var intent = new Intent(context, typeof(SmsService));

            if (Build.VERSION.SdkInt >= BuildVersionCodes.O)
            {
                _ = context.StartForegroundService(intent);
            }
            else
            {
                context.StartService(intent);
            }
            Preferences.Set(AppConstants.SmsToEmailServiceRunning, true);
        }

        public void StopService()
        {
            var intent = new Intent(context, typeof(SmsService));
            context.StopService(intent);
            Preferences.Set(AppConstants.SmsToEmailServiceRunning, false);
        }
    }
}
