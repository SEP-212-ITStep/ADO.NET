using FinalExam.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalExam.Services
{
    internal class Chat
    {
        string name { get; set; }
        User user { get; set; }
        Group group { get; set; }

        public Chat() { }

        public Chat(string name) { this.name = name; }
        public Chat(string name, User a) { this.name = name; this.user = a; }
        public Chat(string name, Group a) { this.name = name; this.group = a; }
    }
}
