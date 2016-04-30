using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WackyTrivia.Abstracts;
using WackyTrivia.Data;
using WackyTrivia.View;
using WackyTrivia.ViewModel;
using Xamarin.Forms;

namespace WackyTrivia
{
    /*  App class that is called on startup - handles connection to database, registering
     *  ViewModels, Views, and Navigation elements.
     *  Author: Jesse Rowland
     */
    public class App : Application
    {
        //variable to hold database connection
        static WackyTriviaDatabase _database;

        public static WackyTriviaDatabase Database
        {
            get { return _database ?? (_database = new WackyTriviaDatabase()); }
        }

        //Registers view and view model bindings
        static void RegisterTypes()
        {
            ViewFactory.Register<MainPage, MainPageViewModel>();
            ViewFactory.Register<GameView, GameViewModel>();
            ViewFactory.Register<StatsPage, StatsPageViewModel>();
        }

        //displays the MainPage on App startup
        public App()
        {
            RegisterTypes ();
            // The root page of your application
            MainPage = new NavigationPage(ViewFactory.CreatePage(new MainPageViewModel()));
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
