using System;
using Acr.UserDialogs;
using MessageniusSample.Views;
using MessageniusSDK;
using Prism.Commands;
using Prism.Navigation;
using Xamarin.Forms;

namespace MessageniusSample.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {
        public DelegateCommand NavigateToSignupPageCommand => new DelegateCommand(() => NavigationService.NavigateAsync($"{nameof(SignupPage)}"));
        public DelegateCommand LoginTappedCommand => new DelegateCommand(Login);

        private readonly Messagenius _messagenius;

        public LoginViewModel(INavigationService navigationService, Messagenius messagenius) : base(navigationService)
        {
            Title = "Login";
            _messagenius = messagenius;

            Username = "ali123";
            Password = "testing";
        }

        private string _username;
        public string Username
        {
            get { return _username; }
            set { SetProperty(ref _username, value); }
        }

        private string _password;
        public string Password
        {
            get { return _password; }
            set { SetProperty(ref _password, value); }
        }

        private async void Login()
        {
            try
            {
                Device.BeginInvokeOnMainThread(() => UserDialogs.Instance.ShowLoading("Wait"));
                var user = await _messagenius.LoginAsync(Username, Password);
                if (user != null)
                {
                    Device.BeginInvokeOnMainThread(() => UserDialogs.Instance.HideLoading());
                    await NavigationService.NavigateAsync($"/{nameof(MainPage)}/{nameof(Xamarin.Forms.NavigationPage)}/{nameof(OFSendEventPage)}");
                }
            }
            catch (Exception ex)
            {
                Device.BeginInvokeOnMainThread(() => UserDialogs.Instance.HideLoading());
                UserDialogs.Instance.Toast(new ToastConfig(ex.Message.ToUpper())
                {
                    BackgroundColor = Color.FromHex("#30336b"),
                    MessageTextColor = Color.White,
                    Position = ToastPosition.Bottom
                });
            }
        }
    }
}
