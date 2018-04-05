using System;
using BigTed;
using GlattMart.iOS;
using Xamarin.Forms;

[assembly: Dependency(typeof(LoadProgressbar))]
namespace GlattMart.iOS
{
    public class LoadProgressbar: IProgressbar
    {
        public LoadProgressbar()
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                BTProgressHUD.ForceiOS6LookAndFeel = true;
            });
        }

        public void Hide()
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                BTProgressHUD.Dismiss();
            });
        }

        public void Show(string message = "Loading")
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                BTProgressHUD.Show(maskType: ProgressHUD.MaskType.Gradient);
            });
        }
    }
}
