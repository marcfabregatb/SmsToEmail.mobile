using SmsToEmail.mobile.Services.Interfaces;

namespace SmsToEmail.mobile.ViewModels;

public partial class MainViewModel : BaseViewModel
{
    private readonly ISmsToEmailService _smsToEmailManager;
    [ObservableProperty] private bool _startServiceButtonVisible;
    [ObservableProperty] private bool _stopServiceButtonVisible;

    public MainViewModel(ISmsToEmailService smsToEmailManager)
    {
        _smsToEmailManager = smsToEmailManager;

        StartServiceButtonVisible = true;
        StopServiceButtonVisible = false;
    }
    
    [RelayCommand]
    private void NavigateToConfiguration()
    {
        Shell.Current.GoToAsync("ConfigurationPage");
    }

    [RelayCommand]
    private void ToggleService()
    {
        _smsToEmailManager.Start();
    }

    [RelayCommand]
    private void StopService()
    {
        _smsToEmailManager.Stop();
    }
}
