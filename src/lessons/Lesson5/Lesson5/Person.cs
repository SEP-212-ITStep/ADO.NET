using Lesson5;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson5
{
    public class Person
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public string TitleName { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public int PhoneNumber { get; set; }
        public string PictureUrlLarge { get; set; }
        public int PersonAddressId { get; set; }
        public virtual PersonAddress PersonAddress { get; set; }

    }

}
