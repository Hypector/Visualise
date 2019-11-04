using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Visualise.Services;
using Visualise.Views;
using Visualise.Data;
using System.IO;

namespace Visualise
{
    public partial class App : Application
    {

        static FormsDB database;

        public static string FilePath;

        public static FormsDB Database
        {
            get
            {
                if (database == null)
                {
                    database = new FormsDB(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "FormsDB.db3"));
                }
                return database;
            }
        }

        public App(string filePath)
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            MainPage = new AppShell();

            FilePath = filePath;
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
