using MemoMoods.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MemoMoods.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MemoMoodsReviewPage : ContentPage
	{
		public MemoMoodsReviewPage()
		{
			InitializeComponent();
			//SetGoalSectionVisibilty();

		}

		/*async void SetGoalSectionVisibilty()
		{
			List<MemoMoodsItem> memoMoodsItems = await App.Database.GetItemsAsync();
			var lastItem = memoMoodsItems[1];

			if (lastItem.Question3 != null)
			{
				GoalTitle.IsVisible = true;
				GoalQuote.IsVisible = true;
				YesterdaysGoalQuestion.IsVisible = true;
				GoalDivider.IsVisible = true;

				GoalQuoteLabel.Text = lastItem.Question3;

			}
			else
			{
				GoalTitle.IsVisible = false;
				GoalQuote.IsVisible = false;
				YesterdaysGoalQuestion.IsVisible = false;
				GoalDivider.IsVisible = false;
			}
		}*/


		async void OnBackClicked(object sender, EventArgs e)
		{
			await Navigation.PopAsync();
		}
	}
}