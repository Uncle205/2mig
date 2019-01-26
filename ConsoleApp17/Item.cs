using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp17
{
  public  class Item
    {
        public Guid id { get; set; }
        public string Name { get; set;}
        public int Price { get; set; }
        public DateTime? ProductOutOfDate { get; set; }
        public virtual ICollection<Cart> Carts { get; set; }
    }
}
