using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvadersFV.Objects.shapes
{
    internal class TagedRectangle : GenericRectangle
    {
        public TagedRectangle(int _height, int _width, string _tag) : base(_height, _width)
        {
            shape.Tag = _tag;
        }
    }
}
