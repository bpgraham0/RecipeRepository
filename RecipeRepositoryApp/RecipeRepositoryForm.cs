﻿using System;
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
    public partial class RecipeRepositoryForm : Form
    {
        public RecipeRepositoryForm(SqlRecipeRepository recipeRepository, SqlIngredientListRepository ingredientListRepository, SqlFoodTypeRepository foodTypeRepository, SqlCourseTypeRepository courseTypeRepository)
        {
            InitializeComponent();
            
            //initalize databases
            this.recipeRepository = recipeRepository;
            this.ingredientListRepository = ingredientListRepository;
            this.foodTypeRepository = foodTypeRepository;
            this.courseTypeRepository = courseTypeRepository;

            RefreshDataGridView();//Returns reader

        }
        SqlRecipeRepository recipeRepository;
        SqlFoodTypeRepository foodTypeRepository;
        SqlIngredientListRepository ingredientListRepository;
        SqlCourseTypeRepository courseTypeRepository;

        /// <summary>
        /// refreshes main data tables
        /// </summary>
        private void RefreshDataGridView()
        {
            uxDataGridViewRecipes.DataSource = recipeRepository.GetRecipeList();//Returns reader

            if (uxDataGridViewRecipes.Columns.Count > 0)
            {
                uxDataGridViewRecipes.RowHeadersVisible = false; //makes row header invisible as they had no relevant info
            }
        }


        /// <summary>
        /// opens filter screen and populates main table based on selection added
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxFilterRecipesButton_Click(object sender, EventArgs e)
        {
            FilterRecipeForm filterRecipe = new FilterRecipeForm(recipeRepository);
            DialogResult dl = filterRecipe.ShowDialog();
            if (dl == DialogResult.OK)
            {
                /// <summary>
                /// REPORT QUERY 1: Massive custom search from user
                /// </summary>
                /// <returns></returns>
                uxDataGridViewRecipes.DataSource = filterRecipe.GetStandardSearchQuery();//Returns reader
                if (uxDataGridViewRecipes.Columns.Count > 0)
                {
                    uxDataGridViewRecipes.RowHeadersVisible = false;
                }
            }

            
            if (dl == DialogResult.Ignore)
            {
                /// <summary>
                /// REPORT QUERY 2: Gets top ten recipes for this month and sorts by stars
                /// </summary>
                /// <returns></returns>
                uxDataGridViewRecipes.DataSource = recipeRepository.GetTopTenMonthly();//Returns reader
                if (uxDataGridViewRecipes.Columns.Count > 0)
                {
                    uxDataGridViewRecipes.RowHeadersVisible = false;
                }
            }
            
            if (dl == DialogResult.Yes)
            {
                /// <summary>
                /// REPORT QUERY 3: gets recipes where user is only X ingredients away from being able to make now
                /// </summary>
                /// <returns></returns>
                uxDataGridViewRecipes.DataSource = filterRecipe.GetRecipesXIngredientsAway();//Returns reader
                if (uxDataGridViewRecipes.Columns.Count > 0)
                {
                    uxDataGridViewRecipes.RowHeadersVisible = false;
                }
            }
            if (dl == DialogResult.No)
            {
                /// <summary>
                /// REPORT QUERY 4: Gets a new recipe that the user hasnt made in a month
                /// </summary>
                /// <returns></returns>
                uxDataGridViewRecipes.DataSource = recipeRepository.GetFreshRecipe();//Returns reader
                if (uxDataGridViewRecipes.Columns.Count > 0)
                {
                    uxDataGridViewRecipes.RowHeadersVisible = false;
                }
            }
            if (dl == DialogResult.Retry)
            {
                /// <summary>
                /// fetches history of made recipes
                /// </summary>
                /// <returns></returns>
                uxDataGridViewRecipes.DataSource = recipeRepository.GetRecipeHistory();//Returns reader
                if (uxDataGridViewRecipes.Columns.Count > 0)
                {
                    uxDataGridViewRecipes.RowHeadersVisible = false;
                    uxDataGridViewRecipes.AutoResizeColumns();

                }

            }
        }

        /// <summary>
        /// open add recipe screen
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxAddRecipeButton_Click(object sender, EventArgs e)
        {
            AddRecipeForm addRecipe = new AddRecipeForm(recipeRepository, foodTypeRepository, courseTypeRepository);
            DialogResult dl = addRecipe.ShowDialog();
            if (dl == DialogResult.OK)
            {
                addRecipe.CreateUpdateRecipeInfo();
                RefreshDataGridView();//Returns reader
                //Add recipe to 
            }
        }

        /// <summary>
        /// opens recipe view button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxButtonViewRecipe_Click(object sender, EventArgs e)
        {
            if (uxDataGridViewRecipes.SelectedRows.Count > 0)
            {
                ViewRecipeForm viewRecipe = new ViewRecipeForm(recipeRepository, ingredientListRepository, foodTypeRepository, courseTypeRepository, recipeRepository.GetRecipeFromName(uxDataGridViewRecipes.SelectedRows[0].Cells[0].Value.ToString()));
                DialogResult dl = viewRecipe.ShowDialog();
                if (dl == DialogResult.Cancel)
                {
                    //Add recipe to 
                }
            }
        }

        /// <summary>
        /// revers main view to show all recipes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxButtonClear_Click(object sender, EventArgs e)
        {
            RefreshDataGridView();//Returns reader
        }

        /// <summary>
        /// opens edit recipe view
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxEditRecipeButton_Click(object sender, EventArgs e)
        {
            if (uxDataGridViewRecipes.SelectedRows.Count > 0)
            {
                EditRecipeForm editRecipe = new EditRecipeForm(recipeRepository, ingredientListRepository, foodTypeRepository, courseTypeRepository, recipeRepository.GetRecipeFromName(uxDataGridViewRecipes.SelectedRows[0].Cells[0].Value.ToString()));
                DialogResult dl = editRecipe.ShowDialog();
                if (dl == DialogResult.OK)
                {
                    editRecipe.CreateUpdateRecipeInfo();
                    RefreshDataGridView();//Returns reader
                                          //Add recipe to 

                }
                if (dl == DialogResult.No)
                {
                    RefreshDataGridView();//Returns reader
                }
            }
        }

        /// <summary>
        /// opens pantry vew where people can changes whether they have an item or not
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxOpenPantry_Click(object sender, EventArgs e)
        {
            PantryForm pantryForm = new PantryForm(ingredientListRepository);
            DialogResult dl = pantryForm.ShowDialog();
            if (dl == DialogResult.OK)
            {
                RefreshDataGridView();//Returns reader
                //Add recipe to 
            }
        }
    } 
}
