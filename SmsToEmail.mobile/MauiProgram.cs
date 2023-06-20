using SmsToEmail.mobile.Services;
using SmsToEmail.mobile.Services.Interfaces;

namespace SmsToEmail.mobile;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp(Action<IServiceCollection> addPlatformServices = null)
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.UseMauiCommunityToolkit()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("FontAwesome6FreeBrands.otf", "FontAwesomeBrands");
				fonts.AddFont("FontAwesome6FreeRegular.otf", "FontAwesomeRegular");
				fonts.AddFont("FontAwesome6FreeSolid.otf", "FontAwesomeSolid");
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

        // Add platform specific services
        addPlatformServices?.Invoke(builder.Services);

        builder.Services.AddTransient<ISmsToEmailService, SmsToEmailService>();
        builder.Services.AddTransient<ISendEmailService, SendEmailService>();

        builder.Services.AddSingleton<BlankViewModel>();

		builder.Services.AddSingleton<BlankPage>();

		// TODO: Add App Center secrets
		AppCenter.Start(
			"windowsdesktop={Your Windows App secret here};" +
			"android={Your Android App secret here};" +
			"ios={Your iOS App secret here};" +
			"macos={Your macOS App secret here};",
			typeof(Analytics), typeof(Crashes));

		return builder.Build();
	}
}
