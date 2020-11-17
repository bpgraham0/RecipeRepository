﻿namespace RecipeRepositoryApp
{
    partial class RecipeRepositoryForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.uxAddRecipeButton = new System.Windows.Forms.Button();
            this.uxFilterRecipesButton = new System.Windows.Forms.Button();
            this.uxButtonViewRecipe = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.uxDataGridViewRecipes = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.uxDataGridViewRecipes)).BeginInit();
            this.SuspendLayout();
            // 
            // uxAddRecipeButton
            // 
            this.uxAddRecipeButton.Location = new System.Drawing.Point(269, 419);
            this.uxAddRecipeButton.Name = "uxAddRecipeButton";
            this.uxAddRecipeButton.Size = new System.Drawing.Size(230, 65);
            this.uxAddRecipeButton.TabIndex = 1;
            this.uxAddRecipeButton.Text = "Add/Edit Recipe";
            this.uxAddRecipeButton.UseVisualStyleBackColor = true;
            this.uxAddRecipeButton.Click += new System.EventHandler(this.uxAddRecipeButton_Click);
            // 
            // uxFilterRecipesButton
            // 
            this.uxFilterRecipesButton.Location = new System.Drawing.Point(12, 12);
            this.uxFilterRecipesButton.Name = "uxFilterRecipesButton";
            this.uxFilterRecipesButton.Size = new System.Drawing.Size(230, 52);
            this.uxFilterRecipesButton.TabIndex = 3;
            this.uxFilterRecipesButton.Text = "Filter Recipes";
            this.uxFilterRecipesButton.UseVisualStyleBackColor = true;
            this.uxFilterRecipesButton.Click += new System.EventHandler(this.uxFilterRecipesButton_Click);
            // 
            // uxButtonViewRecipe
            // 
            this.uxButtonViewRecipe.Location = new System.Drawing.Point(12, 419);
            this.uxButtonViewRecipe.Name = "uxButtonViewRecipe";
            this.uxButtonViewRecipe.Size = new System.Drawing.Size(230, 65);
            this.uxButtonViewRecipe.TabIndex = 4;
            this.uxButtonViewRecipe.Text = "View Recipe";
            this.uxButtonViewRecipe.UseVisualStyleBackColor = true;
            this.uxButtonViewRecipe.Click += new System.EventHandler(this.uxButtonViewRecipe_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(269, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(230, 52);
            this.button1.TabIndex = 5;
            this.button1.Text = "Clear Filter";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // uxDataGridViewRecipes
            // 
            this.uxDataGridViewRecipes.AllowUserToAddRows = false;
            this.uxDataGridViewRecipes.AllowUserToDeleteRows = false;
            this.uxDataGridViewRecipes.AllowUserToOrderColumns = true;
            this.uxDataGridViewRecipes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.uxDataGridViewRecipes.Location = new System.Drawing.Point(13, 71);
            this.uxDataGridViewRecipes.MultiSelect = false;
            this.uxDataGridViewRecipes.Name = "uxDataGridViewRecipes";
            this.uxDataGridViewRecipes.ReadOnly = true;
            this.uxDataGridViewRecipes.RowHeadersWidth = 62;
            this.uxDataGridViewRecipes.RowTemplate.Height = 28;
            this.uxDataGridViewRecipes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.uxDataGridViewRecipes.Size = new System.Drawing.Size(486, 342);
            this.uxDataGridViewRecipes.TabIndex = 6;
            // 
            // RecipeRepositoryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(511, 496);
            this.Controls.Add(this.uxDataGridViewRecipes);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.uxButtonViewRecipe);
            this.Controls.Add(this.uxFilterRecipesButton);
            this.Controls.Add(this.uxAddRecipeButton);
            this.Name = "RecipeRepositoryForm";
            this.Text = "RecipeRepository";
            ((System.ComponentModel.ISupportInitialize)(this.uxDataGridViewRecipes)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button uxAddRecipeButton;
        private System.Windows.Forms.Button uxFilterRecipesButton;
        private System.Windows.Forms.Button uxButtonViewRecipe;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView uxDataGridViewRecipes;
    }
}

