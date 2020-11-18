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
       
        public EditRecipeForm(SqlRecipeRepository recipeRepository, SqlIngredientListRepository ingredientListRepository, SqlFoodTypeRepository foodTypeRepository, SqlCourseTypeRepository courseTypeRepository, Recipe recipe)
        {
            InitializeComponent();
            uxTextBoxName.Text = recipe.Name;
            this.recipeRepository = recipeRepository;
            this.ingredientListRepository = ingredientListRepository;
            this.foodTypeRepository = foodTypeRepository;
            this.courseTypeRepository = courseTypeRepository;

            uxTextBoxDescription.Text = recipe.Description;
            uxTextBoxCourseType.Text = recipe.CourseTypeId.ToString(); //use repository to get course type
            uxTextBoxFoodType.Text = recipe.FoodTypeId.ToString(); //use repository to get course type
            uxNumericUpDownServingSize.Value = Convert.ToDecimal(recipe.ServingSize);
            uxNumericUpDownPrepTime.Value = Convert.ToDecimal(recipe.PrepTime.ToString());
            uxNumericUpDownCookTime.Value = Convert.ToDecimal(recipe.CookTime.ToString());
            uxDataGridViewIngredients.DataSource = ingredientListRepository.GetIngredientList(recipe.RecipeId);
            uxDataGridViewSteps.DataSource = recipeRepository.GetStepList(recipe.RecipeId);

            this.recipe = recipe;
        }
        Recipe recipe;
        SqlRecipeRepository recipeRepository;
        SqlIngredientListRepository ingredientListRepository;
        SqlFoodTypeRepository foodTypeRepository;
        SqlCourseTypeRepository courseTypeRepository;



        public void CreateUpdateRecipeInfo()
        {
            SqlRecipeRepository recipeRepository = new SqlRecipeRepository();

            //recplace with REpository for creating recipe
            int foodTypeId = foodTypeRepository.GetOrAddFoodTypeId(uxTextBoxCourseType.Text); 
            int courseTypeId = courseTypeRepository.GetOrAddCourseTypeId(uxTextBoxCourseType.Text); 

            recipeRepository.CreateUpdateRecipe(foodTypeId, courseTypeId, uxTextBoxName.Text, uxTextBoxDescription.Text,
                Convert.ToDouble(uxNumericUpDownServingSize.Value), Convert.ToInt32(uxNumericUpDownPrepTime.Value),
                Convert.ToInt32(uxNumericUpDownCookTime.Value));
        }

        
        private void uxButtonRemoveIngredient_Click(object sender, EventArgs e)
        {
            var selectedRows = uxDataGridViewIngredients.SelectedRows;
            foreach(DataGridViewSelectedRowCollection Row in selectedRows)
            {
                ingredientListRepository.DeleteIngredient(recipe.RecipeId, Row[0].Cells[0].Value);

            }


        }

        private void uxButtonAddIngredient_Click(object sender, EventArgs e)
        {
            AddIngredientForm addIngredient = new AddIngredientForm(ingredientListRepository);
            DialogResult dl = addIngredient.ShowDialog();
            if (dl == DialogResult.OK)
            {
                addIngredient.AddUpdateIngredientInfo(recipe);
                uxDataGridViewIngredients.DataSource = ingredientListRepository.GetRecipeIngredientList(recipe);//Returns reader
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
                uxDataGridViewSteps.DataSource = recipeRepository.GetStepList(recipe.RecipeId);//Returns reader
                //Add recipe to 
            }
        }


        private void uxButtonDeleteStep_Click(object sender, EventArgs e)
        {
            var selectedRows = uxDataGridViewSteps.SelectedRows;
            foreach (DataGridViewSelectedRowCollection Row in selectedRows)
            {
                recipeRepository.DeleteStep(recipe.RecipeId, Row[0].Cells[0].Value);

            }
        }

        private void uxButtonDeleteRecipe_Click(object sender, EventArgs e)
        {
            recipeRepository.DeleteRecipe(recipe.RecipeId);
        }
    }
}
