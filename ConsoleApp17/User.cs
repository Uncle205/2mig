using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp17
{
  public  class User
    {

        public Guid Id { get; set; }
        public string login { get; set; }
        public string Password { get; set; }
        public virtual Cart Cart { get; set; }
    }
}
