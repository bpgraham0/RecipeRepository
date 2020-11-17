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



namespace RecipeRepositoryApp
{
    public partial class RecipeRepositoryForm : Form
    {
        public RecipeRepositoryForm()
        {
            InitializeComponent();
        }

        private void RecipeRepository_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'recipeRepositoryDataSet.Recipe' table. You can move, or remove it, as needed.
            this.recipeTableAdapter.Fill(this.recipeRepositoryDataSet.Recipe);

        }

        

        private void uxFilterRecipesButton_Click(object sender, EventArgs e)
        {
           
        }

        private void uxAddRecipeButton_Click(object sender, EventArgs e)
        {
            uxTextBoxCourseType addRecipe = new uxTextBoxCourseType();
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
