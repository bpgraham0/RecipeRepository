using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RecipeData.Models;

namespace RecipeData.Repositories
{
    public interface  IRecipeRepository
    {
        IReadOnlyList<Recipe> RetreiveRecipes();

        Recipe FetchRecipe(int recipeId);

        Recipe CreateUpdateRecipe(int foodTypeId, int courseTypeId, string name, string description, double servingSize, int prepTime, int cookTime);

        void DeletRecipe(int recipeId);
    }
}
