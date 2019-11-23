using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace imPACt.Pages
{
    public partial class UserProfilePage : ContentPage
    {
        private int DescCount = 0;
        private const int MaxDescLimit = 120;
        private string[] Roles = { "Mentor", "Mentee"};
        private string[] MajorItems = { "Animal Sciences",
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

        private string[] MinorItems = { "Aerospace Engineering",
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

        public UserProfilePage()
        {
            InitializeComponent();

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
        }

        void UpdateUserDescription (object sender, EventArgs args)
        {
            Description.Text = DescriptionEntry.Text;
            DescCount = DescriptionEntry.Text.Length;
            DescriptionLimit.Text = DescCount + "/" + MaxDescLimit;
        }

    }
}
