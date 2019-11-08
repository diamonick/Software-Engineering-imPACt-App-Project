using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace imPACt.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UserClassificationPage : ContentPage
    {
        private string Institution = "";        //String from institution entry
        private string Location = "";           //String from location entry
        private string[] CurrDegree = {};      //String array from current degree(s) entry
        private string[] ProsDegree = {};       //String array from prospective degree(s) entry
        private string[] ComplDegrees = {};     //String array from completed degrees(s) entry
        private bool Bachelors = false;         //Boolean from degree entry
        private bool Masters = false;           //Boolean from degree entry
        private bool Phd = false;               //Boolean from degree entry
        private bool Mentor = false;            //Boolean from Mentor selection
        private bool Mentee = false;            //Boolean from Mentee selection

        public UserClassificationPage()
        {
            //InitializeComponent();
        }
    }
}