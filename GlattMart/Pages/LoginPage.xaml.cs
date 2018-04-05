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

        void OnSignupBtnClicked(object sender, EventArgs args)
        {
            Title = "";
            Navigation.PushAsync(new SignupPage());
        }

        void OnForgotPasswordClicked(object sender, EventArgs args)
        {
            Title = "";
            Navigation.PushAsync(new ForgotPasswordPage());
        }
	}
}
