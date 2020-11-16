using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RecipeData.Models;

namespace RecipeData
{
    public class RecipeList
    {
        private readonly string connectionString = @"Data Source=(localdb)\LocalDBApp1;Initial Catalog=RecipeRepository;Integrated Security=True"; 

        public IList<Recipe> recipeList { get; set; }

        public IList<IngredientList> ingredientList { get; set; }


    }
}
