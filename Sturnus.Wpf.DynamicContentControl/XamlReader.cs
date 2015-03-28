// <copyright file="XamlReader.cs">
// Copyright (c) 2015 Jeroen Spreeuwenberg
// </copyright>
// <author>Jeroen Spreeuwenberg</author>

using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Windows.Markup;

namespace Sturnus.Wpf.DynamicContentControl
{
    public class XamlReader : System.Windows.Markup.XamlReader
    {
        #region Methods
        public static object Parse(string xamlText, IEnumerable<string> xamlNamespaces)
        {
            return Parse(xamlText, xamlNamespaces.Select(s => XamlNamespaceReader.Parse(s)));
        }

        public static object Parse(string xamlText, IEnumerable<XamlNamespace> xamlNamespaces)
        {
            // Declare local variables
            ParserContext parserContext = new ParserContext() { XamlTypeMapper = new XamlTypeMapper(new string[] { }) };

            // Load specified assemblies
            foreach (XamlNamespace xamlNamespace in xamlNamespaces.Where(xn => xn.Assembly != null))
                Assembly.Load(xamlNamespace.Assembly);

            // Add xml namespaces to parser context
            foreach (XamlNamespace xamlNamespace in xamlNamespaces.Where(xn => xn.Prefix != null && xn.XmlNamespace != null))
                parserContext.XmlnsDictionary.Add(xamlNamespace.Prefix, xamlNamespace.XmlNamespace);

            // Add clr namespaces to parser context
            foreach (XamlNamespace xamlNamespace in xamlNamespaces.Where(xn => xn.XmlNamespace != null && xn.ClrNamespace != null && xn.Assembly != null))
                parserContext.XamlTypeMapper.AddMappingProcessingInstruction(xamlNamespace.XmlNamespace, xamlNamespace.ClrNamespace, xamlNamespace.Assembly);

            return Parse(xamlText, parserContext);
        }
        #endregion
    }
}
