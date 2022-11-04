using Microsoft.Data.SqlClient.DataClassification;

namespace LukmankhakimDarkhan_Console_App_Lesson_4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Add to Blog
            //Update Blog
            //Delete Blog
            //Show All
            
            Label:
            try
            {
                var number = ShowMenu();
                SwitchMenu(number);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                Console.ReadLine();
                goto Label;
            }

          

            Console.WriteLine("Hello, World!");
        }
        
        public static int ShowMenu()
        {
            Console.Clear();
            Console.WriteLine("1. Add to Blog");
            Console.WriteLine("2. Update Blog");
            Console.WriteLine("3. Delete Blog");
            Console.WriteLine("4. Show All");
        var inputString = Console.ReadLine();

            if (string.IsNullOrEmpty(inputString)) {
                return 0;
            }
            int number = int.Parse(inputString);
            return number;
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
                    UpdateBlog();
                    break;
                case 3:
                    RemoveBlog();
                    break;
                case 4:
                    ShowAllData();
                    break;
                default:
                    break;
            }
        }
        public static void UpdateBlog()
        {
            Console.WriteLine("Enter yours identificators:");
            var id = int.Parse(Console.ReadLine() ?? throw new InvalidOperationException("No yours enters!!!"));
            using var dbContext = new Entity_Framework_Core();
            var blog = dbContext.Blogs.First(f => f.BlogId == id);
            Console.WriteLine("Changes content:");
            var newContent = Console.ReadLine();
            blog.Content = newContent;
            dbContext.SaveChanges();

            Console.WriteLine("Changes great!");
            Thread.Sleep(2000);
            SwitchMenu(ShowMenu());
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

            using var dbContext = new Entity_Framework_Core();

            dbContext.Blogs.Add(blog);
            dbContext.SaveChanges();
            Console.WriteLine("Изменения успешно сохранены.");
            Thread.Sleep(1500);
            Console.ReadLine();
            SwitchMenu(ShowMenu());
        }
        public static void ShowAllData()
        {
            using var dbContext = new Entity_Framework_Core();
            var blogs = dbContext.Blogs.ToList();
            foreach (var blog in blogs)
            {
                Console.WriteLine($"{blog.AuthorName} - {blog.Content} ," +
                    $"Like count - {blog.LikeCount}");
            }
        }

        public static void RemoveBlog()
        {
            Console.WriteLine("Enter yours identificators:");
            var id = int.Parse(Console.ReadLine() ?? throw new InvalidOperationException("No yours enters!!!"));
            using var dbContext = new Entity_Framework_Core();
            var blog = dbContext.Blogs.First(f => f.BlogId == id);
            dbContext.Blogs.Remove(blog);
            dbContext.SaveChanges();

            Console.WriteLine("Changes great!");
            Thread.Sleep(2000);
            SwitchMenu(ShowMenu());
        }

    }
}