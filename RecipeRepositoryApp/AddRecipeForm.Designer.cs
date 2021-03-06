﻿namespace RecipeRepositoryApp
{
    partial class AddRecipeForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.uxTextBoxName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.uxTextBoxDescription = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.uxNumericUpDownServingSize = new System.Windows.Forms.NumericUpDown();
            this.uxNumericUpDownPrepTime = new System.Windows.Forms.NumericUpDown();
            this.uxNumericUpDownCookTime = new System.Windows.Forms.NumericUpDown();
            this.uxButtonAddRecipe = new System.Windows.Forms.Button();
            this.uxButtonCancelRecipe = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.uxTextBoxFoodType = new System.Windows.Forms.TextBox();
            this.uxTextBoxCourseType = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.uxNumericUpDownServingSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uxNumericUpDownPrepTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uxNumericUpDownCookTime)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.label1.Location = new System.Drawing.Point(11, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(174, 32);
            this.label1.TabIndex = 0;
            this.label1.Text = "Add a recipe";
            // 
            // uxTextBoxName
            // 
            this.uxTextBoxName.Location = new System.Drawing.Point(93, 63);
            this.uxTextBoxName.Name = "uxTextBoxName";
            this.uxTextBoxName.Size = new System.Drawing.Size(333, 26);
            this.uxTextBoxName.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label2.Location = new System.Drawing.Point(12, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 25);
            this.label2.TabIndex = 2;
            this.label2.Text = "Name:";
            // 
            // uxTextBoxDescription
            // 
            this.uxTextBoxDescription.Location = new System.Drawing.Point(17, 136);
            this.uxTextBoxDescription.Multiline = true;
            this.uxTextBoxDescription.Name = "uxTextBoxDescription";
            this.uxTextBoxDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.uxTextBoxDescription.Size = new System.Drawing.Size(409, 86);
            this.uxTextBoxDescription.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label3.Location = new System.Drawing.Point(12, 98);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(115, 25);
            this.label3.TabIndex = 4;
            this.label3.Text = "Description:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label4.Location = new System.Drawing.Point(12, 327);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(129, 25);
            this.label4.TabIndex = 5;
            this.label4.Text = "Serving Size:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label5.Location = new System.Drawing.Point(12, 364);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(167, 25);
            this.label5.TabIndex = 6;
            this.label5.Text = "Preparation Time:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label6.Location = new System.Drawing.Point(12, 398);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(114, 25);
            this.label6.TabIndex = 7;
            this.label6.Text = "Cook Time:";
            // 
            // uxNumericUpDownServingSize
            // 
            this.uxNumericUpDownServingSize.Location = new System.Drawing.Point(306, 309);
            this.uxNumericUpDownServingSize.Name = "uxNumericUpDownServingSize";
            this.uxNumericUpDownServingSize.Size = new System.Drawing.Size(120, 26);
            this.uxNumericUpDownServingSize.TabIndex = 8;
            // 
            // uxNumericUpDownPrepTime
            // 
            this.uxNumericUpDownPrepTime.Location = new System.Drawing.Point(306, 346);
            this.uxNumericUpDownPrepTime.Name = "uxNumericUpDownPrepTime";
            this.uxNumericUpDownPrepTime.Size = new System.Drawing.Size(120, 26);
            this.uxNumericUpDownPrepTime.TabIndex = 9;
            // 
            // uxNumericUpDownCookTime
            // 
            this.uxNumericUpDownCookTime.Location = new System.Drawing.Point(306, 383);
            this.uxNumericUpDownCookTime.Name = "uxNumericUpDownCookTime";
            this.uxNumericUpDownCookTime.Size = new System.Drawing.Size(120, 26);
            this.uxNumericUpDownCookTime.TabIndex = 10;
            // 
            // uxButtonAddRecipe
            // 
            this.uxButtonAddRecipe.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.uxButtonAddRecipe.Location = new System.Drawing.Point(17, 432);
            this.uxButtonAddRecipe.Name = "uxButtonAddRecipe";
            this.uxButtonAddRecipe.Size = new System.Drawing.Size(409, 50);
            this.uxButtonAddRecipe.TabIndex = 11;
            this.uxButtonAddRecipe.Text = "Add Recipe";
            this.uxButtonAddRecipe.UseVisualStyleBackColor = true;
            // 
            // uxButtonCancelRecipe
            // 
            this.uxButtonCancelRecipe.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.uxButtonCancelRecipe.Location = new System.Drawing.Point(17, 492);
            this.uxButtonCancelRecipe.Name = "uxButtonCancelRecipe";
            this.uxButtonCancelRecipe.Size = new System.Drawing.Size(409, 50);
            this.uxButtonCancelRecipe.TabIndex = 12;
            this.uxButtonCancelRecipe.Text = "Cancel";
            this.uxButtonCancelRecipe.UseVisualStyleBackColor = true;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label11.Location = new System.Drawing.Point(12, 242);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(113, 25);
            this.label11.TabIndex = 26;
            this.label11.Text = "Food Type:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label12.Location = new System.Drawing.Point(12, 286);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(132, 25);
            this.label12.TabIndex = 27;
            this.label12.Text = "Course Type:";
            // 
            // uxTextBoxFoodType
            // 
            this.uxTextBoxFoodType.Location = new System.Drawing.Point(273, 228);
            this.uxTextBoxFoodType.Name = "uxTextBoxFoodType";
            this.uxTextBoxFoodType.Size = new System.Drawing.Size(153, 26);
            this.uxTextBoxFoodType.TabIndex = 28;
            // 
            // uxTextBoxCourseType
            // 
            this.uxTextBoxCourseType.Location = new System.Drawing.Point(273, 267);
            this.uxTextBoxCourseType.Name = "uxTextBoxCourseType";
            this.uxTextBoxCourseType.Size = new System.Drawing.Size(153, 26);
            this.uxTextBoxCourseType.TabIndex = 29;
            // 
            // AddRecipeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(457, 558);
            this.Controls.Add(this.uxTextBoxCourseType);
            this.Controls.Add(this.uxTextBoxFoodType);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.uxButtonCancelRecipe);
            this.Controls.Add(this.uxButtonAddRecipe);
            this.Controls.Add(this.uxNumericUpDownCookTime);
            this.Controls.Add(this.uxNumericUpDownPrepTime);
            this.Controls.Add(this.uxNumericUpDownServingSize);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.uxTextBoxDescription);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.uxTextBoxName);
            this.Controls.Add(this.label1);
            this.Name = "AddRecipeForm";
            this.Text = "AddRecipeForm";
            ((System.ComponentModel.ISupportInitialize)(this.uxNumericUpDownServingSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uxNumericUpDownPrepTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uxNumericUpDownCookTime)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox uxTextBoxName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox uxTextBoxDescription;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown uxNumericUpDownServingSize;
        private System.Windows.Forms.NumericUpDown uxNumericUpDownPrepTime;
        private System.Windows.Forms.NumericUpDown uxNumericUpDownCookTime;
        private System.Windows.Forms.Button uxButtonAddRecipe;
        private System.Windows.Forms.Button uxButtonCancelRecipe;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox uxTextBoxFoodType;
        private System.Windows.Forms.TextBox uxTextBoxCourseType;
    }
}