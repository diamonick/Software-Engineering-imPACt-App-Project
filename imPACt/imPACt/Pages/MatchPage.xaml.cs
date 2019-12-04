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
    public partial class MatchPage : ContentPage
    {

        readonly User Mentor1;
        readonly User Mentor2;
        readonly User Mentor3;
        readonly User Mentor4;


        public MatchPage()
        {
            InitializeComponent();

        }

        void HighlightButton(object sender, EventArgs args)
        {
            var Button = (Button)sender;

            if (Button == FirstMatchButton) { FirstMatchButton.BackgroundColor = Color.FromHex("#B9E9F0");
                FirstDeclineButton.BackgroundColor = Color.FromHex("#ff708a");
                FirstDeclineButton.IsEnabled = true;
            }
            else if (Button == SecondMatchButton) { SecondMatchButton.BackgroundColor = Color.FromHex("#B9E9F0");
                SecondDeclineButton.BackgroundColor = Color.FromHex("#ff708a");
                SecondDeclineButton.IsEnabled = true;
            }
            else if (Button == ThirdMatchButton) { ThirdMatchButton.BackgroundColor = Color.FromHex("#B9E9F0");
                ThirdDeclineButton.BackgroundColor = Color.FromHex("#ff708a");
                ThirdDeclineButton.IsEnabled = true;
            }
            else if (Button == FourthMatchButton) { FourthMatchButton.BackgroundColor = Color.FromHex("#B9E9F0");
                FourthDeclineButton.BackgroundColor = Color.FromHex("#ff708a");
                FourthDeclineButton.IsEnabled = true;
            }
            else if (Button == FifthMatchButton) { FifthMatchButton.BackgroundColor = Color.FromHex("#B9E9F0");
                FifthDeclineButton.BackgroundColor = Color.FromHex("#ff708a");
                FifthDeclineButton.IsEnabled = true;
            }



            if (Button == FirstDeclineButton) { FirstDeclineButton.BackgroundColor = Color.FromHex("#ffc2cd");
                FirstMatchButton.BackgroundColor = Color.FromHex("#08B3C9");
                FirstDeclineButton.IsEnabled = false;
            }
            else if (Button == SecondDeclineButton) { SecondDeclineButton.BackgroundColor = Color.FromHex("#ffc2cd");
                SecondMatchButton.BackgroundColor = Color.FromHex("#08B3C9");
                SecondDeclineButton.IsEnabled = false;
            }
            else if (Button == ThirdDeclineButton) { ThirdDeclineButton.BackgroundColor = Color.FromHex("#ffc2cd");
                ThirdMatchButton.BackgroundColor = Color.FromHex("#08B3C9");
                ThirdDeclineButton.IsEnabled = false;
            }
            else if (Button == FourthDeclineButton) { FourthDeclineButton.BackgroundColor = Color.FromHex("#ffc2cd");
                FourthMatchButton.BackgroundColor = Color.FromHex("#08B3C9");
                FourthDeclineButton.IsEnabled = false;
            }
            else if (Button == FifthDeclineButton) { FifthDeclineButton.BackgroundColor = Color.FromHex("#ffc2cd");
                FifthMatchButton.BackgroundColor = Color.FromHex("#08B3C9");
                FifthDeclineButton.IsEnabled = false;
            }
        }

        void EnableMatchedTag(object sender, EventArgs args)
        {
            var Button = (Button)sender;

            if (Button == FirstMatchButton)
            {
                firstMatchTagBackground.IsVisible = true;
                firstMatchTagLabel.IsVisible = true;
            }
            else if (Button == SecondMatchButton)
            {
                secondMatchTagBackground.IsVisible = true;
                secondMatchTagLabel.IsVisible = true;
            }
            else if (Button == ThirdMatchButton)
            {
                thirdMatchTagBackground.IsVisible = true;
                thirdMatchTagLabel.IsVisible = true;
            }
            else if (Button == FourthMatchButton)
            {
                fourthMatchTagBackground.IsVisible = true;
                fourthMatchTagLabel.IsVisible = true;
            }
            else if (Button == FifthMatchButton)
            {
                fifthMatchTagBackground.IsVisible = true;
                fifthMatchTagLabel.IsVisible = true;
            }
        }

        void DisableMatchedTag(object sender, EventArgs args)
        {
            var Button = (Button)sender;

            if (Button == FirstDeclineButton)
            {
                firstMatchTagBackground.IsVisible = false;
                firstMatchTagLabel.IsVisible = false;
            }
            else if (Button == SecondDeclineButton)
            {
                secondMatchTagBackground.IsVisible = false;
                secondMatchTagLabel.IsVisible = false;
            }
            else if (Button == ThirdDeclineButton)
            {
                thirdMatchTagBackground.IsVisible = false;
                thirdMatchTagLabel.IsVisible = false;
            }
            else if (Button == FourthDeclineButton)
            {
                fourthMatchTagBackground.IsVisible = false;
                fourthMatchTagLabel.IsVisible = false;
            }
            else if (Button == FifthDeclineButton)
            {
                fifthMatchTagBackground.IsVisible = false;
                fifthMatchTagLabel.IsVisible = false;
            }
        }


        async void GoToMentorPage(object sender, EventArgs args)
        {
            var imageButton = (ImageButton)sender;

            if (imageButton == MentorProfile1) { await Navigation.PushAsync(new MentorProfilePage(Mentor1)); }
            else if (imageButton == MentorProfile2) { await Navigation.PushAsync(new MentorProfilePage(Mentor2)); }
            else if (imageButton == MentorProfile3) { await Navigation.PushAsync(new MentorProfilePage(Mentor3)); }
            else if (imageButton == MentorProfile4) { await Navigation.PushAsync(new MentorProfilePage(Mentor4)); }
            else if (imageButton == MentorProfile5) { await Navigation.PushAsync(new MentorProfilePage(Mentor4)); }
        }
    }
}
