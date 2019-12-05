using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SQLite;
using imPACt.Models;

namespace imPACt.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UserInterestsPage : ContentPage
    {
        User newUser;

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

        private string[] MajorItems = {   "N/A",
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

        //Pick from a string of classifications
        private string[] ClassificationItems = {    "Freshman",
                                                    "Sophomore",
                                                    "Junior",
                                                    "Senior",
                                                    "Graduate",
                                                    "Professor",
                                                    "Researcher"
        };

        private const double PressedSize = 1.1;                     //Size of button when pressed
        public int SelectedIndex { get; set; }
        public UserInterestsPage(User u)
        {
            InitializeComponent();
            this.newUser = u;

            //Add all items from University items to the University list
            foreach (string i in UniversityItems)
            {
                UniversityInterestList.Items.Add(i);
            }

            //Add all items from Location items to the Location list
            foreach (string i in LocationItems)
            {
                LocationInterestList.Items.Add(i);
            }

            foreach (string i in MajorItems)
            {
                MajorInterestList.Items.Add(i);
            }

            //Add all items from Classification items to the Classification list
            foreach (string i in ClassificationItems)
            {
                ClassificationInterestList.Items.Add(i);
            }

            CheckFields();
        }

        void HighlightButton(object sender, EventArgs args)
        {
            var button = (Button)sender;

            button.TextColor = Color.FromRgb(200, 200, 200);
            button.BackgroundColor = Color.FromRgb(0, 85, 92);
            button.ScaleTo(PressedSize, 200, Easing.SinOut);
        }

        void CheckFields()
        {
            if (UniversityInterestList.SelectedIndex != -1
                && LocationInterestList.SelectedIndex != -1
                && MajorInterestList.SelectedIndex != -1
                && ClassificationInterestList.SelectedIndex != -1)
            {
                MATCH.IsEnabled = true;
                MATCH.Opacity = 1.0;
            }
            else
            {
                MATCH.IsEnabled = false;
                MATCH.Opacity = 0.5;
            }
        }

        //SelectedIndexChanged Event that runs when the user selects an item from a picker
        void PickedItem(object sender, EventArgs args)
        {
            CheckFields();
        }

        async void GoToMatchPage(object sender, EventArgs args)
        {
            var button = (Button)sender;

            await button.ScaleTo(1.0, 200, Easing.SinOut);
            await Navigation.PushAsync(new MatchPage());

            this.newUser.UniversityInterest = (string)UniversityInterestList.SelectedItem;
            this.newUser.LocationInterest = (string)LocationInterestList.SelectedItem;
            this.newUser.MajorInterest = (string)MajorInterestList.SelectedItem;
            this.newUser.ClassificationInterest = (string)ClassificationInterestList.SelectedItem;
        }
    }
}