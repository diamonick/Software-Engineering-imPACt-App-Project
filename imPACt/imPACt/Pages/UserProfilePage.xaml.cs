using System;
using System.Collections.Generic;

using Xamarin.Forms;
using imPACt.Models;
using imPACt.Data;
using SQLite;
using System.IO;

namespace imPACt.Pages
{
    public partial class UserProfilePage : ContentPage
    {
        User newUser;
        private int DescCount = 0;
        private const int MaxDescLimit = 210;
        private string[] Roles = { "Mentor", "Mentee"};
        private string[] MajorItems = { "Undecided",
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
                                        "Software Engineering"};

        private string[] MinorItems = { "N/A",
                                        "Aerospace Engineering",
                                        "Aerospace Studies",
                                        "African & African American Studies",
                                        "Agricultural Business",
                                        "Agricultural Communication",
                                        "Agricultural Pest Management",
                                        "Agriculture",
                                        "Agronomy",
                                        "Animal, Dairy & Poultry Sciences",
                                        "Anthropology",
                                        "Applied Statistics",
                                        "Aquaculture",
                                        "Arabic Studies",
                                        "Architectural History",
                                        "Art History",
                                        "Arts Administration",
                                        "Asian Studies",
                                        "Biological Engineering",
                                        "Biological Sciences",
                                        "Business Administration",
                                        "Ceramics",
                                        "Chemistry",
                                        "Chinese",
                                        "Classical Civilization",
                                        "Coach Education",
                                        "Communication Sciences and Disorders",
                                        "Communication Studies",
                                        "Community Design",
                                        "Computer Science",
                                        "Construction Management",
                                        "Dance",
                                        "Digital Media AVATAR Arts",
                                        "Digital Media Arts & Engineering-Technology",
                                        "Disaster Science & Management",
                                        "E-Commerce Engineering",
                                        "Economics",
                                        "Electrical & Computer Engineering",
                                        "Energy",
                                        "English",
                                        "Entomology",
                                        "Entrepreneurship",
                                        "Environmental Engineering",
                                        "Environmental Management Systems",
                                        "Environmental Sciences",
                                        "Environmental Toxicology",
                                        "Extension Education",
                                        "Fine Art",
                                        "Fisheries",
                                        "Forestry",
                                        "French",
                                        "Geographic Information Systems (GIS)",
                                        "Geography",
                                        "Geology",
                                        "German",
                                        "Greek",
                                        "Health Science - Kinesiology",
                                        "Health Science - School Health",
                                        "Heritage Conservation",
                                        "History",
                                        "Horticulture",
                                        "Human Nutrition",
                                        "Information Technology Management",
                                        "Internal Auditing",
                                        "International Automotive Engineering",
                                        "International Studies",
                                        "Italian",
                                        "Jewish Studies",
                                        "LGBTQ Studies",
                                        "Latin",
                                        "Leadership Development",
                                        "Library Science",
                                        "Linguistics",
                                        "Mass Communication",
                                        "Materials Science & Engineering",
                                        "Mathematics",
                                        "Mechanical Engineering",
                                        "Music",
                                        "Nuclear Power Engineering",
                                        "Nuclear Science",
                                        "Oceanography & Coastal Sciences",
                                        "Painting & Drawing",
                                        "Personal Investing",
                                        "Philosophy",
                                        "Photography",
                                        "Physical Activity and Health",
                                        "Physical Theatre",
                                        "Physics",
                                        "Plant Biotechnology and Crop Development",
                                        "Political Communication",
                                        "Political Science",
                                        "Printmaking",
                                        "Professional Leadership",
                                        "Psychology",
                                        "Religious Studies",
                                        "Robotics Engineering",
                                        "Screen Arts",
                                        "Sculpture",
                                        "Social Work",
                                        "Sociology",
                                        "Spanish",
                                        "Special Education",
                                        "Sport Studies",
                                        "Structural Engineering",
                                        "Sugar Engineering",
                                        "Surveying",
                                        "Technical Sales",
                                        "Textiles, Apparel & Merchandising",
                                        "Theatre",
                                        "Transportation Engineering"};

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

