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
    public partial class FilterRecipeForm : Form
    {
        public FilterRecipeForm(SqlRecipeRepository recipeRepository)
        {
            InitializeComponent();
            this.recipeRepository = recipeRepository;
        }
        SqlRecipeRepository recipeRepository;

        public DataTable GetStandardSearchQuery()
        {
            return recipeRepository.GetStandardSearchQuery(uxTextBoxName.Text, uxTextBoxDescription.Text, uxTextBoxCourseType.Text,
                uxTextBoxFoodType.Text, Convert.ToDouble(uxNumericUpDownMinimumStars.Value),Convert.ToDouble(uxNumericUpDownMaximumStars.Value),
                uxTextBoxIngredient.Text, Convert.ToInt32(uxNumericUpDownPrepTime.Value), Convert.ToInt32(uxNumericUpDownCookTime.Value),
                uxDateTimePickerRecentDate.Value.Date, uxDateTimePickerLatestDate.Value.Date,
                uxCheckBoxHaveItem.Checked);
        }

        public DataTable GetRecipesXIngredientsAway()
        {
            return recipeRepository.GetRecipesXIngredientsAway(Convert.ToInt32(uxNumericUpDownMissing.Value));
        }


    }
}
