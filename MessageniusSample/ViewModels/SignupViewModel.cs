using System;
using Acr.UserDialogs;
using MessageniusSample.Views;
using MessageniusSDK;
using Prism.Commands;
using Prism.Navigation;
using Xamarin.Forms;

namespace MessageniusSample.ViewModels
{
    public class SignupViewModel : ViewModelBase
    {
        public DelegateCommand NavigateToLoginPageCommand => new DelegateCommand(() => NavigationService.GoBackAsync());
        public DelegateCommand SignupTappedCommand => new DelegateCommand(SignUp);

        private readonly Messagenius _messagenius;

        public SignupViewModel(INavigationService navigationService, Messagenius messagenius) : base(navigationService)
        {
            Title = "Signup";
            _messagenius = messagenius;
        }

        public override void Initialize(INavigationParameters parameters)
        {
            base.Initialize(parameters);

            Username = "ali123";
            Password = "testing";
        }

        private string _email;
        public string Email
        {
            get { return _email; }
            set { SetProperty(ref _email, value); }
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

        private async void SignUp()
        {
            try
            {
                Device.BeginInvokeOnMainThread(() => UserDialogs.Instance.ShowLoading("Wait"));
                var user =  await _messagenius.SignUpAsync(Username, Email, Password);
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
