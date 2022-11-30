using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace KitchenRoom.model
{
    internal class Washer : KitchenEmployee
    {
        public Washer()
        {
            x = 10;
            y = 12;
            sprite = Image.FromFile("C:\\Users\\hp\\OneDrive\\Bureau\\P-H\\informatique\\ucac-icam\\X1\\projets\\boulderdash-group3\\Code\\BoulderDash-project\\main\\sprites\\rock.png");
        }
        public override void Start()
        {
            //while (true)
            //{
            //    int pastX = x;
            //    int pastY = y;
            //    MoveRight();
            //    NotifyHasMoved(pastX, pastY, x, y);
            //}
        }
    }
}
