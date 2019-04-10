using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alchemister
{
    public class Inventory
    {
        public List<ItemSlot> ItemSlots = new List<ItemSlot>();

        public Inventory()
        {
            for (int i = 0; i < 35; i++)
            {
                ItemSlots.Add(new ItemSlot());
            }
        }
    }
}
