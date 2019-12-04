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
        public MentorProfilePage(User u)
        {
            InitializeComponent();
            this.newUser = u;

            //Clears all the user's interests
            this.newUser.Interests.Clear();

            FullNameText.Text = newUser.Name;
            Description.Text = newUser.Description;
            ProfilePic.Source = newUser.ProfilePhoto;

            if (this.newUser.Email == MentorEmail1)
            {
                this.newUser.Interests.Add("InterestsIcons-01.png");
                this.newUser.Interests.Add("InterestsIcons-04.png");
                this.newUser.Interests.Add("InterestsIcons-06.png");
                this.newUser.Interests.Add("InterestsIcons-09.png");
                this.newUser.Interests.Add("InterestsIcons-15.png");
            }
            else if (this.newUser.Email == MentorEmail2)
            {
                this.newUser.Interests.Add("InterestsIcons-02.png");
                this.newUser.Interests.Add("InterestsIcons-05.png");
                this.newUser.Interests.Add("InterestsIcons-06.png");
                this.newUser.Interests.Add("InterestsIcons-08.png");
                this.newUser.Interests.Add("InterestsIcons-09.png");
            }
            else if (this.newUser.Email == MentorEmail3)
            {
                this.newUser.Interests.Add("InterestsIcons-03.png");
                this.newUser.Interests.Add("InterestsIcons-04.png");
                this.newUser.Interests.Add("InterestsIcons-05.png");
                this.newUser.Interests.Add("InterestsIcons-06.png");
                this.newUser.Interests.Add("InterestsIcons-07.png");
                this.newUser.Interests.Add("InterestsIcons-09.png");
                this.newUser.Interests.Add("InterestsIcons-13.png");
            }
            else if (this.newUser.Email == MentorEmail4)
            {
                this.newUser.Interests.Add("InterestsIcons-01.png");
                this.newUser.Interests.Add("InterestsIcons-04.png");
                this.newUser.Interests.Add("InterestsIcons-09.png");
                this.newUser.Interests.Add("InterestsIcons-10.png");
                this.newUser.Interests.Add("InterestsIcons-11.png");
            }

            int InterestIndex = 0;

            foreach (string S in newUser.Interests)
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
        }
    }
}
