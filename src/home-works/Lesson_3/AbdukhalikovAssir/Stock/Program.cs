namespace Stock
{
    internal class Program
    {
        const string connectionString = "Server=ASIRUSH-PC;Database=stock;Trusted_Connection=true;Encrypt=false;";
        static void Main(string[] args)
        {
        label:
            try
            {
                var number = ShowMenu();
                SwitchMenu(number);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                Console.ReadLine();
                goto label;
            }
        }

        public static void SwitchMenu(int number)
        {
            switch (number)
            {
                case 1:

                    break;
                case 2:

                    break;
                case 3:

                    break;
                case 4:

                    break;
                case 5:

                    break;
                case 6:

                    break;
                case 7:

                    break;

                default:
                    break;
            }
        }

        public static int ShowMenu()
        {
            Console.Clear();
            Console.WriteLine("1. Show Product Data");
            Console.WriteLine("2. Show All Product Types");
            Console.WriteLine("3. Show Providers");
            Console.WriteLine("4. Show Max Count Product");
            Console.WriteLine("5. Show Min Count Product");
            Console.WriteLine("6. Show Max Product Price");
            Console.WriteLine("7. Show Min Product Price");

            var inputString = Console.ReadLine();
            if (string.IsNullOrEmpty(inputString))
            {
                return 0;
            }

            int number = int.Parse(inputString);
            return number;
        }
    }
}