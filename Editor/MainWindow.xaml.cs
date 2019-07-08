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

namespace Editor
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            mainFrame.Navigate(new ItemCreatePage());
        }

        private void Navigate1(object sender, RoutedEventArgs e)
        {
            mainFrame.Navigate(new ItemCreatePage());
        }

        private void Navigate2(object sender, RoutedEventArgs e)
        {
            mainFrame.Navigate(new RecipeCreatePage());
        }

        internal void Navigate(UserControl newPage)
        {
            throw new NotImplementedException();
        }
    }
}
