using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace KitchenRoom1.model
{
    internal class Chef : KitchenEmployee
    {
        public Chef()
        {
            x = 28;
            y = 150;
            sprite = Image.FromFile("D:\\UCAC\\X3\\ProgrammationConcurrente\\Projet\\Ressource\\download.jpg");
        }

        public override void Start()
        {
        }
    }
}
