using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ReadingApp.Models;

[assembly: Xamarin.Forms.Dependency(typeof(ReadingApp.Services.MockDataStore))]
namespace ReadingApp.Services
{
    public class MockDataStore : IDataStore<Results>
    {
        List<Results> items;

        public MockDataStore()
        {
            items = new List<Results>();
            var mockItems = new List<Results>
            {
                new Results { Id = Guid.NewGuid().ToString(), Name = "Andrew Nowotarski", GradeLevel="10th", SpeedGrade=86m, AccuracyGrade=90.0m, ComprehensionGrade=75m, OverallGrade=83.66m },
                new Results { Id = Guid.NewGuid().ToString(), Name = "Gregory Hayes", GradeLevel="2nd", SpeedGrade=76m, AccuracyGrade=80.0m, ComprehensionGrade=65m, OverallGrade=73.66m },
                new Results { Id = Guid.NewGuid().ToString(), Name = "Michael Smith", GradeLevel="3rd", SpeedGrade=66m, AccuracyGrade=70.0m, ComprehensionGrade=55m, OverallGrade=63.66m }
            };

            foreach (var item in mockItems)
            {
                items.Add(item);
            }
        }

        public async Task<bool> AddItemAsync(Results item)
        {
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(Results item)
        {
            var _item = items.Where((Results arg) => arg.Id == item.Id).FirstOrDefault();
            items.Remove(_item);
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(Results item)
        {
            var _item = items.Where((Results arg) => arg.Id == item.Id).FirstOrDefault();
            items.Remove(_item);

            return await Task.FromResult(true);
        }

        public async Task<Results> GetItemAsync(string id)
        {
            return await Task.FromResult(items.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Results>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(items);
        }
    }
}