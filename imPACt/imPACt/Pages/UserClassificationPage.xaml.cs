using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SQLite;

namespace imPACt.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UserClassificationPage : ContentPage
    {
        //Designate your role
        private string[] RoleItems = {  "Mentor",
                                        "Mentee"
        };

        //Pick from a string of institutions
        private string[] UniversityItems = {    "Auburn University",
                                                "Louisiana State University",
                                                "Mississippi State University",
                                                "Texas A&M University",
                                                "University of Alabama",
                                                "University of Arkansas",
                                                "University of Florida",
                                                "University of Georgia",
                                                "University of Kentucky",
                                                "University of Mississippi",
                                                "University of Missouri",
                                                "University of South Carolina",
                                                "University of Tennessee",
                                                "Vanderbilt University"
        };

        //Pick from a string of states
        private string[] LocationItems = {  "Alabama",
                                            "Alazka",
                                            "Arizona",
                                            "Arkansas",
                                            "California",
                                            "Colorado",
                                            "Connecticut",
                                            "Delaware",
                                            "Florida",
                                            "Georgia",
                                            "Hawaii",
                                            "Idaho",
                                            "Illinois",
                                            "Indiana",
                                            "Iowa",
                                            "Kansas",
                                            "Kentucky",
                                            "Louisiana",
                                            "Maine",
                                            "Maryland",
                                            "Massachusetts",
                                            "Michigan",
                                            "Minnesota",
                                            "Mississippi",
                                            "Missouri",
                                            "Montana",
                                            "Nebraska",
                                            "Nevada",
                                            "New Hampshire",
                                            "New Jersey",
                                            "New Mexico",
                                            "New York",
                                            "North Carolina",
                                            "North Dakota",
                                            "Ohio",
                                            "Oklahoma",
                                            "Oregon",
                                            "Pennsylvania",
                                            "Rhode Island",
                                            "South Carolina",
                                            "South Dakota",
                                            "Tennessee",
                                            "Texas",
                                            "Utah",
                                            "Vermont",
                                            "Virginia",
                                            "Washington",
                                            "West Virginia",
                                            "Wisconsin",
                                            "Wyoming"
        };

        //Pick from a string of classifications
        private string[] ClassificationItems = {    "Freshman",
                                                    "Sophomore",
                                                    "Junior",
                                                    "Senior",
                                                    "Graduate",
                                                    "Professor",
                                                    "Researcher"
        };

        //Pick from a string of degrees
        private string[] DegreeItems = {   "N/A",
                                                    "Animal Sciences",
                                                    "Astronomy",
                                                    "Biochemistry",
                                                    "Biological Chemistry",
                                                    "Biological Engineering",
                                                    "Biological Sciences",
                                                    "Biology",
                                                    "Biomolecular Chemical Engineering",
                                                    "Chemical Engineering",
                                                    "Chemical Physics",
                                                    "Chemistry",
                                                    "Civil Engineering",
                                                    "Cloud Computing and Networking",
                                                    "Coastal Environmental Science",
                                                    "Computational Mathematics",
                                                    "Computer Engineering",
                                                    "Computer Science",
                                                    "Conservation Biology",
                                                    "Construction Management",
                                                    "Data Science and Analytics",
                                                    "Digital Art",
                                                    "Disaster Science and Management",
                                                    "Electrical Engineering",
                                                    "Environmental Engineering",
                                                    "Food Science and Technology",
                                                    "Horticulture",
                                                    "Industrial Engineering",
                                                    "Mathematical Statistics",
                                                    "Mathematics",
                                                    "Mechanical Engineering",
                                                    "Microbiology",
                                                    "Petroleum Engineering",
                                                    "Software Engineering"
        };

        //private string Institution = "";        //String from institution entry
        //private string Location = "";           //String from location entry
        //private string[] CurrDegree = {};      //String array from current degree(s) entry
        //private string[] ProsDegree = {};       //String array from prospective degree(s) entry
        //private string[] ComplDegrees = {};     //String array from completed degrees(s) entry
        //private bool Bachelors = false;         //Boolean from degree entry
        //private bool Masters = false;           //Boolean from degree entry
        //private bool Phd = false;               //Boolean from degree entry
        //private bool Mentor = false;            //Boolean from Mentor selection
        //private bool Mentee = false;            //Boolean from Mentee selection

            public int SelectedIndex { get; set; }
        public UserClassificationPage()
        {
            InitializeComponent();

            //Add all items from Role items to Role list
            foreach (string i in RoleItems)
            {
                RoleList.Items.Add(i);
            }

            //Add all items from University items to the University list
            foreach (string i in UniversityItems)
            {
                UniversityList.Items.Add(i);
            }

            //Add all items from Location items to the Location list
            foreach (string i in LocationItems)
            {
                LocationList.Items.Add(i);
            }

            //Add all items from Classification items to the Classification list
            foreach (string i in ClassificationItems)
            {
                ClassificationList.Items.Add(i);
            }

            //Add all items from Completed Level Items to the Completed Level list
            foreach (string i in DegreeItems)
            {
                DegreeList.Items.Add(i);
            }

            checkFields();
        }
        void checkFields()
        {
            SUBMIT.IsEnabled = true;
            SUBMIT.Opacity = 1.0;
        }

        async void GoToHomeFeedPage(object sender, EventArgs args)
        {
            await Navigation.PushAsync(new HomeFeedPage());
        }
    }
}