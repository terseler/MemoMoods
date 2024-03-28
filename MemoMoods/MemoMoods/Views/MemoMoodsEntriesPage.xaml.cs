using System;
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
                await Navigation.PushAsync(new MemoMoodsItemPage
                {
                    BindingContext = e.SelectedItem as MemoMoodsItem
                });
            }
        }

    }
}