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
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UserClassificationPage : ContentPage
    {
        User newUser;

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
                                            "Alaska",
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

        private const double PressedSize = 1.1;                     //Size of button when pressed
        public int SelectedIndex { get; set; }
        public UserClassificationPage(User u)
        {
            InitializeComponent();
            this.newUser = u;

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
            //foreach (string i in ClassificationItems)
            //{
            //    CompletedLevelList.Items.Add(i);
            //    CurrentLevelList.Items.Add(i);
            //    ProspectiveLevelList.Items.Add(i);
            //}

            //Add all items from Completed Level Items to the Completed Level list
            //foreach (string i in DegreeItems)
            //{
            //    CompletedDegreeList.Items.Add(i);
            //    CurrentDegreeList.Items.Add(i);
            //    ProspectiveDegreeList.Items.Add(i);
            //}

            CheckFields();
        }


        void HighlightButton(object sender, EventArgs args)
        {
            var button = (Button)sender;

            button.TextColor = Color.FromRgb(200, 200, 200);
            button.BackgroundColor = Color.FromRgb(0, 85, 92);
            button.ScaleTo(PressedSize, 200, Easing.SinOut);
        }

        //Check if all the fields are filled. If true, allow user to press the Complete button
        void CheckFields()
        {
            if (RoleList.SelectedIndex != -1
                && UniversityList.SelectedIndex != -1
                && LocationList.SelectedIndex != -1)
            {
                COMPLETE.IsEnabled = true;
                COMPLETE.Opacity = 1.0;
            }
            else
            {
                COMPLETE.IsEnabled = false;
                COMPLETE.Opacity = 0.5;
            }
        }

        //SelectedIndexChanged Event that runs when the user selects an item from a picker
        void PickedItem(object sender, EventArgs args)
        {
            CheckFields();
        }

        async void GoToHomeFeedPage(object sender, EventArgs args)
        {
            var button = (Button)sender;

            User User1 = await App.Database.GetUserByEmail("qsharp55@lsu.edu");
            User User2 = await App.Database.GetUserByEmail("srift16@lsu.edu");
            User User3 = await App.Database.GetUserByEmail("foconnor24@lsu.edu");
            User User4 = await App.Database.GetUserByEmail("elogg22@lsu.edu");
            Event Event1 = await App.Database.GetEventByKeyword("C#");
            Event Event2 = await App.Database.GetEventByKeyword("VR");

            await button.ScaleTo(1.0, 200, Easing.SinOut);

            //Add Data to New User
            this.newUser.Role = (string)RoleList.SelectedItem;
            this.newUser.University = (string)UniversityList.SelectedItem;
            this.newUser.Location = (string)LocationList.SelectedItem;

            //Add preset mentors to database
            User mentor1 = new User
            {
                Name = "Qubic Sharp",
                Email = "qsharp55@lsu.edu",
                Password = "SeeSharp",
                Classification = "Professor",
                Description = "My name is Qubic C. Sharp. I'm a LSU professor who specializes in C# programming " +
                              "and mobile app development. Feel free to stop by my office when you get the chance.",
                ProfilePhoto = "InterestsIcons-06.png"
            };
            User mentor2 = new User
            {
                Name = "Spencer Rift",
                Email = "srift16@lsu.edu",
                Password = "ILoveVR500",
                Classification = "Graduate",
                Description = "Howdy howdy! I'm Specner Rift! I'm an avid fan of virtual reality (VR) and " +
                              "augmented reality (AR).",
                ProfilePhoto = "InterestsIcons-01.png"
            };
            User mentor3 = new User
            {
                Name = "Flora O'Connor",
                Email = "foconnor24@lsu.edu",
                Password = "Magnolia",
                Classification = "Graduate",
                Description = "Hi! I'm Flora O'Connor. I love chemistry and video games. I'm tutoring students in " +
                              "Organic Chemistry so if you need any assistance, contact me. If you know how to " +
                              "play the game, you can tackle any course.",
                ProfilePhoto = "FloraPortrait.png"
            };
            User mentor4 = new User
            {
                Name = "Dr. Earl Logg",
                Email = "elogg22@lsu.edu",
                Password = "loggerror314",
                Classification = "Professor",
                Description = "My name is Dr. Earl Logg. My research mostly pertains to cloud computing, data storage, " +
                              "and version control. I also host events that prepare CSC undergraduates for the workplace.",
                ProfilePhoto = "InterestsIcons-09.png"
            };

            Event event1 = new Event
            {
                Keyword = "C#",
                Title = "Sharpen Your C# Skills",
                Type = "Workshop",
                Photo = "EventPoster1.png",
                Summary = "Interested in sharpening your C# Skills? Stop by PFT and learn the hidden intricacies " +
                          "of C#. You don't need to have prior knowledge of C# to participate. As a bonus, there " +
                          "will be free drinks and pizza!",
                EventDateTime = "Dec 12, 2019 at 5:00pm to 7:00pm",
                Location = "1263 Patrick Taylor Hall",
                NumAttendees = 32
            };
            Event event2 = new Event
            {
                Keyword = "VirtualReality",
                Title = "The Potential of Virtual Reality",
                Type = "Seminar",
                Photo = "EventPoster2.png",
                Summary = "Imagine a future where you can step into a digitally crafted world and experience interact " +
                          "with your surroundings. Amazing, isn't it? I'm having a cool seminar where I talk about, you " +
                          "guessed it, virtual reality. This seminar covers how VR is incorporated in video game development, the military, and education.",
                EventDateTime = "Dec 19, 2019 at 5:00pm to 6:20pm",
                Location = "Royal Cotillion Ballroom",
                NumAttendees = 77
            };


            await App.Database.DeleteEventAsync(Event1);
            await App.Database.DeleteEventAsync(Event2);

            //Save Event to Database
            await App.Database.SaveEventAsync(event1);
            await App.Database.SaveEventAsync(event2);

            //Save New User to Database
            await App.Database.SaveUserAsync(this.newUser);
            //Current User is now New User
            App.currentUserID = this.newUser.ID;
            await Navigation.PushAsync(new HomeFeedPage());
        }
    }
}