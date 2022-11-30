using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KitchenRoom.contract
{
    internal interface IOobserver
    {
        public void UpdateHasMoved(int pastX, int pastY, int newX, int newY);
    }
}
