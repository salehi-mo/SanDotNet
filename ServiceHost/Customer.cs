﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceHost
{
    public class Customer
    {
        public long CustomerId { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public DateTime? ClockOut { get; set; }
    }
}
