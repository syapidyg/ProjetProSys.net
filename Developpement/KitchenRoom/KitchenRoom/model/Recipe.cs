﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KitchenRoom.model
{
    internal class Recipe
    {
        public string name { get; set; }
        public Ingredient[] ingredients { get; set; }
        public RecipeTask[] recipeTasks { get; set; }

        public Recipe(string name, Ingredient[] ingredients, RecipeTask[] recipeTasks)
        {
            this.name = name;
            this.ingredients = ingredients;
            this.recipeTasks = recipeTasks;
        }
    }
}
