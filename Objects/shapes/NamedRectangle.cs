using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows;

namespace SpaceInvadersFV.Objects.shapes
{
    public class NamedRectangle : GenericRectangle
    {
        string name;
        public NamedRectangle(int _height, int _width, string _name) : base(_height, _width)
        {
            shape.Name = _name;
            name = _name;
        }
        public string GetName() { return name; }
    }
}
