using lesson4;
using System;

namespace lesson4
{
    public class Person
    {
        public int Id { set; get; }
        public string Gender { set; get; }
        public string Title { set; get; }
        public string FirstName { set; get; }
        public string LastName { set; get; }
        public int LocationId { set; get; }
        public virtual Location PersonLocation { set; get; }
        public string Email { set; get; }
        public Authorization Auth { set; get; }
        public DateTime dob { set; get; }
        public int Age { set; get; }
        public DateTime Registration { set; get; }
        public string Phone { set; get; }
        public string PicUrlLarge { set; get; }

    }
}