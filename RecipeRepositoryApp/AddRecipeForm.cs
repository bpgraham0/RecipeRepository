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
    public partial class AddRecipeForm : Form
    {
        public AddRecipeForm()
        {
            InitializeComponent();
        }

        public Recipe GetRecipeInfo()
        {
            //recplace with REpository for creating recipe
            return new Recipe(1, 1, 1, uxTextBoxName.Text, uxTextBoxDescription.Text, Convert.ToInt32(uxNumericUpDownServingSize.Value), Convert.ToInt32(uxNumericUpDownPrepTime.Value), Convert.ToInt32(uxNumericUpDownCookTime.Value), DateTime.Now, DateTime.Now);//use Repository to create Recipe Item
        }

        private void uxButtonRateRecipe_Click(object sender, EventArgs e)
        {

        }
    }
}
