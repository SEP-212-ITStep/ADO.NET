using Microsoft.Identity.Client;
using System.ComponentModel.Design;

namespace vegetables
{
    internal class Program
    {
        static void Main(string[] args)
        {
            VegetablesService Products = new();

            try
            {
                menu:
                Console.WriteLine("Welcome!");
                Console.WriteLine("1. Add a Record");
                Console.WriteLine("2. Show all Records");
                Console.WriteLine("3. Show all Names");
                Console.WriteLine("4. Show all Colours");
                Console.WriteLine("5. Show Max Calories");
                Console.WriteLine("6. Show Min Calories");
                Console.WriteLine("7. Show Avg Calories");
                Console.WriteLine("8. Count Vegetables");
                Console.WriteLine("9. Count Fruits");
                Console.WriteLine("10. Show Specific Colour Products");
                Console.WriteLine("11. Show Count of Each Colour");
                Console.WriteLine("12. Show Products With Lower cal than");
                Console.WriteLine("13. Show Products With Higher cal than");
                Console.WriteLine("14. Show Products With cal In Range");
                Console.WriteLine("15. Show All Yellow or Red Products");
                Console.Write("Select the action: "); int tmp = Int32.Parse(Console.ReadLine());
                switch (tmp)
                {
                    case 1:
                        Console.Clear();
                        Console.Write("Write name of the proudct: "); string name = Console.ReadLine();
                        Console.Write("Write type of the proudct: "); string type = Console.ReadLine();
                        Console.Write("Write colour of the proudct: "); string colour = Console.ReadLine();
                        Console.Write("Write calories of the proudct: "); int calories = Console.Read();
                        Products.AddVegetable(name, type, colour, calories);
                        break;
                    case 2:
                        Console.Clear();
                        List<string> list1 = Products.GetData();
                        foreach(var item in list1)
                        {
                            Console.WriteLine(item);
                        }
                        break;
                    case 3:
                        Console.Clear();
                        List<string> list2 = Products.GetNames();
                        foreach (var item in list2)
                        {
                            Console.WriteLine(item);
                        }
                        break;
                    case 4:
                        Console.Clear();
                        Products.GetColours();
                        break;
                    case 5:
                        Console.Clear();
                        Products.GetMaxCal();
                        break;
                    case 6:
                        Console.Clear();
                        Products.GetMinCal();
                        break;
                    case 7:
                        Console.Clear();
                        Products.GetAvgCal();
                        break;
                    case 8:
                        Console.Clear();
                        Products.GetVegCount();
                        break;
                    case 9:
                        Console.Clear();
                        Products.GetFruitCount();
                        break;
                    case 10:
                        Console.Clear();
                        Console.WriteLine("Select specific colour: "); string specColour = Console.ReadLine();
                        Products.GetDataWithSpecColour(specColour);
                        break;
                    case 11:
                        Console.Clear();
                        Products.GetDataByColours();
                        break;
                    case 12:
                        Console.Clear();
                        Console.WriteLine("Select calories value for lover border: "); int lvrBrd = Console.Read();
                        Products.ListWithLoverCal(lvrBrd);
                        break;
                    case 13:
                        Console.Clear();
                        Console.WriteLine("Select calories value for higher border: "); int hgrBrd = Console.Read();
                        Products.ListWithHigherCal(hgrBrd);
                        break;
                    case 14:
                        Console.Clear();
                        Console.WriteLine("Select calories value in range(min, max): "); int lvrBrd1 = Console.Read(); int hgrBrd1 = Console.Read();
                        Products.ListWithCalInRange(lvrBrd1, hgrBrd1);
                        break;
                    case 15:
                        Console.Clear();
                        Products.ShowYelAndRed();
                        break;
                }
                goto menu;
            }
            catch (Exception ex) { Console.WriteLine("Error: {0}", ex.Message); }
        }
    }
}