namespace SmsToEmail.mobile.Views;

public partial class ConfigurationPage : ContentPage
{
    private readonly ConfigurationViewModel _viewModel;

    public ConfigurationPage(ConfigurationViewModel configurationViewModel)
	{
		InitializeComponent();
        BindingContext = _viewModel = configurationViewModel;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        _viewModel.OnAppearing();
    }
}