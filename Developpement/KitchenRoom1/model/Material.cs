using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KitchenRoom1.model
{
    internal abstract class Material : StaticKitchenElement
    {
        public String name { get; set; }



        public Material(string name)
        {
            this.name = name;
        }
    }
}
