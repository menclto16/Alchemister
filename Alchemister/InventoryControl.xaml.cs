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

namespace Alchemister
{
    /// <summary>
    /// Interaction logic for InventoryControl.xaml
    /// </summary>
    public partial class InventoryControl : UserControl
    {
        public int NumOfSlots = 35;
        public Inventory InventoryObject = new Inventory();

        public InventoryControl()
        {
            InitializeComponent();

            InventoryObject.ItemSlots[0].Item.ItemImageClass.ImagePath = "Data/Sprites/Ingredients/plant.png";

            for (int i = 0; i < NumOfSlots; i++)
            {
                ItemSlotControl itemSlotControl = new ItemSlotControl();
                itemSlotControl.ItemSlotObject = InventoryObject.ItemSlots[NumOfSlots - 1];
                wrapPanel.Children.Add(itemSlotControl);
            }
        }
    }
}
