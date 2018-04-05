using System;
using System.Collections.Generic;
using GlattMart.PageModels;
using GlattMart.Pages;
using Xamarin.Forms;

namespace GlattMart
{
    public partial class LoginPage : ContentPage
    {
        LoginPageModel uvm;
        
        public LoginPage()
        {
            InitializeComponent();
            uvm = new LoginPageModel();  
            BindingContext = uvm;  
        }

       

        protected override void OnAppearing()
		{
			base.OnAppearing();

            NavigationPage.SetHasNavigationBar(this, false);
		}

       async void OnSignupBtnClicked(object sender, EventArgs args)
        {
            Title = "";
            //  Navigation.PushAsync(new SignupPage());
            await Application.Current.MainPage.Navigation.PopModalAsync();

            await Application.Current.MainPage.Navigation.PushAsync(new SignupPage());

        }

       async void OnForgotPasswordClicked(object sender, EventArgs args)
        {
            Title = "";
            //  Navigation.PushAsync(new ForgotPasswordPage());
            await Application.Current.MainPage.Navigation.PushAsync(new ForgotPasswordPage());

        }

        private async void TapGestureRecognizer_OnTapped(object sender, EventArgs e)
        {
            await Application.Current.MainPage.Navigation.PopModalAsync();
        }
    }
}
