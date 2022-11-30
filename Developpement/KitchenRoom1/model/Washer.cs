using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KitchenRoom1.model
{
    internal class Washer : KitchenEmployee
    {
        public Washer()
        {
            x = 10;
            y = 12;
            sprite = Image.FromFile("D:\\UCAC\\X3\\ProgrammationConcurrente\\Projet\\Ressource\\download.jpg");
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
