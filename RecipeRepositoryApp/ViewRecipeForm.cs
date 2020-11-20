using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RecipeData.Models;
using RecipeData.Repositories;

namespace RecipeRepositoryApp
{
    public partial class ViewRecipeForm : Form
    {
        public ViewRecipeForm(SqlRecipeRepository recipeRepository, SqlIngredientListRepository ingredientListRepository, SqlFoodTypeRepository foodTypeRepository, SqlCourseTypeRepository courseTypeRepository ,Recipe recipe)
        {
            
            InitializeComponent();
            this.recipeRepository = recipeRepository;
            uxTextBoxName.Text = recipe.Name;
            uxTextBoxDescription.Text = recipe.Description;
            uxTextBoxCourseType.Text = courseTypeRepository.FetchCourseType(recipe.RecipeId); //use repository to get course type
            uxTextBoxFoodType.Text = foodTypeRepository.FetchFoodType(recipe.RecipeId); //use repository to get course type
            uxTextBoxServingSize.Text = recipe.ServingSize.ToString();
            uxTextBoxPrepTime.Text = recipe.PrepTime.ToString();
            uxTextBoxCookTime.Text = recipe.CookTime.ToString();
            uxDataGridViewIngredients.DataSource = ingredientListRepository.FetchIngredientList(recipe.RecipeId);
            uxDataGridViewSteps.DataSource = recipeRepository.GetStepList(recipe.RecipeId);
            uxLabelRateStars.Text = "Currently Rated " + recipeRepository.GetStars(recipe.RecipeId).ToString() + " out of 5 Stars";


            this.recipe = recipe;

        }
        Recipe recipe;
        SqlRecipeRepository recipeRepository;

        private void uxButtonRateRecipe_Click(object sender, EventArgs e)
        {
            recipeRepository.addtoHistoryOfUsedRecipes(recipe.RecipeId, Convert.ToDouble(uxNumbericUpDownRate.Value));
            uxLabelRateStars.Text = "Currently Rated " + recipeRepository.GetStars(recipe.RecipeId).ToString() +" out of 5 Stars";

        }
    }
}
