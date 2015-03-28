// <copyright file="XamlNamespace.cs">
// Copyright (c) 2015 Jeroen Spreeuwenberg
// </copyright>
// <author>Jeroen Spreeuwenberg</author>

namespace Sturnus.Wpf.DynamicContentControl
{
    public class XamlNamespace
    {
        #region Properties
        public string Prefix { get; set; }
        public string XmlNamespace { get; set; }
        public string ClrNamespace { get; set; }
        public string Assembly { get; set; }
        #endregion
    }
}