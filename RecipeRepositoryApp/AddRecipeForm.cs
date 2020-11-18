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
    public partial class AddRecipeForm : Form
    {
        public AddRecipeForm()
        {
            InitializeComponent();
        }
        

        public void CreateUpdateRecipeInfo()
        {
            SqlRecipeRepository recipeRepository = new SqlRecipeRepository();

            //recplace with REpository for creating recipe
            int foodTypeId = recipeRepository.GetOrAddFoodTypeId(uxTextBoxCourseType.Text); 
            int courseTypeId = recipeRepository.GetOrAddCourseTypeId(uxTextBoxCourseType.Text); 

            recipeRepository.CreateUpdateRecipe(fooodTypeId, courseTypeId, uxTextBoxName.Text, uxTextBoxDescription.Text,
                Convert.ToDouble(uxNumericUpDownServingSize.Value), Convert.ToInt32(uxNumericUpDownPrepTime.Value),
                Convert.ToInt32(uxNumericUpDownCookTime.Value));
        }

        
        private void uxButtonRemoveIngredient_Click(object sender, EventArgs e)
        {
            IIngredientListRepository ingredientListRepository = new IIngredientListRepository();
            var selectedRows = uxDataGridViewIngredients.SelectedRows;
            foreach(DataGridViewSelectedRowCollection Row in selectedRows)
            {
                ingredientListRepository.DeleteIngredient(recipe.RecipeId, Row[0].Cells[0].Value);

            }


        }

        private void uxButtonAddIngredient_Click(object sender, EventArgs e)
        {
            AddIngredientForm addIngredient = new AddIngredientForm();
            DialogResult dl = addIngredient.ShowDialog();
            if (dl == DialogResult.OK)
            {
                addIngredient.AddUpdateIngredientInfo(recipe);
                uxDataGridViewRecipes.DataSource = recipeRepository.GetRecipeIngredientList(recipe);//Returns reader
                //Add recipe to 
            }
        }

        private void uxButtonAddStep_Click(object sender, EventArgs e)
        {
            AddStepForm addStep = new AddStepForm();
            DialogResult dl = addStep.ShowDialog();
            if (dl == DialogResult.OK)
            {
                addStep.AddUpdateStepInfo(recipe);
                uxDataGridViewSteps.DataSource = recipeRepository.GetRecipeStepList(recipe);//Returns reader
                //Add recipe to 
            }
        }


        private void uxButtonDeleteStep_Click(object sender, EventArgs e)
        {
            IStepRepository stepRepository = new IStepRepository();
            var selectedRows = uxDataGridViewIngredients.SelectedRows;
            foreach (DataGridViewSelectedRowCollection Row in selectedRows)
            {
                stepRepository.DeleteStep(recipe.RecipeId, Row[0].Cells[0].Value);

            }
        }
    }
}
