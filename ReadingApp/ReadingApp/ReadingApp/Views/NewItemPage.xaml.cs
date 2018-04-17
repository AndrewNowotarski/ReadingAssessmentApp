using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using ReadingApp.Models;

namespace ReadingApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewItemPage : ContentPage
    {
        public Results Item { get; set; }

        public NewItemPage()
        {
            InitializeComponent();

            Item = new Results
            {
                Name = "Andrew Nowotarski",
                GradeLevel = "10th",
                OverallGrade = 95.4M
            };

            BindingContext = this;
        }

        async void Save_Clicked(object sender, EventArgs e)
        {
            MessagingCenter.Send(this, "AddItem", Item);
            await Navigation.PopModalAsync();
        }
    }
}