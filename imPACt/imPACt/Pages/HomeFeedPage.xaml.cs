using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace imPACt.Pages
{
    public partial class HomeFeedPage : MasterDetailPage
    {
        private const double PressedSize = 1.1;                     //Size of button when pressed

        public HomeFeedPage()
        {
            InitializeComponent();

            Detail = new NavigationPage(new HomePage());
            IsPresented = false;
            this.IsPresentedChanged += OnPresentedChanged;
        }

        async private void OnPresentedChanged(object sender, EventArgs args)
        {
            if (this.IsPresented)
            {
                await ForegroundLayer.FadeTo(0.5, 100, Easing.CubicOut);
            }
            else
            {
                await ForegroundLayer.FadeTo(0.0, 100, Easing.CubicOut);
            }
        }

        //Highlight the button to let the user know it's pressed
        void HighlightDetailButton(object sender, EventArgs args)
        {
            var button = (Button)sender;

            button.BackgroundColor = Color.FromRgb(0, 133, 143);
        }

        //Go to the page you selected from Master Page
        void GoToSpecifiedPage(object sender, EventArgs args)
        {
            var button = (Button)sender;

            button.BackgroundColor = Color.FromRgb(0, 45, 48);

            if (button == HomeButton)
            {
                Detail = new NavigationPage(new HomePage());
            }
            else if (button == ContactsButton)
            {
                Detail = new NavigationPage(new ContactsPage());
            }
            else if (button == SettingsButton)
            {
                Detail = new NavigationPage(new SettingsPage());
            }

            IsPresented = false;
        }
    }
}
