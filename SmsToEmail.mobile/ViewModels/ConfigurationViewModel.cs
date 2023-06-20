﻿using SmsToEmail.mobile.Helpers;

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
            if (string.IsNullOrWhiteSpace(_email)) return false;

            return true;
        }



        public void LoadValues()
        {
            Email = Preferences.Get(AppConstants.ConfigurationModel, String.Empty);
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
            
        }
    }
}