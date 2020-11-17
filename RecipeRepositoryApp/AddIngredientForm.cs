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
        public AddIngredientForm()
        {
            InitializeComponent();
            
        }

       public Ingredient GetIngredientInfo(Recipe recipe)
        {
            IIngredientRepository ingredientRepository = new IIngredientRepository();
            IIngredientListRepository ingredientListRepository = new IIngredientListRepository();
            Ingredient ingredient = ingredientRepository.CreateGetIngredient(uxTextBoxName.Text,false); //for now, have item is default to false
            ingredientListRepository.AddItemToIngredientList(recipe.RecipeId,ingredient.IngredientId,uxComboBoxMeasurement.SelectedItem.ToString(), Convert.ToInt32(uxNumericUpDownQuantity.Value));
            return ingredient;
        } 
    }
}
