using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlchemisterLib
{
    public abstract class AItem
    {
        public string Name;
        public string Description;
        public int GoldValue;
        public int ItemLevel;
        public string ID;

        int Sell() {
            return GoldValue;
        }
    }
}
