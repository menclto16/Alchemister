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
using AlchemisterLib;

namespace Alchemister
{
    /// <summary>
    /// Interaction logic for InventoryControl.xaml
    /// </summary>
    public partial class InventoryControl : UserControl
    {
        public int NumOfSlots = 35;
        public Inventory InventoryObject = new Inventory();
        public List<ItemSlotControl> ItemSlots = new List<ItemSlotControl>();

        public InventoryControl()
        {
            InitializeComponent();
            RefreshInventory();
        }

        public void RefreshInventory()
        {
            ItemSlotsListbox.Items.Clear();
            for (int i = 0; i < NumOfSlots; i++)
            {
                ItemSlotControl itemSlotControl = new ItemSlotControl();
                itemSlotControl.ItemSlotObject = InventoryObject.ItemSlots[i];
                itemSlotControl.RefreshItemSlot();
                ItemSlotsListbox.Items.Add(itemSlotControl);
            }
        }
    }
}
