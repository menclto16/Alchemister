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
using static Alchemister.MainWindow;
using AlchemisterLib;
using System.Timers;

namespace Alchemister
{
    /// <summary>
    /// Interakční logika pro BrewingPage.xaml
    /// </summary>
    public partial class BrewingPage : Page
    {
        public BrewingPage()
        {
            InitializeComponent();
            inventory.InventoryObject = Globals.PlayerObject.PlayerInventory;
            inventory.RefreshInventory();
            ClearMaterials();
        }

        void NavigationService_Navigated(object sender, NavigationEventArgs e)
        {
            inventory.RefreshInventory();
        }

        private void ClearMaterials()
        {
            MaterialA.ItemSlotObject.Item = null;
            MaterialA.RefreshItemSlot();
            MaterialB.ItemSlotObject.Item = null;
            MaterialB.RefreshItemSlot();

            Message.Content = "";
        }

        private void Button_Click1(object sender, RoutedEventArgs e)
        {
            if (MaterialA.ItemSlotObject.Item == null | MaterialB.ItemSlotObject.Item == null)
            {
                Message.Foreground = Brushes.Red;
                Message.Content = "Not enough materials!";
                return;
            }

            bool brewingSuccess = false;

            foreach (var recipe in Globals.RecipeLib)
            {
                if ((MaterialA.ItemSlotObject.Item.ID == recipe.ItemA.ID & MaterialB.ItemSlotObject.Item.ID == recipe.ItemB.ID) | (MaterialA.ItemSlotObject.Item.ID == recipe.ItemB.ID & MaterialB.ItemSlotObject.Item.ID == recipe.ItemA.ID))
                {
                    Globals.PlayerObject.PlayerInventory.AddItems(recipe.ItemC, 1);

                    Globals.PlayerObject.PlayerInventory.RemoveItems(MaterialA.ItemSlotObject.Item, 1);
                    Globals.PlayerObject.PlayerInventory.RemoveItems(MaterialB.ItemSlotObject.Item, 1);

                    ClearMaterials();

                    inventory.RefreshInventory();

                    brewingSuccess = true;

                    Message.Foreground = Brushes.Green;
                    Message.Content = "Brewing successful!";

                    break;
                }
            }

            if (!brewingSuccess)
            {
                Message.Foreground = Brushes.Red;
                Message.Content = "Brewing failed!";
            }
        }

        private void Button_Click2(object sender, RoutedEventArgs e)
        {
            ClearMaterials();
        }

        private void Button_Click3(object sender, RoutedEventArgs e)
        {
            Message.Content = "";

            if (inventory.ItemSlotsListbox.SelectedIndex == -1) return;

            if (MaterialA.ItemSlotObject.Item != null & MaterialB.ItemSlotObject.Item != null)
            {
                Message.Foreground = Brushes.Red;
                Message.Content = "Cauldron full!";
                return;
            }

            dynamic addedItem = inventory.ItemSlotsListbox.SelectedItem;
            AItem newItem;
            newItem = addedItem.ItemSlotObject.Item;

            if (MaterialA.ItemSlotObject.Item == newItem)
            {
                Message.Foreground = Brushes.Red;
                Message.Content = "Material type already in!";
                return;
            }

            if (MaterialA.ItemSlotObject.Item == null)
            {
                MaterialA.ItemSlotObject.Item = newItem;
                MaterialA.RefreshItemSlot();
            }
            else
            {
                MaterialB.ItemSlotObject.Item = newItem;
                MaterialB.RefreshItemSlot();
            }
        }

        private void Button_Click4(object sender, RoutedEventArgs e)
        {
            Message.Content = "";

            if (inventory.ItemSlotsListbox.SelectedIndex == -1) return;

            dynamic addedItem = inventory.ItemSlotsListbox.SelectedItem;
            AItem newItem;
            newItem = addedItem.ItemSlotObject.Item;

            if (newItem is Potion)
            {
                Globals.PlayerObject.Health += 10 * newItem.ItemLevel;

                Globals.PlayerObject.PlayerInventory.RemoveItems(newItem, 1);

                inventory.RefreshInventory();
            }
            else
            {
                Message.Foreground = Brushes.Red;
                Message.Content = "You can't drink that!";
            }
        }
    }
}
