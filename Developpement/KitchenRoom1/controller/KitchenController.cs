using KitchenRoom1.contract;
using KitchenRoom1.model;
using KitchenRoom1.view;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KitchenRoom1.controller
{
    internal class KitchenController
    {
        private static int TIME_SCALE = 1000;

        public KitchenModel model { get; set; }
        public KitchenView view { get; set; }
        public Queue<Order> orderQueue { get; set; }
        private static Mutex orderQueueMut = new Mutex();
        private static ManualResetEvent orderQueueMre = new ManualResetEvent(false);
        private static Mutex notifyOrderQueueMut = new Mutex();
        public Queue<Order> pendingOrderQueue { get; set; }
        private static Mutex pendingOrderQueueMut = new Mutex();
        private static ManualResetEvent pendingOrderQueueMre = new ManualResetEvent(false);
        private static Mutex notifyPendingOrderQueueMut = new Mutex();

        public Queue<Order> doneOrderQueue { get; set; }
        private static Mutex doneOrderQueueMut = new Mutex();
        private static ManualResetEvent doneOrderQueueMre = new ManualResetEvent(false);
        private static Mutex notifyDoneOrderQueueMut = new Mutex();

        public Queue<Recipe> recipeQueue { get; set; }
        private static Mutex recipeQueueMut = new Mutex();
        private static ManualResetEvent recipeQueueMre = new ManualResetEvent(false);
        private static Mutex notifyRecipeQueueMut = new Mutex();

        public Queue<RecipeTask> recipeTaskQueue { get; set; }
        private static Mutex recipeTaskQueueMut = new Mutex();
        private static ManualResetEvent recipeTaskQueueMre = new ManualResetEvent(false);
        private static Mutex notifyRecipeTaskQueueMut = new Mutex();

        public Queue<(KitchenMaterial, int)> materialWashQueue { get; set; }
        private static Mutex materialWashQueueMut = new Mutex();
        private static ManualResetEvent materialWashQueueMre = new ManualResetEvent(false);
        private static Mutex notifyMaterialWashMut = new Mutex();



        public KitchenController(KitchenModel model, KitchenView view)
        {
            this.model = model;
            this.view = view;

            orderQueue = new Queue<Order>();
            pendingOrderQueue = new Queue<Order>();
            doneOrderQueue = new Queue<Order>();
            recipeQueue = new Queue<Recipe>();
            recipeTaskQueue = new Queue<RecipeTask>();
            materialWashQueue = new Queue<(KitchenMaterial, int)>();
        }

        public void Start()
        {
            Thread chefThread = new(new ThreadStart(ChefTask));
            chefThread.Name = "Chef";
            chefThread.Start();
            model.chef.AddObserver((IObserver)view);

            Thread distantWaiterThread = new(new ThreadStart(DistantWaiterTask));
            distantWaiterThread.Name = "Waiter";
            distantWaiterThread.Start();

            for (int i = 0; i < model.partChefs.Length; i++)
            {
                Thread partChefThread = new(new ThreadStart(PartChefTask));
                partChefThread.Name = "Part Chef #" + (i + 1);
                partChefThread.Start();
            }

            for (int i = 0; i < model.clerks.Length; i++)
            {
                Thread KitchenClerkThread = new(new ThreadStart(KitchenClerkTask));
                KitchenClerkThread.Name = "Clerk #" + (i + 1);
                KitchenClerkThread.Start();
            }

            Thread washerThread = new(new ThreadStart(WasherTask));
            washerThread.Name = "Washer";
            washerThread.Start();
            Application.Run(view.kitchenForm);
        }

        private void ChefTask()
        {
            while (true)
            {
                Console.WriteLine(Thread.CurrentThread.Name + ": Waiting for order...");

                orderQueueMre.WaitOne();
                Console.WriteLine(Thread.CurrentThread.Name + ": Order received.");
                Console.WriteLine(Thread.CurrentThread.Name + ": Sending to Part Chef");

                orderQueueMut.WaitOne();
                pendingOrderQueueMut.WaitOne();
                pendingOrderQueue.Enqueue(orderQueue.First<Order>());
                pendingOrderQueueMre.Set();
                pendingOrderQueueMut.ReleaseMutex();

                recipeQueueMut.WaitOne();
                recipeQueue.Enqueue(orderQueue.First<Order>().recipe);
                recipeQueueMre.Set();
                recipeQueueMut.ReleaseMutex();
                orderQueue.Dequeue();

                orderQueueMut.ReleaseMutex();

                orderQueueMre.Reset();
            }
        }

        private void PartChefTask()
        {
            while (true)
            {
                Console.WriteLine(Thread.CurrentThread.Name + ": Waiting for Recipe...");
                notifyOrderQueueMut.WaitOne();
                recipeQueueMre.WaitOne();
                recipeQueueMre.Reset();
                notifyOrderQueueMut.ReleaseMutex();

                Console.WriteLine(Thread.CurrentThread.Name + ": Recipe received.");

                recipeQueueMut.WaitOne();
                Recipe recipe = recipeQueue.First<Recipe>();
                recipeQueue.Dequeue();
                recipeQueueMut.ReleaseMutex();


                foreach (RecipeTask task in recipe.recipeTasks)
                {
                    while (task.material.Item2 == 0)
                    {
                        Console.WriteLine(Thread.CurrentThread.Name + ": Waiting for " + task.material.Item1.name);
                        Thread.Sleep(2000);

                    }
                    task.material = (task.material.Item1, task.material.Item2 - 1);
                    Console.WriteLine(Thread.CurrentThread.Name + ": Doing task '" + task.name + "' ...");
                    Thread.Sleep(task.duration * TIME_SCALE);
                    Console.WriteLine(Thread.CurrentThread.Name + ": Task '" + task.name + "' done.");

                    materialWashQueueMut.WaitOne();
                    materialWashQueue.Enqueue(task.material);
                    materialWashQueueMre.Set();
                    materialWashQueueMut.ReleaseMutex();
                }

                Console.WriteLine(Thread.CurrentThread.Name + ": Recipe '" + recipe.name + "' done.");


                doneOrderQueueMut.WaitOne();
                pendingOrderQueueMut.WaitOne();
                doneOrderQueue.Enqueue(pendingOrderQueue.First<Order>());
                doneOrderQueueMre.Set();
                pendingOrderQueueMut.ReleaseMutex();
                doneOrderQueueMut.ReleaseMutex();
            }
        }

        private void KitchenClerkTask()
        {
            while (true)
            {
                Console.WriteLine(Thread.CurrentThread.Name + ": Waiting for done orders...");

                notifyDoneOrderQueueMut.WaitOne();
                doneOrderQueueMre.WaitOne();
                doneOrderQueueMre.Reset();
                notifyDoneOrderQueueMut.ReleaseMutex();

                Console.WriteLine(Thread.CurrentThread.Name + ": Done order received");

                doneOrderQueueMut.WaitOne();
                Console.WriteLine(Thread.CurrentThread.Name + ": Moving'" + doneOrderQueue.First<Order>().recipe.name + "' to comptoir");
                doneOrderQueue.Dequeue();
                doneOrderQueueMut.ReleaseMutex();
            }
        }

        private void WasherTask()
        {
            while (true)
            {
                Console.WriteLine(Thread.CurrentThread.Name + ": Waiting for material to wash...");
                notifyMaterialWashMut.WaitOne();
                materialWashQueueMre.WaitOne();
                materialWashQueueMut.WaitOne();
                Console.WriteLine(Thread.CurrentThread.Name + ": Material '" + materialWashQueue.First<(KitchenMaterial, int)>().Item1.name + "' received.");
                Console.WriteLine(Thread.CurrentThread.Name + ": Washing Material '" + materialWashQueue.First<(KitchenMaterial, int)>().Item1.name + "' ...");
                Thread.Sleep(2000);
                Console.WriteLine(Thread.CurrentThread.Name + ": Washing Material '" + materialWashQueue.First<(KitchenMaterial, int)>().Item1.name + "' done.");

                (KitchenMaterial, int) material = materialWashQueue.First<(KitchenMaterial, int)>();
                material = (material.Item1, material.Item2 + 1);

                materialWashQueue.Dequeue();

                materialWashQueueMut.ReleaseMutex();
                materialWashQueueMre.Reset();
                notifyMaterialWashMut.ReleaseMutex();



            }
        }

        private void DistantWaiterTask()
        {
            while (true)
            {
                Thread.Sleep(2000);
                orderQueueMut.WaitOne();
                orderQueue.Enqueue(new Order(1, model.recipes[0]));
                orderQueueMre.Set();
                orderQueueMut.ReleaseMutex();
            }
        }
    }
}
