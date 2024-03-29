﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MemoMoods.Data;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MemoMoods.Models;


namespace MemoMoods.Views
{
    public partial class MemoMoodsItemPage 
    {
        public bool MoodSelected = false;
        public MemoMoodsItemPage()
        {
            InitializeComponent();
        }
        async void OnSaveClicked(object sender, EventArgs e)
        {
            if (MoodSelected == true)
            {
				var memoMoodsItem = (MemoMoodsItem)BindingContext;
				// TodoItemDatabase database = await TodoItemDatabase.Instance;
				await App.Database.SaveItemAsync(memoMoodsItem);
				await Navigation.PopAsync();
			}
        }

        async void OnCancelClicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
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

            MoodText.Source = "TextUpset";
			MoodText.WidthRequest = 150;
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

			MoodText.Source = "TextNervous";
			MoodText.WidthRequest = 200;
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

			MoodText.Source = "TextHappy";
			MoodText.WidthRequest = 175;
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

			MoodText.Source = "TextContent";
			MoodText.WidthRequest = 175;
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

			MoodText.Source = "TextSad";
			MoodText.WidthRequest = 100;
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

			MoodText.Source = "TextTired";
			MoodText.WidthRequest = 150;
		}
	}
}