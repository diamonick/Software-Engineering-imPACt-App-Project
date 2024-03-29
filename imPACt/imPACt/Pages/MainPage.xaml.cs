﻿using System;
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
        private const double PressedSize = 1.1;     //Size of button when pressed
        private int CurrentNote = 1;                //Current Note


        public MainPage()
        {
            InitializeComponent();

        }

        //Highlight the button to let the user know it's pressed
        async void HighlightButton(object sender, EventArgs args)
        {
            var button = (Button)sender;

            button.TextColor = Color.FromRgb(200, 200, 200);
            button.BackgroundColor = Color.FromRgb(0, 85, 92);
            await button.ScaleTo(PressedSize, 200, Easing.SinOut);
        }

        //Skip the introduction and send user straight to the login page
        async void SkipToLogin(object sender, EventArgs args)
        {
            SkipButton.TextColor = Color.FromRgb(255, 255, 255);
            SkipButton.BackgroundColor = Color.FromHex("#00858F");
            await SkipButton.ScaleTo(1.0, 200, Easing.SinOut);
            await Navigation.PushAsync(new SignInPage());
        }

        //Go to the next note of the introduction page
        async void NextNote(object sender, EventArgs args)
        {
            NextButton.TextColor = Color.FromRgb(255, 255, 255);
            NextButton.BackgroundColor = Color.FromHex("#00858F");
            await NextButton.ScaleTo(1.0, 200, Easing.SinOut);

            //If user is on the third note, send user to login page
            //(ignores all code below this code block)
            if (CurrentNote == 3)
            {
                await Navigation.PushAsync(new SignInPage());
                return;
            }

            //Execute note transition (if user hasn't reached to the third and last note)
            await NoteTransition(CurrentNote);
        }

        //Execute a fade in/fade out transition when user moves to next note
        async Task NoteTransition(int Note)
        {
            if (CurrentNote == 1)
            {
                NoteIcon.FadeTo(0.0, 500, Easing.Linear);
                await Introduction_Note.FadeTo(0.0, 500, Easing.Linear);
                CurrentNote++;
                Introduction_Note.Text = "Exchange information with\nresearchers and mentors from your\ninstitute and others!";
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
                Introduction_Note.Text = "Join workshops, events, and seminars\nled by mentors you match with!";
                NoteIcon.Source = "LS_PAC_MODELS_Icon3.png";
                NextButton.Text = "Get Started";
                NoteIcon.FadeTo(1.0, 500, Easing.Linear);
                CheckNotes();
                await Introduction_Note.FadeTo(1.0, 500, Easing.Linear);
            }
        }

        //Assign the correct color to all note points to indicate which note the user is on
        void CheckNotes()
        {
            Color OnNote_Col = Color.FromHex("#00858F");    //Color for current note
            Color OutNote_Col = Color.FromHex("#FFE780");   //Color for nonactive note

            First_Note.BackgroundColor = (CurrentNote == 1 ? OnNote_Col : OutNote_Col);
            Second_Note.BackgroundColor = (CurrentNote == 2 ? OnNote_Col : OutNote_Col);
            Third_Note.BackgroundColor = (CurrentNote == 3 ? OnNote_Col : OutNote_Col);
        }
    }
}
