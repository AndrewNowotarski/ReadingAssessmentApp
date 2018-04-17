using System;

using ReadingApp.Models;

namespace ReadingApp.ViewModels
{
    public class ItemDetailViewModel : BaseViewModel
    {
        public Results Item { get; set; }
        public ItemDetailViewModel(Results item = null)
        {
            Title = item?.Name;
            Item = item;
        }
    }
}
