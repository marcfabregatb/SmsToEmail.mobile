using Android.App;
using Android.Content;
using Android.Runtime;
using SmsToEmail.mobile.Helpers;
using SmsToEmail.mobile.Helpers.Events;
using SmsToEmail.mobile.Platforms.Android.Services;
using SmsToEmail.mobile.Platforms.Android.Services.SmsReceiver;

namespace SmsToEmail.mobile;

[Application]
public class MainApplication : MauiApplication
{
	public MainApplication(IntPtr handle, JniHandleOwnership ownership)
		: base(handle, ownership)
	{
	}

	protected override MauiApp CreateMauiApp() => MauiProgram.CreateMauiApp(PlatformSpecificServices);


    static void PlatformSpecificServices(IServiceCollection services)
    {
        services.AddTransient<IAndroidServiceHelper, AndroidServiceHelper>();
    }

    public override void OnCreate()
    {
        base.OnCreate();

        if (Preferences.Get(AppConstants.SmsToEmailServiceRunning, false) == true)
        {
            var serviceHelper = this.Services.GetService<IAndroidServiceHelper>();
            serviceHelper?.StartService();
        }
        SetServiceMethods();
    }
    void SetServiceMethods()
    {
        var serviceHelper = this.Services.GetService<IAndroidServiceHelper>();
        MessagingCenter.Subscribe<StartServiceMessage>(this, "ServiceStarted", message => {
            if (Preferences.Get(AppConstants.ServiceConfigured, false) && !IsServiceRunning(typeof(SmsService)))
            {
                serviceHelper?.StartService();
            }
        });

        MessagingCenter.Subscribe<StopServiceMessage>(this, "ServiceStopped", message => {
            if (IsServiceRunning(typeof(SmsService)))
                serviceHelper?.StopService();
        });
    }
    private bool IsServiceRunning(System.Type cls)
    {
        ActivityManager manager = (ActivityManager)GetSystemService(Context.ActivityService);
        foreach (var service in manager.GetRunningServices(int.MaxValue))
        {
            if (service.Service.ClassName.Equals(Java.Lang.Class.FromType(cls).CanonicalName))
            {
                return true;
            }
        }
        return false;
    }

}
