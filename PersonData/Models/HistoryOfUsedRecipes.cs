using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeData.Models
{
    public class HistoryOfUsedRecipes
    {
        public int RecipeId { get; }
        public DateTime LastDateUsed { get; }
        public int Stars { get; }
        public HistoryOfUsedRecipes(int recipeId, DateTime lastDateUsed, int stars)
        {
            RecipeId = recipeId;
            LastDateUsed = lastDateUsed;
            Stars = stars;
        }
    }
}
