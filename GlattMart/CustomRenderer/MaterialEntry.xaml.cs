using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace GlattMart
{
    public partial class MaterialEntry : ContentView
    {
        public static BindableProperty TextProperty = BindableProperty.Create(nameof(Text), typeof(string), typeof(MaterialEntry), defaultBindingMode: BindingMode.TwoWay);
        public static BindableProperty PlaceholderProperty = BindableProperty.Create(nameof(Placeholder), typeof(string), typeof(MaterialEntry), defaultBindingMode: BindingMode.TwoWay, propertyChanged: (bindable, oldVal, newval) =>
        {
            var matEntry = (MaterialEntry)bindable;
            matEntry.EntryField.Placeholder = (string)newval;
            matEntry.HiddenLabel.Text = (string)newval;
        });

        public static BindableProperty PlaceholderColorProperty = BindableProperty.Create(nameof(PlaceholderColor), typeof(Color), typeof(MaterialEntry), Color.White, defaultBindingMode: BindingMode.TwoWay, propertyChanged: (bindable, oldVal, newval) =>
        {
            var matEntry = (MaterialEntry)bindable;
            matEntry.EntryText.PlaceholderColor = (Color)newval;
            //matEntry.EntryField.Placeholder = (string)newval;
            //matEntry.HiddenLabel.Text = (string)newval;
        });

        public static BindableProperty TextColorProperty = BindableProperty.Create(nameof(TextColor), typeof(Color), typeof(MaterialEntry), Color.White, defaultBindingMode: BindingMode.TwoWay, propertyChanged: (bindable, oldVal, newval) =>
        {
            var matEntry = (MaterialEntry)bindable;
            matEntry.EntryText.TextColor = (Color)newval;
            //matEntry.EntryField.Placeholder = (string)newval;
            //matEntry.HiddenLabel.Text = (string)newval;
        });

        public static BindableProperty IsPasswordProperty = BindableProperty.Create(nameof(IsPassword), typeof(bool), typeof(MaterialEntry), defaultValue: false, propertyChanged: (bindable, oldVal, newVal) =>
        {
            var matEntry = (MaterialEntry)bindable;
            matEntry.EntryField.IsPassword = (bool)newVal;
        });
        public static BindableProperty KeyboardProperty = BindableProperty.Create(nameof(Keyboard), typeof(Keyboard), typeof(MaterialEntry), defaultValue: Keyboard.Default, propertyChanged: (bindable, oldVal, newVal) =>
        {
            var matEntry = (MaterialEntry)bindable;
            matEntry.EntryField.Keyboard = (Keyboard)newVal;
        });

        public event System.EventHandler<TextChangedEventArgs> TextChangedEvent; //In OnContentViewTextChangedEvent() we return our custom InputFieldContentView control as the sender but we could have returned the Entry itself as the sender if we wanted to do that instead.


        public static BindableProperty MaxLenghtProperty = BindableProperty.Create("MaxLenght", typeof(int), typeof(MaterialEntry), defaultValue: default(int), propertyChanged: (bindable, oldVal, newVal) =>
        {
            var matEntry = (MaterialEntry)bindable;
            matEntry.EntryField.Behaviors.Add(new EntryLengthValidatorBehavior { MaxLength = (int)newVal });
        });


        //private void OnTextChangedEvent(object sender, TextChangedEventArgs args)
        //{
        //  if (TextChangedEvent != null) { 
        //              TextChangedEvent(this, new TextChangedEventArgs(args.OldTextValue, args.NewTextValue)); 
        //          } //Here is where we pass in 'this' (which is the InputFieldContentView) instead of 'sender' (which is the Entry control)
        //}

        //public static readonly BindableProperty EntryTextProperty = BindableProperty.Create("EntryText", typeof(string), typeof(MaterialEntry), string.Empty, BindingMode.TwoWay, null, OnEntryTextChanged);

        //private static void OnEntryTextChanged(BindableObject bindable, object oldValue, object newValue)
        //{
        //          MaterialEntry contentView = (MaterialEntry)bindable;
        //  contentView.EntryText = (string)newValue;
        //}

        public CustomEntry EntryText { get; set; }

        public int MaxLenght
        {
            get
            {
                return (int)GetValue(MaxLenghtProperty);
            }
            set
            {
                this.EntryField.Behaviors.Add(new EntryLengthValidatorBehavior { MaxLength = value });
                SetValue(MaxLenghtProperty, value);
            }
        }
        public static BindableProperty AccentColorProperty = BindableProperty.Create(nameof(AccentColor), typeof(Color), typeof(MaterialEntry), defaultValue: Color.Accent);
        public Color AccentColor
        {
            get
            {
                return (Color)GetValue(AccentColorProperty);
            }
            set
            {

                SetValue(AccentColorProperty, value);
            }
        }
        public Keyboard Keyboard
        {
            get
            {
                return (Keyboard)GetValue(KeyboardProperty);
            }
            set
            {
                SetValue(KeyboardProperty, value);
            }
        }

        //public EventHandler<TextChangedEventArgs> TextChanged
        //{
        //    get
        //    {

        //        return (EventHandler<TextChangedEventArgs>)GetValue(TextChangedProperty);
        //    }
        //    set
        //    {

        //        SetValue(TextChangedProperty,value);
        //    }
        //}

        public bool IsPassword
        {
            get
            {
                return (bool)GetValue(IsPasswordProperty);
            }
            set
            {
                SetValue(IsPasswordProperty, value);
            }
        }

        public string Text
        {
            get
            {
                return (string)GetValue(TextProperty);
            }
            set
            {
                SetValue(TextProperty, value);
            }
        }
        public string Placeholder
        {
            get
            {
                return (string)GetValue(PlaceholderProperty);
            }
            set
            {
                SetValue(PlaceholderProperty, value);
            }
        }

        public Color PlaceholderColor
        {
            get
            {
                return (Color)GetValue(PlaceholderColorProperty);
            }
            set
            {
                SetValue(PlaceholderColorProperty, value);
            }
        }

        public Color TextColor
        {
            get
            {
                return (Color)GetValue(TextColorProperty);
            }
            set
            {
                SetValue(TextColorProperty, value);
            }
        }


        public MaterialEntry()
        {
            InitializeComponent();
            EntryField.BindingContext = this;

            EntryText = EntryField;

            EntryText.TextColor = TextColor;
            EntryText.PlaceholderColor = PlaceholderColor;

            EntryField.Focused += async (s, a) =>
            {
                HiddenBottomBorder.BackgroundColor = AccentColor;
                HiddenLabel.TextColor = AccentColor;
                HiddenLabel.IsVisible = true;
                if (string.IsNullOrEmpty(EntryField.Text))
                {
                    // animate both at the same time
                    await Task.WhenAll(
                    HiddenBottomBorder.LayoutTo(new Rectangle(BottomBorder.X, BottomBorder.Y, BottomBorder.Width, BottomBorder.Height), 200),
                    HiddenLabel.FadeTo(1, 60),
                    HiddenLabel.TranslateTo(HiddenLabel.TranslationX, EntryField.Y - EntryField.Height + 4, 200, Easing.BounceIn)
                 );
                    EntryField.Placeholder = null;
                }
                else
                {
                    await HiddenBottomBorder.LayoutTo(new Rectangle(BottomBorder.X, BottomBorder.Y, BottomBorder.Width, BottomBorder.Height), 200);
                }
            };


            EntryField.Unfocused += async (s, a) =>
            {
                HiddenLabel.TextColor = Color.Gray;
                if (string.IsNullOrEmpty(EntryField.Text))
                {
                    // animate both at the same time
                    await Task.WhenAll(
                    HiddenBottomBorder.LayoutTo(new Rectangle(BottomBorder.X, BottomBorder.Y, 0, BottomBorder.Height), 200),
                    HiddenLabel.FadeTo(0, 180),
                    HiddenLabel.TranslateTo(HiddenLabel.TranslationX, EntryField.Y, 200, Easing.BounceIn)
                 );
                    EntryField.Placeholder = Placeholder;
                }
                else
                {
                    await HiddenBottomBorder.LayoutTo(new Rectangle(BottomBorder.X, BottomBorder.Y, 0, BottomBorder.Height), 200);
                }
            };
        }
    }

}
