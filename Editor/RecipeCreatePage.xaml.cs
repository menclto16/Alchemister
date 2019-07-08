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

namespace Editor
{
    /// <summary>
    /// Interaction logic for RecipeCreatePage.xaml
    /// </summary>
    public partial class RecipeCreatePage : Page
    {
        FileHandler fileHandler = new FileHandler();
        List<AItem> itemList = new List<AItem>();
        List<Recipe> recipeList = new List<Recipe>();

        public RecipeCreatePage()
        {
            InitializeComponent();
            itemList = fileHandler.GetItems();
            recipeList = fileHandler.GetRecipes();
            LoadItems();
        }

        public void LoadItems()
        {
            ItemList1.Items.Clear();
            ItemList2.Items.Clear();
            ItemList3.Items.Clear();

            foreach (var item in itemList)
            {
                if (item is Potion)
                {
                    Image imageControl = new Image();

                    imageControl.Source = new BitmapImage(new Uri(Environment.CurrentDirectory + "/Data/Images/" + item.ID + ".png"));
                    imageControl.Width = 40;
                    imageControl.Height = 40;
                    ItemList3.Items.Add(imageControl);
                } else
                {
                    Image imageControl1 = new Image();
                    Image imageControl2 = new Image();

                    imageControl1.Source = new BitmapImage(new Uri(Environment.CurrentDirectory + "/Data/Images/" + item.ID + ".png"));
                    imageControl1.Width = 40;
                    imageControl1.Height = 40;
                    imageControl2.Source = new BitmapImage(new Uri(Environment.CurrentDirectory + "/Data/Images/" + item.ID + ".png"));
                    imageControl2.Width = 40;
                    imageControl2.Height = 40;
                    ItemList1.Items.Add(imageControl1);
                    ItemList2.Items.Add(imageControl2);
                }
            }
        }

        private void clearFields()
        {
            ItemNameLabel1.Content = "";
            ItemIDLabel1.Content = "";
            ItemLevelLabel1.Content = "";

            ItemNameLabel2.Content = "";
            ItemIDLabel2.Content = "";
            ItemLevelLabel2.Content = "";

            ItemNameLabel3.Content = "";
            ItemIDLabel3.Content = "";
            ItemLevelLabel3.Content = "";

            ItemList1.SelectedIndex = -1;
            ItemList2.SelectedIndex = -1;
            ItemList3.SelectedIndex = -1;
        }

        void ListBoxChanged1(object sender, SelectionChangedEventArgs args)
        {
            if (ItemList1.SelectedValue == null) return;

            dynamic selectedItem = ItemList1.SelectedValue;
            string itemID = System.IO.Path.GetFileNameWithoutExtension(selectedItem.Source.UriSource.LocalPath);
            foreach (var item in itemList)
            {
                if (item.ID == itemID)
                {
                    ItemNameLabel1.Content = item.Name;
                    ItemIDLabel1.Content = item.ID;
                    ItemLevelLabel1.Content = item.ItemLevel;
                }
            }
        }

        void ListBoxChanged2(object sender, SelectionChangedEventArgs args)
        {
            if (ItemList2.SelectedValue == null) return;

            dynamic selectedItem = ItemList2.SelectedValue;
            string itemID = System.IO.Path.GetFileNameWithoutExtension(selectedItem.Source.UriSource.LocalPath);
            foreach (var item in itemList)
            {
                if (item.ID == itemID)
                {
                    ItemNameLabel2.Content = item.Name;
                    ItemIDLabel2.Content = item.ID;
                    ItemLevelLabel2.Content = item.ItemLevel;
                }
            }
        }

        void ListBoxChanged3(object sender, SelectionChangedEventArgs args)
        {
            if (ItemList3.SelectedValue == null) return;

            dynamic selectedItem = ItemList3.SelectedValue;
            string itemID = System.IO.Path.GetFileNameWithoutExtension(selectedItem.Source.UriSource.LocalPath);
            foreach (var item in itemList)
            {
                if (item.ID == itemID)
                {
                    ItemNameLabel3.Content = item.Name;
                    ItemIDLabel3.Content = item.ID;
                    ItemLevelLabel3.Content = item.ItemLevel;
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Recipe newRecipe = new Recipe();

            AItem itemA = new Material();
            AItem itemB = new Material();
            AItem itemC = new Material();

            dynamic selectedItem1 = ItemList1.SelectedValue;
            string itemAID = System.IO.Path.GetFileNameWithoutExtension(selectedItem1.Source.UriSource.LocalPath);
            dynamic selectedItem2 = ItemList2.SelectedValue;
            string itemBID = System.IO.Path.GetFileNameWithoutExtension(selectedItem2.Source.UriSource.LocalPath);
            dynamic selectedItem3 = ItemList3.SelectedValue;
            string itemCID = System.IO.Path.GetFileNameWithoutExtension(selectedItem3.Source.UriSource.LocalPath);

            foreach (var item in itemList)
            {
                if (item.ID == itemAID)
                {
                    itemA = item;
                }
                else if (item.ID == itemBID)
                {
                    itemB = item;
                }
                else if (item.ID == itemCID)
                {
                    itemC = item;
                }
            }

            newRecipe.ItemA = itemA;
            newRecipe.ItemB = itemB;
            newRecipe.ItemC = itemC;

            recipeList.Add(newRecipe);

            fileHandler.SaveRecipes(recipeList);

            clearFields();
        }
    }
}
