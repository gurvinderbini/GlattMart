using System;
using Xamarin.Forms;

namespace GlattMart
{
    public class Gradient_Stack : StackLayout
    {
        //public Color StartColor { get; set; }
        //public Color EndColor { get; set; }

        public static readonly BindableProperty StartColorProperty =
            BindableProperty.Create(propertyName: nameof(StartColor),
              returnType: typeof(Color),
                                  declaringType: typeof(Gradient_Stack),
              defaultValue: Color.Accent);

        public static readonly BindableProperty EndColorProperty =
            BindableProperty.Create(propertyName: nameof(EndColor),
               returnType: typeof(Color),
                                   declaringType: typeof(Gradient_Stack),
               defaultValue: Color.Accent);

        public Color StartColor
        {
            get { return (Color)GetValue(StartColorProperty); }
            set { SetValue(StartColorProperty, value); }
        }

        public Color EndColor
        {
            get { return (Color)GetValue(EndColorProperty); }
            set { SetValue(EndColorProperty, value); }
        }
    }
}