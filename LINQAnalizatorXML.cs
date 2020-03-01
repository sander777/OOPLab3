using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPLab3
{
    public class LINQAnalizatorXML : AnalizatorXMLStrategy
    {
        public LINQAnalizatorXML(string _path) : base(_path)
        { }

        override public List<Element> Search(Element element)
        {
            List<Element> result = new List<Element>();

            var doc = XDocument.Load(path);
            var r = doc.Descendants("element");
            IEnumerable<XElement> matches = from val in doc.Descendants("element")
                                            where (((double.Parse(val.Attribute("mass").Value.ToString()) >= element.mass[0]) &&
                                            (double.Parse(val.Attribute("mass").Value.ToString()) <= element.mass[1])) &&
                                            (element.Group.Equals(String.Empty) || element.Group == val.Attribute("group").Value) &&
                                            (element.Period.Equals(String.Empty) || element.Period == val.Attribute("period").Value) &&
                                            (element.Class.Equals(String.Empty) || element.Class == val.Attribute("class").Value))
                                            select val;

            foreach (XElement match in matches)
            {
                Element res = new Element();
                res.Symbol = match.Attribute("symbol").Value;
                res.Name = match.Attribute("name").Value;
                res.Number = match.Attribute("number").Value;
                res.Mass = match.Attribute("mass").Value;
                res.Period = match.Attribute("period").Value;
                res.Group = match.Attribute("group").Value;
                res.Class = match.Attribute("class").Value;
                result.Add(res);
            }
            return result;
        }
    }
}
