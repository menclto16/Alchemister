using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Reflection;
using Alchemister;

namespace Editor
{
    class FileHandler
    {
        public string[] GetImages()
        {
            string[] imagePaths = Directory.GetFiles("Images/");
            return imagePaths;
        }
    }
}
