using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using SpaceInvadersFV.Objects.shapes;

namespace SpaceInvadersFV
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static string projectFolder = AppDomain.CurrentDomain.BaseDirectory;
        public static NamedRectangle playerShape = new(50, 50, "player");   //first two int controll the size of the player
        public static NamedRectangle goalShape = new(1, 800, "goal");
        public static NamedRectangle bulletPlaceholderLeft = new(40, 10, "BPHleft");
        public static NamedRectangle bulletPlaceholderRight = new(40, 10, "BPHright");
        static public bool leftFlag = false;
        static public bool rightFlag = false;
        static public bool fireFlag = false;
        static public EntityController EC = new();
        static public LoadLvl Lvl1 = new LoadLvl(28, 3, 20, 30,1); //first int controlls the ammount of enemies, second int controlls the ammount of rows
                                                                //third and fourth controlls the size of the enemy, fifth is the health of the alien
        public MainWindow()
        {
            InitializeComponent();
            Setup.LoadPlayer(GameWindow,playerShape);
            Setup.LoadGoal(GameWindow,goalShape);
            Mainloop.Loop(GameWindow);
        }
        private void KeyIsDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.A) leftFlag = true;
            if (e.Key == Key.D) rightFlag = true;
            if (e.Key == Key.W) fireFlag = true;
            if (e.Key == Key.H) DeleteAllEnemies();
        }
        private void KeyIsUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.A) leftFlag = false;
            if (e.Key == Key.D) rightFlag = false;
            if (e.Key == Key.W) fireFlag = false;
        }
        private void DeleteAllEnemies()
        {
            foreach(Objects.Entities.BasicAlien alien in EC.enemyList)
            {
                alien.shape.Fill = Brushes.Green;
            }
        }
    }
}
