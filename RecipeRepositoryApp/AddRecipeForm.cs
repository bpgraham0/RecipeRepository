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
        public AddRecipeForm(SqlRecipeRepository recipeRepository, SqlFoodTypeRepository foodTypeRepository, SqlCourseTypeRepository courseTypeRepository)
        {
            InitializeComponent();
            this.recipeRepository = recipeRepository;
            this.foodTypeRepository = foodTypeRepository;
            this.courseTypeRepository = courseTypeRepository;

        }
        SqlRecipeRepository recipeRepository;
        SqlFoodTypeRepository foodTypeRepository;
        SqlCourseTypeRepository courseTypeRepository;

        public void CreateUpdateRecipeInfo()
        {
            

            //recplace with REpository for creating recipe
            int foodTypeId = foodTypeRepository.CreateUpdateFoodType(uxTextBoxFoodType.Text); 
            int courseTypeId = courseTypeRepository.CreateUpdateCourseType(uxTextBoxCourseType.Text); 

            recipeRepository.CreateUpdateRecipe(foodTypeId, courseTypeId, uxTextBoxName.Text, uxTextBoxDescription.Text,
                Convert.ToDouble(uxNumericUpDownServingSize.Value), Convert.ToInt32(uxNumericUpDownPrepTime.Value),
                Convert.ToInt32(uxNumericUpDownCookTime.Value));
        }


    }
}
