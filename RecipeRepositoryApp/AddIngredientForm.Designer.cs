namespace RecipeRepositoryApp
{
    partial class AddIngredientForm
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
            this.uxButtonAddIngredient = new System.Windows.Forms.Button();
            this.uxButtonCancel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.uxTextBoxName = new System.Windows.Forms.TextBox();
            this.uxNumericUpDownQuantity = new System.Windows.Forms.NumericUpDown();
            this.uxComboBoxMeasurement = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.uxNumericUpDownQuantity)).BeginInit();
            this.SuspendLayout();
            // 
            // uxButtonAddIngredient
            // 
            this.uxButtonAddIngredient.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.uxButtonAddIngredient.Location = new System.Drawing.Point(30, 183);
            this.uxButtonAddIngredient.Name = "uxButtonAddIngredient";
            this.uxButtonAddIngredient.Size = new System.Drawing.Size(172, 83);
            this.uxButtonAddIngredient.TabIndex = 0;
            this.uxButtonAddIngredient.Text = "Add Ingredient";
            this.uxButtonAddIngredient.UseVisualStyleBackColor = true;
            // 
            // uxButtonCancel
            // 
            this.uxButtonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.uxButtonCancel.Location = new System.Drawing.Point(236, 183);
            this.uxButtonCancel.Name = "uxButtonCancel";
            this.uxButtonCancel.Size = new System.Drawing.Size(172, 83);
            this.uxButtonCancel.TabIndex = 1;
            this.uxButtonCancel.Text = "Cancel";
            this.uxButtonCancel.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label1.Location = new System.Drawing.Point(25, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 29);
            this.label1.TabIndex = 2;
            this.label1.Text = "Name:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label2.Location = new System.Drawing.Point(25, 79);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(214, 29);
            this.label2.TabIndex = 3;
            this.label2.Text = "Measurement Unit:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label3.Location = new System.Drawing.Point(25, 132);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(184, 29);
            this.label3.TabIndex = 4;
            this.label3.Text = "Quantity of Item:";
            // 
            // uxTextBoxName
            // 
            this.uxTextBoxName.Location = new System.Drawing.Point(132, 28);
            this.uxTextBoxName.Name = "uxTextBoxName";
            this.uxTextBoxName.Size = new System.Drawing.Size(276, 26);
            this.uxTextBoxName.TabIndex = 6;
            // 
            // uxNumericUpDownQuantity
            // 
            this.uxNumericUpDownQuantity.Location = new System.Drawing.Point(245, 135);
            this.uxNumericUpDownQuantity.Name = "uxNumericUpDownQuantity";
            this.uxNumericUpDownQuantity.Size = new System.Drawing.Size(163, 26);
            this.uxNumericUpDownQuantity.TabIndex = 11;
            // 
            // uxComboBoxMeasurement
            // 
            this.uxComboBoxMeasurement.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.uxComboBoxMeasurement.FormattingEnabled = true;
            this.uxComboBoxMeasurement.Location = new System.Drawing.Point(245, 80);
            this.uxComboBoxMeasurement.Name = "uxComboBoxMeasurement";
            this.uxComboBoxMeasurement.Size = new System.Drawing.Size(163, 28);
            this.uxComboBoxMeasurement.TabIndex = 12;
            // 
            // AddIngredientForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(425, 289);
            this.Controls.Add(this.uxComboBoxMeasurement);
            this.Controls.Add(this.uxNumericUpDownQuantity);
            this.Controls.Add(this.uxTextBoxName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.uxButtonCancel);
            this.Controls.Add(this.uxButtonAddIngredient);
            this.Name = "AddIngredientForm";
            this.Text = "AddIngredientForm";
            ((System.ComponentModel.ISupportInitialize)(this.uxNumericUpDownQuantity)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button uxButtonAddIngredient;
        private System.Windows.Forms.Button uxButtonCancel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox uxTextBoxName;
        private System.Windows.Forms.NumericUpDown uxNumericUpDownQuantity;
        private System.Windows.Forms.ComboBox uxComboBoxMeasurement;
    }
}