using AlchemisterLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Alchemister
{
    /// <summary>
    /// Interakční logika pro MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Timer timer;

        public static class Globals
        {
            public static FileHandler FileHandlerObject = new FileHandler();
            public static Player PlayerObject = new Player();
            public static List<AItem> ItemLib = new List<AItem>();
            public static List<Recipe> RecipeLib = new List<Recipe>();
        }

        public MainWindow()
        {
            InitializeComponent();

            SetAlignment();

            Globals.ItemLib = Globals.FileHandlerObject.GetItems();
            Globals.RecipeLib = Globals.FileHandlerObject.GetRecipes();

            mainFrame.Navigate(new BrewingPage());

            timer = new System.Timers.Timer(100);
            timer.Elapsed += OnTimedEvent;
            timer.Enabled = true;
        }

        public static void SetAlignment()
        {
            var ifLeft = SystemParameters.MenuDropAlignment;

            if (ifLeft)
            {
                var t = typeof(SystemParameters);
                var field = t.GetField("_menuDropAlignment", BindingFlags.NonPublic | BindingFlags.Static);
                field.SetValue(null, false);

                ifLeft = SystemParameters.MenuDropAlignment;
            }
        }

        private void Button_Click1(object sender, RoutedEventArgs e)
        {
            mainFrame.Navigate(new BrewingPage());
        }

        private void Button_Click2(object sender, RoutedEventArgs e)
        {
            mainFrame.Navigate(new AdventurePage());
        }

        private void Button_Click3(object sender, RoutedEventArgs e)
        {
            mainFrame.Navigate(new ShopPage());
        }

        private void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            this.Dispatcher.Invoke(() =>
            {
                HPBar.Value = Globals.PlayerObject.Health;
                ManaBar.Value = Globals.PlayerObject.Mana;
            });
        }
    }
}
