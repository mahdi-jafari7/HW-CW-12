using HW12.Entities;
using HW12.Entities.HW12.Entities;
using HW12.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW12.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public List<Tasktodo> Tasks { get; set; }
    }
}



//-----------

   