using SmsToEmail.mobile.Helpers.Constants;

namespace SmsToEmail.mobile.ViewModels
{
    public partial class ConfigurationViewModel : BaseViewModel
    {
        [ObservableProperty]
        private bool _customSmtpHost;
        [ObservableProperty]
        private string _email;
        [ObservableProperty]
        private bool _startOnBoot;
        [ObservableProperty]
        private string _smtpHost;
        [ObservableProperty]
        private bool _sslEnabled;
        [ObservableProperty]
        private int _port;
        [ObservableProperty]
        private int _secondaryPort;
        [ObservableProperty]
        private string _user;
        [ObservableProperty]
        private string _password;

        [RelayCommand]
        private void SaveConfiguration()
        {
            if (!ValidateForm()) return;

            SaveValues();

            Preferences.Set(AppConstants.ServiceConfigured, true);
            Shell.Current.GoToAsync("..");
        }

        private bool ValidateForm()
        {
            var isValid = true;
            if (string.IsNullOrWhiteSpace(_email)) isValid = false;
            if (string.IsNullOrWhiteSpace(_smtpHost)) isValid = false;
            if (_port == 0) return false;
            if (string.IsNullOrWhiteSpace(_user)) isValid = false;
            if (string.IsNullOrWhiteSpace(_password)) isValid = false;

            if (!isValid)
            {
                Application.Current.MainPage.DisplayAlert("Error", "Please fill all mandatory fields", "Ok");
                return false;
            
            }
            return true;
        }



        public void LoadValues()
        {
            Email = Preferences.Get(AppConstants.Configuration_Email, String.Empty);
            StartOnBoot = Preferences.Get(AppConstants.Configuration_StartOnBoot, true);
            SslEnabled = Preferences.Get(AppConstants.Configuration_SslEnabled, false);
            SmtpHost = Preferences.Get(AppConstants.Configuration_SmtpHost, String.Empty);
            Port = Preferences.Get(AppConstants.Configuration_Port, 25);
            SecondaryPort = Preferences.Get(AppConstants.Configuration_SecondaryPort, 0);
            User = Preferences.Get(AppConstants.Configuration_User, String.Empty);
            //Password = Preferences.Get(AppConstants.Configuration_Password, String.Empty);
        }

        public void SaveValues()
        {

            Preferences.Set(AppConstants.Configuration_Email, _email);
            Preferences.Set(AppConstants.Configuration_StartOnBoot, _startOnBoot);
            Preferences.Set(AppConstants.Configuration_SslEnabled, _sslEnabled);
            Preferences.Set(AppConstants.Configuration_SmtpHost, _smtpHost);
            Preferences.Set(AppConstants.Configuration_Port, _port);
            Preferences.Set(AppConstants.Configuration_SecondaryPort, _secondaryPort);
            Preferences.Set(AppConstants.Configuration_User, _user);
            if (!string.IsNullOrWhiteSpace(_password))
                Preferences.Set(AppConstants.Configuration_Password, _password);
        }


        public void OnAppearing()
        {
            LoadValues();
        }
    }
}
