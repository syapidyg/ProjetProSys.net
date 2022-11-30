using KitchenRoom.contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;




namespace KitchenRoom.model

{
    internal abstract class MobileKitchenElement : KitchenElement
    {
        private List<IOobserver> observers;
        public int x { get; set; }
        public int y { get; set; }

        public int speed { get; set; }

        public MobileKitchenElement()
        {
            observers = new List<IOobserver>();
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

        public void AddObserver(IOobserver observer)
        {
            observers.Add(observer);
        }

        public void NotifyHasMoved(int pastX, int pastY, int newX, int newY)
        {
            foreach (IOobserver observer in observers)
            {
                observer.UpdateHasMoved(pastX, pastY, newX, newY);
            }
        }

        public abstract void Start();
    }
}
