using System.Reflection.Metadata.Ecma335;

namespace Grocery_List_Lab
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool runAgain = true;
            //create menu and display it right away before asking what the user wants
            Dictionary<string, double> menu = new Dictionary<string, double>();
            menu.Add("eggs", 3.99);
            menu.Add("bacon", 5.99);
            menu.Add("bread", 6.99);
            menu.Add("oreos", 4.99);
            menu.Add("chicken", 10.99);
            menu.Add("steak", 13.99);
            menu.Add("salmon", 11.99);
            menu.Add("cake", 36.99);
            Console.WriteLine("Welcome to Sean's. Here are the items we have and their prices:");
            //create empty shopping list which takes input as elements
            List<string> shopList = new List<string>();
            //run this loop to add elements until the user has all the items they want
            bool list = true;
            while (list == true)
            {
                foreach (KeyValuePair<string, double> item in menu)
                {
                    Console.WriteLine(item.Key + " " + item.Value);
                }
                Console.WriteLine("Which item would you like to add to your list?");
                string input = Console.ReadLine().ToLower().Trim();
                if (input == "eggs" || input == "bacon" || input == "bread" || input == "oreos" || input == "chicken" || input == "steak" || input == "salmon" || input == "cake")
                {
                    //a string is added to the shopping list with each run of the loop where the user enters a proper input
                    shopList.Add(input);
                    Console.WriteLine("Would you like to add another item to your list? y/n");
                    string input2 = Console.ReadLine();
                    if (input2 == "y" || input2 == "yes")
                    {
                        list = true;
                    }
                    else if (input2 == "n" || input2 == "no")
                    {
                        list = false;
                    }
                    else
                    {
                        Console.WriteLine("That item is not on our list.");
                        list = true;
                    }
                }
                else
                {
                    Console.WriteLine("Please enter an item that is on the menu");
                    list = true;
                }

            }
            //now we need to take the items inputted by the user and find their price by feeding them back into the menu dictionary
            bool hasItem = menu.ContainsKey("eggs");
            if (hasItem == true)
            {
                double price = menu["eggs"];
                Console.WriteLine("eggs " + price);
            }
            Console.WriteLine("Okay, here are the items that you ordered:");
            foreach (string x in shopList)
            {
                Console.WriteLine(x + " " + menu[x]);
            }

            double totalPrice = Math.Round(CalculatePrice(shopList, menu), 2);
            Console.WriteLine("That brings your total to " + totalPrice);
            runAgain = restart();
        }
        public static double CalculatePrice(List<string> shopList, Dictionary<string, double> menu)
        {
            double sum = 0;

            foreach(string item in shopList)
            {
                if (menu.ContainsKey(item) == true)
                {
                    sum += menu[item];
                }
            }
            return sum;
        }
        public static bool restart()
        {
            Console.WriteLine("Do you want to start another list? Y/N");
            string input = Console.ReadLine().ToLower();

            if (input == "y")
            {
                return true;
            }
            else if (input == "n")
            {
                return false;
            }
            else //if user input is not "y" or "n"
            {
                Console.WriteLine("I'm sorry, I'm afraid I can't do that, invalid input. Please try again.");
                return restart();
            }
        }
    }
}