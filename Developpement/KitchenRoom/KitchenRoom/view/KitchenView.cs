using KitchenRoom.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KitchenRoom.view
{
    internal class KitchenView : IObserver
    {
        private static int FPS = 25;
        private static int FRAME_RATE = 1000 / FPS;
        private static int SQUARE_SIZE = 32;
        public KitchenForm kitchenForm { get; set; }

        public KitchenView(KitchenModel model)
        {
            kitchenForm = new KitchenForm(model);
        }

        void IObserver.UpdateHasMoved(int pastX, int pastY, int newX, int newY)
        {
            kitchenForm.Invoke((MethodInvoker)delegate
            {
                kitchenForm.Invalidate(new Rectangle(pastX, pastY, SQUARE_SIZE, SQUARE_SIZE));
                kitchenForm.Invalidate(new Rectangle(newX, newY, SQUARE_SIZE, SQUARE_SIZE));
                kitchenForm.Update();
            });

            Thread.Sleep(FRAME_RATE);
        }
    }
}
