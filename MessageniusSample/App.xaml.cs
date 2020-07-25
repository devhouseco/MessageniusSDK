using MessageniusSample.ViewModels;
using MessageniusSample.Views;
using MessageniusSDK;
using Prism;
using Prism.Ioc;
using Xamarin.Forms;

namespace MessageniusSample
{
    public partial class App
    {
        public App() : this(null) { }

        public App(IPlatformInitializer initializer) : base(initializer) { }

        protected override void OnInitialized()
        {
            InitializeComponent();
            NavigationService.NavigateAsync($"{nameof(NavigationPage)}/{nameof(InitilizePage)}");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterInstance(Messagenius.Current);
            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<LoginPage, LoginViewModel>();
            containerRegistry.RegisterForNavigation<SignupPage, SignupViewModel>();
            containerRegistry.RegisterForNavigation<MainPage, MainViewModel>();
            containerRegistry.RegisterForNavigation<InitilizePage, InitilizeViewModel>();
            containerRegistry.RegisterForNavigation<OFSendEventPage, OFSendEventViewModel>();
            containerRegistry.RegisterForNavigation<OFSendPositionPage, OFSendPositionViewModel>();
            containerRegistry.RegisterForNavigation<OFCheckinStatusPage, OFCheckinStatusViewModel>();
            containerRegistry.RegisterForNavigation<OFRegisterTokenPage, OFRegisterTokenViewModel>();
            containerRegistry.RegisterForNavigation<OFUnregisterTokenPage, OFUnregisterTokenViewModel>();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
