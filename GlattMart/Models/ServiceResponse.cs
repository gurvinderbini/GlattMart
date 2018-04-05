using System;
namespace GlattMart
{
    public class ServiceResponse<T> : ResponseBase
    {
        public T Data { get; set; }
    }
}
