using SmsToEmail.mobile.Helpers.Constants;
using SmsToEmail.mobile.Services.Interfaces;

namespace SmsToEmail.mobile.ViewModels;

public partial class MainViewModel : BaseViewModel
{
    private readonly ISmsToEmailService _smsToEmailManager;
    [ObservableProperty] private bool _isServiceRunning;
    [ObservableProperty] private bool _isServiceConfigured;

    public MainViewModel(ISmsToEmailService smsToEmailManager)
    {
        _smsToEmailManager = smsToEmailManager;
        
    }
    
    [RelayCommand]
    private async void NavigateToConfiguration()
    {
        await Shell.Current.GoToAsync("ConfigurationPage");
    }

    [RelayCommand]
    private void ToggleService()
    {
        
        if (IsServiceRunning)
            _smsToEmailManager.Stop();
        else
            _smsToEmailManager.Start();
        IsServiceRunning = Preferences.Get(AppConstants.SmsToEmailServiceRunning, false);
    }

    [RelayCommand]
    private void StopService()
    {
        _smsToEmailManager.Stop();
    }

    public void OnAppearing()
    {
        IsServiceRunning = Preferences.Get(AppConstants.SmsToEmailServiceRunning, false);
        IsServiceConfigured = Preferences.Get(AppConstants.ServiceConfigured, false);
    }
}
