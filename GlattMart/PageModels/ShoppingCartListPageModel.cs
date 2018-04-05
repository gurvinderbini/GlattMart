using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Net.Http;
using System.Threading.Tasks;
using GlattMart.Helper;
using GlattMart.Models;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace GlattMart
{
    public class ShoppingCartListPageModel: FreshMvvm.FreshBasePageModel, INotifyPropertyChanged
    {
        ServiceResponse<string> data = new ServiceResponse<String>();
       
        public ShoppingCartListPageModel()
        {
           
            InitialPage();
        }
        public async void InitialPage()
        {
            await Task.Factory.StartNew(() =>
            {
                DependencyService.Get<IProgressbar>().Show("");
                CartIndexListParam param = new CartIndexListParam();
                param.token = ConstantData.token;
                data = ServiceManager.GenericRestCallUsingHttpClient<string, CartIndexListParam>("cart/index", HttpMethod.Post,param);
            });
            DependencyService.Get<IProgressbar>().Hide();
            if (data != null)
            {
                if (data.Data != null)
                {
                    var CategoryData = JsonConvert.DeserializeObject<ShoppingCartResponseModel>(data.Data);
                    Subtotal = CategoryData.totals.subtotal+"";
                    GrandTotal=CategoryData.totals.grandTotal + "";
                    Discount = CategoryData.discount;
                    SubCategoryData = CategoryData.productDetails;
                    //MainCategoryData = CategoryData;
                    //SubCategoryData = MainCategoryData.subcategories;
                }
            }
        }

        private string subtotal;
        public string Subtotal
        {
            get { return subtotal; }
            set
            {
                subtotal = value;
                OnPropertyChanged("Subtotal");
            }
        }


        private string grandTotal;
        public string GrandTotal
        {
            get { return grandTotal; }
            set
            {
                grandTotal = value;
                OnPropertyChanged("GrandTotal");
            }
        }

        private string discount;
        public string Discount
        {
            get { return discount; }
            set
            {
                discount = value;
                OnPropertyChanged("Discount");
            }
        }

        private MainMenuModel mainCategoryData;
        public MainMenuModel MainCategoryData
        {
            get
            {
                return mainCategoryData;
            }

            set
            {
                mainCategoryData = value;
            }
        }

        private ObservableCollection<ProductDetail> subCategoryData;
        public ObservableCollection<ProductDetail> SubCategoryData
        {
            get
            {
                return subCategoryData;
            }

            set
            {
                subCategoryData = value;
                if (value != null)
                    OnPropertyChanged("SubCategoryData");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
