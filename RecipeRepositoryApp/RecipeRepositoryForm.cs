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
        public RecipeRepositoryForm(SqlRecipeRepository recipeRepository, SqlIngredientListRepository ingredientListRepository, SqlFoodTypeRepository foodTypeRepository, SqlCourseTypeRepository courseTypeRepository)
        {
            InitializeComponent();
            

            this.recipeRepository = recipeRepository;
            this.ingredientListRepository = ingredientListRepository;
            this.foodTypeRepository = foodTypeRepository;
            this.courseTypeRepository = courseTypeRepository;
            //DataTable dt = new DataTable();
            //dt.Load(command.ExecuteReader());
            //return dt;
            RefreshDataGridView();//Returns reader

        }
        SqlRecipeRepository recipeRepository;
        SqlFoodTypeRepository foodTypeRepository;
        SqlIngredientListRepository ingredientListRepository;
        SqlCourseTypeRepository courseTypeRepository;


        private void RefreshDataGridView()
        {
            uxDataGridViewRecipes.DataSource = recipeRepository.GetRecipeList();//Returns reader

            if (uxDataGridViewRecipes.Columns.Count > 0)
            {
                uxDataGridViewRecipes.RowHeadersVisible = false;
            }
        }



        private void uxFilterRecipesButton_Click(object sender, EventArgs e)
        {
            FilterRecipeForm filterRecipe = new FilterRecipeForm(recipeRepository);
            DialogResult dl = filterRecipe.ShowDialog();
            if (dl == DialogResult.OK)
            {
                uxDataGridViewRecipes.DataSource = filterRecipe.GetStandardSearchQuery();//Returns reader
            }
            if (dl == DialogResult.Ignore)
            {
                uxDataGridViewRecipes.DataSource = recipeRepository.GetTopTenMonthly();//Returns reader
            }
            if (dl == DialogResult.Yes)
            {
                uxDataGridViewRecipes.DataSource = filterRecipe.GetRecipesXIngredientsAway();//Returns reader
            }
            if (dl == DialogResult.No)
            {
                uxDataGridViewRecipes.DataSource = recipeRepository.GetFreshRecipe();//Returns reader
            }
            if (dl == DialogResult.Retry)
            {
                uxDataGridViewRecipes.DataSource = recipeRepository.GetRecipeHistory();//Returns reader

            }
        }

        private void uxAddRecipeButton_Click(object sender, EventArgs e)
        {
            AddRecipeForm addRecipe = new AddRecipeForm(recipeRepository, foodTypeRepository, courseTypeRepository);
            DialogResult dl = addRecipe.ShowDialog();
            if (dl == DialogResult.OK)
            {
                addRecipe.CreateUpdateRecipeInfo();
                RefreshDataGridView();//Returns reader
                //Add recipe to 
            }
        }

        private void uxButtonViewRecipe_Click(object sender, EventArgs e)
        {
            if (uxDataGridViewRecipes.SelectedRows.Count > 0)
            {
                ViewRecipeForm viewRecipe = new ViewRecipeForm(recipeRepository, ingredientListRepository, foodTypeRepository, courseTypeRepository, recipeRepository.GetRecipeFromName(uxDataGridViewRecipes.SelectedRows[0].Cells[0].Value.ToString()));
                DialogResult dl = viewRecipe.ShowDialog();
                if (dl == DialogResult.Cancel)
                {
                    //Add recipe to 
                }
            }
        }

        private void uxButtonClear_Click(object sender, EventArgs e)
        {
            RefreshDataGridView();//Returns reader
        }

        private void uxEditRecipeButton_Click(object sender, EventArgs e)
        {
            if (uxDataGridViewRecipes.SelectedRows.Count > 0)
            {
                EditRecipeForm editRecipe = new EditRecipeForm(recipeRepository, ingredientListRepository, foodTypeRepository, courseTypeRepository, recipeRepository.GetRecipeFromName(uxDataGridViewRecipes.SelectedRows[0].Cells[0].Value.ToString()));
                DialogResult dl = editRecipe.ShowDialog();
                if (dl == DialogResult.OK)
                {
                    editRecipe.CreateUpdateRecipeInfo();
                    RefreshDataGridView();//Returns reader
                                          //Add recipe to 

                }
                if (dl == DialogResult.No)
                {
                    RefreshDataGridView();//Returns reader
                }
            }
        }

        private void uxOpenPantry_Click(object sender, EventArgs e)
        {
            PantryForm pantryForm = new PantryForm(ingredientListRepository);
            DialogResult dl = pantryForm.ShowDialog();
            if (dl == DialogResult.OK)
            {
                RefreshDataGridView();//Returns reader
                //Add recipe to 
            }
        }
    } 
}
