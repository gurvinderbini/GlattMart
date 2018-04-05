using System;
namespace GlattMart.Models
{
    public class SignupModelResponse
    {
        public bool result { get; set; }
        public string msg { get; set; }
        public Model model { get; set; }
    }
    //public class Model
    //{
    //    public string id { get; set; }
    //    public string firstname { get; set; }
    //    public string lirstname { get; set; }
    //    public string email { get; set; }
    //    public object customer_number { get; set; }
    //    public string customer_group { get; set; }
    //}
}
