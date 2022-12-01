using KitchenRoom1.contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KitchenRoom1.model
{
    internal class KitchenModel
    {
        private List<IObserver> observers;

        public KitchenRoom kitchenRoom { get; set; }

        public KitchenMaterial cookingFire;

        public KitchenMaterial oven;

        public KitchenMaterial blender;

        public KitchenMaterial pan;

        public KitchenMaterial kitchenKnife;

        public Recipe[] recipes { get; set; }

    
        public Chef[] chefs { get; set; }

        
        public PartChef[] partChefs { get; set; }

       
        public KitchenClerk[] clerks { get; set; }

        
        public Washer[] washers { get; set; }


        public KitchenModel()
        {
            kitchenRoom = new KitchenRoom();
            observers = new List<IObserver>();


            cookingFire = KitchenMaterialFactory.CreateCookingFire();
            oven = KitchenMaterialFactory.CreateOven();
            blender = KitchenMaterialFactory.CreateBlender();
            pan = KitchenMaterialFactory.CreatePan();
            kitchenKnife = KitchenMaterialFactory.CreateKitchenKnife();

            recipes = new Recipe[1]
            {
                new Recipe
                (
                    "Feuilleté au crabe",

                    new Ingredient[4]
                    {
                        new Ingredient("pâte feuilletée"),
                        new Ingredient("oeuf"),
                        new Ingredient("sel"),
                        new Ingredient("poivre")
                    },

                    new RecipeTask[3]
                    {
                        new RecipeTask("Préchauffer le four à 230°", 5, oven),
                        new RecipeTask("Mélanger crabe, citron, chapelure, herbes", 1, blender),
                        new RecipeTask("Lier le tout avec un oeuf", 1, kitchenKnife)
                    }
                ),


            };
            SetEmployeeConfig(1, 2, 2, 1);


        }
        public void SetEmployeeConfig(int chefNumber, int partChefNumber, int clerkNumber, int washerNumber)
        {
            chefs = new Chef[chefNumber];
            partChefs = new PartChef[partChefNumber];
            clerks = new KitchenClerk[clerkNumber];
            washers = new Washer[washerNumber];

            for (int i = 0; i < chefs.Length; i++)
            {
                chefs[i] = new Chef();
                chefs[i].y = i;
            }

            for (int i = 0; i < partChefs.Length; i++)
            {
                PartChef partChef = new()
                {
                    x = 1,
                    y = i + 1
                };


                if (i % 2 != 0)
                {
                    partChef.currentSprite = partChef.GetSprite("moving-down");
                }

                partChefs[i] = partChef;
            }

            for (int i = 0; i < clerks.Length; i++)
            {
                clerks[i] = new();
                clerks[i].x = 0;
                clerks[i].y = i + 2;
            }

            for (int i = 0; i < washers.Length; i++)
            {
                washers[i] = new Washer();
            }
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

    }


}
