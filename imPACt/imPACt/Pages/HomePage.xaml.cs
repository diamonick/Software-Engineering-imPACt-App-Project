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

    public partial class HomePage : ContentPage
    {
        private const double PressedSize = 1.1;                     //Size of button when pressed
        User newUser;
        User Mentor1;
        User Mentor2;
        User Mentor3;
        User Mentor4;
        Event Event1;
        Event Event2;
        Event Event3;
        Event Event4;
        private const string MentorEmail1 = "qsharp56@lsu.edu";
        private const string MentorEmail2 = "srift17@lsu.edu";
        private const string MentorEmail3 = "foconnor24@lsu.edu";
        private const string MentorEmail4 = "elogg23@lsu.edu";
        private const string EventKeyword1 = "C#";
        private const string EventKeyword2 = "VirtualReality";
        private const string EventKeyword3 = "GGJ";
        private const string EventKeyword4 = "Testing";

        List<string> Words = new List<string>
        { "" };

        public HomePage(User u)
        {
            InitializeComponent();

            this.newUser = u;
            LoadMentors();
            LoadEvents();
        }

        //Load available mentors from database
        async void LoadMentors()
        {
            Mentor1 = await App.Database.GetUserByEmail(MentorEmail1);
            Mentor2 = await App.Database.GetUserByEmail(MentorEmail2);
            Mentor3 = await App.Database.GetUserByEmail(MentorEmail3);
            Mentor4 = await App.Database.GetUserByEmail(MentorEmail4);
        }

        //Load available event from database
        async void LoadEvents()
        {
            Event1 = await App.Database.GetEventByKeyword(EventKeyword1);
            Event2 = await App.Database.GetEventByKeyword(EventKeyword2);
            Event3 = await App.Database.GetEventByKeyword(EventKeyword3);
            Event4 = await App.Database.GetEventByKeyword(EventKeyword4);
        }

        async void PressedEvent(object sender, EventArgs args)
        {
            var button = (Button)sender;

            if (button == FirstPostButton) { await FirstPost.ScaleTo(PressedSize, 200, Easing.SinOut); }
            else if (button == SecondPostButton) { await SecondPost.ScaleTo(PressedSize, 200, Easing.SinOut); }
            else if (button == ThirdPostButton) { await ThirdPost.ScaleTo(PressedSize, 200, Easing.SinOut); }
            else if (button == FourthPostButton) { await FourthPost.ScaleTo(PressedSize, 200, Easing.SinOut); }
            else if (button == FifthPostButton) { await FifthPost.ScaleTo(PressedSize, 200, Easing.SinOut); }
        }

        async void GoToEventPage(object sender, EventArgs args)
        {
            var button = (Button)sender;

            if (button == FirstPostButton)
            {
                await FirstPost.ScaleTo(1.0, 200, Easing.SinOut);
                await Navigation.PushAsync(new EventPage(newUser, Mentor1, Event1));
            }
            else if (button == SecondPostButton)
            {
                await SecondPost.ScaleTo(1.0, 200, Easing.SinOut);
                await Navigation.PushAsync(new EventPage(newUser, Mentor2, Event2));
            }
            else if (button == ThirdPostButton)
            {
                await ThirdPost.ScaleTo(1.0, 200, Easing.SinOut);
                await Navigation.PushAsync(new EventPage(newUser, Mentor3, Event3));
            }
            else if (button == FourthPostButton)
            {
                await FourthPost.ScaleTo(1.0, 200, Easing.SinOut);
                await Navigation.PushAsync(new EventPage(newUser, Mentor4, Event4));
            }
            else if (button == FifthPostButton)
            {
                await FifthPost.ScaleTo(1.0, 200, Easing.SinOut);
                await Navigation.PushAsync(new EventPage(newUser, Mentor4, Event1));
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
