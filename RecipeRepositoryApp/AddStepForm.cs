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
    public partial class AddStepForm : Form
    {
        public AddStepForm(SqlRecipeRepository recipeRepository, Recipe recipe)
        {
            InitializeComponent();
            //initalize values
            this.recipeRepository = recipeRepository;
            DataTable dt = recipeRepository.GetStepList(recipe.RecipeId);
            if (dt.Rows.Count > 0)
            {
                DataRow dr = dt.Rows[dt.Rows.Count-1];
                uxNumericUpDownStepNumber.Value = (int)dr["Step Number"]+1;
            }
        }
        SqlRecipeRepository recipeRepository;
        /// <summary>
        /// creates step from info
        /// </summary>
        /// <param name="recipe"></param>
        public void AddUpdateStepInfo(Recipe recipe)
        {
            
            recipeRepository.CreateGetStep(recipe.RecipeId,(int)uxNumericUpDownStepNumber.Value, uxTextBoxDescription.Text); 

        }
    }
}

