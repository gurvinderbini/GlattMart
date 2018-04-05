using System;
using System.Collections.Generic;
using System.Linq;
using BadgeView.iOS;
using FFImageLoading;
using FFImageLoading.Forms.Touch;
using FFImageLoading.Transformations;
using Foundation;
using Syncfusion.ListView.XForms.iOS;
using Syncfusion.SfNumericUpDown.XForms.iOS;
using UIKit;

namespace GlattMart.iOS
{
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {

            CachedImageRenderer.Init();

            var ignore = new CircleTransformation();

            var config = new FFImageLoading.Config.Configuration()
            {
                VerboseLogging = false,
                VerbosePerformanceLogging = false,
                VerboseMemoryCacheLogging = false,
                VerboseLoadingCancelledLogging = false,
                Logger = new CustomLogger(),
            };
            ImageService.Instance.Initialize(config);
            new Syncfusion.SfNavigationDrawer.XForms.iOS.SfNavigationDrawerRenderer(); 
            global::Xamarin.Forms.Forms.Init();
            SfListViewRenderer.Init();
            CircleViewRenderer.Initialize();
            new SfNumericUpDownRenderer();
            LoadApplication(new App());

            return base.FinishedLaunching(app, options);
        }


        public class CustomLogger : FFImageLoading.Helpers.IMiniLogger
        {
            public void Debug(string message)
            {
                Console.WriteLine(message);
            }

            public void Error(string errorMessage)
            {
                Console.WriteLine(errorMessage);
            }

            public void Error(string errorMessage, Exception ex)
            {
                Error(errorMessage + System.Environment.NewLine + ex.ToString());
            }
        }
    }
}
