﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BarberShop.EF;

namespace BarberShop
{
    internal class ClassEntities
    {
        public static BarbyShopEntities1 context { get; set; } = new BarbyShopEntities1();
    }
}
