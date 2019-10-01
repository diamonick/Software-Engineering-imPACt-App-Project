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
    public partial class ChooseSignInPage : ContentPage
    {
        private string PWD = "";
        const uint MinPWDLength = 8;
        private Color EmptyColor = Color.FromHex("#B5E4FF");
        private Color InvalidColor = Color.FromHex("#FFB5B5");
        private Color ValidColor = Color.FromHex("#75FF89");
        private const string HideIcon = "NotVisibleIcon.png";
        private const string ShowIcon = "VisibleIcon.png";

        public ChooseSignInPage()
        {
            InitializeComponent();

            ShowPasswordIcon.Source = "NotVisibleIcon.png";
        }

        void ValidateEntry(object sender, TextChangedEventArgs e)
        {
            var entry = (Entry)sender;

            if (entry.Text.Length > 0) { entry.BackgroundColor = ValidColor; }
            else { entry.BackgroundColor = EmptyColor; }
        }

        async void ValidatePasswordLength(object sender, TextChangedEventArgs e)
        {
            PWD = Password.Text;

            if (PWD.Length == 0) { Password.BackgroundColor = EmptyColor; return; }
            await Task.Delay(1000);

            PWD = Password.Text;
            if (PWD.Length == 0) { Password.BackgroundColor = EmptyColor; }
            else if (PWD.Length >= MinPWDLength)
            {
                Password.BackgroundColor = ValidColor;
            }
            else { Password.BackgroundColor = InvalidColor; }
        }

        void DisplayPassword(object sender, EventArgs args)
        {
            Password.IsPassword = !Password.IsPassword;

            if (Password.IsPassword) { ShowPasswordIcon.Source = HideIcon; }
            else { ShowPasswordIcon.Source = ShowIcon; }
        }

        void GoToSignInPage(object sender, EventArgs args)
        {
            
        }
    }
}
