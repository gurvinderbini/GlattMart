using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Net.Http;
using System.Threading.Tasks;
using GlattMart.Helper;
using GlattMart.Models;
using GlattMart.Pages;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace GlattMart
{
    public class ProductListingPageModel: FreshMvvm.FreshBasePageModel, INotifyPropertyChanged
    {
        ServiceResponse<string> data = new ServiceResponse<String>();
        Subcategory Category;
       
        public ProductListingPageModel(Subcategory category)
        {
            Category = category;
            InitialPage();

        }
        public async void InitialPage()
        {
            await Task.Factory.StartNew(() =>
            {
                DependencyService.Get<IProgressbar>().Show("");
                ProductListParamModel param = new ProductListParamModel();
                param.token = ConstantData.token;
                param.id = Category.subCategoryId;
                data = ServiceManager.GenericRestCallUsingHttpClient<string, ProductListParamModel>("product/list", HttpMethod.Post, param);
            });
            DependencyService.Get<IProgressbar>().Hide();
            if (data != null)
            {
                if (data.Data != null)
                {
                    var CategoryData = JsonConvert.DeserializeObject<ProductListModel>(data.Data);
                    MainCategoryData = CategoryData;
                    SubCategoryData = MainCategoryData.products;
                }
            }
        }

        private ProductListModel mainCategoryData;
        public ProductListModel MainCategoryData
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

        public Command ShoppingCartNavigationCommand
        {
            get
            {
                return new Command(async () =>
                {
                    await Application.Current.MainPage.Navigation.PushAsync(new ShoppingCartListPage());

                });
            }
        }

        private ObservableCollection<Product> subCategoryData;
        public ObservableCollection<Product> SubCategoryData
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

        private Product selectedProductData;
        public Product OnSelectedProductData
        {
            get
            {
                return selectedProductData;
            }

            set
            {
                selectedProductData = value;
                if (value != null)
                {
                    OnPropertyChanged("OnSelectedProductData");
                    SelectedCategory.Execute(value);
                }
            }
        }

        public Command<Product> SelectedCategory
        {
            get
            {
                return new Command<Product>(async (dashBoardSelected) =>
                {
                    //await Task.Factory.StartNew(() =>
                    //{
                    //    DependencyService.Get<IProgressbar>().Show("");
                    //    ProductListParamModel param = new ProductListParamModel();
                    //    param.token = ConstantData.token;
                    //    param.id = dashBoardSelected.subCategoryId;
                    //    data = ServiceManager.GenericRestCallUsingHttpClient<string, ProductListParamModel>("product/list", HttpMethod.Post, param);
                    //});
                    //DependencyService.Get<IProgressbar>().Hide();
                    //if (data != null)
                    //{
                    //    if (data.Data != null)
                    //    {
                    //        JToken token = JToken.Parse(data.Data);

                    //        var participantsFromToken = token["products"];
                    //        if (participantsFromToken == null)
                    //        {
                    //            await Application.Current.MainPage.Navigation.PushAsync(new CategoriesPage(dashBoardSelected));
                    //        }
                    //        else
                    //        {
                    //            await Application.Current.MainPage.Navigation.PushAsync(new ProductListingPage(dashBoardSelected));
                    //        }
                    //    }
                    //}
                    await  Application.Current.MainPage.Navigation.PushAsync(new AddToShoppingCartPage(dashBoardSelected));
                    //await CoreMethods.PushPageModel<IBDPublicationTabPageModel>();
                });
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
