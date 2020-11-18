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
    public partial class AddStepForm : Form
    {
        public AddStepForm()
        {
            InitializeComponent();
        }

        public void AddUpdateStepInfo(Recipe recipe)
        {
            
            SqlRecipeRepository recipeRepository = new SqlRecipeRepository();
            recipeRepository.CreateGetStep(recipe.RecipeId,(int)uxNumericUpDownStepNumber.Value, uxTextBoxDescription.Text); 

        }
    }
}

