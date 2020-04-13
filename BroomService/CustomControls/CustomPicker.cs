using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace BroomService.CustomControls
{
    public class CustomPicker : Picker
    {
        public static readonly BindableProperty ImageProperty = BindableProperty.Create(nameof(Icon), typeof(string), typeof(CustomPicker), string.Empty);
        public string Icon
        {
            get
            {
                return (string)GetValue(ImageProperty);
            }
            set
            {
                SetValue(ImageProperty, value);
            }
        }
        public static readonly BindableProperty BorderDisplayProperty = BindableProperty.Create(nameof(IsBorderDisplay), typeof(bool), typeof(CustomPicker), true);
        public bool IsBorderDisplay
        {
            get
            {
                return (bool)GetValue(BorderDisplayProperty);
            }
            set
            {
                SetValue(BorderDisplayProperty, value);
            }
        }
    }
}
