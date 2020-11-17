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
            uxDataGridViewRecipes.DataSource = recipeRepository.GetRecipeList();//Returns reader
            //DataTable dt = new DataTable();
            //dt.Load(command.ExecuteReader());
            //return dt;

        }

        

        

        private void uxFilterRecipesButton_Click(object sender, EventArgs e)
        {
            FilterRecipeForm filterRecipe = new FilterRecipeForm();
            DialogResult dl = filterRecipe.ShowDialog();
            if (dl == DialogResult.OK)
            {
                uxDataGridViewRecipes.DataSource = recipeRepository.GetRecipeList();//Returns reader
                //Add recipe to 

            }
        }

        private void uxAddRecipeButton_Click(object sender, EventArgs e)
        {
            AddRecipeForm addRecipe = new AddRecipeForm();
            DialogResult dl = addRecipe.ShowDialog();
            if (dl == DialogResult.OK)
            {
                addRecipe.CreateUpdateRecipeInfo();
                uxDataGridViewRecipes.DataSource = recipeRepository.GetRecipeList();//Returns reader
                //Add recipe to 
            }
        }

        private void uxButtonViewRecipe_Click(object sender, EventArgs e)
        {
            ViewRecipeForm viewRecipe = new ViewRecipeForm(recipeRepository.GetRecipeIdFromName(uxDataGridViewRecipes.SelectedRows[0].Cells[0].Value.ToString())); 
            DialogResult dl = viewRecipe.ShowDialog();
            if (dl == DialogResult.Cancel)
            {
                //Add recipe to 
            }
        }

        private void uxButtonClear_Click(object sender, EventArgs e)
        {
            uxDataGridViewRecipes.DataSource = recipeRepository.GetRecipeList();//Returns reader
        }

        private void uxEditRecipeButton_Click(object sender, EventArgs e)
        {
            AddRecipeForm editRecipe = new AddRecipeForm(recipeRepository.GetRecipeIdFromName(uxDataGridViewRecipes.SelectedRows[0].Cells[0].Value.ToString()));
            DialogResult dl = editRecipe.ShowDialog();
            if (dl == DialogResult.OK)
            {
                editRecipe.CreateUpdateRecipeInfo();
                uxDataGridViewRecipes.DataSource = recipeRepository.GetRecipeList();//Returns reader
                //Add recipe to 
            }
        }

        private void uxOpenPantry_Click(object sender, EventArgs e)
        {

        }
    }
}
