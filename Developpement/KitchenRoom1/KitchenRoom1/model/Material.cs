﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KitchenRoom1.model
{
    internal abstract class Material : StaticKitchenElement
    {
        public String name { get; set; }
        public int quantity { get; set; }
        public bool washable { get; set; }

        public Material(string name, int quantity)
        {
            this.name = name;
            this.quantity = quantity;
            this.washable = true;
        }
    }
}
