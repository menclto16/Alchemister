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
        FileHandler fileHandler = new FileHandler();

        public MainWindow()
        {
            InitializeComponent();
            LoadImages();
        }

        public void LoadImages()
        {
            string[] images = fileHandler.GetImages();
            foreach (var imagePath in images)
            {
                Image imageControl = new Image();
                imageControl.Source = new BitmapImage(new Uri(Environment.CurrentDirectory + "/" + imagePath));
                imageControl.Width = 40;
                imageControl.Height = 40;
                ItemList.Items.Add(imageControl);
            }
        }
    }
}
