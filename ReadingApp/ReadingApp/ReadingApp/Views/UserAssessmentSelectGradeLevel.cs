using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ReadingApp.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UserAssessmentSelectGradeLevel : ContentPage
	{
        public int SelectedGradeLevel { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public UserAssessmentSelectGradeLevel ()
		{
			InitializeComponent();
		}

        void StartAssessment_Clicked(object sender, System.EventArgs e)
        {
            //Passage.Text = TextToRead;
        }

	}
}