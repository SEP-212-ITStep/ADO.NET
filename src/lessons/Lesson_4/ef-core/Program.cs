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
            Console.WriteLine("1. Добавить блог");
            Console.WriteLine("2. Обновить контент блога");
            Console.WriteLine("3. Удалить");
            Console.WriteLine("4. Показать всё");
            try
            {
                var inputString = Console.ReadLine();
                if (string.IsNullOrEmpty(inputString))
                {
                    return;
                }

                int number = int.Parse(inputString);
                switch (number)
                {
                    case 1:
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
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
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