using KitchenRoom1.contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KitchenRoom1.model
{
    internal abstract class MobileKitchenElement : KitchenElement
    {
        public int x { get; set; }
        public int y { get; set; }

        public int speed { get; set; }

        public MobileKitchenElement()
        {
            speed = 1;
        }

        public void MoveLeft()
        {
            x -= speed;
        }

        public void MoveRight()
        {
            x += speed;
        }

        public void MoveUp()
        {
            y -= speed;
        }

        public void MoveDown()
        {
            y += speed;
        }

        
    }
}
