using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using ReadingApp.Models;
using ReadingApp.ViewModels;

namespace ReadingApp.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ItemDetailPage : ContentPage
	{
        ItemDetailViewModel viewModel;

        public ItemDetailPage(ItemDetailViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = this.viewModel = viewModel;
        }

        public ItemDetailPage()
        {
            InitializeComponent();

            var item = new Results
            {
                Name = "Andrew Nowotarski",
                GradeLevel = "10th",
                OverallGrade = 95.4M
            };

            viewModel = new ItemDetailViewModel(item);
            BindingContext = viewModel;
        }
    }
}