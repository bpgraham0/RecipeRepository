﻿using System;
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
        public PantryForm(SqlIngredientListRepository ingredientRepository)
        {
            InitializeComponent();
            //initalize repo
            this.ingredientRepository = ingredientRepository;
        }
        SqlIngredientListRepository ingredientRepository;

        /// <summary>
        /// on load, gets all items from item table
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PantryForm_Load(object sender, EventArgs e)
        {
            uxDataGridViewPantry.DataSource = ingredientRepository.FetchAllIngredient();
            if (uxDataGridViewPantry.Columns.Count > 0)
            {
                uxDataGridViewPantry.RowHeadersVisible = false;
            }
        }

        /// <summary>
        /// allows user to change whether they have a specific item or not
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxDataGridViewPantry_Click(object sender, EventArgs e)
        {
            
            var dataSource = uxDataGridViewPantry.SelectedRows[0];
            string ingredientName = dataSource.Cells[0].Value.ToString();
            bool hasItem = (bool)dataSource.Cells[1].Value;
            ingredientRepository.UpdateHaveItem(ingredientName, hasItem);

            uxDataGridViewPantry.DataSource = ingredientRepository.FetchAllIngredient();
            if (uxDataGridViewPantry.Columns.Count > 0)
            {
                uxDataGridViewPantry.RowHeadersVisible = false;
            }

        }
    }
}
