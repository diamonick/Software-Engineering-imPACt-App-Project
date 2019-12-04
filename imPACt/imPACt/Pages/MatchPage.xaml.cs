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

            if (Button == FirstMatchButton) { (FirstMatchButton.BackgroundColor = Color.FromHex("#B9E9F0"); }
            else if (Button == SecondMatchButton) { (SecondMatchButton.BackgroundColor = Color.FromHex("#B9E9F0"); }
            else if (Button == ThirdMatchButton) { (ThirdMatchButton.BackgroundColor = Color.FromHex("#B9E9F0"); }
            else if (Button == FourthMatchButton) { FourthMatchButton.BackgroundColor = Color.FromHex("#B9E9F0"); }
            else if (Button == FifthMatchButton) { FifthMatchButton.BackgroundColor = Color.FromHex("#B9E9F0"); }
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
            else if (Button == SecondMatchButton)
            {
                thirdMatchTagBackground.IsVisible = true;
                thirdMatchTagLabel.IsVisible = true;
            }
            else if (Button == SecondMatchButton)
            {
                fourthMatchTagBackground.IsVisible = true;
                fourthMatchTagLabel.IsVisible = true;
            }
            else if (Button == SecondMatchButton)
            {
                fifthMatchTagBackground.IsVisible = true;
                fifthMatchTagLabel.IsVisible = true;
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
