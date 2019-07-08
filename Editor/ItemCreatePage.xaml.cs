using System;
using System.Collections.Generic;
using System.IO;
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

namespace Editor
{
    /// <summary>
    /// Interaction logic for ItemCreatePage.xaml
    /// </summary>
    public partial class ItemCreatePage : Page
    {
        FileHandler fileHandler = new FileHandler();
        List<AItem> itemList = new List<AItem>();

        public ItemCreatePage()
        {
            InitializeComponent();
            itemList = fileHandler.GetItems();
            LoadItems();
            LoadImages();
        }

        public void LoadItems()
        {
            ItemList.Items.Clear();
            foreach (var item in itemList)
            {
                Image imageControl = new Image();
                imageControl.Source = new BitmapImage(new Uri(Environment.CurrentDirectory + "/Data/Images/" + item.ID + ".png"));
                imageControl.Width = 40;
                imageControl.Height = 40;
                ItemList.Items.Add(imageControl);
            }
        }

        public void LoadImages()
        {
            ImageList.Items.Clear();
            string[] images = fileHandler.GetImages();
            foreach (var imagePath in images)
            {
                Image imageControl = new Image();
                imageControl.Source = new BitmapImage(new Uri(Environment.CurrentDirectory + "/" + imagePath));
                imageControl.Width = 40;
                imageControl.Height = 40;
                ImageList.Items.Add(imageControl);
            }
        }

        void clearFields()
        {
            ItemNameInput.Text = "";
            ItemDescriptionInput.Text = "";
            ItemGoldValueInput.Text = "";
            ItemLevelInput.Text = "";
            ID.Text = "";
            PotionBool.IsChecked = false;
            ImageList.Visibility = Visibility.Visible;
        }

        private void updateFields()
        {
            if (ItemList.Items.Count == 0) return;

            dynamic selectedItem = ItemList.SelectedValue;
            string itemID = System.IO.Path.GetFileNameWithoutExtension(selectedItem.Source.UriSource.LocalPath);

            foreach (var item in itemList)
            {
                if (item.ID == itemID)
                {
                    ItemNameInput.Text = item.Name;
                    ItemDescriptionInput.Text = item.Description;
                    ItemGoldValueInput.Text = item.GoldValue.ToString();
                    ItemLevelInput.Text = item.ItemLevel.ToString();
                    ID.Text = item.ID;
                    ImageList.Visibility = Visibility.Hidden;
                    if (item is Potion)
                    {
                        PotionBool.IsChecked = true;
                    }
                    else
                    {
                        PotionBool.IsChecked = false;
                    }
                }
            }
        }

        void UpdateFields(object sender, SelectionChangedEventArgs args)
        {
            updateFields();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            dynamic newImage = new Image();

            if (ImageList.SelectedIndex >= 0)
            {
                newImage = ImageList.SelectedItem;
            }

            AItem newItem;

            if ((bool)PotionBool.IsChecked)
            {
                newItem = new Potion();
            }
            else
            {
                newItem = new Material();
            }

            newItem.Name = ItemNameInput.Text;
            newItem.Description = ItemDescriptionInput.Text;
            newItem.GoldValue = int.Parse(ItemGoldValueInput.Text);
            newItem.ItemLevel = int.Parse(ItemLevelInput.Text);
            while (true)
            {
                Random random = new Random();
                string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
                string randomID = new string(Enumerable.Repeat(chars, 6).Select(s => s[random.Next(s.Length)]).ToArray());
                bool IDExists = false;
                foreach (var item in itemList)
                {
                    if (item.ID == randomID) IDExists = true;
                }
                if (!IDExists)
                {
                    newItem.ID = randomID;
                    break;
                }
            }

            if (ID.Text == "")
            {
                File.Copy(newImage.Source.UriSource.LocalPath, "Data/Images/" + newItem.ID + ".png");

                itemList.Add(newItem);
            }
            else
            {
                for (int i = 0; i < itemList.Count(); i++)
                {
                    if (ID.Text == itemList[i].ID)
                    {
                        newItem.ID = itemList[i].ID;
                        itemList[i] = newItem;
                    }
                }
            }
            
            fileHandler.SaveItems(itemList);
            clearFields();
            LoadItems();
        }
    }
}
