using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeData.Models
{
    public class IngredientList
    {
        public int RecipeId { get; }
        public int IngredientId { get; }
        public int MeasurementId { get; }
        public double Quantity { get; }

        public IngredientList(int recipeId, int ingredientId, int measurementId, double  quantity)
        {
            RecipeId = recipeId;
            IngredientId = ingredientId;
            MeasurementId = measurementId;
            Quantity = quantity;
        }
    }
}
