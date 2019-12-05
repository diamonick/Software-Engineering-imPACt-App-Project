using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using Xamarin.Forms;
using imPACt.Models;
using imPACt.Data;
using SQLite;
using System.IO;

namespace imPACt.Pages
{
    enum PageLayout { SignUpLayout=1, LogInLayout};

    public partial class SignInPage : ContentPage
    {
        private string PWD = "";                                    //String from Password entry
        private string ConfirmPWD = "";                             //String from Confirm Password entry
        private const string Checkmark = "checkmark.png";           //Green Check mark
        private const string Xmark = "xmark.png";                   //Red X mark
        private const string EmptyString = "";                      //Empty string (used to display no image for Image elements)
        const uint MinPWDLength = 8;                                //Minumum password character limit (8)
        private const double PressedSize = 1.1;                     //Size of button when pressed
        private Color EmptyColor = Color.FromHex("#B5E4FF");        //Color for empty entry
        private Color InvalidColor = Color.FromHex("#FFB5B5");      //Color for invalid entry
        private Color ValidColor = Color.FromHex("#75FF89");        //Color for valid entry
        private Color ActiveColor = Color.FromHex("#00CFB3");       //Color for active button
        private Color InactiveColor = Color.FromHex("#435258");     //Color for inactive button
        private const string HideIcon = "NotVisibleIcon.png";       //Eyeball icon (Hide)
        private const string ShowIcon = "VisibleIcon.png";          //Eyeball icon (Show)
        private PageLayout PL = PageLayout.SignUpLayout;            //Page Layout

        private bool FullName_Checked = false;
        private bool SU_Email_Checked = false;
        private bool LI_Email_Checked = false;
        private bool SU_PWD_Checked = false;
        private bool LI_PWD_Checked = false;
        private bool ConfirmPWD_Checked = false;

        public SignInPage()
        {
            InitializeComponent();

            SU_FullName.Keyboard = Keyboard.Create(KeyboardFlags.CapitalizeNone | KeyboardFlags.Suggestions);
            SU_Email.Keyboard = Keyboard.Create(KeyboardFlags.CapitalizeNone | KeyboardFlags.Suggestions);
            SU_Password.Keyboard = Keyboard.Create(KeyboardFlags.CapitalizeNone | KeyboardFlags.Suggestions);
            SU_ConfirmPassword.Keyboard = Keyboard.Create(KeyboardFlags.CapitalizeNone | KeyboardFlags.Suggestions);
            LI_Email.Keyboard = Keyboard.Create(KeyboardFlags.CapitalizeNone | KeyboardFlags.Suggestions);
            LI_Password.Keyboard = Keyboard.Create(KeyboardFlags.CapitalizeNone | KeyboardFlags.Suggestions);
            SU_ShowPasswordIcon.Source = "NotVisibleIcon.png";

            //Testing Purposes (will not appear in final product)
            SU_FullName.Text = "Alan Turing";
            SU_Email.Text = "aturing64@lsu.edu";
            SU_Password.Text = "SeeSharp";
            SU_ConfirmPassword.Text = "SeeSharp";
        }

        //Highlight the button to let the user know it's pressed
        async void HighlightButton(object sender, EventArgs args)
        {
            var button = (Button)sender;

            if ((button == SignUp && PL != PageLayout.SignUpLayout) ||
                (button == LogIn && PL != PageLayout.LogInLayout))
            {
                button.TextColor = Color.FromRgb(200, 200, 200);
                button.BackgroundColor = Color.FromRgb(0, 85, 92);
            }

            //Grow Sign Up node
            if (button == SignUp) { NodeSignUp.ScaleTo(PressedSize, 200, Easing.SinOut); }
            //Grow Log In node
            else if (button == LogIn) { NodeLogIn.ScaleTo(PressedSize, 200, Easing.SinOut); }

            await button.ScaleTo(PressedSize, 200, Easing.SinOut);
        }

        //Highlight the Sign In or Login button to let the user know it's pressed
        void HighlightConfirm(object sender, EventArgs args)
        {
            var button = (Button)sender;

            button.TextColor = Color.FromRgb(200, 200, 200);
            button.BackgroundColor = Color.FromRgb(0, 85, 92);
            button.ScaleTo(PressedSize, 200, Easing.SinOut);
        }

