﻿using System;
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
        User Mentor1;
        User Mentor2;
        User Mentor3;
        User Mentor4;
        Event Event1;
        Event Event2;
        private const string MentorEmail1 = "qsharp55@lsu.edu";
        private const string MentorEmail2 = "srift16@lsu.edu";
        private const string MentorEmail3 = "foconnor24@lsu.edu";
        private const string MentorEmail4 = "elogg22@lsu.edu";
        private const string EventKeyword1 = "C#";
        private const string EventKeyword2 = "VirtualReality";

        List<string> Words = new List<string>
        { "" };

        public HomePage()
        {
            InitializeComponent();

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
                await Navigation.PushAsync(new EventPage(Mentor1, Event1));
            }
            else if (button == SecondPostButton)
            {
                await SecondPost.ScaleTo(1.0, 200, Easing.SinOut);
                await Navigation.PushAsync(new EventPage(Mentor2, Event2));
            }
            else if (button == ThirdPostButton)
            {
                await ThirdPost.ScaleTo(1.0, 200, Easing.SinOut);
                await Navigation.PushAsync(new EventPage(Mentor3, Event1));
            }
            else if (button == FourthPostButton)
            {
                await FourthPost.ScaleTo(1.0, 200, Easing.SinOut);
                await Navigation.PushAsync(new EventPage(Mentor4, Event1));
            }
            else if (button == FifthPostButton)
            {
                await FifthPost.ScaleTo(1.0, 200, Easing.SinOut);
                await Navigation.PushAsync(new EventPage(Mentor4, Event1));
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
