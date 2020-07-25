using System;
using Acr.UserDialogs;
using MessageniusSDK;
using Prism.Commands;
using Prism.Navigation;
using Prism.Services;

namespace MessageniusSample.ViewModels
{
    public class OFRegisterTokenViewModel : ViewModelBase
    {
        public DelegateCommand RegisterTokenTappedCommand => new DelegateCommand(RegisterToken);

        private readonly Messagenius _messagenius;
        private readonly IPageDialogService _pageDialogService;

        public OFRegisterTokenViewModel(INavigationService navigationService, Messagenius messagenius, IPageDialogService pageDialogService) : base(navigationService)
        {
            Title = "Register Token";
            _messagenius = messagenius;
            _pageDialogService = pageDialogService;
        }

        public override void Initialize(INavigationParameters parameters)
        {
            base.Initialize(parameters);

            Token = "22332222-1122333322-223333444-333333";
            Device = "1221213123123131331444";
            Username = "ali123";
        }

        private string _token;
        public string Token
        {
            get { return _token; }
            set { SetProperty(ref _token, value); }
        }

        private string _device;
        public string Device
        {
            get { return _device; }
            set { SetProperty(ref _device, value); }
        }

        private string _username;
        public string Username
        {
            get { return _username; }
            set { SetProperty(ref _username, value); }
        }

        private void RegisterToken()
        {
            try
            {
                Xamarin.Forms.Device.BeginInvokeOnMainThread(() => UserDialogs.Instance.ShowLoading("Wait"));
                var result = _messagenius.OFRegisterToken(Token,Device,Username);
                Xamarin.Forms.Device.BeginInvokeOnMainThread(() => UserDialogs.Instance.HideLoading());
                UserDialogs.Instance.Toast(new ToastConfig("Success")
                {
                    BackgroundColor = Xamarin.Forms.Color.FromHex("#30336b"),
                    MessageTextColor = Xamarin.Forms.Color.White,
                    Position = ToastPosition.Bottom
                });
            }
            catch (Exception ex)
            {
                Xamarin.Forms.Device.BeginInvokeOnMainThread(() => UserDialogs.Instance.HideLoading());
                UserDialogs.Instance.Toast(new ToastConfig(ex.Message.ToUpper())
                {
                    BackgroundColor = Xamarin.Forms.Color.FromHex("#30336b"),
                    MessageTextColor = Xamarin.Forms.Color.White,
                    Position = ToastPosition.Bottom
                });
            }
        }
    }
}
