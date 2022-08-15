using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Shapes;
using System.Windows.Controls;
using SpaceInvadersFV.Objects.Entities;

namespace SpaceInvadersFV
{
    public class EntityController
    {
        public Rectangle? player;
        public Rectangle? goal;
        public List<BasicAlien>? enemyList = new List<BasicAlien>();
        public List<Rectangle>? fBulletList = new List<Rectangle>();
        public void FirstLoad(Canvas game)
        {
            LoadPlayer(game);
            LoadGoal(game);
        }
        public void LoadPlayer(Canvas game)
        {
            Object _player = game.FindName("player");
            Rectangle Player = _player as Rectangle;
            player = Player;
        }
        public void LoadGoal(Canvas game)
        {
            Object _goal = game.FindName("goal");
            Rectangle Goal = _goal as Rectangle;
            goal = Goal;
        }
        public void LoadEnemy(Canvas game, string name)
        {
            Object _enemy = game.FindName(name);
            Rectangle Enemy = _enemy as Rectangle;
            BasicAlien enemy = new BasicAlien(Enemy,3);
            enemyList.Add(enemy);
        }
    }
}
