using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KitchenRoom.model
{
    internal class KitchenMaterialFactory
    {
        private static KitchenMaterial COOKING_FIRE = new KitchenMaterial("cooking fire");
        private static KitchenMaterial PAN = new KitchenMaterial("pan");
        private static KitchenMaterial OVEN = new KitchenMaterial("oven");
        private static KitchenMaterial BLENDER = new KitchenMaterial("blender");
        private static KitchenMaterial KITCHEN_KNIFE = new KitchenMaterial("kitchen knife");


        public static KitchenMaterial CreateCookingFire()
        {
            return COOKING_FIRE;
        }
        public static KitchenMaterial CreatePan()
        {
            return PAN;
        }
        public static KitchenMaterial CreateOven()
        {
            return OVEN;
        }
        public static KitchenMaterial CreateBlender()
        {
            return BLENDER;
        }
        public static KitchenMaterial CreateKitchenKnife()
        {
            return KITCHEN_KNIFE;
        }
    }
}
