using System;
using MessageniusSample.Views;
using MessageniusSDK;
using Prism.Commands;
using Prism.Navigation;

namespace MessageniusSample.ViewModels
{
    public class InitilizeViewModel : ViewModelBase
    {
        public DelegateCommand InitTappedCommand => new DelegateCommand(Init);

        private readonly Messagenius _messagenius;

        public InitilizeViewModel(INavigationService navigationService, Messagenius messagenius) : base(navigationService)
        {
            Title = "INIT";
            _messagenius = messagenius;
        }

        public override void Initialize(INavigationParameters parameters)
        {
            base.Initialize(parameters);

            ApplicationId = "mess-smarthub-of";
            Server = "https://chatdcpdmz.enel.com:443/api/lite-v1/";
            WindowsKey = "";
        }

        private string _applicationId;
        public string ApplicationId
        {
            get { return _applicationId; }
            set { SetProperty(ref _applicationId, value); }
        }

        private string _server;
        public string Server
        {
            get { return _server; }
            set { SetProperty(ref _server, value); }
        }

        private string _windowsKey;
        public string WindowsKey
        {
            get { return _windowsKey; }
            set { SetProperty(ref _windowsKey, value); }
        }

        private void Init()
        {
            _messagenius.Init(ApplicationId,Server,WindowsKey);
            NavigationService.NavigateAsync($"{nameof(LoginPage)}");
        }

    }
}
