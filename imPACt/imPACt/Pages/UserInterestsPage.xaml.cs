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
    public partial class UserInterestsPage : ContentPage
    {
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

        private string[] InterestedFieldItems = {   "N/A",
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

        public UserInterestsPage()
        {
            InitializeComponent();

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

            foreach (string i in InterestedFieldItems)
            {
                InterestedFieldList.Items.Add(i);
            }

            //Add all items from Classification items to the Classification list
            foreach (string i in ClassificationItems)
            {
                ClassifcationList.Items.Add(i);
            }

            checkFields();
        }
        void checkFields()
        {
            SUBMIT.IsEnabled = true;
            SUBMIT.Opacity = 1.0;
        }

        async void GoToMatchPage(object sender, EventArgs args)
        {
            await Navigation.PushAsync(new MatchPage());
        }
    }
}