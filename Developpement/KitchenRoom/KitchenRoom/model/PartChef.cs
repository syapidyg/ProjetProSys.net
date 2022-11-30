using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using KitchenRoom.contract;

namespace KitchenRoom.model
{
    internal class PartChef : KitchenEmployee
    {
        public PartChef()
        {
            x = 168;
            y = 10;
            sprite = Image.FromFile("C:\\Users\\hp\\OneDrive\\Bureau\\P-H\\informatique\\ucac-icam\\X1\\projets\\boulderdash-group3\\Code\\BoulderDash-project\\main\\sprites\\ground.png");
        }

        public override void Start()
        {
            //while (true)
            //{
            //    int pastX = x;
            //    int pastY = y;
            //    MoveDown();
            //    NotifyHasMoved(pastX, pastY, x, y);
            //}
        }
    }
}
