using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MessageniusSample.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : MasterDetailPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        async void TapGestureRecognizer_Tapped(System.Object sender, System.EventArgs e)
        {
            if(sender is StackLayout stackLayout)
            {
                await stackLayout.FadeTo(0, 100, Easing.SpringIn);
                await stackLayout.FadeTo(1, 100, Easing.SinInOut);
            }
        }
    }
}
