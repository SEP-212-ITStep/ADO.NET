using Microsoft.Data.SqlClient;
using Microsoft.IdentityModel.Tokens;
using System.Data;

namespace homework5
{
     public class Program
    {
        //1)	Создать консольное приложение с версией фреймворка .NET 6
        //2)	Создать таблицу в БД(Имя БД можно выбрать самим) которая будет описывать каталог автомобилей, любого бренда заполнить её любыми читаемыми данными.
        //3)	Сделать меню в консольном приложении чтобы можно было
        //a.Показать все модели за введенный год(к примеру 2002, 2012, 2022)
        //b.Выбрать конкретную машину под номером модели и года
        //i.Показать Базовые характеристики выбранного автомобиля
        //ii.Внести дополнительную информацию по машине (SqlUpdateCommand)
        //c.	Добавить новую машину (SqlInsertCommand)
        //Рекомендации по выполнению, нужно использовать – отсоединенный режим (DataSet, SqlDataAdapter), потому что это может вам помочь с пунктом b.i и c
        public static void showAllModelsByYear()
        {
            string? inputyear = "";
            while (inputyear.IsNullOrEmpty())
            {
                Console.WriteLine("Введите год модели");
                inputyear = Console.ReadLine();
            }

            const string connectionString = "Server=KCELL50787\\MSSQLSERVER2;Database=CarDb;User Id=sa;Password=Qwerty123!;Encrypt=false;";
            try
            {

                string SqlQuerty = $"SELECT carMake, carColor, engineVolume, carYear, modelNumber, modelName, modelYear FROM dbo.cars where modelYear='{inputyear}'";

                using var sqlConnection = new SqlConnection(connectionString);
                sqlConnection.Open();
                Console.WriteLine("Connection is opened");
                using var sqlCommand = new SqlCommand(SqlQuerty, sqlConnection);
                using var reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    var carmake = reader["carMake"].ToString();
                    var carcolor = reader["carColor"].ToString();
                    var enginevolume = reader["engineVolume"].ToString();
                    var caryear = reader["carYear"].ToString();
                    var modelnumber = reader["modelNumber"].ToString();
                    var modelname = reader["modelName"].ToString();
                    var modelyear = reader["modelYear"].ToString();

                    Console.WriteLine($"make- {carmake}, color - {carcolor}, engine volume -{enginevolume},car year- {caryear}, modelnumber - {modelnumber}, modelname -{modelname}, modelyear - {modelyear}");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public static Car getCarByModelNumberAndYear(string model, string year)
        {
            
            Car thecar = new Car();

            const string connectionString = "Server=KCELL50787\\MSSQLSERVER2;Database=CarDb;User Id=sa;Password=Qwerty123!;Encrypt=false;";
            try
            {
                string SqlQuerty = $"SELECT carMake,carColor,engineVolume,carYear,modelNumber,modelName,modelYear FROM dbo.cars where modelYear='{year}' and modelName = '{model}'";

                using var sqlConnection = new SqlConnection(connectionString);
                sqlConnection.Open();
                Console.WriteLine("Connection is opened");
                using var sqlCommand = new SqlCommand(SqlQuerty, sqlConnection);
                using var reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    var carmake = reader["carMake"].ToString();
                    var carcolor = reader["carColor"].ToString();
                    var enginevolume = reader["engineVolume"].ToString();
                    var caryear = reader["carYear"].ToString();
                    var modelnumber = reader["modelNumber"].ToString();
                    var modelname = reader["modelName"].ToString();
                    var modelyear = reader["modelYear"].ToString();

                    Console.WriteLine($"make- {carmake}, color - {carcolor}, engine volume -{enginevolume}, car year - {caryear}, modelnumber - {modelnumber}, modelname -{modelname}, modelyear - {modelyear}");

                    thecar.carMake = carmake;
                    thecar.carColor = carcolor;
                    thecar.engineVolume = enginevolume;
                    if (!caryear.IsNullOrEmpty())
                        thecar.carYear = DateTime.Parse(caryear);
                    thecar.modelNumber = modelnumber;
                    thecar.modelName = modelname;
                    if (!modelyear.IsNullOrEmpty())
                        thecar.modelYear = DateTime.Parse(modelyear);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return thecar;
        }
        public static void showBaseCharacteristics(Car thatcar)
        {
            Console.WriteLine($"make - {thatcar.carMake}, color - {thatcar.carColor}, engine volume - {thatcar.engineVolume},car year - {thatcar.carYear}, modelnumber - {thatcar.modelNumber}, modelname - {thatcar.modelName}, modelyear - {thatcar.modelYear}");
        }
        public static void updateCarDetails(Car somecar,string model,string year)
        {
            Console.Write("Какой параметр поменять? ");
            Console.WriteLine($"\t\n 1. производитель машины - {somecar.carMake}\n 2. модель - {somecar.modelName}\n 3. цвет -  {somecar.carColor}\n 4. объем двигателя -  {somecar.engineVolume}\n 5. год производства -  {somecar.carYear}");
            int selector = int.Parse(Console.ReadLine());

            switch (selector)
            {
                case 1:
                    Console.WriteLine("выбрано: производитель машины");
                    Console.WriteLine("введите новое значение");
                    string newname = Console.ReadLine();
                    updateDB("carMake", newname, model, year);
                    break;
                case 2:
                    Console.WriteLine("выбрано: модель");
                    Console.WriteLine("введите новое значение ");
                    string newmod = Console.ReadLine();
                    updateDB("modelName", newmod, model, year);
                    break;
                case 3:
                    Console.WriteLine("выбрано: цвет");
                    Console.WriteLine("введите новое значение");
                    string newcolor = Console.ReadLine();
                    updateDB("carColor", newcolor, model, year);
                    break;
                case 4:
                    Console.WriteLine("выбрано: объем двигателя");
                    Console.WriteLine("введите новое значение");
                    string newvolume = Console.ReadLine();
                    updateDB("engineVolume", newvolume, model, year);
                    break;
                case 5:
                    Console.WriteLine("выбрано: год производства");
                    Console.WriteLine("введите новое значение");
                    string newcaryear = Console.ReadLine();
                    updateDB("carYear", newcaryear, model, year);
                    break;
            }
        }
        public static void updateDB(string column, string value, string modelName, string caryear)
        {

            const string connectionString = "Server=KCELL50787\\MSSQLSERVER2;Database=CarDb;User Id=sa;Password=Qwerty123!;Encrypt=false;";
            try
            {
                using var sqlConnection = new SqlConnection(connectionString);
                sqlConnection.Open();
                Console.WriteLine("Connection is opened");
              
                string sql = $"UPDATE dbo.cars set {column}='{value}' where modelYear='{caryear}' and modelName = '{modelName}'";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    // Создаем объект DataAdapter
                    SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);
                    // Создаем объект DataSet
                    DataSet ds = new DataSet();
                    // Заполняем Dataset
                    adapter.Fill(ds);
                    Console.WriteLine("изменения успешно сохранены.");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public static void addNewCar()
        {
            Console.WriteLine("Введите производителя машины, цвет машины,номер модели, название модели, год модели");
            var carmake = "";
            var carcolor = "";
            var modelnumber = "";
            var modelname = "";
            var modelyear = "";
            while (carmake.IsNullOrEmpty())
            {
                Console.Write("производитель машины: ");
                carmake = Console.ReadLine();
            }
            while (carcolor.IsNullOrEmpty())
            {
                Console.Write("цвет машины: ");
                carcolor = Console.ReadLine();
            }
            while (modelnumber.IsNullOrEmpty())
            {
                Console.Write("номер модели: ");
                modelnumber = Console.ReadLine();
            }
            while (modelname.IsNullOrEmpty())
            {
                Console.Write("название модели: ");
                modelname = Console.ReadLine();
            }
            while (modelyear.IsNullOrEmpty())
            {
                Console.Write("год модели: ");
                modelyear = Console.ReadLine();
            }
            AddNewRecord(carmake, carcolor, modelnumber, modelname, modelyear);

        }
        public static void AddNewRecord(string crmake, string carclr, string mdllnumber, string modlname, string year)
        {
            const string connectionString = "Server=KCELL50787\\MSSQLSERVER2;Database=CarDb;User Id=sa;Password=Qwerty123!;Encrypt=false;";
            try
            {
                using var sqlConnection = new SqlConnection(connectionString);
                sqlConnection.Open();
                Console.WriteLine("Connection is opened");

                var date = Convert.ToDateTime("01-01-" + year);
                Console.WriteLine(date);
                Console.WriteLine(year);


                string sql = $"INSERT INTO dbo.cars (carMake, carColor,modelNumber,modelName,modelYear) VALUES ('{crmake}','{carclr}','{mdllnumber}','{modlname}', '{date.ToString("yyyy-MM-dd HH:mm:ss")}')";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    // Создаем объект DataAdapter
                    SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);
                    // Создаем объект DataSet
                    DataSet ds = new DataSet();
                    // Заполняем Dataset
                    adapter.Fill(ds);
                    Console.WriteLine("изменения успешно сохранены.");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public static int showMenu()
        {
            Console.Clear();
            Console.WriteLine("1. Показать все модели за введенный год");
            Console.WriteLine("2. Выбрать конкретную машину под номером модели и года");
            Console.WriteLine("   - Показать Базовые характеристики выбранного автомобиля");
            Console.WriteLine("   - Внести дополнительную информацию по машине");
            Console.WriteLine("3. Добавить новую машину");
            Console.WriteLine();

            var inputString = Console.ReadLine();
            if (string.IsNullOrEmpty(inputString))
            {
                return 0;
            }
            //var outputString = Console.ReadLine();
            Console.WriteLine();
            int number = int.Parse(inputString);

            return number;
        }
        public static void SwitchMenu(int number)
        {
            switch (number)
            {
                case 1:
                    showAllModelsByYear();
                    BackToMenu();
                    break;
                case 2:
                    string? modelFullname = "";
                    string? inputyear = "";
                    while (inputyear.IsNullOrEmpty() || modelFullname.IsNullOrEmpty())
                    {
                        Console.WriteLine("Введите название модели");
                        modelFullname = Console.ReadLine();
                        Console.WriteLine("Введите год модели");
                        inputyear = Console.ReadLine();
                    }
                    var thecar = getCarByModelNumberAndYear(modelFullname, inputyear);
                    Console.WriteLine("1. Показать Базовые характеристики выбранного автомобиля");
                    Console.WriteLine("2. Внести дополнительную информацию по машине");
                    Console.WriteLine(" ");
                    int tmp = int.Parse(Console.ReadLine());
                    if (tmp == 1)
                    {
                        Console.WriteLine(thecar.modelNumber);
                        Console.WriteLine(thecar.modelYear.ToString());
                        showBaseCharacteristics(thecar);
                    }
                    else if (tmp == 2)
                    {
                        updateCarDetails(thecar, modelFullname, inputyear);
                    }
                    BackToMenu();
                    break;
                case 3:
                    addNewCar();
                    BackToMenu();
                    break;
            }
        }
        public static void BackToMenu()
        {
            Console.WriteLine("0. Вернуться в меню.");
            Console.WriteLine("1. Выйти");
            var inputString = Console.ReadLine();
            if (string.IsNullOrEmpty(inputString))
            {
                Console.WriteLine("Введите цифру");
            }
            //var outputString = Console.ReadLine();

            Console.WriteLine();
            int number = int.Parse(inputString);

            if (number == 0)
            {
                SwitchMenu(showMenu());
            }
            else if (number == 1)
            {
                return;
            }
        }
        static void Main(string[] args)
        {
            try
            {
                SwitchMenu(showMenu());
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}