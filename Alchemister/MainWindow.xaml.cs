using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
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

namespace Alchemister
{
    /// <summary>
    /// Interakční logika pro MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        SoundPlayer mediaPlayer = new SoundPlayer();

        public MainWindow()
        {
            InitializeComponent();

            mediaPlayer.SoundLocation = "Data/Sound/carnivalrides.wav";
            mediaPlayer.Load();
            mediaPlayer.PlayLooping();
        }
    }
}
