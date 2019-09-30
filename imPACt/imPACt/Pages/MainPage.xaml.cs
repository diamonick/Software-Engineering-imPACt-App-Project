using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace imPACt.Pages
{

    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        private const double PressedSize = 1.1;
        private const double RO_FontSize = 24.0;
        private const double RO_ButtonWidth = 120.0;
        private int CurrentNote = 1;


        public MainPage()
        {
            InitializeComponent();

        }

        async void HighlightSkipButton(object sender, EventArgs args)
        {
            SkipButton.TextColor = Color.FromRgb(200, 200, 200);
            SkipButton.BackgroundColor = Color.FromRgb(0, 85, 92);
            await SkipButton.ScaleTo(PressedSize, 200, Easing.SinOut);
        }


        async void SkipToLogin(object sender, EventArgs args)
        {
            SkipButton.TextColor = Color.FromRgb(255, 255, 255);
            SkipButton.BackgroundColor = Color.FromHex("#00858F");
            await SkipButton.ScaleTo(1.0, 200, Easing.SinOut);
            await Navigation.PushAsync(new ChooseSignInPage());
        }

        async void HighlightNextButton(object sender, EventArgs args)
        {
            NextButton.TextColor = Color.FromRgb(200, 200, 200);
            NextButton.BackgroundColor = Color.FromRgb(0, 85, 92);
            await NextButton.ScaleTo(PressedSize, 200, Easing.SinOut);
        }
        
        async void NextNote(object sender, EventArgs args)
        {
            NextButton.TextColor = Color.FromRgb(255, 255, 255);
            NextButton.BackgroundColor = Color.FromHex("#00858F");
            await NextButton.ScaleTo(1.0, 200, Easing.SinOut);

            if (CurrentNote == 3)
            {
                await Navigation.PushAsync(new ChooseSignInPage());
                return;
            }

            //Execute note transition (if user hasn't reached to the third and last note)
            await NoteTransition(CurrentNote);
        }

        async Task NoteTransition(int Note)
        {
            if (CurrentNote == 1)
            {
                NoteIcon.FadeTo(0.0, 500, Easing.Linear);
                await Introduction_Note.FadeTo(0.0, 500, Easing.Linear);
                CurrentNote++;
                Introduction_Note.Text = "Exchange information with researchers and mentors from your institute and others!";
                NoteIcon.Source = "LS_PAC_MODELS_Icon2.png";
                NoteIcon.FadeTo(1.0, 500, Easing.Linear);
                CheckNotes();
                await Introduction_Note.FadeTo(1.0, 500, Easing.Linear);
            }
            else
            {
                NoteIcon.FadeTo(0.0, 500, Easing.Linear);
                await Introduction_Note.FadeTo(0.0, 500, Easing.Linear);
                CurrentNote++;
                Introduction_Note.Text = "Find collaborators for your current grant!";
                NoteIcon.Source = "LS_PAC_MODELS_Icon3.png";
                NextButton.Text = "Get Started";
                NoteIcon.FadeTo(1.0, 500, Easing.Linear);
                CheckNotes();
                await Introduction_Note.FadeTo(1.0, 500, Easing.Linear);
            }
        }

        void CheckNotes()
        {
            Color OnNote_Col = Color.FromHex("#00858F");
            Color OutNote_Col = Color.FromHex("#FFE780");

            First_Note.BackgroundColor = (CurrentNote == 1 ? OnNote_Col : OutNote_Col);
            Second_Note.BackgroundColor = (CurrentNote == 2 ? OnNote_Col : OutNote_Col);
            Third_Note.BackgroundColor = (CurrentNote == 3 ? OnNote_Col : OutNote_Col);
        }
    }
}
