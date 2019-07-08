using AlchemisterLib;
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

namespace Alchemister
{
    /// <summary>
    /// Interaction logic for AdventurePage.xaml
    /// </summary>
    public partial class AdventurePage : Page
    {
        public AdventurePage()
        {
            InitializeComponent();
        }

        private void Button_Click1(object sender, RoutedEventArgs e)
        {
            RewardsPanel.Children.Clear();

            if (Globals.PlayerObject.Health < 0)
            {
                Message.Foreground = Brushes.Red;
                Message.Content = "Adventure failed...";
                return;
            } else
            {
                Message.Foreground = Brushes.Green;
                Message.Content = "Success!";
            }

            Globals.PlayerObject.Health = Globals.PlayerObject.Health - 10;
            if (Globals.PlayerObject.Health < 0) Globals.PlayerObject.Health = 0;
            //Globals.PlayerObject.Mana = Globals.PlayerObject.Mana - 10;

            List<AItem> rewardsPool = new List<AItem>();
            foreach (var item in Globals.ItemLib)
            {
                if (item.ItemLevel == 1 & item is Material)
                {
                    rewardsPool.Add(item);
                }
            }

            Random rnd = new Random();

            foreach (var reward in rewardsPool)
            {
                int randomInt = rnd.Next(0, 3);

                if (randomInt == 0) continue;

                ItemSlotControl itemSlotControl = new ItemSlotControl();
                itemSlotControl.ItemSlotObject.Item = reward;
                itemSlotControl.ItemSlotObject.Count = randomInt;
                itemSlotControl.RefreshItemSlot();
                RewardsPanel.Children.Add(itemSlotControl);

                Globals.PlayerObject.PlayerInventory.AddItems(reward, randomInt);
            }
        }

        private void Button_Click2(object sender, RoutedEventArgs e)
        {
            RewardsPanel.Children.Clear();

            if (Globals.PlayerObject.Health < 20)
            {
                Message.Foreground = Brushes.Red;
                Message.Content = "Adventure failed...";
                return;
            }
            else
            {
                Message.Foreground = Brushes.Green;
                Message.Content = "Success!";
            }

            Globals.PlayerObject.Health = Globals.PlayerObject.Health - 20;
            //Globals.PlayerObject.Mana = Globals.PlayerObject.Mana - 20;

            List<AItem> rewardsPool = new List<AItem>();
            foreach (var item in Globals.ItemLib)
            {
                if (item.ItemLevel == 2 & item is Material)
                {
                    rewardsPool.Add(item);
                }
            }

            Random rnd = new Random();

            foreach (var reward in rewardsPool)
            {
                int randomInt = rnd.Next(0, 3);

                if (randomInt == 0) continue;

                ItemSlotControl itemSlotControl = new ItemSlotControl();
                itemSlotControl.ItemSlotObject.Item = reward;
                itemSlotControl.ItemSlotObject.Count = randomInt;
                itemSlotControl.RefreshItemSlot();
                RewardsPanel.Children.Add(itemSlotControl);

                Globals.PlayerObject.PlayerInventory.AddItems(reward, randomInt);
            }
        }

        private void Button_Click3(object sender, RoutedEventArgs e)
        {
            RewardsPanel.Children.Clear();

            if (Globals.PlayerObject.Health < 30)
            {
                Message.Foreground = Brushes.Red;
                Message.Content = "Adventure failed...";
                return;
            }
            else
            {
                Message.Foreground = Brushes.Green;
                Message.Content = "Success!";
            }

            Globals.PlayerObject.Health = Globals.PlayerObject.Health - 30;
            //Globals.PlayerObject.Mana = Globals.PlayerObject.Mana - 30;

            List<AItem> rewardsPool = new List<AItem>();
            foreach (var item in Globals.ItemLib)
            {
                if (item.ItemLevel == 3 & item is Material)
                {
                    rewardsPool.Add(item);
                }
            }

            Random rnd = new Random();

            foreach (var reward in rewardsPool)
            {
                int randomInt = rnd.Next(0, 3);

                if (randomInt == 0) continue;

                ItemSlotControl itemSlotControl = new ItemSlotControl();
                itemSlotControl.ItemSlotObject.Item = reward;
                itemSlotControl.ItemSlotObject.Count = randomInt;
                itemSlotControl.RefreshItemSlot();
                RewardsPanel.Children.Add(itemSlotControl);

                Globals.PlayerObject.PlayerInventory.AddItems(reward, randomInt);
            }
        }

        private void Button_Click4(object sender, RoutedEventArgs e)
        {
            RewardsPanel.Children.Clear();

            if (Globals.PlayerObject.Health < 40)
            {
                Message.Foreground = Brushes.Red;
                Message.Content = "Adventure failed...";
                return;
            }
            else
            {
                Message.Foreground = Brushes.Green;
                Message.Content = "Success!";
            }

            Globals.PlayerObject.Health = Globals.PlayerObject.Health - 40;
            //Globals.PlayerObject.Mana = Globals.PlayerObject.Mana - 40;

            List<AItem> rewardsPool = new List<AItem>();
            foreach (var item in Globals.ItemLib)
            {
                if (item.ItemLevel == 4 & item is Material)
                {
                    rewardsPool.Add(item);
                }
            }

            Random rnd = new Random();

            foreach (var reward in rewardsPool)
            {
                int randomInt = rnd.Next(0, 3);

                if (randomInt == 0) continue;

                ItemSlotControl itemSlotControl = new ItemSlotControl();
                itemSlotControl.ItemSlotObject.Item = reward;
                itemSlotControl.ItemSlotObject.Count = randomInt;
                itemSlotControl.RefreshItemSlot();
                RewardsPanel.Children.Add(itemSlotControl);

                Globals.PlayerObject.PlayerInventory.AddItems(reward, randomInt);
            }
        }
    }
}
