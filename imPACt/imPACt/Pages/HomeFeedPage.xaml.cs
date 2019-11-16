using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Xamarin.Essentials;

namespace imPACt.Pages
{
    public partial class HomeFeedPage : MasterDetailPage
    {
        private const double PressedSize = 1.1;                     //Size of button when pressed
        private Color ActiveColor = Color.FromRgb(0, 179, 176);
        private Color InactiveColor = Color.FromRgb(0, 45, 48);

        public HomeFeedPage()
        {
            InitializeComponent();

            HomeNode.IsVisible = false;
            MatchNode.IsVisible = false;
            ContactsNode.IsVisible = false;
            SettingsNode.IsVisible = false;

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

            button.BackgroundColor = ActiveColor;

            if (button == HomeButton)
            {
                HomeNode.IsVisible = true;
                MatchNode.IsVisible = false;
                ContactsNode.IsVisible = false;
                SettingsNode.IsVisible = false;

                MatchButton.BackgroundColor = InactiveColor;
                ContactsButton.BackgroundColor = InactiveColor;
                SettingsButton.BackgroundColor = InactiveColor;

                Detail = new NavigationPage(new HomePage());
            }
            else if (button == MatchButton)
            {
                HomeNode.IsVisible = false;
                MatchNode.IsVisible = true;
                ContactsNode.IsVisible = false;
                SettingsNode.IsVisible = false;

                HomeButton.BackgroundColor = InactiveColor;
                ContactsButton.BackgroundColor = InactiveColor;
                SettingsButton.BackgroundColor = InactiveColor;

                Detail = new NavigationPage(new MatchPage());
            }
            else if (button == ContactsButton)
            {
                HomeNode.IsVisible = false;
                MatchNode.IsVisible = false;
                ContactsNode.IsVisible = true;
                SettingsNode.IsVisible = false;

                HomeButton.BackgroundColor = InactiveColor;
                MatchButton.BackgroundColor = InactiveColor;
                SettingsButton.BackgroundColor = InactiveColor;

                Detail = new NavigationPage(new ContactsPage());
            }
            else if (button == SettingsButton)
            {
                HomeNode.IsVisible = false;
                MatchNode.IsVisible = false;
                ContactsNode.IsVisible = false;
                SettingsNode.IsVisible = true;

                HomeButton.BackgroundColor = InactiveColor;
                MatchButton.BackgroundColor = InactiveColor;
                ContactsButton.BackgroundColor = InactiveColor;

                Detail = new NavigationPage(new SettingsPage());
            }

            IsPresented = false;
        }

        //Go to the user's profile page
        void GoToProfilePage(object sender, EventArgs args)
        {
            var imageButton = (ImageButton)sender;

            Detail = new NavigationPage(new UserProfilePage());
            IsPresented = false;
        }
    }
}
