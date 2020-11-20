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
            uxDateTimePickerLatestDate.Value = DateTime.Today;
            uxDateTimePickerRecentDate.Value = DateTime.Today;
            uxDateTimePickerLatestDate.Format = DateTimePickerFormat.Custom;
            uxDateTimePickerRecentDate.Format = DateTimePickerFormat.Custom;
            uxDateTimePickerLatestDate.CustomFormat = "MMM dd, yyyy";
            uxDateTimePickerRecentDate.CustomFormat = "MMM dd, yyyy";
            dateChanged = false;


        }
        SqlRecipeRepository recipeRepository;
        bool dateChanged = false;
        public DataTable GetStandardSearchQuery()
        {
            return recipeRepository.SearchAllRecipes(uxTextBoxName.Text, uxTextBoxDescription.Text, uxTextBoxCourseType.Text,
                uxTextBoxFoodType.Text, Convert.ToDouble(uxNumericUpDownMinimumStars.Value),Convert.ToDouble(uxNumericUpDownMaximumStars.Value),
                uxTextBoxIngredient.Text, Convert.ToInt32(uxNumericUpDownPrepTime.Value), Convert.ToInt32(uxNumericUpDownCookTime.Value),
                uxDateTimePickerRecentDate.Value.Date, uxDateTimePickerLatestDate.Value.Date,
                uxCheckBoxHaveItem.Checked,dateChanged);
        }

        public DataTable GetRecipesXIngredientsAway()
        {
            return recipeRepository.GetRecipesXIngredientsAway(Convert.ToInt32(uxNumericUpDownMissing.Value));
        }

        private void uxDateTimePickerLatestDate_ValueChanged(object sender, EventArgs e)
        {
            dateChanged = true;
        }

        private void uxDateTimePickerRecentDate_ValueChanged(object sender, EventArgs e)
        {
            dateChanged = true;
        }
    }
}
