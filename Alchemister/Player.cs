using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alchemister
{
    public class Player
    {
        public int Health = 100;
        public int Mana = 100;
        public int Gold = 100;
        public Inventory PlayerInventory = new Inventory();
    }
}
