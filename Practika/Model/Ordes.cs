﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practika.Model
{
    internal class Ordes
    {
        public class Order
        {
            public int Id { get; set; }
            public string Description { get; set; }
            public decimal TotalPrice { get; set; }
        }
    }
}
