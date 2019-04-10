using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alchemister
{
    public abstract class AItem
    {
        string Name;
        string Description;
        int GoldValue;
        int ItemLevel;
        public ItemImage ItemImageClass = new ItemImage();

        int Sell() {
            return GoldValue;
        }
    }
}
