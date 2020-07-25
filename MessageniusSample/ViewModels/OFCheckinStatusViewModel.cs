using System;
using Acr.UserDialogs;
using MessageniusSDK;
using Prism.Commands;
using Prism.Navigation;
using Prism.Services;

namespace MessageniusSample.ViewModels
{
    public class OFCheckinStatusViewModel : ViewModelBase
    {
        public DelegateCommand CheckinStatusTappedCommand => new DelegateCommand(CheckinStatus);

        private readonly Messagenius _messagenius;
        private readonly IPageDialogService _pageDialogService;

        public OFCheckinStatusViewModel(INavigationService navigationService, Messagenius messagenius, IPageDialogService pageDialogService) : base(navigationService)
        {
            Title = "Checkin Status";
            _messagenius = messagenius;
            _pageDialogService = pageDialogService;
        }

        public override void Initialize(INavigationParameters parameters)
        {
            base.Initialize(parameters);

            Order = "T_ORDER_154515";
            RoomId = "T_ORDER_154515_AA";
        }

        private string _order;
        public string Order
        {
            get { return _order; }
            set { SetProperty(ref _order, value); }
        }

        private string _roomId;
        public string RoomId
        {
            get { return _roomId; }
            set { SetProperty(ref _roomId, value); }
        }

        private async void CheckinStatus()
        {
            try
            {
                Xamarin.Forms.Device.BeginInvokeOnMainThread(() => UserDialogs.Instance.ShowLoading("Wait"));
                var result = await _messagenius.OFCheckinStatus(Order,RoomId,"sendEvent");
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
