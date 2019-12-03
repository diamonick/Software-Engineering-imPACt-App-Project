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
    public partial class MentorProfilePage : ContentPage
    {
        User newUser;
        public MentorProfilePage(User u)
        {
            InitializeComponent();
            this.newUser = u;

            FullNameText.Text = newUser.Name;
            Description.Text = newUser.Description;
            ProfilePic.Source = newUser.ProfilePhoto;
        }
    }
}
