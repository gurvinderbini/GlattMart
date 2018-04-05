using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace GlattMart.Models
{
    public class MainMenuModel
    {
        public Category category { get; set; }
        public ObservableCollection<Subcategory> subcategories { get; set; }
    }

    public class Category
    {
        public string CategoryName { get; set; }
        public string categoryId { get; set; }
        public string image { get; set; }
    }

    public class Subcategory
    {
        public string name { get; set; }
        public string subCategoryId { get; set; }
        public string image { get; set; }
    }
}
