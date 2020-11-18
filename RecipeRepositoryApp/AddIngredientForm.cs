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
            IList <Measurement> measurements = ingredientListRepository.FetchMeasurementList().ToList();
            foreach(Measurement item in measurements)
            {
                uxComboBoxMeasurement.Items.Add(item.Name);

            }
            if(uxComboBoxMeasurement.Items.Count >0)
                uxComboBoxMeasurement.SelectedItem = 1;

        }
        SqlIngredientListRepository ingredientListRepository;


        public void AddUpdateIngredientInfo(Recipe recipe)
        {
            Ingredient ingredient = ingredientListRepository.CreateGetIngredient(uxTextBoxName.Text,false); //for now, have item is default to false
            ingredientListRepository.AddItemToIngredientList(recipe.RecipeId,ingredient.IngredientId,ingredientListRepository.GetMeasurementIdFromName(uxComboBoxMeasurement.SelectedItem.ToString()), Convert.ToDouble(uxNumericUpDownQuantity.Value));
            return ;
        } 
    }
}
