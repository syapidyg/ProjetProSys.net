using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KitchenRoom1.model
{
    internal class PartChef : KitchenEmployee
    {
        public PartChef()
        {
            x = 168;
            y = 10;
            sprite = Image.FromFile("D:\\UCAC\\X3\\ProgrammationConcurrente\\Projet\\Ressource\\download.jpg");
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
