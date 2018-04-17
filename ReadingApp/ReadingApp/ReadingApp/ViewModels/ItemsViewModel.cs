﻿using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;

using Xamarin.Forms;

using ReadingApp.Models;
using ReadingApp.Views;

namespace ReadingApp.ViewModels
{
    public class ItemsViewModel : BaseViewModel
    {
        public ObservableCollection<Results> Items { get; set; }
        public Command LoadItemsCommand { get; set; }

        public ItemsViewModel()
        {
            Title = "Assessment History";
            Items = new ObservableCollection<Results>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

            MessagingCenter.Subscribe<NewItemPage, Results>(this, "AddItem", async (obj, item) =>
            {
                var _item = item as Results;
                Items.Add(_item);
                await DataStore.AddItemAsync(_item);
            });
        }

        async Task ExecuteLoadItemsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                Items.Clear();
                var items = await DataStore.GetItemsAsync(true);
                foreach (var item in items)
                {
                    Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}