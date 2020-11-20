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
            this.courseTypeRepository = courseTypeRepository;
            this.foodTypeRepository = foodTypeRepository;
            this.ingredientListRepository = ingredientListRepository;
            this.recipe = recipe;
            RefreshView();

        }
        Recipe recipe;
        SqlRecipeRepository recipeRepository;
        SqlCourseTypeRepository courseTypeRepository;
        SqlFoodTypeRepository foodTypeRepository;
        SqlIngredientListRepository ingredientListRepository;

        private void RefreshView()
        {
            uxTextBoxName.Text = recipe.Name;
            uxTextBoxDescription.Text = recipe.Description;
            uxTextBoxCourseType.Text = courseTypeRepository.FetchCourseType(recipe.RecipeId); //use repository to get course type
            uxTextBoxFoodType.Text = foodTypeRepository.FetchFoodType(recipe.RecipeId); //use repository to get course type
            uxTextBoxServingSize.Text = recipe.ServingSize.ToString();
            uxTextBoxPrepTime.Text = recipe.PrepTime.ToString();
            uxTextBoxCookTime.Text = recipe.CookTime.ToString();
            uxDataGridViewIngredients.DataSource = ingredientListRepository.FetchIngredientList(recipe.RecipeId);
            if (uxDataGridViewIngredients.Columns.Count > 0)
            {
                uxDataGridViewIngredients.Columns[0].Visible = false;
                uxDataGridViewIngredients.RowHeadersVisible = false;
            }
            uxDataGridViewSteps.DataSource = recipeRepository.GetStepList(recipe.RecipeId);
            if (uxDataGridViewSteps.Columns.Count > 0)
            {
                uxDataGridViewSteps.RowHeadersVisible = false;
            }
            uxLabelRateStars.Text = "Currently Rated " + recipeRepository.GetStars(recipe.RecipeId).ToString() + " out of 5 Stars";

        }

        private void uxButtonRateRecipe_Click(object sender, EventArgs e)
        {
            recipeRepository.addtoHistoryOfUsedRecipes(recipe.RecipeId, Convert.ToDouble(uxNumbericUpDownRate.Value));
            RefreshView();
        }
    }
}
