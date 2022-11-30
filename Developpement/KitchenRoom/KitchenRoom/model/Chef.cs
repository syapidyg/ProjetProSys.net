using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using KitchenRoom.contract;


namespace KitchenRoom.model
{
    internal class Chef : KitchenEmployee
    {
        public Chef()
        {
            x = 15; 
            y = 150;
            sprite = Image.FromFile("C:\\Users\\hp\\OneDrive\\Bureau\\P-H\\informatique\\ucac-icam\\X1\\projets\\boulderdash-group3\\Code\\BoulderDash-project\\main\\sprites\\diamond.png");
        }

        public override void Start()
        {
        }
    }
}
