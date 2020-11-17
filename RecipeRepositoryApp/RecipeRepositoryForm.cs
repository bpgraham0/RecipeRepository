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
    public partial class RecipeRepositoryForm : Form
    {
        public RecipeRepositoryForm(IRecipeRepository recipeRepository)
        {
            InitializeComponent();
            //uxDataGridViewRecipes.DataSource = recipeRepository.GetRecipeList();//Returns reader
            //DataTable dt = new DataTable();
            //dt.Load(command.ExecuteReader());
            //return dt;

        }

        

        

        private void uxFilterRecipesButton_Click(object sender, EventArgs e)
        {
           
        }

        private void uxAddRecipeButton_Click(object sender, EventArgs e)
        {
            AddRecipeForm addRecipe = new AddRecipeForm();
            DialogResult dl = addRecipe.ShowDialog();
            if (dl == DialogResult.OK)
            {
                Recipe recipe = addRecipe.GetRecipeInfo();
                //Add recipe to 
            }
        }

        private void uxButtonViewRecipe_Click(object sender, EventArgs e)
        {

        }
    }
}
