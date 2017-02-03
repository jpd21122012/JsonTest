using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Web;
using System.Net.Http;
using Newtonsoft.Json;


namespace JSONDataStorage
{
    class Item : IEquatable<Item>
    {
        public string name;
        public int price;
        public Item(string name, int price=0) {
            this.name = name;
            this.price = price;
        }
        public bool Equals(Item other) {
            if (other == null) return false;
            return (this.name.Equals(other.name));
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            // read file into a string and deserialze JSON to a type
            Console.WriteLine("Reading data.json");
            string jsonSTRING = File.ReadAllText("data.json");
            List <Item> myList = JsonConvert.DeserializeObject<List<Item>>(jsonSTRING);
            if (myList == null)
            {
                myList = new List<Item>();

                string input = "";
                int inputInt = 0;
                string inputString = "";
                while (input != "q")
                {
                    Console.WriteLine("Press 'a' to add new Item");
                    Console.WriteLine("Press 'd' to delete Item");
                    Console.WriteLine("Press 's' to Show Content");
                    Console.WriteLine("Press 'q' to Quit Program");
                    Console.WriteLine("Press Command:");
                    input = Console.ReadLine();
                    switch (input)
                    {
                        case "a":
                            Console.WriteLine("Adding a new Item");
                            Console.WriteLine("Enter a Item name:");
                            inputString = Console.ReadLine();
                            Console.WriteLine("Enter item price (Numeric Values Only): ");
                            inputInt = Convert.ToInt32(Console.ReadLine());
                            myList.Add(new Item(inputString,inputInt));
                            Console.WriteLine("Added Item "+inputString+" with price"+inputInt);
                            break;
                        case "d":
                            Console.WriteLine("Deleting Item");
                            Console.WriteLine("Enter Item name to delete:");
                            inputString = Console.ReadLine();
                            myList.Remove(new Item(inputString));
                            Console.WriteLine("Deleted item with name "+inputString);
                            break;
                        case "q":
                            Console.WriteLine("Quit Program");
                            break;
                        case "s":
                            Console.WriteLine("\nShowing Contents:");
                            foreach (Item item in myList)
                            {
                                Console.WriteLine("Item: "+ item.name+" | $"+item.price);
                            }
                            Console.WriteLine("\n");
                            break;
                        default:
                            Console.WriteLine("Incorrect command, try again");
                            break;
                    }
                }
                Console.WriteLine("Rewriting data.json");
                string data = JsonConvert.SerializeObject(myList);
                File.WriteAllText("data.json",data);
                Console.ReadLine();
            }
        }
    }
}
