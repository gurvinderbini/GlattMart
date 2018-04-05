using System;
using System.Collections.ObjectModel;

namespace GlattMart.Models
{
    public class ProductListModel
    {
        public Category category { get; set; }
        public ObservableCollection<Product> products { get; set; }
    }

    public class Product
    {
        public string name { get; set; }
        public string price { get; set; }
        public string shortDescription { get; set; }
        public string sku { get; set; }
        public string id { get; set; }
        public bool is_in_stock { get; set; }
        public string is_salable { get; set; }
        public string thumbnail { get; set; }
    }
}
