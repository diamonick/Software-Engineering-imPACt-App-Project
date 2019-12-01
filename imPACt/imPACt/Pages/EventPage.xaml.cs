using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace imPACt.Pages
{
    public partial class EventPage : ContentPage
    {
        public EventPage()
        {
            InitializeComponent();
        }

        async void GoToMentorPage(object sender, EventArgs args)
        {
            await Navigation.PushAsync(new MentorProfilePage());
        }
    }
}
