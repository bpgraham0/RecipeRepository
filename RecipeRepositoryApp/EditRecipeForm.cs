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
    public partial class EditRecipeForm : Form
    {
        public EditRecipeForm()
        {
            InitializeComponent();
        }
        public AddRecipeForm(SqlRecipeRepository recipeRepository, Recipe recipe)
        {
            InitializeComponent();
            uxTextBoxName.Text = recipe.Name;
            uxTextBoxDescription.Text = recipe.Description;
            uxTextBoxCourseType.Text = recipe.CourseTypeId.ToString(); //use repository to get course type
            uxTextBoxFoodType.Text = recipe.FoodTypeId.ToString(); //use repository to get course type
            uxNumericUpDownServingSize.Value = Convert.ToDecimal(recipe.ServingSize);
            uxNumericUpDownPrepTime.Value = Convert.ToDecimal(recipe.PrepTime.ToString());
            uxNumericUpDownCookTime.Value = Convert.ToDecimal(recipe.CookTime.ToString());
            uxDataGridViewIngredients.DataSource = SqlRecipeRepository.GetIngredientList(recipe.RecipeId);
            uxDataGridViewSteps.DataSource = SqlRecipeRepository.GetStepList(recipe.RecipeId);

            this.recipe = recipe;
        }
        Recipe recipe;


        public void CreateUpdateRecipeInfo()
        {
            SqlRecipeRepository recipeRepository = new SqlRecipeRepository();

            //recplace with REpository for creating recipe
            int foodTypeId = recipeRepository.GetOrAddFoodTypeId(uxTextBoxCourseType.Text); 
            int courseTypeId = recipeRepository.GetOrAddCourseTypeId(uxTextBoxCourseType.Text); 

            recipeRepository.CreateUpdateRecipe(fooodTypeId, courseTypeId, uxTextBoxName.Text, uxTextBoxDescription.Text,
                Convert.ToDouble(uxNumericUpDownServingSize.Value), Convert.ToInt32(uxNumericUpDownPrepTime.Value),
                Convert.ToInt32(uxNumericUpDownCookTime.Value));
        }

        
        private void uxButtonRemoveIngredient_Click(object sender, EventArgs e)
        {
            IIngredientListRepository ingredientListRepository = new IIngredientListRepository();
            var selectedRows = uxDataGridViewIngredients.SelectedRows;
            foreach(DataGridViewSelectedRowCollection Row in selectedRows)
            {
                ingredientListRepository.DeleteIngredient(recipe.RecipeId, Row[0].Cells[0].Value);

            }


        }

        private void uxButtonAddIngredient_Click(object sender, EventArgs e)
        {
            AddIngredientForm addIngredient = new AddIngredientForm();
            DialogResult dl = addIngredient.ShowDialog();
            if (dl == DialogResult.OK)
            {
                addIngredient.AddUpdateIngredientInfo(recipe);
                uxDataGridViewRecipes.DataSource = recipeRepository.GetRecipeIngredientList(recipe);//Returns reader
                //Add recipe to 
            }
        }

        private void uxButtonAddStep_Click(object sender, EventArgs e)
        {
            AddStepForm addStep = new AddStepForm();
            DialogResult dl = addStep.ShowDialog();
            if (dl == DialogResult.OK)
            {
                addStep.AddUpdateStepInfo(recipe);
                uxDataGridViewSteps.DataSource = recipeRepository.GetRecipeStepList(recipe);//Returns reader
                //Add recipe to 
            }
        }


        private void uxButtonDeleteStep_Click(object sender, EventArgs e)
        {
            IStepRepository stepRepository = new IStepRepository();
            var selectedRows = uxDataGridViewIngredients.SelectedRows;
            foreach (DataGridViewSelectedRowCollection Row in selectedRows)
            {
                stepRepository.DeleteStep(recipe.RecipeId, Row[0].Cells[0].Value);

            }
        }
    }
}
