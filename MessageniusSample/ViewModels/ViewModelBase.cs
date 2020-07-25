using System;
using Prism.Mvvm;
using Prism.Navigation;

namespace MessageniusSample.ViewModels
{
    public class ViewModelBase : BindableBase, IInitialize, INavigationAware, IDestructible
    {
        private readonly INavigationService _navigationService;
        private string _title;

        public ViewModelBase(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        public INavigationService NavigationService => _navigationService;

        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        public virtual void Destroy() { }

        public virtual void Initialize(INavigationParameters parameters) { }

        public virtual void OnNavigatedFrom(INavigationParameters parameters) { }

        public virtual void OnNavigatedTo(INavigationParameters parameters) { }
    }
}
