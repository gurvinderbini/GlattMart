using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Syncfusion.ListView.XForms;
using Xamarin.Forms;

namespace GlattMart
{
    public partial class ShoppingCartListPage : ContentPage
    {
        List<ShoppingCartModel> listData = new List<ShoppingCartModel>();
        String[] ProductTitle = new String[] { "Pita Mini 6 ct","Super Pita","Love Bakery Baguette","Whole Wheat Bread","White Bread","Classic Le PalAIS Section Bread","Rudi's Organic Bakery Bread 100% Whole Wheat",
            "Stren's Bread 100% Whole Wheat","Victory Bread Puri","International Pita"};
        String[] ProductNo = new String[] { "#8370", "#8371", "#8372", "#8375", "#8376", "#8377", "#8381", "#8382", "#8398", "#8399" };
        String[] Size = new String[] { "10.00 ct", "6.00 ct", "1.00 ct", "27.00 OZ", "1.00 EA", "1.00 EA", "22.00 Ounc", "21.00 Oz", "16.00 OZ", "8.00Z" };
        string PageTitle = "";
        ShoppingCartListPageModel vm;
        public ShoppingCartListPage()
        {
            InitializeComponent();
            vm = new ShoppingCartListPageModel();
            BindingContext = vm;
            this.Title ="Shopping Cart";
            //for (int i = 0; i < 3; i++)
            //{
            //    ShoppingCartModel model = new ShoppingCartModel();
            //    model.ProductTitle = ProductTitle[i];
            //    model.ProductNo = ProductNo[i];
            //    model.Size = Size[i];
            //    model.PCK = 1 + "";
            //    model.QTY = i+"";
            //    model.Price = "$ 10" + i;
            //    //model.UPC = "0-94046-10061-" + i;

            //    listData.Add(model);
            //}
            this.Title = "Shopping Cart";
            PageTitle = this.Title;
            //listViewShoppingCart.ItemTemplate = new DataTemplate(typeof(ShoppingCartListViewCell));
            //listViewShoppingCart.ItemsSource = listData;
            //listViewShoppingCart.ItemTapped += listViewShoppingCart_ItemTapped;
        }

        private void listViewShoppingCart_ItemTapped(object sender, Syncfusion.ListView.XForms.ItemTappedEventArgs e)
        {
           
        }
    }

    public class ShoppingCartModel
    {
        public string ProductTitle { get; set; }
        public string ProductNo { get; set; }
        public string Size { get; set; }
        public string PCK { get; set; }
        public string QTY { get; set; }
        public string Price { get; set; }
    }
}
