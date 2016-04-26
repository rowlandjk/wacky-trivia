using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WackyTrivia.Abstracts;
using WackyTrivia.View;
using WackyTrivia.ViewModel;
using Xamarin.Forms;

namespace WackyTrivia
{
    public class App : Application
    {
        static void RegisterTypes()
        {
            ViewFactory.Register<MainPage, MainPageViewModel>();
            ViewFactory.Register<GameView, GameViewModel>();
            ViewFactory.Register<StatsPage, StatsPageViewModel>();
        }

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
