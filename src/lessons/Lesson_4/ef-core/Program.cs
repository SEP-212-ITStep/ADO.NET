using System.ComponentModel;

namespace ef_core
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 1. Добавить блог
            // 2. Обновить контент блога
            // 3. Удалить
            // 4. Показать всё
           
            try
            {
                var number = ShowMenu();
                SwitchMenu(number);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
        public static void SwitchMenu(int number)
        {
            switch (number)
            {
                case 1:
                    Console.Write("Имя автора:");
                    var authorName = Console.ReadLine();
                    Console.Write("Контент блога:");
                    var blogContent = Console.ReadLine();
                    AddNewBlog(authorName, blogContent);
                    break;
                case 2:
                    break;
                case 3:
                    break;
                case 4:
                    ShowAllData();
                    break;
                default:
                    break;
            }
        }
        public static int ShowMenu()
        {
            Console.Clear();
            Console.WriteLine("1. Добавить блог");
            Console.WriteLine("2. Обновить контент блога");
            Console.WriteLine("3. Удалить");
            Console.WriteLine("4. Показать всё");

            var inputString = Console.ReadLine();
            if (string.IsNullOrEmpty(inputString))
            {
                return 0;
            }

            int number = int.Parse(inputString);
            return number;
        }

        public static void AddNewBlog(string authorName, string content)
        {
            var blog = new Blog()
            {
                AuthorName = authorName,
                Content = content,
                LikeCount = Random.Shared.Next(100, 100000),
                Url = "microsoft.com"
            };

            using var dbContext = new BloggingContext();

            dbContext.Blogs.Add(blog);
            dbContext.SaveChanges();
            Console.WriteLine("Изменения успешно сохранены.");
            Thread.Sleep(1500);
            SwitchMenu(ShowMenu());
        }
        public static void ShowAllData()
        {
            using var dbContext = new BloggingContext();
            var blogs = dbContext.Blogs.ToList();
            foreach (var blog in blogs)
            {
                Console.WriteLine($"{blog.AuthorName} - {blog.Content}, " +
                    $"Like count - {blog.LikeCount}");
            }
        }
    }
}