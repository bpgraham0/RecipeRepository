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
        public ViewRecipeForm(Recipe recipe)
        {
            InitializeComponent();
            uxTextBoxName.Text = recipe.Name;
            uxTextBoxDescription.Text = recipe.Description;
            uxTextBoxCourseType.Text = recipe.CourseTypeId.ToString(); //use repository to get course type
            uxTextBoxFoodType.Text = recipe.FoodTypeId.ToString(); //use repository to get course type
            uxTextBoxServingSize.Text = recipe.ServingSize.ToString();
            uxTextBoxPrepTime.Text = recipe.PrepTime.ToString();
            uxTextBoxCookTime.Text = recipe.CookTime.ToString();
            uxDataGridIngredients.DataSource = SqlRecipeRepository.GetIngredientList(recipe.RecipeId);
            uxDataGridSteps.DataSource = SqlRecipeRepository.GetStepList(recipe.RecipeId);
            uxLabelRateStars.Text = SqlHistoryRepository.GetStars(recipe.RecipeId);


            this.recipe = recipe;

        }
        Recipe recipe;

        private void uxButtonRateRecipe_Click(object sender, EventArgs e)
        {
            //SqlHistoryRepository.AddUpdateRecipeHistory(recipe.RecipeId, Convert.ToDouble(uxNumericUpDownStars.Value));
            //uxLabelRateStars.Text = SqlHistoryRepository.GetStars(recipe.RecipeId);
        }
    }
}
