// <copyright file="XamlNamespaceReader.cs">
// Copyright (c) 2015 Jeroen Spreeuwenberg
// </copyright>
// <author>Jeroen Spreeuwenberg</author>

namespace Sturnus.Wpf.DynamicContentControl
{
    public class XamlNamespaceReader
    {
        #region Methods
        public static XamlNamespace Parse(string xamlNamespaceText)
        {
            // Declare local variables
            XamlNamespace xamlNamespace = new XamlNamespace();

            if (xamlNamespaceText.StartsWith("xmlns"))
            {
                // Read and set the prefix
                xamlNamespace.Prefix = xamlNamespaceText.Substring(0, xamlNamespaceText.IndexOf("=")).Replace("xmlns", "").Trim(':');

                if (xamlNamespaceText.Contains(";assembly="))
                {
                    // Read the assembly and remove it from xamlNamespaceText
                    string assembly = xamlNamespaceText.Substring(xamlNamespaceText.IndexOf(";assembly=")).Trim('"');
                    xamlNamespaceText = xamlNamespaceText.Replace(assembly, "");

                    // Set the assembly
                    xamlNamespace.Assembly = assembly.Replace(";assembly=", "");
                }

                if (xamlNamespaceText.Contains("clr-namespace:"))
                {
                    // Read the clr namespace and remove it from xamlNamespaceText
                    string clrNameSpace = xamlNamespaceText.Substring(xamlNamespaceText.IndexOf("clr-namespace:")).Trim('"');
                    xamlNamespaceText = xamlNamespaceText.Replace(clrNameSpace, "");

                    // Set the clr and xml namespaces
                    xamlNamespace.ClrNamespace = clrNameSpace.Replace("clr-namespace:", "");
                    xamlNamespace.XmlNamespace = clrNameSpace;

                    // If the assembly was not previously set, set it to the clr namespace
                    if (string.IsNullOrWhiteSpace(xamlNamespace.Assembly))
                        xamlNamespace.Assembly = xamlNamespace.ClrNamespace;
                }
                else
                {
                    // Read and set the xaml namespace
                    xamlNamespace.XmlNamespace = xamlNamespaceText.Substring(xamlNamespaceText.IndexOf("=")).Trim('=', '"');
                }
            }

            // Return the xaml namespace
            return xamlNamespace;
        }
        #endregion
    }
}