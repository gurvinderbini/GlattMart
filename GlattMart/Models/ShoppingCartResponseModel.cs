using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace GlattMart.Models
{
    public class ShoppingCartResponseModel
    {
        public List<string> msg { get; set; }
        public ObservableCollection<ProductDetail> productDetails { get; set; }
        public string discount { get; set; }
        public Totals totals { get; set; }
    }

    public class ProductDetail
    {
        public string productName { get; set; }
        public int quantity { get; set; }
        public string productId { get; set; }
        public string price { get; set; }
        public string image { get; set; }
        public string subtotal { get; set; }
    }

    public class Totals
    {
        public object grandTotal { get; set; }
        public object subtotal { get; set; }
    }
}
