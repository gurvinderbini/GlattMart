using System;
using System.Collections.Generic;
using System.Linq;
using GlattMart.ListViewCell;
using GlattMart.Models;
using GlattMart.Pages;
using Syncfusion.ListView.XForms;
using Xamarin.Forms;

namespace GlattMart
{
    public partial class ProductListingPage : ContentPage
    {
        List<ProductCategoriesListModel> listData = new List<ProductCategoriesListModel>();
        String[] ProductTitle = new String[] { "Pita Mini 6 ct","Super Pita","Love Bakery Baguette","Whole Wheat Bread","White Bread","Classic Le PalAIS Section Bread","Rudi's Organic Bakery Bread 100% Whole Wheat",
            "Stren's Bread 100% Whole Wheat","Victory Bread Puri","International Pita"};
        String[] ProductNo = new String[] {"#8370","#8371","#8372","#8375","#8376","#8377","#8381","#8382","#8398","#8399"};
        String[] Size = new String[] {"10.00 ct","6.00 ct","1.00 ct","27.00 OZ","1.00 EA","1.00 EA","22.00 Ounc","21.00 Oz","16.00 OZ","8.00Z" };
        string PageTitle = "";
        //public ProductListingPage()
        //{
        //    InitializeComponent();
        //}
        ProductListingPageModel vm;
        public ProductListingPage(Subcategory category)
        {
            InitializeComponent();
            vm = new ProductListingPageModel(category);
            BindingContext = vm;
            this.Title = category.name+ "";

            PageTitle = this.Title;
            //for (int i = 0; i < ProductTitle.Length; i++)
            //{
            //    ProductCategoriesListModel model = new ProductCategoriesListModel();
            //    model.ProductTitle = ProductTitle[i];
            //    model.ProductNo = ProductNo[i];
            //    model.Size = Size[i];
            //    model.PCK = 1 + "";
            //    model.UPC = "0-94046-10061-" + i;

            //    listData.Add(model);
            //}
            //this.Title = Model.CategoryTitle;
           
            listViewCategories.ItemTemplate = new DataTemplate(typeof(CategoriesProductPage));
            //listViewCategories.ItemsSource = listData;
            listViewCategories.ItemTapped += listViewCategories_ItemTapped;


            //if (ToolbarItems.Count > 0)
            //{
            //    DependencyService.Get<IToolbarItemBadgeService>().SetBadge(this, ToolbarItems.First(), "20", Color.Red, Color.White);
            //}

            //NavigationPage.SetHasBackButton();
            //NavigationPage.SetBackButtonTitle(this,"");
        }

        private void listViewCategories_ItemTapped(object sender, Syncfusion.ListView.XForms.ItemTappedEventArgs e)
        {
            listViewCategories.SelectionBackgroundColor = Color.Transparent;
            this.Title = "";
            listViewCategories.SelectedItem = null;
            //ProductCategoriesListModel data = e.ItemData as ProductCategoriesListModel;
            //Navigation.PushAsync(new AddToShoppingCartPage(data));
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            this.Title = PageTitle;
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
         
          
        }
	}
}
