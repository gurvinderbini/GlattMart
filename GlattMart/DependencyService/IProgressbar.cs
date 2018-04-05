using System;
namespace GlattMart
{
    public interface IProgressbar
    {
        void Show(string message = "Loading");

        void Hide();
    }
}
