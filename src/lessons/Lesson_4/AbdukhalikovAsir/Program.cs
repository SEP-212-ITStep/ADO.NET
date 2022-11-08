using Microsoft.Data.SqlClient;
using System.Data;
using System;
using Microsoft.EntityFrameworkCore;

namespace lesson_4
{
    internal class Program
    {
        static async Task Main(string[] args){
            var httpClient = new HttpClient(){
                BaseAddress = Uri("https://randomuser.me/api/")
            };

            var responce = await httpClient.GetStringAsync("");
            var obj = JsonSerializer.Deserialize<RootObject>(responce);

            Console.WriteLine(responce);
            var nullableResult = obj.results[0];
            await using var DbContext = new PersonDbContext();

            var PersonAddress = LocationCreate(nullableResult);
            DbContext.Location.Add(PersonAddress);
            var person = PersonCreate(nullableResult);
            DbContext.People.Add(person);
            await DbContext.SaveChangesAsync();
        }

        static Person PersonCreate(Result rs){
            Person person = new Person();
            person.FirstName = rs.name.first;
            person.LastName = rs.name.last;
            person.Gender = rs.gender;
            person.Email = rs.email;
            person.Phone = Random.Shared.Next(1000000, 999999999);
            person.dob = rs.dob.date;
            person.Age = rs.dob.age;   
            person.PersonLocation = new Location();
            person.PersonLocation.Address = rs.location.Address;
            person.PersonLocation.City = rs.location.City;
            person.PersonLocation.State = rs.location.state;
            person.PersonLocation.Country = rs.location.Country;
            person.PersonLocation.PostCode = rs.location.PostCode;
            person.PicUrlLarge = rs.picture.large;
            return person;
        }

        static Location LocationCreate(Result rs){
            var tmp = new Location();
            tmp.Address = rs.location.Address;
            tmp.City = rs.location.City;
            tmp.State = rs.location.State;
            tmp.PostCode = rs.location.PostCode;
            tmp.Country = rs.location.country;
            tmp.Latitude = double.Parse(rs.location.Latitude);
            tmp.Longtitude = double.Parse(rs.location.Longtitude);
            return tmp;
        }
        
    }
}