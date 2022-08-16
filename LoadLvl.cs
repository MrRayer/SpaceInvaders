using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Shapes;
using SpaceInvadersFV.Objects.shapes;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Diagnostics;

namespace SpaceInvadersFV
{
    public class LoadLvl
    {
        int placedEnemies = 0;
        int placedInColumn = 0;
        bool heightFlag = true;
        int levelEnemies;
        int rows;
        public int AlienHeight;
        public int AlienWidth;
        NamedRectangle? levelShape;
        int AlienHealth;
        public LoadLvl(int _levelEnemies, int _rows, int EHeight, int EWidth, int EHealth)
        {
            levelEnemies = _levelEnemies;
            rows = _rows;
            AlienHeight = EHeight;
            AlienWidth = EWidth;
            AlienHealth = EHealth;
        }
        public void Load(Canvas game)
        {
            while (placedInColumn < rows && placedEnemies < levelEnemies)
            {
                NamedRectangle shape = new(AlienHeight, AlienWidth, $"Alien{placedEnemies}");
                levelShape = shape;
                int height;
                if (heightFlag) height = 15 + AlienHeight * placedInColumn + AlienHeight * placedInColumn;
                // border + row in column + separation
                else height = 15 + AlienHeight * placedInColumn + AlienHeight * placedInColumn - AlienHeight;
                // border + row in column + separation + offset
                SpawnEnemy(game, shape, height, 785 - AlienWidth);
                MainWindow.EC.LoadEnemy(game, $"Alien{placedEnemies}", AlienHealth);
                placedInColumn++;
                placedEnemies++;
            }
            if (placedInColumn == rows)
            {
                if (heightFlag) { heightFlag = false; placedInColumn = 1; }
                else { heightFlag = true; placedInColumn = 0; }
            }
        }
        public static void SpawnEnemy(Canvas game, NamedRectangle enemy, int top, int left)
        {
            try
            {
                ImageBrush enemySkin = new ImageBrush();
                enemySkin.ImageSource = new BitmapImage(new Uri(System.IO.Path.Combine(MainWindow.projectFolder, @"..\..\..\lib\img\Saucer.png")));
                enemy.GetShape().Fill = enemySkin;
            }
            catch { enemy.GetShape().Fill = Brushes.Blue; }
            Canvas.SetTop(enemy.GetShape(), top);
            Canvas.SetLeft(enemy.GetShape(), left);
            game.RegisterName(enemy.GetName(), enemy.GetShape());
            game.Children.Add(enemy.GetShape());
        }
    }
}
