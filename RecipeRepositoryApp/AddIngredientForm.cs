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
            this.ingredientListRepository = ingredientListRepository;
            uxComboBoxMeasurement.DataSource = ingredientListRepository.FetchMeasurementList().Columns[1].DefaultValue;
            if(uxComboBoxMeasurement.Items.Count >0)
                uxComboBoxMeasurement.SelectedItem = 1;

        }
        SqlIngredientListRepository ingredientListRepository;


        public void AddUpdateIngredientInfo(Recipe recipe)
        {
            ingredientListRepository.CreateIngredient(uxTextBoxName.Text,0); //for now, have item is default to false
            ingredientListRepository.AddToIngredientList(recipe.RecipeId,ingredientListRepository.FetchMeasurementId(uxComboBoxMeasurement.Text),ingredientListRepository.GetMeasurementIdFromName(uxComboBoxMeasurement.SelectedItem.ToString()), Convert.ToDouble(uxNumericUpDownQuantity.Value));
            return ;
        } 
    }
}
