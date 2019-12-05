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
    public partial class EventPage : ContentPage
    {
        User newUser;
        User mentor;
        Event eventpost;
        private const double PressedSize = 1.1;                     //Size of button when pressed
        private bool IsInterested = false;
        private const string MentorEmail1 = "qsharp56@lsu.edu";
        private const string MentorEmail2 = "srift17@lsu.edu";
        private const string MentorEmail3 = "foconnor24@lsu.edu";
        private const string MentorEmail4 = "elogg23@lsu.edu";

        public EventPage(User u, User m, Event e)
        {
            InitializeComponent();
            this.newUser = u;
            this.mentor = m;
            this.eventpost = e;

            ProfilePic.Source = mentor.ProfilePhoto;
            TopMentorName.Text = mentor.Name;
            MentorName.Text = mentor.Name;
            EventTitle.Text = eventpost.Title;
            EventType.Text = eventpost.Type;
            EventImage.Source = eventpost.Photo;
            Description.Text = eventpost.Summary;
            DateTime.Text = eventpost.EventDateTime;
            Location.Text = eventpost.Location;

            if (eventpost.Type.ToLower() == "workshop") { EventTypeTag.BackgroundColor = Color.FromHex("#FFAF00"); }
            else if (eventpost.Type.ToLower() == "seminar") { EventTypeTag.BackgroundColor = Color.FromHex("#00DE12"); }
            else if (eventpost.Type.ToLower() == "event") { EventTypeTag.BackgroundColor = Color.FromHex("#0084FF"); }

            ConfirmInterested(this.mentor.Email);
        }

        void HighlightButton(object sender, EventArgs args)
        {
            InterestedButton.TextColor = Color.FromRgb(200, 200, 200);
            InterestedButton.BackgroundColor = (IsInterested ? Color.FromRgb(0, 85, 92) : Color.FromHex("#181818"));
            InterestedField.ScaleTo(PressedSize, 200, Easing.SinOut);
        }

        async void InterestedClicked(object sender, EventArgs args)
        {
            await InterestedField.ScaleTo(1.0, 200, Easing.SinOut);

            IsInterested = !IsInterested;

            InterestedButton.Text = (IsInterested ? "You are registered!" : "Interested?");
            InterestedButton.BackgroundColor = (IsInterested ? Color.FromHex("#00CFB3") : Color.FromHex("#303030"));
            InterestedButton.TextColor = Color.White;
            if (IsInterested) { await Checkmark.FadeTo(1.0, 200, Easing.Linear); }
            else { await Checkmark.FadeTo(0.0, 200, Easing.Linear); }

            if (this.mentor.Email == MentorEmail1) { this.newUser.InterestedInEvents[0] = !(this.newUser.InterestedInEvents[0]); }
            else if (this.mentor.Email == MentorEmail2) { this.newUser.InterestedInEvents[1] = !(this.newUser.InterestedInEvents[1]); }
            else if (this.mentor.Email == MentorEmail3) { this.newUser.InterestedInEvents[2] = !(this.newUser.InterestedInEvents[2]); }
            else if (this.mentor.Email == MentorEmail4) { this.newUser.InterestedInEvents[3] = !(this.newUser.InterestedInEvents[3]); }
        }

        void ConfirmInterested(string email)
        {
            if (this.mentor.Email == MentorEmail1) { IsInterested = this.newUser.InterestedInEvents[0]; }
            if (this.mentor.Email == MentorEmail2) { IsInterested = this.newUser.InterestedInEvents[1]; }
            if (this.mentor.Email == MentorEmail3) { IsInterested = this.newUser.InterestedInEvents[2]; }
            if (this.mentor.Email == MentorEmail4) { IsInterested = this.newUser.InterestedInEvents[3]; }

            InterestedButton.Text = (IsInterested ? "You are registered!" : "Interested?");
            InterestedButton.BackgroundColor = (IsInterested ? Color.FromHex("#00CFB3") : Color.FromHex("#303030"));
            InterestedButton.TextColor = Color.White;

            Checkmark.Opacity = (IsInterested ? 1.0 : 0.0);
        }

        async void GoToMentorPage(object sender, EventArgs args)
        {
            await Navigation.PushAsync(new MentorProfilePage(this.newUser, this.mentor));
        }
    }
}
