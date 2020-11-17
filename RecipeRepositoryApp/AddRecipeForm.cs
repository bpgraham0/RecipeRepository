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
    public partial class AddRecipeForm : Form
    {
        public AddRecipeForm()
        {
            InitializeComponent();
        }

        public Recipe GetRecipeInfo()
        {
            SqlRecipeRepository recipeRepository = new SqlRecipeRepository();

            //recplace with REpository for creating recipe
            //int foodTypeId = recipeRepository.GetOrAddFoodTypeId(uxTextBoxCourseType.Text); 
            //int courseTypeId = recipeRepository.GetOrAddCourseTypeId(uxTextBoxCourseType.Text); 

            return recipeRepository.CreateUpdateRecipe(1, 1, uxTextBoxName.Text, uxTextBoxDescription.Text,
                Convert.ToDouble(uxNumericUpDownServingSize.Value), Convert.ToInt32(uxNumericUpDownPrepTime.Value),
                Convert.ToInt32(uxNumericUpDownCookTime.Value));
        }

        
        private void uxButtonRemoveIngredient_Click(object sender, EventArgs e)
        {
            var selectedRows = uxDataGridViewIngredients.SelectedRows;
            foreach(DataGridViewSelectedRowCollection Row in selectedRows)
            {
                //SqlIngredientListRepository.DeleteIngredient(Row[0].Cells[0].Value);

            }


        }

        private void uxButtonAddIngredient_Click(object sender, EventArgs e)
        {

        }
    }
}
