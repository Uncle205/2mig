﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp17
{
  public  class Cart
    {
        public Guid id { get; set; }
        public virtual ICollection<Item> Items { get; set; }

    }
}
