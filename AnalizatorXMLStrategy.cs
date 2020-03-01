using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPLab3
{
    public abstract class AnalizatorXMLStrategy
    {
        protected string path;
        
        public AnalizatorXMLStrategy(string _path)
        {
            path = _path;
        }
        public abstract List<Element> Search(Element element);
    }
}
