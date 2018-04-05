﻿using System;
using Xamarin.Forms;

namespace GlattMart
{
    public class Badge : AbsoluteLayout
    {
        /// <summary>
        /// The text property.
        /// </summary>
        public static readonly BindableProperty TextProperty =
            BindableProperty.Create("Text", typeof(String), typeof(Badge), "");

        /// <summary>
        /// The box color property.
        /// </summary>
        public static readonly BindableProperty BoxColorProperty =
            BindableProperty.Create("BoxColor", typeof(Color), typeof(Badge), Color.Default);

        /// <summary>
        /// The text.
        /// </summary>
        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        /// <summary>
        /// Gets or sets the color of the box.
        /// </summary>
        public Color BoxColor
        {
            get { return (Color)GetValue(BoxColorProperty); }
            set { SetValue(BoxColorProperty, value); }
        }

        /// <summary>
        /// The box.
        /// </summary>
        protected RoundedBox Box;

        /// <summary>
        /// The label.
        /// </summary>
        protected Label Label;

        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroFiveBit.Forms.Basic.Badge"/> class.
        /// </summary>
        public Badge(double size, double fontSize)
        {
            HeightRequest = size;
            WidthRequest = HeightRequest;

            // Box
            Box = new RoundedBox
            {
                CornerRadius = HeightRequest / 2
            };
            Box.SetBinding(BackgroundColorProperty, new Binding("BoxColor", source: this));
            Children.Add(Box, new Rectangle(0, 0, 1.0, 1.0), AbsoluteLayoutFlags.All);

            // Label
            Label = new Label
            {
                TextColor = Color.White,
                FontSize = fontSize,
                XAlign = TextAlignment.Center,
                YAlign = TextAlignment.Center
            };
            Label.SetBinding(Label.TextProperty, new Binding("Text",
                BindingMode.OneWay, source: this));
            Children.Add(Label, new Rectangle(0, 0, 1.0, 1.0), AbsoluteLayoutFlags.All);

            // Auto-width
            SetBinding(WidthRequestProperty, new Binding("Text", BindingMode.OneWay,
                new BadgeWidthConverter(WidthRequest), source: this));

            // Hide if no value
            SetBinding(IsVisibleProperty, new Binding("Text", BindingMode.OneWay,
                new BadgeVisibleValueConverter(), source: this));

            // Default color
            BoxColor = Color.Red;
        }
    }

    /// <summary>
    /// Badge visible value converter.
    /// </summary>
    class BadgeVisibleValueConverter : IValueConverter
    {
        #region IValueConverter implementation

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var text = value as string;
            return !String.IsNullOrEmpty(text);
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        #endregion
    }

    /// <summary>
    /// Badge width converter.
    /// </summary>
    class BadgeWidthConverter : IValueConverter
    {
        /// <summary>
        /// The width of the base.
        /// </summary>
        readonly double baseWidth;

        /// <summary>
        /// The width ratio.
        /// </summary>
        const double widthRatio = 0.33;

        public BadgeWidthConverter(double baseWidth)
        {
            this.baseWidth = baseWidth;
        }

        #region IValueConverter implementation

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var text = value as string;
            if ((text != null) && (text.Length > 1))
            {
                // We won't measure text length exactly here!
                // May be we should, but it's too tricky. So,
                // we'll just approximate new badge width as
                // linear function from text legth.

                return baseWidth * (1 + widthRatio * (text.Length - 1));
            }
            return baseWidth;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
