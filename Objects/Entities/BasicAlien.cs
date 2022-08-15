using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Shapes;

namespace SpaceInvadersFV.Objects.Entities
{
    public class BasicAlien
    {
        public Rectangle? shape;
        public int health;
        public BasicAlien(Rectangle _shape, int _health)
        {
            shape = _shape;
            health = _health;
        }
    }
}
