using System;
using System.Collections.Generic;
using GlattMart.Models;
using Xamarin.Forms;

namespace GlattMart.Pages
{
    public partial class AddToShoppingCartPage : ContentPage
    {
        AddToShoppingCartPageModel vm;
        public AddToShoppingCartPage()
        {
            InitializeComponent();
        }
        public AddToShoppingCartPage(Product binding)
        {
            InitializeComponent();
            vm = new AddToShoppingCartPageModel(binding);
            this.BindingContext = vm;

           // lbl_ProductId.Text = "Product Code : "+binding.id+"";
            //this.Title =binding.ProductTitle;
            //lbl_Price.Text = "$" + binding.price;
        }
    }
}
