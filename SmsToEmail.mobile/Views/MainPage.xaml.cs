namespace SmsToEmail.mobile.Views;

public partial class MainPage : ContentPage
{
    private readonly MainViewModel _viewModel;
	public MainPage(MainViewModel mainViewModel)
	{
		InitializeComponent();
        BindingContext = _viewModel = mainViewModel;
        Routing.RegisterRoute(nameof(ConfigurationPage), typeof(ConfigurationPage));
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        _viewModel.OnAppearing();
    }
}