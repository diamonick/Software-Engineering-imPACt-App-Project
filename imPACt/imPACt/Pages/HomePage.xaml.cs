using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace imPACt.Pages
{

    public partial class HomePage : ContentPage
    {
        private const double PressedSize = 1.1;                     //Size of button when pressed
        List<string> Words = new List<string>
        { "" };

        public HomePage()
        {
            InitializeComponent();
        }

        async void PressedEvent(object sender, EventArgs args)
        {
            await FirstPost.ScaleTo(PressedSize, 200, Easing.SinOut);
        }

        async void GoToEventPage(object sender, EventArgs args)
        {
            await FirstPost.ScaleTo(1.0, 200, Easing.SinOut);
            await Navigation.PushAsync(new EventPage());
        }

        async void GoToMentorPage(object sender, EventArgs args)
        {
            await Navigation.PushAsync(new MentorProfilePage());
        }
    }
}
