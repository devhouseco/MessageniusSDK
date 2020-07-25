using System;
using System.Collections.Generic;
using MessageniusSample.Models;
using MessageniusSample.Views;
using MessageniusSDK;
using Prism.Commands;
using Prism.Navigation;

namespace MessageniusSample.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private readonly Messagenius _messagenius;

        public DelegateCommand<MenuItem> MenuItemTappedCommand => new DelegateCommand<MenuItem>(NavigateToPage);

        private void NavigateToPage(MenuItem menuItem)
        {
            if(menuItem != null && menuItem.ItemName != "Logout")
            {
                NavigationService.NavigateAsync($"{nameof(Xamarin.Forms.NavigationPage)}/{menuItem.PageName}");
            }
            else
            {
                _messagenius.LogOut();
                NavigationService.NavigateAsync($"/{nameof(Xamarin.Forms.NavigationPage)}/{nameof(InitilizePage)}");
            }
        }

        public List<MenuItem> MenuItems { get; set; }

        public MainViewModel(INavigationService navigationService, Messagenius messagenius) : base(navigationService)
        {
            _messagenius = messagenius;
            MenuItems = new List<MenuItem>
            {
                new MenuItem { ItemName = "Send Event" , PageName = nameof(OFSendEventPage) },
                new MenuItem { ItemName = "Send Position" , PageName = nameof(OFSendPositionPage) },
                new MenuItem { ItemName = "Checkin Status" , PageName = nameof(OFCheckinStatusPage) },
                new MenuItem { ItemName = "Register Token" , PageName = nameof(OFRegisterTokenPage) },
                new MenuItem { ItemName = "Unregister Token" , PageName = nameof(OFUnregisterTokenPage) },
                new MenuItem { ItemName = "Logout" }
            };
        }
    }
}
