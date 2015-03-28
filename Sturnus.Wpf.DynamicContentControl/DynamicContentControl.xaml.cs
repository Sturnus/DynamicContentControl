// <copyright file="DynamicContentControl.xaml.cs">
// Copyright (c) 2015 Jeroen Spreeuwenberg
// </copyright>
// <author>Jeroen Spreeuwenberg</author>

using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace Sturnus.Wpf.DynamicContentControl
{
    /// <summary>
    /// Interaction logic for DynamicContentControl.xaml
    /// </summary>
    public partial class DynamicContentControl : UserControl
    {
        #region Constructors
        public DynamicContentControl()
        {
            InitializeComponent();
        }
        #endregion

        #region (Dependency) Properties
        public static readonly DependencyProperty XamlNamespacesProperty = DependencyProperty.Register("XamlNamespaces", typeof(IEnumerable<string>), typeof(DynamicContentControl), new PropertyMetadata(new List<string>() { @"xmlns=""http://schemas.microsoft.com/winfx/2006/xaml/presentation""", @"xmlns:x=""http://schemas.microsoft.com/winfx/2006/xaml""" }, null));

        public IEnumerable<string> XamlNamespaces
        {
            get { return (IEnumerable<string>)GetValue(XamlNamespacesProperty); }
            set { SetValue(XamlNamespacesProperty, value); }
        }

        public static readonly DependencyProperty XamlTextProperty = DependencyProperty.Register("XamlText", typeof(string), typeof(DynamicContentControl), new PropertyMetadata("<Grid />", OnXamlTextChanged));

        public string XamlText
        {
            get { return (string)GetValue(XamlTextProperty); }
            set { SetValue(XamlTextProperty, value); }
        }
        #endregion

        #region Methods
        private static void OnXamlTextChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            (d as DynamicContentControl).OnXamlTextChanged(e);
        }

        private void OnXamlTextChanged(DependencyPropertyChangedEventArgs e)
        {
            DynamicContentControlLayoutRoot.Children.Clear();
            DynamicContentControlLayoutRoot.Children.Add(ParseXamlText(XamlText, XamlNamespaces));
        }

        private UIElement ParseXamlText(string xamlText, IEnumerable<string> xamlNamespaces)
        {
            return (UIElement)XamlReader.Parse(xamlText, xamlNamespaces);
        }
        #endregion
    }
}
