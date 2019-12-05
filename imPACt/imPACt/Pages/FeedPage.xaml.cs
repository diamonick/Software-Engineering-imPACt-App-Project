using System;
using System.Collections.Generic;
using imPACt.Models;
using Xamarin.Forms;

namespace imPACt.Pages
{
    public partial class FeedPage : ContentPage
    {

        private const double PressedSize = 1.1;                     //Size of button when pressed
        private int NumOfInterests = 0; 
        private const int RequiredNumOfInterests = 5;
        private bool[] InterestsSelected = new bool[15];
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
        private User newUser;

        public FeedPage(User u)
        {
            InitializeComponent();
            this.newUser = u;
            InterestCounter.Text = "Number of Interests: " + NumOfInterests + "/5";
        }

        void HighlightInterest(object sender, EventArgs args)
        {
            var imageButton = (ImageButton)sender;

            if (imageButton == MathematicsTab) { MATH_CheckTag.ScaleTo(PressedSize, 200, Easing.SinOut); }
            else if (imageButton == PhysicsTab) { PHYS_CheckTag.ScaleTo(PressedSize, 200, Easing.SinOut); }
            else if (imageButton == BiologyTab) { BIOL_CheckTag.ScaleTo(PressedSize, 200, Easing.SinOut); }
            else if (imageButton == MechanicalEngineeringTab) { ME_CheckTag.ScaleTo(PressedSize, 200, Easing.SinOut); }
            else if (imageButton == ScienceTab) { SC_CheckTag.ScaleTo(PressedSize, 200, Easing.SinOut); }
            else if (imageButton == TechnologyTab) { TECH_CheckTag.ScaleTo(PressedSize, 200, Easing.SinOut); }
            else if (imageButton == ChemistryTab) { CHEM_CheckTag.ScaleTo(PressedSize, 200, Easing.SinOut); }
            else if (imageButton == WorkshopsTab) { WS_CheckTag.ScaleTo(PressedSize, 200, Easing.SinOut); }
            else if (imageButton == ComputerScienceTab) { CSC_CheckTag.ScaleTo(PressedSize, 200, Easing.SinOut); }
            else if (imageButton == ElectricalEngineeringTab) { EE_CheckTag.ScaleTo(PressedSize, 200, Easing.SinOut); }
            else if (imageButton == CivilEngineeringTab) { CE_CheckTag.ScaleTo(PressedSize, 200, Easing.SinOut); }
            else if (imageButton == PetroleumEngineeringTab) { PE_CheckTag.ScaleTo(PressedSize, 200, Easing.SinOut); }
            else if (imageButton == MedicalScienceTab) { MSC_CheckTag.ScaleTo(PressedSize, 200, Easing.SinOut); }
            else if (imageButton == EnvironmentalScienceTab) { ESC_CheckTag.ScaleTo(PressedSize, 200, Easing.SinOut); }
            else if (imageButton == StatisticsTab) { STATS_CheckTag.ScaleTo(PressedSize, 200, Easing.SinOut); }

            imageButton.ScaleTo(PressedSize, 200, Easing.SinOut);
        }

        void HighlightButton(object sender, EventArgs args)
        {
            var button = (Button)sender;

            button.TextColor = Color.FromRgb(200, 200, 200);
            button.BackgroundColor = Color.FromRgb(0, 85, 92);
            button.ScaleTo(PressedSize, 200, Easing.SinOut);
        }

