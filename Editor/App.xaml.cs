using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Editor
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            string path = System.IO.Directory.GetCurrentDirectory()+"\\Images";

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
        }
    
}
}
