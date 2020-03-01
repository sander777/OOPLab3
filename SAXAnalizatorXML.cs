using System;
using System.Collections.Generic;
using System.Xml;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPLab3
{
    public class SAXAnalizatorXML : AnalizatorXMLStrategy
    {
        public SAXAnalizatorXML(string _path) : base(_path)
        { }

        override public List<Element> Search(Element element)
        {
            List<Element> result = new List<Element>();
            Element el = null;
            XmlReader reader = XmlReader.Create(path);

            while (reader.Read())
            {
                switch (reader.NodeType)
                {
                    case XmlNodeType.Element:
                        if (reader.Name == "element")
                        {
                            el = new Element();
                            while (reader.MoveToNextAttribute())
                            {
                                if (reader.Name.Equals("mass") &&
                                    (double.Parse(reader.Value.ToString()) <= element.mass[1]
                                    && double.Parse(reader.Value.ToString()) >= element.mass[0]))
                                    el.Mass = reader.Value;
                                else if (reader.Name.Equals("group") && (reader.Value.Equals(element.Group) || element.Group.Equals(String.Empty)))
                                    el.Group = reader.Value;
                                else if (reader.Name.Equals("period") && (reader.Value.Equals(element.Period) || element.Period.Equals(String.Empty)))
                                    el.Period = reader.Value;
                                else if (reader.Name.Equals("class") && (reader.Value.Equals(element.Class) || element.Class.Equals(String.Empty)))
                                    el.Class = reader.Value;
                                else if (reader.Name.Equals("name"))
                                    el.Name = reader.Value;
                                else if (reader.Name.Equals("number"))
                                    el.Number = reader.Value;
                                else if (reader.Name.Equals("symbol"))
                                    el.Symbol = reader.Value;
                            }
                            if(!el.HasEmptyValue())
                                result.Add(el);


                        }
                        break;
                }
            }
            return result;
        }
    }
}