        //Switch to Sign Up layout
        async void SignUpLayout(object sender, EventArgs args)
        {
            //Only run this if page layout isn't already a Sign Up layout (Performance)
            if (PL != PageLayout.SignUpLayout)
            {
                PL = PageLayout.SignUpLayout;

                //Make Sign Up button active
                SignUp.BackgroundColor = ActiveColor;
                SignUp.TextColor = Color.White;
                NodeSignUp.BackgroundColor = Color.White;
                //Make Log In button inactive
                LogIn.BackgroundColor = InactiveColor;
                LogIn.TextColor = Color.FromHex("#808080");
                NodeLogIn.BackgroundColor = Color.FromHex("#808080");

                //Disable Log In features
                LogInTemplate.IsVisible = false;
                LogInTemplate.IsEnabled = false;
                //Enable Sign Up features
                SignUpTemplate.IsVisible = true;
                SignUpTemplate.IsEnabled = true;
            }

            NodeSignUp.ScaleTo(1.0, 200, Easing.SinOut);
            await SignUp.ScaleTo(1.0, 200, Easing.SinOut);
        }

        //Switch to Log In layout
        async void LogInLayout(object sender, EventArgs args)
        {
            //Only run this if page layout isn't already a Log In layout (Performance)
            if (PL != PageLayout.LogInLayout)
            {
                PL = PageLayout.LogInLayout;

                //Make Log In button active
                LogIn.BackgroundColor = ActiveColor;
                LogIn.TextColor = Color.White;
                NodeLogIn.BackgroundColor = Color.White;
                //Make Sign Up button inactive
                SignUp.BackgroundColor = InactiveColor;
                SignUp.TextColor = Color.FromHex("#808080");
                NodeSignUp.BackgroundColor = Color.FromHex("#808080");

                //Disable Sign Up features
                SignUpTemplate.IsVisible = false;
                SignUpTemplate.IsEnabled = false;
                //Enable Log In features
                LogInTemplate.IsVisible = true;
                LogInTemplate.IsEnabled = true;
            }
            
            NodeLogIn.ScaleTo(1.0, 200, Easing.SinOut);
            await LogIn.ScaleTo(1.0, 200, Easing.SinOut);
        }

        //Check if entry (e.g. Full Name and Email) is filled
        void ValidateEntry(object sender, TextChangedEventArgs e)
        {
            var entry = (Entry)sender;
            var emailSyntax = "^[a-zA-Z]{1,}[0-9]{1,}@lsu.edu$";

            //Confirm entry if there's at least one character
            if (entry.Text.Length > 0)
            {
                //Display check mark
                if (PL == PageLayout.SignUpLayout)
                {
                    if (entry == SU_FullName)
                    {
                        SU_FullNameMark.Source = Checkmark;
                        FullName_Checked = true;
                        entry.BackgroundColor = ValidColor;
                    }
                    else if (entry == SU_Email)
                    {
                        if (Regex.IsMatch(entry.Text, emailSyntax))
                        {
                            SU_EmailMark.Source = Checkmark;
                            SU_Email_Checked = true;
                            entry.BackgroundColor = ValidColor;
                        }
                        else
                        {
                            SU_EmailMark.Source = Xmark;
                            SU_Email_Checked = false;
                            entry.BackgroundColor = InvalidColor;
                        }
                    }
                }
            }
            //Entry is empty
            else
            {
                entry.BackgroundColor = EmptyColor;

                //Don't display anything
                if (PL == PageLayout.SignUpLayout)
                {
                    if (entry == SU_FullName) { SU_FullNameMark.Source = EmptyString; FullName_Checked = false; }
                    else if (entry == SU_Email) { SU_EmailMark.Source = EmptyString; SU_Email_Checked = false; }
                }
            }

            if (PL == PageLayout.SignUpLayout) { CheckSignUp(); }
        }

        void ValidatePasswordLength(object sender, TextChangedEventArgs e)
        {
            var entry = (Entry)sender;
            var image = SU_PasswordMark;
            PWD = entry.Text;

            //Display nothing if password entry is empty
            if (PWD.Length == 0)
            {
                if (PL == PageLayout.SignUpLayout) { SU_PWD_Checked = false; }
                else { LI_PWD_Checked = false; }
                entry.BackgroundColor = EmptyColor;
                image.Source = EmptyString;
                Field_ConfirmPassword.Opacity = 0.5;
                Field_ConfirmPassword.IsEnabled = false;
                SU_ConfirmPassword.Text = "";
            }
            //Password is valid if number of characters in password entry is at least 8 characters
            else if (PWD.Length >= MinPWDLength)
            {
                if (PL == PageLayout.SignUpLayout) { SU_PWD_Checked = true; }
                else { LI_PWD_Checked = true; }
                entry.BackgroundColor = ValidColor;
                image.Source = Checkmark;
                Field_ConfirmPassword.Opacity = 1.0;
                Field_ConfirmPassword.IsEnabled = true;
            }
            else
            {
                if (PL == PageLayout.SignUpLayout) { SU_PWD_Checked = false; }
                else { LI_PWD_Checked = false; }
                entry.BackgroundColor = InvalidColor;
                image.Source = Xmark;
                SU_ConfirmPassword.Text = "";
                Field_ConfirmPassword.Opacity = 0.5;
                Field_ConfirmPassword.IsEnabled = false;
            }

            if (PL == PageLayout.SignUpLayout) { CheckSignUp(); }
        }

