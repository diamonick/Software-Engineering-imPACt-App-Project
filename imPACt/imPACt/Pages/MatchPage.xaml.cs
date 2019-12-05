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
    public partial class MatchPage : CarouselPage
    {
        readonly User newUser;
        User Mentor1;
        User Mentor2;
        User Mentor3;
        User Mentor4;
        private const double PressedSize = 1.1;                     //Size of button when pressed
        private bool MatchRunning = true;
        private bool AbleToClickProfile = false;
        private const string MentorEmail1 = "qsharp56@lsu.edu";
        private const string MentorEmail2 = "srift17@lsu.edu";
        private const string MentorEmail3 = "foconnor24@lsu.edu";
        private const string MentorEmail4 = "elogg23@lsu.edu";


        public MatchPage(User u)
        {
            InitializeComponent();
            this.newUser = u;

            LoadMentors();

            Matching();
            SpinLoadingAnimation();
            EndMatch();

        }

        //Load available mentors from database
        async void LoadMentors()
        {
            Mentor1 = await App.Database.GetUserByEmail(MentorEmail1);
            Mentor2 = await App.Database.GetUserByEmail(MentorEmail2);
            Mentor3 = await App.Database.GetUserByEmail(MentorEmail3);
            Mentor4 = await App.Database.GetUserByEmail(MentorEmail4);
        }

        async Task SpinLoadingAnimation()
        {
            while(true)
            {
                await LoadIcon.RotateTo(360.0, 2000);
                LoadIcon.Rotation = 0.0;
            }
        }

        async Task Matching()
        {
            await Task.Delay(1000);

            MatchText.FadeTo(1.0, 1500, Easing.Linear);
            LoadIcon.FadeTo(1.0, 1500, Easing.Linear);
            MenteeProfile.TranslateTo(0, 0, 1500, Easing.SinOut);
            MentorProfile.TranslateTo(0, 0, 1500, Easing.SinOut);

            while (MatchRunning)
            {
                if (MatchText.Text.Length > 11) { MatchText.Text = "Matching"; }
                MatchText.Text = MatchText.Text + ".";
                await Task.Delay(500);
            }
        }

        async Task EndMatch()
        {
            await Task.Delay(6000);
            MatchRunning = false;

            LoadIcon.FadeTo(0.0, 500, Easing.Linear);
            MatchText.FadeTo(0.0, 500, Easing.Linear);
            ItsAMatch.FadeTo(1.0, 500, Easing.Linear);
            SmallText.FadeTo(1.0, 500, Easing.Linear);
            await MentorProfile.RotateYTo(90.0, 500, Easing.Linear);
            MentorProfilePhoto.Source = Mentor1.ProfilePhoto;
            await MentorProfile.RotateYTo(0.0, 500, Easing.Linear);

            await Task.Delay(500);

            RequestButton.TranslateTo(75, 0, 500, Easing.SinOut);
            await SwipeButton.TranslateTo(-75, 0, 500, Easing.SinOut);

            MentorProfilePhoto.IsEnabled = true;
            AbleToClickProfile = true;
            Mail1.IsVisible = true;
        }

        void HighlightButton(object sender, EventArgs args)
        {
            var imageButton = (ImageButton)sender;

            imageButton.ScaleTo(PressedSize, 200, Easing.SinOut);
        }

        async void SendRequest(object sender, EventArgs args)
        {
            var imageButton = (ImageButton)sender;

            await imageButton.ScaleTo(1.0, 200, Easing.SinOut);

            if (CurrentPage == FirstMatch) { await Mail1.TranslateTo(200.0, 0.0, 1000, Easing.Linear); }
            else if (CurrentPage == SecondMatch) { await Mail2.TranslateTo(200.0, 0.0, 1000, Easing.Linear); }
            else if (CurrentPage == ThirdMatch) { await Mail3.TranslateTo(200.0, 0.0, 1000, Easing.Linear); }
            else if (CurrentPage == FourthMatch) { await Mail4.TranslateTo(200.0, 0.0, 1000, Easing.Linear); }
            await DisplayAlert("Request Sent", "A request has been sent to your potential mentor.", "OK");

            await Navigation.PopAsync();
        }

        async void SwipeLeft(object sender, EventArgs args)
        {
            var imageButton = (ImageButton)sender;

            await imageButton.ScaleTo(1.0, 200, Easing.SinOut);

            if (CurrentPage == FirstMatch) { CurrentPage = SecondMatch; }
            else if (CurrentPage == SecondMatch) { CurrentPage = ThirdMatch; }
            else if (CurrentPage == ThirdMatch) { CurrentPage = FourthMatch; }
            else if (CurrentPage == FourthMatch) { await Navigation.PopAsync(); }
        }

        async void CheckMentorProfile(object sender, EventArgs args)
        {
            var imageButton = (ImageButton)sender;

            if (AbleToClickProfile)
            {
                if (imageButton == MentorProfilePhoto) { await Navigation.PushAsync(new MentorProfilePage(this.newUser, this.Mentor1)); }
                else if (imageButton == MentorProfilePhoto2) { await Navigation.PushAsync(new MentorProfilePage(this.newUser, this.Mentor2)); }
                else if (imageButton == MentorProfilePhoto3) { await Navigation.PushAsync(new MentorProfilePage(this.newUser, this.Mentor3)); }
                else if (imageButton == MentorProfilePhoto4) { await Navigation.PushAsync(new MentorProfilePage(this.newUser, this.Mentor4)); }
            }
        }
    }
}
