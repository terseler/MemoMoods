using System;
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
        public MemoMoodsItemPage()
        {
            InitializeComponent();
        }
        async void OnSaveClicked(object sender, EventArgs e)
        {
            var memoMoodsItem = (MemoMoodsItem)BindingContext;
            // TodoItemDatabase database = await TodoItemDatabase.Instance;
            await App.Database.SaveItemAsync(memoMoodsItem);
            await Navigation.PopAsync();
        }
        //async void OnDeleteClicked(object sender, EventArgs e)
        //{
        //    var memoMoodsItem = (MemoMoodsItem)BindingContext;
        //    //TodoItemDatabase database = await TodoItemDatabase.Instance;
        //    await App.Database.DeleteItemAsync(memoMoodsItem);
        //    await Navigation.PopAsync();
        //}
        async void OnCancelClicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}