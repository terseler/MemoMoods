using System;
using System.Collections.Generic;
using System.Globalization;
using MemoMoods.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace MemoMoods.Views
{
    public partial class MemoMoodsEntriesPage
    {
        public MemoMoodsEntriesPage()
        {
            InitializeComponent();
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            //TodoItemDatabase database = await TodoItemDatabase.Instance;
            listView.ItemsSource = await App.Database.GetItemsAsync();

        }
        async void OnItemAdded(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MemoMoodsItemPage
            {
                BindingContext = new MemoMoodsItem()
            });
        }

        async void OnListItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                var memoMoodsItem = e.SelectedItem as MemoMoodsItem;
                ChangeVisibilityOfGoalsSection(memoMoodsItem);

                await Navigation.PushAsync(new MemoMoodsReviewPage
                {
                    BindingContext = e.SelectedItem as MemoMoodsItem
                    
                });
                
            }
        }

        async void ChangeVisibilityOfGoalsSection(MemoMoodsItem currentItem)
        {
            var previousItem = await App.Database.GetItemAsync(currentItem.ID - 1);

            if (previousItem.Question3 != null)
            {
                currentItem.PreviousItemHasGoals = true;
                //MemoMoodsItemPage.GoalDivider.Source = "";

			}
            else
            {
                currentItem.PreviousItemHasGoals = false;
            }
        }

    }
}