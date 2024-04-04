using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using MemoMoods.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace MemoMoods.Views
{

    public partial class MemoMoodsEntriesPage : ContentPage, INotifyPropertyChanged
    {

        private int _streakCount;
        
        public MemoMoodsEntriesPage()
        {
            InitializeComponent();
            BindingContext = this;
            StreakCount = StreakManager.GetStreakCount();
            ChangeBannerBasedOnMood();
        }

        public int StreakCount
        {
            get { return _streakCount; }
            set
            {
                if (_streakCount != value)
                {
                    _streakCount = value;
                    OnPropertyChanged(nameof(StreakCount));
                }
            }
        }

        public void UpdateStreak(bool newItemSaved)
        {

            if (newItemSaved)
            {
                DateTime lastEntryDate = StreakManager.GetLastEntryDate();
                if (lastEntryDate.Date != DateTime.Today)
                {
                    StreakManager.ResetStreakCount();
                }

                StreakManager.IncrementStreakCount();
                StreakManager.SetLastEntryDate(DateTime.Today);
                StreakCount = StreakManager.GetStreakCount();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected override async void OnAppearing()

        {
            base.OnAppearing();
            //TodoItemDatabase database = await TodoItemDatabase.Instance;
            listView.ItemsSource = await App.Database.GetItemsAsync();
        }

        async void OnItemAdded(object sender, EventArgs e)
        {
            var memoMoodsItemPage = new MemoMoodsItemPage();
            memoMoodsItemPage.UpdateStreakRequested += (newItemSaved) => UpdateStreak(newItemSaved);
            await Navigation.PushAsync(new MemoMoodsItemPage
            {
                BindingContext = new MemoMoodsItem()
            });
            UpdateStreak(true);
        }


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