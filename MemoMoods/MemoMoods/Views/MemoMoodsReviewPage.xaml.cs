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

		async void OnBackClicked(object sender, EventArgs e)
		{
			await Navigation.PopAsync();
		}
	}
}