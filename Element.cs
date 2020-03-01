using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPLab3
{
    public class Element
    {
        public double[] mass = new double[2];
        public string Symbol { get; set; } = "";
        public string Number { get; set; } = "";
        public string Name { get; set; } = "";
        public string Mass { get; set; } = "";
        public string Group { get; set; } = "";
        public string Period { get; set; } = "";
        public string Class { get; set; } = "";


        public bool HasEmptyValue()
        {
            if (Mass == null || Group == null || Period == null || Class == null)
                return true;

            if (Mass == "" || Group == "" || Period == "" || Class == "")
                return true;

            return false;
        }
    }
}
