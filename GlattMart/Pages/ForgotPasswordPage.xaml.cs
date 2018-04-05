using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace GlattMart.Pages
{
    
    public partial class ForgotPasswordPage : ContentPage
    {
        ForgotPasswordPageModel vm;
        public ForgotPasswordPage()
        {
            InitializeComponent();
            vm = new ForgotPasswordPageModel();

            BindingContext = vm;
        }
    }
}
