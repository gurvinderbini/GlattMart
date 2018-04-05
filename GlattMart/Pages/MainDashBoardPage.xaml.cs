using System;
using System.Collections.Generic;
using System.Linq;
using GlattMart.Helpers;
using GlattMart.ListViewCell;
using GlattMart.Models;
using GlattMart.PageModels;
using Syncfusion.ListView.XForms;
using Xamarin.Forms;

namespace GlattMart.Pages
{
    public partial class MainDashBoardPage : ContentPage
    {
        List<CategoriesListModel> listData = new List<CategoriesListModel>();
        String[] CategoryTitle = new String[] { "Bakery","Fish","Freezer","Fridge","Fruits & Vegetables","Groceries","Meat","Nuts & Candy","Takeout & Deli","Wine/Liquor"};
        String PageTitle = "";
        MainDashBoardPageModel uvm;
        public MainDashBoardPage()
        {
            InitializeComponent();

            uvm = new MainDashBoardPageModel();
            BindingContext = uvm;

            NavigationPage.SetHasNavigationBar(this, false);
            PageTitle = this.Title;

            //for (int i = 0; i < CategoryTitle.Length; i++)
            //{
            //    CategoriesListModel model = new CategoriesListModel();
            //    model.CategoryTitle = CategoryTitle[i];
            //    listData.Add(model);
            //}
            listViewDashboard.ItemTemplate = new DataTemplate(typeof(DashboardListviewCell));
            //listViewDashboard.ItemsSource = listData;
            listViewDashboard.ItemTapped += listViewDashboard_ItemTapped;
            // searchEntry.TextChanged += searchEntry_TextChanged;
            //lbl_username.Text=  Settings.UserName;
            //lbl_email.Text = Settings.Email;

          
        }

        private void searchEntry_TextChanged(object sender, TextChangedEventArgs e)
        {
            if(e.NewTextValue!=null||e.NewTextValue!="")
            {
                if (listViewDashboard.DataSource != null)
                {
                    this.listViewDashboard.DataSource.Filter = FilterContacts;
                    this.listViewDashboard.DataSource.RefreshFilter();
                }
            }
        }

        void hamburgerButton_Clicked(object sender, EventArgs e)
        {
            navigationDrawer.ToggleDrawer();
        }

        async void logout_Clicked(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(Settings.UserName))
            {
                await Application.Current.MainPage.Navigation.PushModalAsync(new LoginPage(), true);
            }
            else
            {
                Settings.UserName = String.Empty;

                await Navigation.PushAsync(new LoginPage());
                var pages = Navigation.NavigationStack.ToList();
                foreach (var page in pages)
                {
                    if (page.GetType() != typeof(LoginPage))
                        Navigation.RemovePage(page);
                }

            }

           
            //Navigation.PushAsync(new LoginPage());
        }

        private void listViewDashboard_ItemTapped(object sender, Syncfusion.ListView.XForms.ItemTappedEventArgs e)
        {
            this.Title = "";
            listViewDashboard.SelectionBackgroundColor = Color.Transparent;
            listViewDashboard.SelectedItem = null;
            //CategoriesListModel binding = e.ItemData as CategoriesListModel;
            //this.Title = "";
            //Navigation.PushAsync(new CategoriesPage(binding));
        }


        private bool FilterContacts(object obj)
        {
            if (searchEntry == null || searchEntry.Text == null)
                return true;

            var contacts = obj as Subcategory;
            if (contacts.name.ToLower().Contains(searchEntry.Text.ToLower()))
                return true;
            else
                return false;
        }
		protected override void OnAppearing()
		{
            base.OnAppearing();

            this.Title = PageTitle;
		    if (!String.IsNullOrEmpty(Settings.UserName))
		    {
		        LoggedInView.IsVisible = true;
		        NotLoggedInView.IsVisible = false;
		        EmailLabel.Text = Settings.Email;
		        FullNameLabel.Text = Settings.UserName;

		        LoginLabel.Text = "Logout";

		    }
		    else
		    {
		        LoggedInView.IsVisible = false;
		        NotLoggedInView.IsVisible = true;
		        EmailLabel.Text = String.Empty;
		        FullNameLabel.Text = String.Empty;

		        LoginLabel.Text = "Login";
		    }
        }

        private void Button_OnClicked(object sender, EventArgs e)
        {
            if (searchEntry.Text != null || searchEntry.Text != "")
            {
                if (listViewDashboard.DataSource != null)
                {
                    this.listViewDashboard.DataSource.Filter = FilterContacts;
                    this.listViewDashboard.DataSource.RefreshFilter();
                }
            }
        }
    }
}
