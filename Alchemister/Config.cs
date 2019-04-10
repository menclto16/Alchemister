using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alchemister
{
    public class Config
    {
        public string GetDataFolderPath()
        {
            return System.Reflection.Assembly.GetExecutingAssembly().Location;
        }
    }
}
