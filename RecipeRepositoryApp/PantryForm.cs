using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RecipeData.Repositories;

namespace RecipeRepositoryApp
{
    public partial class PantryForm : Form
    {
        public PantryForm()
        {
            InitializeComponent();
        }

        private void PantryForm_Load(object sender, EventArgs e)
        {
            SqlIngredientListRepository ingredientRepository = new SqlIngredientListRepository();
            uxDataGridViewPantry.DataSource = ingredientRepository.FetchAllIngredient();

        }

        private void uxDataGridViewPantry_Click(object sender, EventArgs e)
        {
            SqlIngredientListRepository ingredientRepository = new SqlIngredientListRepository();
            var dataSource = uxDataGridViewPantry.SelectedRows[0];
            string ingredientName = dataSource.Cells[0].Value.ToString();
            bool hasItem = (bool)dataSource.Cells[1].Value;
            ingredientRepository.UpdateHaveItem(ingredientName, hasItem);

            uxDataGridViewPantry.DataSource = ingredientRepository.FetchAllIngredient();


        }
    }
}
