using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MemoMoods.Data;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MemoMoods.Models;
using System.ComponentModel;


namespace MemoMoods.Views
{
    public partial class MemoMoodsItemPage
    {
        public bool MoodSelected = false;

        public delegate void UpdateStreakDelegate(bool newItemSaved);
        public event UpdateStreakDelegate UpdateStreakRequested;


        public MemoMoodsItemPage()
        {
            InitializeComponent();
			SetGoalSectionVisibilty();
        }


        async void SetGoalSectionVisibilty()
		{
            List<MemoMoodsItem> memoMoodsItems = await App.Database.GetItemsAsync();
            var lastItem = memoMoodsItems[0];
            
            if (lastItem.Question3 != null)
			{
				GoalQuote.IsVisible = true;
				YesterdaysGoalQuestion.IsVisible = true;
				GoalDivider.IsVisible = true;

				GoalQuoteLabel.Text = lastItem.Question3;

            } else
			{
                GoalQuote.IsVisible = false;
                YesterdaysGoalQuestion.IsVisible = false;
				GoalDivider.IsVisible = false;
			}
		}

        async void OnSaveClicked(object sender, EventArgs e)
        {
            if (MoodSelected)
            {
				Error.Text = "";

				if(DayTitle.Text != null && DayTitle.Text.Length >= 0 )
				{
					var memoMoodsItem = (MemoMoodsItem)BindingContext;
					// TodoItemDatabase database = await TodoItemDatabase.Instance;
					await App.Database.SaveItemAsync(memoMoodsItem);
                    UpdateStreakRequested?.Invoke(true);
                    await Navigation.PopAsync();

                }
                else
				{
					Error.Text = "Please Select Day Title!";
				}
			}
			else
			{
				Error.Text = "Please Select Mood!";
			}
        }

        async void OnCancelClicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

		public void ChangeGoalDivider(bool state)
		{
			GoalDivider.IsVisible = state;
		}

		void Clicked0(object sender, EventArgs e)
		{
			MoodSelected = true;

			var memoMoodsItem = (MemoMoodsItem)BindingContext;
			memoMoodsItem.CowMood = 0;

			Mood0.WidthRequest = 200;
			Mood1.IsVisible = false;
            Mood2.IsVisible = false;
			Mood3.IsVisible = false;
			Mood4.IsVisible = false;
			Mood5.IsVisible = false;

			Button0.IsVisible = false;
			Button1.IsVisible = false;
			Button2.IsVisible = false;
			Button3.IsVisible = false;
			Button4.IsVisible = false;
			Button5.IsVisible = false;

            MoodText.Source = "Text0";
			BackMood.IsVisible = true;
		}

		void Clicked1(object sender, EventArgs e)
		{
			MoodSelected = true;

			var memoMoodsItem = (MemoMoodsItem)BindingContext;
			memoMoodsItem.CowMood = 1;

			Mood0.IsVisible = false;
			Mood1.WidthRequest = 200;
			Mood2.IsVisible = false;
			Mood3.IsVisible = false;
			Mood4.IsVisible = false;
			Mood5.IsVisible = false;

			Button0.IsVisible = false;
			Button1.IsVisible = false;
			Button2.IsVisible = false;
			Button3.IsVisible = false;
			Button4.IsVisible = false;
			Button5.IsVisible = false;

			MoodText.Source = "Text1";
			BackMood.IsVisible = true;
		}

		void Clicked2(object sender, EventArgs e)
		{
			MoodSelected = true;

			var memoMoodsItem = (MemoMoodsItem)BindingContext;
			memoMoodsItem.CowMood = 2;

			Mood0.IsVisible = false;
			Mood1.IsVisible = false;
			Mood2.WidthRequest = 200;
			Mood3.IsVisible = false;
			Mood4.IsVisible = false;
			Mood5.IsVisible = false;

			Button0.IsVisible = false;
			Button1.IsVisible = false;
			Button2.IsVisible = false;
			Button3.IsVisible = false;
			Button4.IsVisible = false;
			Button5.IsVisible = false;

			MoodText.Source = "Text2";
			BackMood.IsVisible = true;
		}
		void Clicked3(object sender, EventArgs e)
		{
			MoodSelected = true;

			var memoMoodsItem = (MemoMoodsItem)BindingContext;
			memoMoodsItem.CowMood = 3;

			Mood0.IsVisible = false;
			Mood1.IsVisible = false;
			Mood2.IsVisible = false;
			Mood3.WidthRequest = 200;
			Mood4.IsVisible = false;
			Mood5.IsVisible = false;

			Button0.IsVisible = false;
			Button1.IsVisible = false;
			Button2.IsVisible = false;
			Button3.IsVisible = false;
			Button4.IsVisible = false;
			Button5.IsVisible = false;

			MoodText.Source = "Text3";
			BackMood.IsVisible = true;
		}
		void Clicked4(object sender, EventArgs e)
		{
			MoodSelected = true;

			var memoMoodsItem = (MemoMoodsItem)BindingContext;
			memoMoodsItem.CowMood = 4;

			Mood0.IsVisible = false;
			Mood1.IsVisible = false;
			Mood2.IsVisible = false;
			Mood3.IsVisible = false;
			Mood4.WidthRequest = 200;
			Mood5.IsVisible = false;

			Button0.IsVisible = false;
			Button1.IsVisible = false;
			Button2.IsVisible = false;
			Button3.IsVisible = false;
			Button4.IsVisible = false;
			Button5.IsVisible = false;

			MoodText.Source = "Text4";
			BackMood.IsVisible = true;
		}
		void Clicked5(object sender, EventArgs e)
		{
			MoodSelected = true;

			var memoMoodsItem = (MemoMoodsItem)BindingContext;
			memoMoodsItem.CowMood = 5;

			Mood0.IsVisible = false;
			Mood1.IsVisible = false;
			Mood2.IsVisible = false;
			Mood3.IsVisible = false;
			Mood4.IsVisible = false;
			Mood5.WidthRequest = 200;

			Button0.IsVisible = false;
			Button1.IsVisible = false;
			Button2.IsVisible = false;
			Button3.IsVisible = false;
			Button4.IsVisible = false;
			Button5.IsVisible = false;

			MoodText.Source = "Text5";
			BackMood.IsVisible = true;
		}

		void BackMoodClicked(object sender, EventArgs e)
		{
			MoodSelected = false;

			Mood0.IsVisible = true;
			Mood1.IsVisible = true;
			Mood2.IsVisible = true;
			Mood3.IsVisible = true;
			Mood4.IsVisible = true;
			Mood5.IsVisible = true;

			Mood0.WidthRequest = 100;
			Mood1.WidthRequest = 100;
			Mood2.WidthRequest = 100;
			Mood3.WidthRequest = 100;
			Mood4.WidthRequest = 100;
			Mood5.WidthRequest = 100;

			Button0.IsVisible = true;
			Button1.IsVisible = true;
			Button2.IsVisible = true;
			Button3.IsVisible = true;
			Button4.IsVisible = true;
			Button5.IsVisible = true;

			MoodText.Source = "";
			BackMood.IsVisible = false;
		}
	}
}