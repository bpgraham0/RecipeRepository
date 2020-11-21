    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeData.Models
{
    public class Ingredient
    {
        public int IngredientId { get; }
        public string Name { get; }
        public bool HaveItem { get; }
        public DateTime CreatedOn { get; }
        public DateTime UpdatedOn { get; } 

        public Ingredient(int ingredientId, string name, int haveInt, DateTime createdOn, DateTime updatedOn)
        {
            IngredientId = ingredientId;
            Name = name;
            if (haveInt == 1)
            {
                HaveItem = true;
            }
            else HaveItem = false;
            CreatedOn = createdOn;
            UpdatedOn = updatedOn;
        }


    }
}
