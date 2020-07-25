using System;
using Acr.UserDialogs;
using MessageniusSDK;
using Prism.Commands;
using Prism.Navigation;
using Prism.Services;

namespace MessageniusSample.ViewModels
{
    public class OFSendEventViewModel : ViewModelBase
    {
        public DelegateCommand SendEventTappedCommand => new DelegateCommand(SendEvent);

        private readonly Messagenius _messagenius;
        private readonly IPageDialogService _pageDialogService;

        public OFSendEventViewModel(INavigationService navigationService, Messagenius messagenius , PageDialogService pageDialogService) : base(navigationService)
        {
            Title = "Send Event";
            _messagenius = messagenius;

            _pageDialogService = pageDialogService;
        }

        public override void Initialize(INavigationParameters parameters)
        {
            base.Initialize(parameters);

            Type = "0";
            Order = "T_ORDER_154515";
            RoomId = "T_ORDER_154515_AA";
            LocationEnabled = true;
            EventStartDate = DateTime.Now;
            EventEndDate = DateTime.Now.AddDays(2);
            Username = "ali866";
        }

        private string _type;
        public string Type
        {
            get { return _type; }
            set { SetProperty(ref _type, value); }
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

        private string _username;
        public string Username
        {
            get { return _username; }
            set { SetProperty(ref _username, value); }
        }

        private DateTime _eventStartDate;
        public DateTime EventStartDate
        {
            get { return _eventStartDate; }
            set { SetProperty(ref _eventStartDate, value); }
        }

        private DateTime _eventEndDate;
        public DateTime EventEndDate
        {
            get { return _eventEndDate; }
            set { SetProperty(ref _eventEndDate, value); }
        }

        private bool _locationEnabled;
        public bool LocationEnabled
        {
            get { return _locationEnabled; }
            set { SetProperty(ref _locationEnabled, value); }
        }

        private void SendEvent()
        {
            try
            {
                Xamarin.Forms.Device.BeginInvokeOnMainThread(() => UserDialogs.Instance.ShowLoading("Wait"));
                var startDate = DateTime.SpecifyKind(EventStartDate, DateTimeKind.Utc);
                DateTimeOffset startUtcTime = startDate;

                var endDate = DateTime.SpecifyKind(EventEndDate, DateTimeKind.Utc);
                DateTimeOffset endUtcDate = endDate;

                var result = _messagenius.OFSendEvent(Type, Order, RoomId, LocationEnabled, startUtcTime.ToUnixTimeSeconds(), endUtcDate.ToUnixTimeSeconds(), Username);
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
