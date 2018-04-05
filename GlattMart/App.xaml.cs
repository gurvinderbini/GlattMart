using GlattMart.CustomRenderer;
using GlattMart.Helpers;
using GlattMart.Pages;
using Xamarin.Forms;

namespace GlattMart
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            // MainPage = new NavigationPage(new MainDashBoardPage());
            //if (Settings.UserName == "")
            //{
                MainPage = new NavigationPageGradientHeader(new LoginPage())
                {
                    BarTextColor = Color.White,
                    LeftColor = Color.FromHex("#3b56a3"),
                    RightColor = Color.FromHex("#0f2a7c")
                };
            //}
            //else
            //{
            //    MainPage = new NavigationPageGradientHeader(new MainDashBoardPage())
            //  {
            //      BarTextColor = Color.White,
            //      LeftColor = Color.FromHex("#3b56a3"),
            //      RightColor = Color.FromHex("#0f2a7c")
            //  };  
            //}
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
