using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Shapes;

namespace SpaceInvadersFV
{
    public class GenericRectangle
    {
        int height;
        int width;
        public Rectangle shape = new Rectangle();
        public GenericRectangle(int _height, int _width)
        {
            height = _height;
            width = _width;
            shape.Height = height;
            shape.Width = width;
        }
        public Rectangle GetShape() { return shape; }
        public int GetHeight() { return height; }
        public int GetWidth() { return width; }
    }
}
