using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace AdbUtils
{
    public static class XMLExtensionMethods
    {
        public static string IdentXML(this string rawXML)
        {
            var ms = new MemoryStream();
            var xmlDocument = new XmlDocument();
            var xmlWriter = new XmlTextWriter(ms, Encoding.Unicode);

            xmlDocument.LoadXml(rawXML);
            xmlWriter.Formatting = Formatting.Indented;
            xmlDocument.WriteContentTo(xmlWriter);
            xmlWriter.Flush();
            ms.Flush();
            ms.Position = 0;

            StreamReader reader = new StreamReader(ms);
            string xmlFormatted = reader.ReadToEnd();

            reader.Close();
            ms.Close();
            xmlWriter.Close();

            return xmlFormatted;            
        }

        public static List<UINode> GetUINodes(this string uiXML) =>
            XDocument.Parse(uiXML)
                    .Descendants()
                    .Select(x => x.Attributes().AssignAttribute()).ToList();                     
        

        public static UINode AssignAttribute(this IEnumerable<XAttribute> attrs)
        {
            var uiNode = new UINode();

            foreach(var attr in attrs)
            {
                if(attr.Name == "index")
                {
                    uiNode.Index = int.Parse(attr.Value);
                }
                else if(attr.Name == "text")
                {
                    uiNode.Text = attr.Value;
                }
                else if(attr.Name == "resource-id")
                {
                    uiNode.ResourceId = attr.Value;
                }
                else if(attr.Name == "class")
                {
                    uiNode.Class = attr.Value;
                }
                else if(attr.Name == "package")
                {
                    uiNode.Package = attr.Value;
                }
                else if(attr.Name == "content-desc")
                {
                    uiNode.ContentDescription = attr.Value;
                }
                else if(attr.Name == "checkable")
                {
                    uiNode.Checkable = bool.Parse(attr.Value);
                }
                else if(attr.Name == "checked")
                {
                    uiNode.Checked = bool.Parse(attr.Value);
                }
                else if(attr.Name == "clickable")
                {
                    uiNode.Clickable = bool.Parse(attr.Value);
                }
                else if(attr.Name == "enabled")
                {
                    uiNode.Enabled = bool.Parse(attr.Value);
                }
                else if(attr.Name == "focusable")
                {
                    uiNode.Focusable = bool.Parse(attr.Value);
                }
                else if(attr.Name == "focused")
                {
                    uiNode.Focused = bool.Parse(attr.Value);
                }
                else if(attr.Name == "scrollable")
                {
                    uiNode.Scrollable = bool.Parse(attr.Value);
                }
                else if(attr.Name == "long-clickable")
                {
                    uiNode.LongClickable = bool.Parse(attr.Value);
                }
                else if(attr.Name == "password")
                {
                    uiNode.Password = bool.Parse(attr.Value);
                }
                else if(attr.Name == "selected")
                {
                    uiNode.Selected = bool.Parse(attr.Value);
                }
                else if(attr.Name == "bounds")
                {
                    uiNode.Bounds = new Bounds(attr.Value);
                }                  
            }

            return uiNode;
        }
    }
}
