namespace SmsToEmail.mobile.Views;

public partial class MainPage : ContentPage
{
	public MainPage(MainViewModel mainViewModel)
	{
		InitializeComponent();
        BindingContext = mainViewModel;
    }
}