using System;
using Acr.UserDialogs;
using MessageniusSDK;
using Prism.Commands;
using Prism.Navigation;
using Prism.Services;

namespace MessageniusSample.ViewModels
{
    public class OFUnregisterTokenViewModel : ViewModelBase
    {
        public DelegateCommand UnregisterTokenTappedCommand => new DelegateCommand(UnregisterToken);

        private readonly Messagenius _messagenius;
        private readonly IPageDialogService _pageDialogService;

        public OFUnregisterTokenViewModel(INavigationService navigationService, Messagenius messagenius, IPageDialogService pageDialogService) : base(navigationService)
        {
            Title = "Unregister Token";
            _messagenius = messagenius;
            _pageDialogService = pageDialogService;
        }

        public override void Initialize(INavigationParameters parameters)
        {
            base.Initialize(parameters);

            Username = "test2";
        }

        private string _username;
        public string Username
        {
            get { return _username; }
            set { SetProperty(ref _username, value); }
        }

        private void UnregisterToken()
        {
            try
            {
                Xamarin.Forms.Device.BeginInvokeOnMainThread(() => UserDialogs.Instance.ShowLoading("Wait"));
                var result = _messagenius.OFUnregisterToken(Username);
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
