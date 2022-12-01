using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KitchenRoom1.model
{
    internal class KitchenMaterial : Material
    {
    
        public KitchenMaterial(String name, int quantity, Image sprite) : base(name, quantity)
        {            
           SetSprite("normal", sprite);
        }

    }
}