        //Show/Hide password in Password entry
        void DisplayPassword(object sender, EventArgs args)
        {
            var image_button = (PL == PageLayout.SignUpLayout ? SU_ShowPasswordIcon : LI_ShowPasswordIcon);

            if (PL == PageLayout.SignUpLayout)
            {
                //Reveal Password toggle
                SU_Password.IsPassword = !SU_Password.IsPassword;

                //Display appropriate icon
                if (SU_Password.IsPassword) { image_button.Source = HideIcon; }
                else { image_button.Source = ShowIcon; }
            }
            else
            {
                //Reveal Password toggle
                LI_Password.IsPassword = !LI_Password.IsPassword;

                if (LI_Password.IsPassword) { image_button.Source = HideIcon; }
                else { image_button.Source = ShowIcon; }
            }
        }

        //Show/Hide password in Confirm Password entry
        void DisplayConfirmPassword(object sender, EventArgs args)
        {
            var image_button = SU_ShowConfirmPasswordIcon;

            //Reveal Confirm Password toggle
            SU_ConfirmPassword.IsPassword = !SU_ConfirmPassword.IsPassword;

            //Display appropriate icon
            if (SU_ConfirmPassword.IsPassword) { image_button.Source = HideIcon; }
            else { image_button.Source = ShowIcon; }
        }

        //Confirms password
        async void MatchPassword(object sender, TextChangedEventArgs e)
        {
            var entry = (Entry)sender;
            ConfirmPWD = entry.Text;

            //Display no mark if entry is empty
            if (ConfirmPWD.Length == 0)
            {
                ConfirmPWD_Checked = false;
                entry.BackgroundColor = EmptyColor;
                SU_ConfirmPasswordMark.Source = EmptyString;
            }
            //If data from Confirm Password matches with Password, confirm password
            else if (ConfirmPWD == PWD)
            {
                ConfirmPWD_Checked = true;
                entry.BackgroundColor = ValidColor;
                SU_ConfirmPasswordMark.Source = Checkmark;
            }
            else
            {
                ConfirmPWD_Checked = false;
                entry.BackgroundColor = InvalidColor;
                SU_ConfirmPasswordMark.Source = Xmark;
            }

            if (PL == PageLayout.SignUpLayout) { CheckSignUp(); }
        }

        //Ensure user has filled all the entries in Sign Up. If true, allow user to sign up.
        void CheckSignUp()
        {
            if (FullName_Checked && SU_Email_Checked && SU_PWD_Checked && ConfirmPWD_Checked)
            {
                SUBMIT.IsEnabled = true;
                SUBMIT.Opacity = 1.0;
            }
            else
            {
                SUBMIT.IsEnabled = false;
                SUBMIT.Opacity = 0.5;
            }
        }

        //Send user to Feed page
        //async void GoToFeedPage(object sender, EventArgs args)
        //{
        //    await Navigation.PushAsync(new FeedPage());
        //}

        //Add User to Local DB
        async void ClickSignUp(object sender, EventArgs e)
        {
            var button = (Button)sender;

            button.TextColor = Color.White;
            button.BackgroundColor = Color.FromHex("#00CFB3");
            await button.ScaleTo(1.0, 200, Easing.SinOut);

            User newUser = new User
            {
                Name = SU_FullName.Text,
                Email = SU_Email.Text,
                Password = SU_Password.Text,
            };
            
            await Navigation.PushAsync(new FeedPage(newUser));

        }

        //Check User DB to see if user exists
        async void ClickSignIn(object sender, EventArgs e)
        {
            var button = (Button)sender;

            button.TextColor = Color.White;
            button.BackgroundColor = Color.FromHex("#00CFB3");
            await button.ScaleTo(1.0, 200, Easing.SinOut);

            User user = await App.Database.GetUserByEmail(LI_Email.Text);
            if (user == null)
                await DisplayAlert("User Not Found", "A user with that email does not exist!", "Back");
            else if (user.Password == LI_Password.Text)
            {
                App.currentUserID = user.ID;
                await Navigation.PushAsync(new HomeFeedPage(user));
            }
            else
                await DisplayAlert("Invalid User", "Wrong Username or Password", "Back");
        }
    }
}
