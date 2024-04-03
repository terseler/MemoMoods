using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using MemoMoods.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace MemoMoods.Views
{
    public partial class MemoMoodsEntriesPage : INotifyPropertyChanged
	{

		public MemoMoodsEntriesPage()
        {
            InitializeComponent();
            ChangeBannerBasedOnMood();
			BindingContext = this;
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

			ChangeBannerBasedOnMood();
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

			}
			else
			{
				currentItem.PreviousItemHasGoals = false;
			}
		}
		public async void ChangeBannerBasedOnMood()
		{
			List<MemoMoodsItem> memoMoodsItems = await App.Database.GetItemsAsync();
			var lastItem = memoMoodsItems[0];

			mostRecentMood = lastItem.CowMood;
		}

		private int _mostRecentMood;


		public int mostRecentMood
		{
			get { return _mostRecentMood; }
			set
			{
				if (_mostRecentMood != value)
				{
					_mostRecentMood = value;
					OnPropertyChanged(nameof(mostRecentMood));
				}
			}
		}

		public event PropertyChangedEventHandler PropertyChanged;
		protected virtual void OnPropertyChanged(string propertyName)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}