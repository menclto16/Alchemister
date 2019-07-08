using AlchemisterLib;
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

        public void AddItems(AItem item, int count)
        {
            bool itemIsInInv = false;

            for (int i = 0; i < ItemSlots.Count; i++)
            {
                if (ItemSlots[i].Item.ID == item.ID)
                {
                    ItemSlots[i].Count = ItemSlots[i].Count + count;
                    itemIsInInv = true;
                    break;
                }
            }
            if (!itemIsInInv)
            {
                for (int i = 0; i < ItemSlots.Count; i++)
                {
                    if (ItemSlots[i].Item.ID == null)
                    {
                        ItemSlots[i].Item = item;
                        ItemSlots[i].Count = count;
                        break;
                    }
                }
            }
        }

        public void RemoveItems(AItem item, int count)
        {
            for (int i = 0; i < ItemSlots.Count; i++)
            {
                if (ItemSlots[i].Item.ID == item.ID)
                {
                    ItemSlots[i].Count = ItemSlots[i].Count - count;
                    if (ItemSlots[i].Count <= 0)
                    {
                        ItemSlots[i].Count = 0;
                        ItemSlots[i] = new ItemSlot();
                    }
                    break;
                }
            }
        }
    }
}
