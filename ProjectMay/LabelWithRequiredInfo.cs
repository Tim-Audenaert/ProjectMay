using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace ProjectMay
{
    //SOURCE: https://stackoverflow.com/questions/33256045/wpf-validation-depending-on-required-not-required-field/33385575
    public class LabelWithRequiredInfo : Label
    {
        public bool IsRequired
        {
            get { return (bool)GetValue(IsRequiredProperty); }
            set { SetValue(IsRequiredProperty, value); }
        }

        // Using a DependencyProperty as the backing store for IsRequired.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IsRequiredProperty =
            DependencyProperty.Register("IsRequired", typeof(bool), typeof(LabelWithRequiredInfo), new PropertyMetadata(false));
        static LabelWithRequiredInfo()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(LabelWithRequiredInfo), new FrameworkPropertyMetadata(typeof(LabelWithRequiredInfo)));
        }
    }
}
