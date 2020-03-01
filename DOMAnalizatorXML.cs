using System;
using System.Collections.Generic;
using System.Xml;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPLab3
{
    public class DOMAnalizatorXML : AnalizatorXMLStrategy
    {
        public DOMAnalizatorXML(string _path) : base(_path)
        { }

        override public List<Element> Search(Element element)
        {
            List<Element> result = new List<Element>();
            XmlDocument doc = new XmlDocument();
            doc.Load(path);

            XmlNode node = doc.DocumentElement;


            foreach(XmlNode nod in node.ChildNodes)
            {
                Element el = new Element();

                foreach (XmlAttribute attribute in nod.Attributes)
                {
                    if(attribute.Name.Equals("mass") &&
                        (double.Parse(attribute.Value.ToString()) <= element.mass[1]
                        && double.Parse(attribute.Value.ToString()) >= element.mass[0]))
                        el.Mass = attribute.Value;
                    else if(attribute.Name.Equals("group") && (attribute.Value.Equals(element.Group) || element.Group.Equals(String.Empty)))
                        el.Group = attribute.Value;
                    else if(attribute.Name.Equals("period") && (attribute.Value.Equals(element.Period) || element.Period.Equals(String.Empty)))
                        el.Period = attribute.Value;
                    else if(attribute.Name.Equals("class") && (attribute.Value.Equals(element.Class) || element.Class.Equals(String.Empty)))
                        el.Class = attribute.Value;
                    else if (attribute.Name.Equals("name"))
                        el.Name = attribute.Value;
                    else if (attribute.Name.Equals("number"))
                        el.Number = attribute.Value;
                    else if (attribute.Name.Equals("symbol"))
                        el.Symbol = attribute.Value;
                }

                if (!el.HasEmptyValue())
                {
                    result.Add(el);
                }
                
            }
            return result;
        }
    }
}
