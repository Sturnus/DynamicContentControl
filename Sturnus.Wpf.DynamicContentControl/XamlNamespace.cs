
namespace Sturnus.Wpf.DynamicContentControl
{
    public class XamlNamespace
    {
        #region Constructor
        public XamlNamespace(string xamlNamespace)
        {
            if (xamlNamespace.StartsWith("xmlns"))
            {
                Prefix = xamlNamespace.Substring(0, xamlNamespace.IndexOf("=")).Replace("xmlns", "").Trim(':');

                if (xamlNamespace.Contains(";assembly="))
                {
                    string assembly = xamlNamespace.Substring(xamlNamespace.IndexOf(";assembly=")).Trim('"');
                    xamlNamespace = xamlNamespace.Replace(assembly, "");

                    Assembly = assembly.Replace(";assembly=", "");
                }

                if (xamlNamespace.Contains("clr-namespace:"))
                {
                    string clrNameSpace = xamlNamespace.Substring(xamlNamespace.IndexOf("clr-namespace:")).Trim('"');
                    xamlNamespace = xamlNamespace.Replace(clrNameSpace, "");

                    ClrNamespace = clrNameSpace.Replace("clr-namespace:", "");
                    XmlNamespace = clrNameSpace;

                    if (string.IsNullOrWhiteSpace(Assembly))
                        Assembly = ClrNamespace;
                }
                else
                {
                    XmlNamespace = xamlNamespace.Substring(xamlNamespace.IndexOf("=")).Trim('=', '"');
                }
            }
        }
        #endregion

        #region Properties
        public string Prefix { get; private set; }
        public string XmlNamespace { get; private set; }
        public string ClrNamespace { get; private set; }
        public string Assembly { get; private set; }
        #endregion
    }
}