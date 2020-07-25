using System;
using Acr.UserDialogs;
using MessageniusSDK;
using Prism.Commands;
using Prism.Navigation;
using Prism.Services;

namespace MessageniusSample.ViewModels
{
    public class OFSendPositionViewModel : ViewModelBase
    {
        public DelegateCommand SendPositionTappedCommand => new DelegateCommand(SendPosition);

        private readonly Messagenius _messagenius;
        private readonly IPageDialogService _pageDialogService;

        public OFSendPositionViewModel(INavigationService navigationService, Messagenius messagenius, IPageDialogService pageDialogService) : base(navigationService)
        {
            Title = "Send Position";
            _messagenius = messagenius;
            _pageDialogService = pageDialogService;
        }

        public override void Initialize(INavigationParameters parameters)
        {
            base.Initialize(parameters);

            Order = "T_ORDER_154515";
            RoomId = "T_ORDER_154515_AA";
            Latitude = 44.89;
            Longitude = 12.10;
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

        private double _latitude;
        public double Latitude
        {
            get { return _latitude; }
            set { SetProperty(ref _latitude, value); }
        }

        private double _longitude;
        public double Longitude
        {
            get { return _longitude; }
            set { SetProperty(ref _longitude, value); }
        }

        private void SendPosition()
        {
            try
            {
                Xamarin.Forms.Device.BeginInvokeOnMainThread(() => UserDialogs.Instance.ShowLoading("Wait"));
                var result = _messagenius.OFSendPosition(Order,RoomId,Latitude,Longitude);
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
