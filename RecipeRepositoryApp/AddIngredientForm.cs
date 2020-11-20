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
    public partial class AddIngredientForm : Form
    {
        public AddIngredientForm(SqlIngredientListRepository ingredientListRepository)
        {
            InitializeComponent();
            //initalize repos
            this.ingredientListRepository = ingredientListRepository;
            uxComboBoxMeasurement.DataSource = ingredientListRepository.FetchMeasurementList().ToList();
            if(uxComboBoxMeasurement.Items.Count >0)
                uxComboBoxMeasurement.SelectedItem = 1;

        }
        SqlIngredientListRepository ingredientListRepository;

        /// <summary>
        /// creates ingredient from form info and adds it to recipe's list
        /// </summary>
        /// <param name="recipe"></param>
        public void AddUpdateIngredientInfo(Recipe recipe)
        {
            int ingredientId = ingredientListRepository.CreateIngredient(uxTextBoxName.Text,0); //for now, have item is default to false
            ingredientListRepository.AddToIngredientList(recipe.RecipeId,ingredientId,ingredientListRepository.FetchMeasurementId(uxComboBoxMeasurement.Text.ToString()), Convert.ToDouble(uxNumericUpDownQuantity.Value));
            
        } 
    }
}
