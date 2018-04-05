using System;
namespace GlattMart
{
    public class ProductDetailModel
    {
        public string id { get; set; }
        public string sku { get; set; }
        public string Name { get; set; }
        public object image { get; set; }
        public string price { get; set; }
        public string description { get; set; }
        public string shortDescription { get; set; }
        public object stockQty { get; set; }
        public bool is_in_stock { get; set; }
        public string is_salable { get; set; }
        public string smallImg { get; set; }
        public string baseImg { get; set; }
        public string thumbnail { get; set; }
    }
}
