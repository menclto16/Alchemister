using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Reflection;
using Newtonsoft.Json;

namespace AlchemisterLib
{
    public class FileHandler
    {
        JsonSerializerSettings settings = new JsonSerializerSettings
        {
            TypeNameHandling = TypeNameHandling.All
        };

        public string[] GetImages()
        {
            bool exists1 = Directory.Exists("Data/NewImages");
            if (!exists1) Directory.CreateDirectory("Data/NewImages");

            bool exists2 = Directory.Exists("Data/Images");
            if (!exists2) Directory.CreateDirectory("Data/Images");

            string[] imagePaths = Directory.GetFiles("Data/NewImages");
            return imagePaths;
        }

        public void SaveRecipes(List<Recipe> itemList)
        {
            string json = JsonConvert.SerializeObject(itemList, settings);

            File.WriteAllText("Data/recipes.json", json);
        }

        public List<Recipe> GetRecipes()
        {
            if (File.Exists("Data/recipes.json"))
            {
                string jsonFromFile = File.ReadAllText("Data/recipes.json");

                return JsonConvert.DeserializeObject<List<Recipe>>(jsonFromFile, settings);
            }
            else
            {
                return new List<Recipe>();
            }
        }

        public void SaveItems(List<AItem> itemList)
        {
            string json = JsonConvert.SerializeObject(itemList, settings);

            File.WriteAllText("Data/items.json", json);
        }

        public List<AItem> GetItems()
        {
            if (File.Exists("Data/items.json"))
            {
                string jsonFromFile = File.ReadAllText("Data/items.json");

                return JsonConvert.DeserializeObject<List<AItem>>(jsonFromFile, settings);
            } else
            {
                return new List<AItem>();
            }
        }
    }
}
