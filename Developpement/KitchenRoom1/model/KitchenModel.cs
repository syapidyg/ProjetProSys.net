using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KitchenRoom1.model
{
    internal class KitchenModel
    {
        public KitchenRoom kitchenRoom { get; set; }

        public (KitchenMaterial, int) cookingFire;

        public (KitchenMaterial, int) oven;

        public (KitchenMaterial, int) blender;

        public (KitchenMaterial, int) pan;

        public (KitchenMaterial, int) kitchenKnife;


        public Recipe[] recipes { get; set; }

        public Chef chef { get; set; }
        public PartChef[] partChefs { get; set; }
        public KitchenClerk[] clerks { get; set; }
        public Washer washer { get; set; }


        public KitchenModel()
        {
            kitchenRoom = new KitchenRoom();

            cookingFire = (KitchenMaterialFactory.CreateCookingFire(), 5);
            oven = (KitchenMaterialFactory.CreateOven(), 1);
            blender = (KitchenMaterialFactory.CreateBlender(), 1);
            pan = (KitchenMaterialFactory.CreatePan(), 10);
            kitchenKnife = (KitchenMaterialFactory.CreateKitchenKnife(), 5);

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

            chef = KitchenEmployeeFactory.CreateChef();

            partChefs = new PartChef[2];
            clerks = new KitchenClerk[2];

            for (int i = 0; i < partChefs.Length; i++)
            {
                partChefs[i] = KitchenEmployeeFactory.CreatePartChef();
            }
            for (int i = 0; i < clerks.Length; i++)
            {
                clerks[i] = KitchenEmployeeFactory.CreateKitchenClerk();
            }

            washer = KitchenEmployeeFactory.CreateWasher();
        }

    }
}
