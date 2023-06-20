namespace SmsToEmail.mobile;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
	}

    protected override async void OnAppearing()
    {
        await Permissions.RequestAsync<Permissions.Sms>();

    }
}
