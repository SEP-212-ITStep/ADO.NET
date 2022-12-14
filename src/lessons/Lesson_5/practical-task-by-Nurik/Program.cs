using System.Globalization;
using System.Text.Json;
using Microsoft.EntityFrameworkCore;

namespace practical_task_by_Nurik
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            // https://randomuser.me/api/

            var httpClient = new HttpClient()
            {
                BaseAddress = new Uri("https://randomuser.me/api/")
            };

            var response = await httpClient.GetStringAsync("");
            var obj = JsonSerializer.Deserialize<Rootobject>(response);
            await using var dbContext = new PersonDbContext();
            await using var tran = await dbContext.Database.BeginTransactionAsync();
            try
            {
                var nullableResult = obj.results[0];

                var personAddress = AddressCreate(nullableResult);

                dbContext.PeopleAddresses.Add(personAddress);
                await dbContext.SaveChangesAsync();

                var person = PersonCreate(nullableResult);
                person.PersonAddressId = personAddress.Id;

                dbContext.People.Add(person);
                await dbContext.SaveChangesAsync();

                await tran.CommitAsync();
                Console.WriteLine("Добавление прошло успешно!");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                await tran.RollbackAsync();
            }
        }

        static Person PersonCreate(Result rs)
        {
            var person = new Person();
            person.Name = rs.name.title + " " + rs.name.first + " " + rs.name.last;
            person.FirstName = rs.name.first;
            person.LastName = rs.name.last;
            person.TitleName = rs.name.title;
            person.Gender = rs.gender;
            person.Address = rs.location.street.number + " " + rs.location.street.name;
            person.Email = rs.email;
            person.Login = rs.login.username;
            person.Password = rs.login.password;
            person.PhoneNumber = Random.Shared.Next(100000, 10000000);
            person.PictureUrlLarge = rs.picture.large;
            return person;
        }

        static PersonAddress AddressCreate(Result rs)
        {
            var personAddress = new PersonAddress();
            personAddress.City = rs.location.city;
            personAddress.Country = rs.location.country;
            personAddress.State = rs.location.state;
            personAddress.PostCode = rs.location.postcode;
            personAddress.Latitude = double.Parse(rs.location.coordinates.latitude, CultureInfo.InvariantCulture);
            personAddress.Longitude = double.Parse(rs.location.coordinates.longitude, CultureInfo.InvariantCulture);
            return personAddress;
        }

    }
    public class Rootobject
    {
        public Result[] results { get; set; }
        public Info info { get; set; }
    }

    public class Info
    {
        public string seed { get; set; }
        public int results { get; set; }
        public int page { get; set; }
        public string version { get; set; }
    }

    public class Result
    {
        public string gender { get; set; }
        public Name name { get; set; }
        public Location location { get; set; }
        public string email { get; set; }
        public Login login { get; set; }
        public Dob dob { get; set; }
        public Registered registered { get; set; }
        public string phone { get; set; }
        public string cell { get; set; }
        public Id id { get; set; }
        public Picture picture { get; set; }
        public string nat { get; set; }
    }

    public class Name
    {
        public string title { get; set; }
        public string first { get; set; }
        public string last { get; set; }
    }

    public class Location
    {
        public Street street { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string country { get; set; }
        public int postcode { get; set; }
        public Coordinates coordinates { get; set; }
        public Timezone timezone { get; set; }
    }

    public class Street
    {
        public int number { get; set; }
        public string name { get; set; }
    }

    public class Coordinates
    {
        public string latitude { get; set; }
        public string longitude { get; set; }
    }

    public class Timezone
    {
        public string offset { get; set; }
        public string description { get; set; }
    }

    public class Login
    {
        public string uuid { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string salt { get; set; }
        public string md5 { get; set; }
        public string sha1 { get; set; }
        public string sha256 { get; set; }
    }

    public class Dob
    {
        public DateTime date { get; set; }
        public int age { get; set; }
    }

    public class Registered
    {
        public DateTime date { get; set; }
        public int age { get; set; }
    }

    public class Id
    {
        public string name { get; set; }
        public string value { get; set; }
    }

    public class Picture
    {
        public string large { get; set; }
        public string medium { get; set; }
        public string thumbnail { get; set; }
    }



}