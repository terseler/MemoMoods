using MemoMoods.Data;
using MemoMoods.Views;
using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MemoMoods
{
    public partial class App : Application
    {
        private static MemoMoodsItemDatabase database;
        internal static MemoMoodsItemDatabase Database
        {
            get
            {
                if (database == null)
                {
                    database = new MemoMoodsItemDatabase(Path.Combine(Environment.GetFolderPath
                    (Environment.SpecialFolder.LocalApplicationData), "MemoMoodsItems.db3"));
                }
                return database;
            }
        }
        public App()
        {
            InitializeComponent();
            MainPage = new NavigationPage(new MemoMoodsEntriesPage());
        }
        protected override void OnStart()
        {
        }
        protected override void OnSleep()
        {
        }
        protected override void OnResume()
        {
        }
    }
}
