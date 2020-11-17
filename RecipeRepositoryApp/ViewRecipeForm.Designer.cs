namespace RecipeRepositoryApp
{
    partial class ViewRecipeForm
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
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.uxButtonRateRecipe = new System.Windows.Forms.Button();
            this.uxTextBoxCourseType = new System.Windows.Forms.TextBox();
            this.uxTextBoxFoodType = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.uxListBoxSteps = new System.Windows.Forms.ListBox();
            this.label10 = new System.Windows.Forms.Label();
            this.uxListBoxIngredients = new System.Windows.Forms.ListBox();
            this.label7 = new System.Windows.Forms.Label();
            this.uxButtonCancelRecipe = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.uxTextBoxDescription = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.uxTextBoxName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.uxTextBoxServingSize = new System.Windows.Forms.TextBox();
            this.uxNumbericUpDownRate = new System.Windows.Forms.NumericUpDown();
            this.uxTextBoxPrepTime = new System.Windows.Forms.TextBox();
            this.uxTextBoxCookTime = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.uxNumbericUpDownRate)).BeginInit();
            this.SuspendLayout();
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label9.Location = new System.Drawing.Point(748, 59);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(64, 25);
            this.label9.TabIndex = 25;
            this.label9.Text = "Stars:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label8.Location = new System.Drawing.Point(743, 14);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(283, 25);
            this.label8.TabIndex = 23;
            this.label8.Text = "Currently Rated 0 out of 5 Stars";
            // 
            // uxButtonRateRecipe
            // 
            this.uxButtonRateRecipe.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.uxButtonRateRecipe.Location = new System.Drawing.Point(892, 53);
            this.uxButtonRateRecipe.Name = "uxButtonRateRecipe";
            this.uxButtonRateRecipe.Size = new System.Drawing.Size(134, 37);
            this.uxButtonRateRecipe.TabIndex = 22;
            this.uxButtonRateRecipe.Text = "Rate Recipe";
            this.uxButtonRateRecipe.UseVisualStyleBackColor = true;
            this.uxButtonRateRecipe.Click += new System.EventHandler(this.uxButtonRateRecipe_Click);
            // 
            // uxTextBoxCourseType
            // 
            this.uxTextBoxCourseType.Location = new System.Drawing.Point(478, 327);
            this.uxTextBoxCourseType.Name = "uxTextBoxCourseType";
            this.uxTextBoxCourseType.ReadOnly = true;
            this.uxTextBoxCourseType.Size = new System.Drawing.Size(153, 26);
            this.uxTextBoxCourseType.TabIndex = 54;
            // 
            // uxTextBoxFoodType
            // 
            this.uxTextBoxFoodType.Location = new System.Drawing.Point(478, 288);
            this.uxTextBoxFoodType.Name = "uxTextBoxFoodType";
            this.uxTextBoxFoodType.ReadOnly = true;
            this.uxTextBoxFoodType.Size = new System.Drawing.Size(153, 26);
            this.uxTextBoxFoodType.TabIndex = 53;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label12.Location = new System.Drawing.Point(335, 329);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(132, 25);
            this.label12.TabIndex = 52;
            this.label12.Text = "Course Type:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label11.Location = new System.Drawing.Point(335, 285);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(113, 25);
            this.label11.TabIndex = 51;
            this.label11.Text = "Food Type:";
            // 
            // uxListBoxSteps
            // 
            this.uxListBoxSteps.FormattingEnabled = true;
            this.uxListBoxSteps.ItemHeight = 20;
            this.uxListBoxSteps.Location = new System.Drawing.Point(651, 127);
            this.uxListBoxSteps.Name = "uxListBoxSteps";
            this.uxListBoxSteps.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.uxListBoxSteps.Size = new System.Drawing.Size(375, 404);
            this.uxListBoxSteps.TabIndex = 48;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label10.Location = new System.Drawing.Point(646, 89);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(69, 25);
            this.label10.TabIndex = 47;
            this.label10.Text = "Steps:";
            // 
            // uxListBoxIngredients
            // 
            this.uxListBoxIngredients.FormattingEnabled = true;
            this.uxListBoxIngredients.ItemHeight = 20;
            this.uxListBoxIngredients.Location = new System.Drawing.Point(18, 265);
            this.uxListBoxIngredients.Name = "uxListBoxIngredients";
            this.uxListBoxIngredients.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.uxListBoxIngredients.Size = new System.Drawing.Size(308, 264);
            this.uxListBoxIngredients.TabIndex = 44;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label7.Location = new System.Drawing.Point(13, 229);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(114, 25);
            this.label7.TabIndex = 43;
            this.label7.Text = "Ingredients:";
            // 
            // uxButtonCancelRecipe
            // 
            this.uxButtonCancelRecipe.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.uxButtonCancelRecipe.Location = new System.Drawing.Point(340, 479);
            this.uxButtonCancelRecipe.Name = "uxButtonCancelRecipe";
            this.uxButtonCancelRecipe.Size = new System.Drawing.Size(291, 50);
            this.uxButtonCancelRecipe.TabIndex = 42;
            this.uxButtonCancelRecipe.Text = "Return To Main";
            this.uxButtonCancelRecipe.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label6.Location = new System.Drawing.Point(335, 441);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(114, 25);
            this.label6.TabIndex = 37;
            this.label6.Text = "Cook Time:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label5.Location = new System.Drawing.Point(335, 407);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(167, 25);
            this.label5.TabIndex = 36;
            this.label5.Text = "Preparation Time:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label4.Location = new System.Drawing.Point(335, 370);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(129, 25);
            this.label4.TabIndex = 35;
            this.label4.Text = "Serving Size:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label3.Location = new System.Drawing.Point(8, 89);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(115, 25);
            this.label3.TabIndex = 34;
            this.label3.Text = "Description:";
            // 
            // uxTextBoxDescription
            // 
            this.uxTextBoxDescription.Location = new System.Drawing.Point(13, 127);
            this.uxTextBoxDescription.Multiline = true;
            this.uxTextBoxDescription.Name = "uxTextBoxDescription";
            this.uxTextBoxDescription.ReadOnly = true;
            this.uxTextBoxDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.uxTextBoxDescription.Size = new System.Drawing.Size(618, 86);
            this.uxTextBoxDescription.TabIndex = 33;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label2.Location = new System.Drawing.Point(8, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 25);
            this.label2.TabIndex = 32;
            this.label2.Text = "Name:";
            // 
            // uxTextBoxName
            // 
            this.uxTextBoxName.Location = new System.Drawing.Point(89, 54);
            this.uxTextBoxName.Name = "uxTextBoxName";
            this.uxTextBoxName.ReadOnly = true;
            this.uxTextBoxName.Size = new System.Drawing.Size(542, 26);
            this.uxTextBoxName.TabIndex = 31;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.label1.Location = new System.Drawing.Point(7, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(263, 32);
            this.label1.TabIndex = 30;
            this.label1.Text = "Add or Edit a recipe";
            // 
            // uxTextBoxServingSize
            // 
            this.uxTextBoxServingSize.Location = new System.Drawing.Point(511, 369);
            this.uxTextBoxServingSize.Name = "uxTextBoxServingSize";
            this.uxTextBoxServingSize.ReadOnly = true;
            this.uxTextBoxServingSize.Size = new System.Drawing.Size(120, 26);
            this.uxTextBoxServingSize.TabIndex = 55;
            // 
            // uxNumbericUpDownRate
            // 
            this.uxNumbericUpDownRate.Increment = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.uxNumbericUpDownRate.Location = new System.Drawing.Point(818, 59);
            this.uxNumbericUpDownRate.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.uxNumbericUpDownRate.Name = "uxNumbericUpDownRate";
            this.uxNumbericUpDownRate.Size = new System.Drawing.Size(68, 26);
            this.uxNumbericUpDownRate.TabIndex = 24;
            this.uxNumbericUpDownRate.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // uxTextBoxPrepTime
            // 
            this.uxTextBoxPrepTime.Location = new System.Drawing.Point(511, 407);
            this.uxTextBoxPrepTime.Name = "uxTextBoxPrepTime";
            this.uxTextBoxPrepTime.ReadOnly = true;
            this.uxTextBoxPrepTime.Size = new System.Drawing.Size(120, 26);
            this.uxTextBoxPrepTime.TabIndex = 56;
            // 
            // uxTextBoxCookTime
            // 
            this.uxTextBoxCookTime.Location = new System.Drawing.Point(511, 442);
            this.uxTextBoxCookTime.Name = "uxTextBoxCookTime";
            this.uxTextBoxCookTime.ReadOnly = true;
            this.uxTextBoxCookTime.Size = new System.Drawing.Size(120, 26);
            this.uxTextBoxCookTime.TabIndex = 57;
            // 
            // ViewRecipeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1056, 551);
            this.Controls.Add(this.uxTextBoxCookTime);
            this.Controls.Add(this.uxTextBoxPrepTime);
            this.Controls.Add(this.uxTextBoxServingSize);
            this.Controls.Add(this.uxTextBoxCourseType);
            this.Controls.Add(this.uxTextBoxFoodType);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.uxListBoxSteps);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.uxListBoxIngredients);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.uxButtonCancelRecipe);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.uxTextBoxDescription);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.uxTextBoxName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.uxNumbericUpDownRate);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.uxButtonRateRecipe);
            this.Name = "ViewRecipeForm";
            this.Text = "ViewRecipeForm";
            ((System.ComponentModel.ISupportInitialize)(this.uxNumbericUpDownRate)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button uxButtonRateRecipe;
        private System.Windows.Forms.TextBox uxTextBoxCourseType;
        private System.Windows.Forms.TextBox uxTextBoxFoodType;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ListBox uxListBoxSteps;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ListBox uxListBoxIngredients;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button uxButtonCancelRecipe;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox uxTextBoxDescription;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox uxTextBoxName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox uxTextBoxServingSize;
        private System.Windows.Forms.NumericUpDown uxNumbericUpDownRate;
        private System.Windows.Forms.TextBox uxTextBoxPrepTime;
        private System.Windows.Forms.TextBox uxTextBoxCookTime;
    }
}