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
        User mentor;
        Event eventpost;

        public EventPage(User u, Event e)
        {
            InitializeComponent();
            this.mentor = u;
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

        }

        async void GoToMentorPage(object sender, EventArgs args)
        {
            await Navigation.PushAsync(new MentorProfilePage(this.mentor));
        }
    }
}
