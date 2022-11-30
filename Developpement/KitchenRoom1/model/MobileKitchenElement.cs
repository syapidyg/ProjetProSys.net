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
        private List<IObserver> observers;
        public int x { get; set; }
        public int y { get; set; }

        public int speed { get; set; }

        public MobileKitchenElement()
        {
            observers = new List<IObserver>();
            speed = 5;
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

        public void AddObserver(IObserver observer)
        {
            observers.Add(observer);
        }

        public void NotifyHasMoved(int pastX, int pastY, int newX, int newY)
        {
            foreach (IObserver observer in observers)
            {
                observer.UpdateHasMoved(pastX, pastY, newX, newY);
            }
        }

        public abstract void Start();
    }
}
