using System;
namespace GlattMart.Models
{
    public class SignupParamModel
    {
        public string token { get; set; }
        public string firstname { get; set; }
        public string lastname { get; set; }
        public string company { get; set; }
        public string email { get; set; }
        public string password { get; set; }
    }
}
