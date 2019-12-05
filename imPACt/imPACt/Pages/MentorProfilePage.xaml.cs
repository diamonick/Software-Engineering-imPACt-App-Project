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
    public partial class MentorProfilePage : ContentPage
    {
        private const double PressedSize = 1.1;                     //Size of button when pressed
        private bool IsFollowing = false;
        private const string MentorEmail1 = "qsharp56@lsu.edu";
        private const string MentorEmail2 = "srift17@lsu.edu";
        private const string MentorEmail3 = "foconnor24@lsu.edu";
        private const string MentorEmail4 = "elogg23@lsu.edu";
        private string[] InterestSource =
        {
            "InterestsIcons-01.png",
            "InterestsIcons-02.png",
            "InterestsIcons-03.png",
            "InterestsIcons-04.png",
            "InterestsIcons-05.png",
            "InterestsIcons-06.png",
            "InterestsIcons-07.png",
            "InterestsIcons-08.png",
            "InterestsIcons-09.png",
            "InterestsIcons-10.png",
            "InterestsIcons-11.png",
            "InterestsIcons-12.png",
            "InterestsIcons-13.png",
            "InterestsIcons-14.png",
            "InterestsIcons-15.png",
        };

        User newUser;
        User mentor;
        public MentorProfilePage(User u, User m)
        {
            InitializeComponent();
            this.newUser = u;
            this.mentor = m;

            //Clears all the user's interests
            this.mentor.Interests.Clear();

            FullNameText.Text = mentor.Name;
            Description.Text = mentor.Description;
            ProfilePic.Source = mentor.ProfilePhoto;

            if (this.mentor.Email == MentorEmail1)
            {
                this.mentor.Interests.Add("InterestsIcons-01.png");
                this.mentor.Interests.Add("InterestsIcons-04.png");
                this.mentor.Interests.Add("InterestsIcons-06.png");
                this.mentor.Interests.Add("InterestsIcons-09.png");
                this.mentor.Interests.Add("InterestsIcons-15.png");
            }
            else if (this.mentor.Email == MentorEmail2)
            {
                this.mentor.Interests.Add("InterestsIcons-02.png");
                this.mentor.Interests.Add("InterestsIcons-05.png");
                this.mentor.Interests.Add("InterestsIcons-06.png");
                this.mentor.Interests.Add("InterestsIcons-08.png");
                this.mentor.Interests.Add("InterestsIcons-09.png");
            }
            else if (this.mentor.Email == MentorEmail3)
            {
                this.mentor.Interests.Add("InterestsIcons-03.png");
                this.mentor.Interests.Add("InterestsIcons-04.png");
                this.mentor.Interests.Add("InterestsIcons-05.png");
                this.mentor.Interests.Add("InterestsIcons-06.png");
                this.mentor.Interests.Add("InterestsIcons-07.png");
                this.mentor.Interests.Add("InterestsIcons-09.png");
                this.mentor.Interests.Add("InterestsIcons-13.png");
            }
            else if (this.mentor.Email == MentorEmail4)
            {
                this.mentor.Interests.Add("InterestsIcons-01.png");
                this.mentor.Interests.Add("InterestsIcons-04.png");
                this.mentor.Interests.Add("InterestsIcons-09.png");
                this.mentor.Interests.Add("InterestsIcons-10.png");
                this.mentor.Interests.Add("InterestsIcons-11.png");
            }

            int InterestIndex = 0;

            foreach (string S in mentor.Interests)
            {
                while (!S.Equals(InterestSource[InterestIndex]))
                {
                    InterestIndex++;
                    if (InterestIndex >= 15) { return; }
                }

                if (Tab1.Source.IsEmpty) { Tab1.Source = (string)S; }
                else if (Tab2.Source.IsEmpty) { Tab2.Source = (string)S; }
                else if (Tab3.Source.IsEmpty) { Tab3.Source = (string)S; }
                else if (Tab4.Source.IsEmpty) { Tab4.Source = (string)S; }
                else if (Tab5.Source.IsEmpty) { Tab5.Source = (string)S; }
                else if (Tab6.Source.IsEmpty) { Tab6.Source = (string)S; }
                else if (Tab7.Source.IsEmpty) { Tab7.Source = (string)S; }
                else if (Tab8.Source.IsEmpty) { Tab8.Source = (string)S; }
                else if (Tab9.Source.IsEmpty) { Tab9.Source = (string)S; }
                else if (Tab10.Source.IsEmpty) { Tab10.Source = (string)S; }
                else if (Tab11.Source.IsEmpty) { Tab11.Source = (string)S; }
                else if (Tab12.Source.IsEmpty) { Tab12.Source = (string)S; }
                else if (Tab13.Source.IsEmpty) { Tab13.Source = (string)S; }
                else if (Tab14.Source.IsEmpty) { Tab14.Source = (string)S; }
                else if (Tab15.Source.IsEmpty) { Tab15.Source = (string)S; }
            }

            ConfirmFollowing(this.mentor.Email);
        }

        void HighlightButton(object sender, EventArgs args)
        {
            FollowButton.TextColor = Color.FromRgb(200, 200, 200);
            FollowButton.BackgroundColor = (IsFollowing ? Color.FromRgb(0, 85, 92) : Color.FromHex("#181818"));
            FollowField.ScaleTo(PressedSize, 200, Easing.SinOut);
        }

        async void FollowClicked(object sender, EventArgs args)
        {
            await FollowField.ScaleTo(1.0, 200, Easing.SinOut);

            IsFollowing = !IsFollowing;

            FollowButton.Text = (IsFollowing ? "Following" : "Follow");
            FollowButton.BackgroundColor = (IsFollowing ? Color.FromHex("#00CFB3") : Color.FromHex("#303030"));
            FollowButton.TextColor = Color.White;
            if (IsFollowing) { await Checkmark.FadeTo(1.0, 200, Easing.Linear); }
            else { await Checkmark.FadeTo(0.0, 200, Easing.Linear); }

            if (this.mentor.Email == MentorEmail1) { this.newUser.FollowingMentor[0] = !(this.newUser.FollowingMentor[0]); }
            else if (this.mentor.Email == MentorEmail2) { this.newUser.FollowingMentor[1] = !(this.newUser.FollowingMentor[1]); }
            else if (this.mentor.Email == MentorEmail3) { this.newUser.FollowingMentor[2] = !(this.newUser.FollowingMentor[2]); }
            else if (this.mentor.Email == MentorEmail4) { this.newUser.FollowingMentor[3] = !(this.newUser.FollowingMentor[3]); }

            //await App.Database.SaveUserAsync(this.mentor);
        }

        void ConfirmFollowing(string email)
        {
            if (this.mentor.Email == MentorEmail1) { IsFollowing = this.newUser.FollowingMentor[0]; }
            if (this.mentor.Email == MentorEmail2) { IsFollowing = this.newUser.FollowingMentor[1]; }
            if (this.mentor.Email == MentorEmail3) { IsFollowing = this.newUser.FollowingMentor[2]; }
            if (this.mentor.Email == MentorEmail4) { IsFollowing = this.newUser.FollowingMentor[3]; }

            FollowButton.Text = (IsFollowing ? "Following" : "Follow");
            FollowButton.BackgroundColor = (IsFollowing ? Color.FromHex("#00CFB3") : Color.FromHex("#303030"));
            FollowButton.TextColor = Color.White;

            Checkmark.Opacity = (IsFollowing ? 1.0 : 0.0);
        }
    }
}
