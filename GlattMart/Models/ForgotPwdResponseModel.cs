using System;
using System.Collections.Generic;

namespace GlattMart
{
    public class ForgotPwdResponseModel
    {
        public bool result { get; set; }
        public object error { get; set; }
        public List<string> msg { get; set; }
    }
}
