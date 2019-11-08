using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace imPACt.Pages
{
    public partial class FeedPage : ContentPage
    {

        private const double PressedSize = 1.1;                     //Size of button when pressed
        private int NumOfInterests = 0; 
        private const int MaxNumOfInterests = 15;

        public FeedPage()
        {
            InitializeComponent();
        }

        async void HighlightButton(object sender, EventArgs args)
        {
            var imageButton = (ImageButton)sender;

            await imageButton.ScaleTo(PressedSize, 200, Easing.SinOut);
        }

        async void SelectCategory(object sender, EventArgs args)
        {
            var imageButton = (ImageButton)sender;

            
            await imageButton.ScaleTo(1.0, 200, Easing.SinOut);
        }
    }
}