        void SelectCategory(object sender, EventArgs args)
        {
            var imageButton = (ImageButton)sender;

            if (imageButton == MathematicsTab)
            {
                InterestsSelected[0] = !InterestsSelected[0];
                MATH_CheckTag.IsVisible = !MATH_CheckTag.IsVisible;
                CountInterests(InterestsSelected[0]);
                MATH_CheckTag.ScaleTo(1.0, 200, Easing.SinOut);
            }
            else if (imageButton == PhysicsTab)
            {
                InterestsSelected[1] = !InterestsSelected[1];
                PHYS_CheckTag.IsVisible = !PHYS_CheckTag.IsVisible;
                CountInterests(InterestsSelected[1]);
                PHYS_CheckTag.ScaleTo(1.0, 200, Easing.SinOut);
            }
            else if (imageButton == BiologyTab)
            {
                InterestsSelected[2] = !InterestsSelected[2];
                BIOL_CheckTag.IsVisible = !BIOL_CheckTag.IsVisible;
                CountInterests(InterestsSelected[2]);
                BIOL_CheckTag.ScaleTo(1.0, 200, Easing.SinOut);
            }
            else if (imageButton == MechanicalEngineeringTab)
            {
                InterestsSelected[3] = !InterestsSelected[3];
                ME_CheckTag.IsVisible = !ME_CheckTag.IsVisible;
                CountInterests(InterestsSelected[3]);
                ME_CheckTag.ScaleTo(1.0, 200, Easing.SinOut);
            }
            else if (imageButton == ScienceTab)
            {
                InterestsSelected[4] = !InterestsSelected[4];
                SC_CheckTag.IsVisible = !SC_CheckTag.IsVisible;
                CountInterests(InterestsSelected[4]);
                SC_CheckTag.ScaleTo(1.0, 200, Easing.SinOut);
            }
            else if (imageButton == TechnologyTab)
            {
                InterestsSelected[5] = !InterestsSelected[5];
                TECH_CheckTag.IsVisible = !TECH_CheckTag.IsVisible;
                CountInterests(InterestsSelected[5]);
                TECH_CheckTag.ScaleTo(1.0, 200, Easing.SinOut);
            }
            else if (imageButton == ChemistryTab)
            {
                InterestsSelected[6] = !InterestsSelected[6];
                CHEM_CheckTag.IsVisible = !CHEM_CheckTag.IsVisible;
                CountInterests(InterestsSelected[6]);
                CHEM_CheckTag.ScaleTo(1.0, 200, Easing.SinOut);
            }
            else if (imageButton == WorkshopsTab)
            {
                InterestsSelected[7] = !InterestsSelected[7];
                WS_CheckTag.IsVisible = !WS_CheckTag.IsVisible;
                CountInterests(InterestsSelected[7]);
                WS_CheckTag.ScaleTo(1.0, 200, Easing.SinOut);
            }
            else if (imageButton == ComputerScienceTab)
            {
                InterestsSelected[8] = !InterestsSelected[8];
                CSC_CheckTag.IsVisible = !CSC_CheckTag.IsVisible;
                CountInterests(InterestsSelected[8]);
                CSC_CheckTag.ScaleTo(1.0, 200, Easing.SinOut);
            }
            else if (imageButton == ElectricalEngineeringTab)
            {
                InterestsSelected[9] = !InterestsSelected[9];
                EE_CheckTag.IsVisible = !EE_CheckTag.IsVisible;
                CountInterests(InterestsSelected[9]);
                EE_CheckTag.ScaleTo(1.0, 200, Easing.SinOut);
            }
            else if (imageButton == CivilEngineeringTab)
            {
                InterestsSelected[10] = !InterestsSelected[10];
                CE_CheckTag.IsVisible = !CE_CheckTag.IsVisible;
                CountInterests(InterestsSelected[10]);
                CE_CheckTag.ScaleTo(1.0, 200, Easing.SinOut);
            }
            else if (imageButton == PetroleumEngineeringTab)
            {
                InterestsSelected[11] = !InterestsSelected[11];
                PE_CheckTag.IsVisible = !PE_CheckTag.IsVisible;
                CountInterests(InterestsSelected[11]);
                PE_CheckTag.ScaleTo(1.0, 200, Easing.SinOut);
            }
            else if (imageButton == MedicalScienceTab)
            {
                InterestsSelected[12] = !InterestsSelected[12];
                MSC_CheckTag.IsVisible = !MSC_CheckTag.IsVisible;
                CountInterests(InterestsSelected[12]);
                MSC_CheckTag.ScaleTo(1.0, 200, Easing.SinOut);
            }
            else if (imageButton == EnvironmentalScienceTab)
            {
                InterestsSelected[13] = !InterestsSelected[13];
                ESC_CheckTag.IsVisible = !ESC_CheckTag.IsVisible;
                CountInterests(InterestsSelected[13]);
                ESC_CheckTag.ScaleTo(1.0, 200, Easing.SinOut);
            }
            else if (imageButton == StatisticsTab)
            {
                InterestsSelected[14] = !InterestsSelected[14];
                STATS_CheckTag.IsVisible = !STATS_CheckTag.IsVisible;
                CountInterests(InterestsSelected[14]);
                STATS_CheckTag.ScaleTo(1.0, 200, Easing.SinOut);
            }

            EnableNext();
            imageButton.ScaleTo(1.0, 200, Easing.SinOut);
        }

        void CountInterests(bool Interest)
        {
            if (Interest) { NumOfInterests++; }
            else { NumOfInterests--; }

            InterestCounter.Text = "Number of Interest: " + NumOfInterests + "/5";
        }

        void EnableNext()
        {
            NEXT.IsEnabled = (NumOfInterests >= RequiredNumOfInterests ? true : false);
            NEXT.Opacity = (NumOfInterests >= RequiredNumOfInterests ? 1.0 : 0.5);
        }

        //Go to User Classification page
        async void GoToClassificationPage(object sender, EventArgs args)
        {
            var button = (Button)sender;

            button.TextColor = Color.White;
            button.BackgroundColor = Color.FromHex("#00CFB3");
            await button.ScaleTo(1.0, 200, Easing.SinOut);


            //Set Interests for New User Here
            for (int i = 0; i < InterestsSelected.Length; i++)
            {
                if (InterestsSelected[i]) { this.newUser.Interests.Add((string)InterestSource[i]); }
            }

            await Navigation.PushAsync(new UserClassificationPage(this.newUser));
        }
    }
}
