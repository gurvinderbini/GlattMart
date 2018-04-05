using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace GlattMart.Pages
{
    public partial class SignupPage : ContentPage
    {
        SignupPageModel uvm;
        public SignupPage()
        {
            InitializeComponent();
            uvm = new SignupPageModel();  
            BindingContext = uvm; 
        }
    }
}
