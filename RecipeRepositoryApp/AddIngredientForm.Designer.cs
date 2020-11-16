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
            this.label4 = new System.Windows.Forms.Label();
            this.uxTextBoxName = new System.Windows.Forms.TextBox();
            this.uxTextBoxMeasurement = new System.Windows.Forms.TextBox();
            this.uxGroupBox = new System.Windows.Forms.GroupBox();
            this.uxRadioButtonYes = new System.Windows.Forms.RadioButton();
            this.RadioButtonNo = new System.Windows.Forms.RadioButton();
            this.uxNumericUpDownQuantity = new System.Windows.Forms.NumericUpDown();
            this.uxGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uxNumericUpDownQuantity)).BeginInit();
            this.SuspendLayout();
            // 
            // uxButtonAddIngredient
            // 
            this.uxButtonAddIngredient.Location = new System.Drawing.Point(30, 235);
            this.uxButtonAddIngredient.Name = "uxButtonAddIngredient";
            this.uxButtonAddIngredient.Size = new System.Drawing.Size(172, 83);
            this.uxButtonAddIngredient.TabIndex = 0;
            this.uxButtonAddIngredient.Text = "Add Ingredient";
            this.uxButtonAddIngredient.UseVisualStyleBackColor = true;
            // 
            // uxButtonCancel
            // 
            this.uxButtonCancel.Location = new System.Drawing.Point(236, 235);
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
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label4.Location = new System.Drawing.Point(25, 189);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(230, 29);
            this.label4.TabIndex = 5;
            this.label4.Text = "Currently have item?";
            // 
            // uxTextBoxName
            // 
            this.uxTextBoxName.Location = new System.Drawing.Point(132, 28);
            this.uxTextBoxName.Name = "uxTextBoxName";
            this.uxTextBoxName.Size = new System.Drawing.Size(276, 26);
            this.uxTextBoxName.TabIndex = 6;
            // 
            // uxTextBoxMeasurement
            // 
            this.uxTextBoxMeasurement.Location = new System.Drawing.Point(245, 83);
            this.uxTextBoxMeasurement.Name = "uxTextBoxMeasurement";
            this.uxTextBoxMeasurement.Size = new System.Drawing.Size(163, 26);
            this.uxTextBoxMeasurement.TabIndex = 7;
            // 
            // uxGroupBox
            // 
            this.uxGroupBox.Controls.Add(this.RadioButtonNo);
            this.uxGroupBox.Controls.Add(this.uxRadioButtonYes);
            this.uxGroupBox.Location = new System.Drawing.Point(261, 176);
            this.uxGroupBox.Name = "uxGroupBox";
            this.uxGroupBox.Size = new System.Drawing.Size(147, 42);
            this.uxGroupBox.TabIndex = 10;
            this.uxGroupBox.TabStop = false;
            // 
            // uxRadioButtonYes
            // 
            this.uxRadioButtonYes.AutoSize = true;
            this.uxRadioButtonYes.Location = new System.Drawing.Point(17, 14);
            this.uxRadioButtonYes.Name = "uxRadioButtonYes";
            this.uxRadioButtonYes.Size = new System.Drawing.Size(62, 24);
            this.uxRadioButtonYes.TabIndex = 0;
            this.uxRadioButtonYes.Text = "Yes";
            this.uxRadioButtonYes.UseVisualStyleBackColor = true;
            // 
            // RadioButtonNo
            // 
            this.RadioButtonNo.AutoSize = true;
            this.RadioButtonNo.Checked = true;
            this.RadioButtonNo.Location = new System.Drawing.Point(85, 14);
            this.RadioButtonNo.Name = "RadioButtonNo";
            this.RadioButtonNo.Size = new System.Drawing.Size(54, 24);
            this.RadioButtonNo.TabIndex = 1;
            this.RadioButtonNo.TabStop = true;
            this.RadioButtonNo.Text = "No";
            this.RadioButtonNo.UseVisualStyleBackColor = true;
            // 
            // uxNumericUpDownQuantity
            // 
            this.uxNumericUpDownQuantity.Location = new System.Drawing.Point(245, 135);
            this.uxNumericUpDownQuantity.Name = "uxNumericUpDownQuantity";
            this.uxNumericUpDownQuantity.Size = new System.Drawing.Size(163, 26);
            this.uxNumericUpDownQuantity.TabIndex = 11;
            // 
            // AddIngredientForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(425, 342);
            this.Controls.Add(this.uxNumericUpDownQuantity);
            this.Controls.Add(this.uxGroupBox);
            this.Controls.Add(this.uxTextBoxMeasurement);
            this.Controls.Add(this.uxTextBoxName);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.uxButtonCancel);
            this.Controls.Add(this.uxButtonAddIngredient);
            this.Name = "AddIngredientForm";
            this.Text = "AddIngredientForm";
            this.uxGroupBox.ResumeLayout(false);
            this.uxGroupBox.PerformLayout();
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
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox uxTextBoxName;
        private System.Windows.Forms.TextBox uxTextBoxMeasurement;
        private System.Windows.Forms.GroupBox uxGroupBox;
        private System.Windows.Forms.RadioButton RadioButtonNo;
        private System.Windows.Forms.RadioButton uxRadioButtonYes;
        private System.Windows.Forms.NumericUpDown uxNumericUpDownQuantity;
    }
}