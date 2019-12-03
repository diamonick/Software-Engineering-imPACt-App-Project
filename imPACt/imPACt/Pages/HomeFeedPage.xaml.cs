using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using imPACt.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SQLite;

namespace imPACt.Pages
{
    public partial class HomeFeedPage : MasterDetailPage
    {
        User newUser;
        private const double PressedSize = 1.1;                     //Size of button when pressed
        private Color ActiveColor = Color.FromRgb(0, 179, 176);
        private Color InactiveColor = Color.FromRgb(0, 45, 48);

        public HomeFeedPage(User u)
        {
            InitializeComponent();
            this.newUser = u;

            HomeNode.IsVisible = false;
            MatchNode.IsVisible = false;
            ContactsNode.IsVisible = false;
            SettingsNode.IsVisible = false;

            FullNameText.Text = newUser.Name;

            Detail = new NavigationPage(new HomePage());
            IsPresented = false;
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

            if (button == HomeButton && !HomeNode.IsVisible)
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
            else if (button == MatchButton && !MatchNode.IsVisible)
            {
                HomeNode.IsVisible = false;
                MatchNode.IsVisible = true;
                ContactsNode.IsVisible = false;
                SettingsNode.IsVisible = false;

                HomeButton.BackgroundColor = InactiveColor;
                ContactsButton.BackgroundColor = InactiveColor;
                SettingsButton.BackgroundColor = InactiveColor;

                Detail = new NavigationPage(new UserInterestsPage());
            }
            else if (button == ContactsButton && !ContactsNode.IsVisible)
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
            else if (button == SettingsButton && !SettingsNode.IsVisible)
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

            HomeNode.IsVisible = false;
            MatchNode.IsVisible = false;
            ContactsNode.IsVisible = false;
            SettingsNode.IsVisible = false;

            HomeButton.BackgroundColor = InactiveColor;
            MatchButton.BackgroundColor = InactiveColor;
            ContactsButton.BackgroundColor = InactiveColor;
            SettingsButton.BackgroundColor = InactiveColor;

            Detail = new NavigationPage(new UserProfilePage(this.newUser));
            IsPresented = false;
        }
    }
}
