using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace WPFAttachedProperty.Utils
{
    public class TextBoxHelper
    {
        private static void OnUseOnPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var texBox = d as TextBox;
            if (texBox == null)
                return;
            if ((bool)e.NewValue)
            {
                texBox.TextChanged += TextBox_TextChanged;
            }
            else
            {
                texBox.TextChanged -= TextBox_TextChanged;
            }
        }

        private static void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            BindingExpression bindingExpression = textBox.GetBindingExpression(TextBox.TextProperty);
            bindingExpression?.UpdateSource();
        }

        public static readonly DependencyProperty UseOnPropertyChangedProperty = DependencyProperty.RegisterAttached("UseOnPropertyChanged",
            typeof(bool), typeof(TextBoxHelper), new PropertyMetadata(false, OnUseOnPropertyChanged));

        public static bool GetUseOnPropertyChanged(DependencyObject obj)
        {
            return (bool)obj.GetValue(UseOnPropertyChangedProperty);
        }

        public static void SetUseOnPropertyChanged(DependencyObject obj, bool value)
        {
            obj.SetValue(UseOnPropertyChangedProperty, value);
        }
    }
}
