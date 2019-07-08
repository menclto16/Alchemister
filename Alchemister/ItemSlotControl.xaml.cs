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
    /// Interakční logika pro ItemSlot.xaml
    /// </summary>
    public partial class ItemSlotControl : UserControl
    {
        public ItemSlot ItemSlotObject = new ItemSlot();

        public ItemSlotControl()
        {
            InitializeComponent();
            RefreshItemSlot();
        }

        public void RefreshItemSlot() {
            if (ItemSlotObject.Item == null)
            {
                ItemImage.Source = null;
                PopupItemName.Text = "";
                PopupItemDescription.Text = "";
                PopupItemGoldValue.Text = "";
                PopupItemRarity.Text = "";
                ItemCountLabel.Visibility = Visibility.Hidden;
                ItemCountText.Text = "";
            }
            else if (ItemSlotObject.Item.ID != null)
            {
                ItemImage.Source = new BitmapImage(new Uri(Environment.CurrentDirectory + "/Data/Images/" + ItemSlotObject.Item.ID + ".png"));
                PopupItemName.Text = ItemSlotObject.Item.Name;
                PopupItemDescription.Text = ItemSlotObject.Item.Description;
                PopupItemGoldValue.Text = ItemSlotObject.Item.GoldValue.ToString() + " gold";
                switch (ItemSlotObject.Item.ItemLevel)
                {
                    case 1:
                        PopupItemRarity.Text = "Common";
                        PopupItemRarity.Foreground = Brushes.White;
                        break;
                    case 2:
                        PopupItemRarity.Text = "Uncommon";
                        PopupItemRarity.Foreground = Brushes.Green;
                        break;
                    case 3:
                        PopupItemRarity.Text = "Rare";
                        PopupItemRarity.Foreground = Brushes.Blue;
                        break;
                    case 4:
                        PopupItemRarity.Text = "Epic";
                        PopupItemRarity.Foreground = Brushes.Purple;
                        break;
                }
            }

            if (ItemSlotObject.Count > 0)
            {
                ItemCountLabel.Visibility = Visibility.Visible;
                ItemCountText.Text = ItemSlotObject.Count.ToString();
            }
        }
    }
}
