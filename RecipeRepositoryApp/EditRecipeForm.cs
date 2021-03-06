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
    public partial class EditRecipeForm : Form
    {
       
        public EditRecipeForm(SqlRecipeRepository recipeRepository, SqlIngredientListRepository ingredientListRepository, SqlFoodTypeRepository foodTypeRepository, SqlCourseTypeRepository courseTypeRepository, Recipe recipe)
        {
            InitializeComponent();
            //initalize values
            uxTextBoxName.Text = recipe.Name;
            this.recipeRepository = recipeRepository;
            this.ingredientListRepository = ingredientListRepository;
            this.foodTypeRepository = foodTypeRepository;
            this.courseTypeRepository = courseTypeRepository;

            uxTextBoxDescription.Text = recipe.Description;
            uxTextBoxCourseType.Text = courseTypeRepository.FetchCourseType(recipe.RecipeId); //use repository to get course type
            uxTextBoxFoodType.Text = foodTypeRepository.FetchFoodType(recipe.RecipeId); //use repository to get course type
            uxNumericUpDownServingSize.Value = Convert.ToDecimal(recipe.ServingSize);
            uxNumericUpDownPrepTime.Value = Convert.ToDecimal(recipe.PrepTime.ToString());
            uxNumericUpDownCookTime.Value = Convert.ToDecimal(recipe.CookTime.ToString());
            uxDataGridViewIngredients.DataSource = ingredientListRepository.FetchIngredientList(recipe.RecipeId);
            if (uxDataGridViewIngredients.Columns.Count > 0)
            {
                uxDataGridViewIngredients.Columns[0].Visible = false;
                uxDataGridViewIngredients.RowHeadersVisible = false;
            }
            uxDataGridViewSteps.DataSource = recipeRepository.GetStepList(recipe.RecipeId);
            if (uxDataGridViewSteps.Columns.Count > 0)
            {
                uxDataGridViewSteps.RowHeadersVisible = false;
            }
            this.recipe = recipe;
        }
        Recipe recipe;
        SqlRecipeRepository recipeRepository;
        SqlIngredientListRepository ingredientListRepository;
        SqlFoodTypeRepository foodTypeRepository;
        SqlCourseTypeRepository courseTypeRepository;


        /// <summary>
        /// creates/updates recipe from info on form
        /// </summary>
        public void CreateUpdateRecipeInfo()
        {
            

            //recplace with REpository for creating recipe
            int foodTypeId = foodTypeRepository.CreateUpdateFoodType(uxTextBoxFoodType.Text); 
            int courseTypeId = courseTypeRepository.CreateUpdateCourseType(uxTextBoxCourseType.Text); 

            recipeRepository.CreateUpdateRecipe(foodTypeId, courseTypeId, uxTextBoxName.Text, uxTextBoxDescription.Text,
                Convert.ToDouble(uxNumericUpDownServingSize.Value), Convert.ToInt32(uxNumericUpDownPrepTime.Value),
                Convert.ToInt32(uxNumericUpDownCookTime.Value));
        }

        
        /// <summary>
        /// removes ingredient from list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxButtonRemoveIngredient_Click(object sender, EventArgs e)
        {
            var selectedRows = uxDataGridViewIngredients.SelectedRows;
            
            foreach(DataGridViewRow Row in selectedRows)
            {
                ingredientListRepository.DeleteFromIngredientList(recipe.RecipeId, (int)Row.Cells[0].Value);

            }
            uxDataGridViewIngredients.DataSource = ingredientListRepository.FetchIngredientList(recipe.RecipeId);//Returns reader
            if (uxDataGridViewIngredients.Columns.Count > 0)
            {
                uxDataGridViewIngredients.Columns[0].Visible = false;
                uxDataGridViewIngredients.RowHeadersVisible = false;
            }


        }

        /// <summary>
        /// adds ingredient to list and creates it if new ingredinet
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxButtonAddIngredient_Click(object sender, EventArgs e)
        {
            AddIngredientForm addIngredient = new AddIngredientForm(ingredientListRepository);
            DialogResult dl = addIngredient.ShowDialog();
            if (dl == DialogResult.OK)
            {
                addIngredient.AddUpdateIngredientInfo(recipe);
                uxDataGridViewIngredients.DataSource = ingredientListRepository.FetchIngredientList(recipe.RecipeId);//Returns reader
                if (uxDataGridViewIngredients.Columns.Count > 0)
                {
                    uxDataGridViewIngredients.Columns[0].Visible = false;
                    uxDataGridViewIngredients.RowHeadersVisible = false;
                }
                //Add recipe to 
            }
        }

        /// <summary>
        /// adds step to list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxButtonAddStep_Click(object sender, EventArgs e)
        {
            AddStepForm addStep = new AddStepForm(recipeRepository, recipe);
            DialogResult dl = addStep.ShowDialog();
            if (dl == DialogResult.OK)
            {
                addStep.AddUpdateStepInfo(recipe);
                uxDataGridViewSteps.DataSource = recipeRepository.GetStepList(recipe.RecipeId);//Returns reader
                if (uxDataGridViewSteps.Columns.Count > 0)
                {
                    uxDataGridViewSteps.RowHeadersVisible = false;
                }
                //Add recipe to 
            }
        }

        /// <summary>
        /// deletes step from list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxButtonDeleteStep_Click(object sender, EventArgs e)
        {
            var selectedRows = uxDataGridViewSteps.SelectedRows;
            foreach (DataGridViewRow Row in selectedRows)
            {
                recipeRepository.DeleteStep(recipe.RecipeId, (int)Row.Cells[0].Value); //StepNumber

            }
            uxDataGridViewSteps.DataSource = recipeRepository.GetStepList(recipe.RecipeId);//Returns reader
            if (uxDataGridViewSteps.Columns.Count > 0)
            {
                uxDataGridViewSteps.RowHeadersVisible = false;
            }
        }

        /// <summary>
        /// hard deletes recipe from database
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxButtonDeleteRecipe_Click(object sender, EventArgs e)
        {
            recipeRepository.DeleteRecipe(recipe.RecipeId);
        }
    }
}