        private string[] InterestSource =
        {
            "InterestsIcons-01.png",
            "InterestsIcons-02.png",
            "InterestsIcons-03.png",
            "InterestsIcons-04.png",
            "InterestsIcons-05.png",
            "InterestsIcons-06.png",
            "InterestsIcons-07.png",
            "InterestsIcons-08.png",
            "InterestsIcons-09.png",
            "InterestsIcons-10.png",
            "InterestsIcons-11.png",
            "InterestsIcons-12.png",
            "InterestsIcons-13.png",
            "InterestsIcons-14.png",
            "InterestsIcons-15.png",
        };

        public UserProfilePage(User u)
        {
            InitializeComponent();
            this.newUser = u;

            DescriptionLimit.Text = DescCount + "/" + MaxDescLimit;

            //Add all items from MajorItems to the Major list
            foreach (string i in MajorItems)
            {
                MajorList.Items.Add(i);
            }

            //Add all items from MinorItems to the Minor list
            foreach (string i in MinorItems)
            {
                MinorList.Items.Add(i);
            }

            //Add all items from UniversityItems to the University list
            foreach (string i in UniversityItems)
            {
                UniversityList.Items.Add(i);
            }

            LoadUser();
        }

        void LoadUser()
        {
            int MajorIndex = -1;
            int MinorIndex = -1;
            int UniversityIndex = -1;
            int InterestIndex = 0;

            FullNameText.Text = newUser.Name;
            PersonalName.Text = newUser.Name;
            PersonalEmail.Text = newUser.Email;
            PersonalPassword.Text = newUser.Password;
            if (newUser.Description == null) { DescriptionEntry.Text = ""; }
            else { DescriptionEntry.Text = newUser.Description; }
            PersonalRole.Text = newUser.Role;
            MajorIndex = MajorList.Items.IndexOf(newUser.Major);
            MinorIndex = MinorList.Items.IndexOf(newUser.Minor);
            UniversityIndex = UniversityList.Items.IndexOf(newUser.University);

            MajorList.SelectedIndex = MajorIndex;
            MinorList.SelectedIndex = MinorIndex;
            UniversityList.SelectedIndex = UniversityIndex;

            //foreach (string S in newUser.Interests)
            //{
            //    while (!S.Equals(InterestSource[InterestIndex]))
            //    {
            //        InterestIndex++;
            //        if (InterestIndex >= 15) { return; }
            //    }

            //    if (Tab1.Source.IsEmpty) { Tab1.Source = (string)S; }
            //    else if (Tab2.Source.IsEmpty) { Tab2.Source = (string)S; }
            //    else if (Tab3.Source.IsEmpty) { Tab3.Source = (string)S; }
            //    else if (Tab4.Source.IsEmpty) { Tab4.Source = (string)S; }
            //    else if (Tab5.Source.IsEmpty) { Tab5.Source = (string)S; }
            //    else if (Tab6.Source.IsEmpty) { Tab6.Source = (string)S; }
            //    else if (Tab7.Source.IsEmpty) { Tab7.Source = (string)S; }
            //    else if (Tab8.Source.IsEmpty) { Tab8.Source = (string)S; }
            //    else if (Tab9.Source.IsEmpty) { Tab9.Source = (string)S; }
            //    else if (Tab10.Source.IsEmpty) { Tab10.Source = (string)S; }
            //    else if (Tab11.Source.IsEmpty) { Tab11.Source = (string)S; }
            //    else if (Tab12.Source.IsEmpty) { Tab12.Source = (string)S; }
            //    else if (Tab13.Source.IsEmpty) { Tab13.Source = (string)S; }
            //    else if (Tab14.Source.IsEmpty) { Tab14.Source = (string)S; }
            //    else if (Tab15.Source.IsEmpty) { Tab15.Source = (string)S; }
            //}
        }

        async void PickedItem(object sender, EventArgs args)
        {
            var picker = (Picker)sender;

            if (picker == MajorList) { newUser.Major = (string)MajorList.SelectedItem; }
            else if (picker == MinorList) { newUser.Minor = (string)MinorList.SelectedItem; }
            else if (picker == UniversityList) { newUser.University = (string)UniversityList.SelectedItem; }

            await App.Database.SaveUserAsync(newUser);
        }

        async void UpdateUserDescription (object sender, EventArgs args)
        {
            Description.Text = DescriptionEntry.Text;
            newUser.Description = DescriptionEntry.Text;
            DescCount = DescriptionEntry.Text.Length;
            DescriptionLimit.Text = DescCount + "/" + MaxDescLimit;

            await App.Database.SaveUserAsync(newUser);
        }

    }
}
