﻿namespace RecipeRepositoryApp
{
    partial class AddStepForm
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
            this.label3 = new System.Windows.Forms.Label();
            this.uxTextBoxDescription = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.uxButtonSaveStep = new System.Windows.Forms.Button();
            this.uxButtonCancelEdit = new System.Windows.Forms.Button();
            this.uxNumericUpDownStepNumber = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.uxNumericUpDownStepNumber)).BeginInit();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label3.Location = new System.Drawing.Point(7, 52);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(115, 25);
            this.label3.TabIndex = 8;
            this.label3.Text = "Description:";
            // 
            // uxTextBoxDescription
            // 
            this.uxTextBoxDescription.Location = new System.Drawing.Point(12, 90);
            this.uxTextBoxDescription.Multiline = true;
            this.uxTextBoxDescription.Name = "uxTextBoxDescription";
            this.uxTextBoxDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.uxTextBoxDescription.Size = new System.Drawing.Size(441, 86);
            this.uxTextBoxDescription.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label2.Location = new System.Drawing.Point(7, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(133, 25);
            this.label2.TabIndex = 6;
            this.label2.Text = "Step Number:";
            // 
            // uxButtonSaveStep
            // 
            this.uxButtonSaveStep.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.uxButtonSaveStep.Location = new System.Drawing.Point(12, 192);
            this.uxButtonSaveStep.Name = "uxButtonSaveStep";
            this.uxButtonSaveStep.Size = new System.Drawing.Size(202, 40);
            this.uxButtonSaveStep.TabIndex = 27;
            this.uxButtonSaveStep.Text = "Save Step";
            this.uxButtonSaveStep.UseVisualStyleBackColor = true;
            // 
            // uxButtonCancelEdit
            // 
            this.uxButtonCancelEdit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.uxButtonCancelEdit.Location = new System.Drawing.Point(251, 192);
            this.uxButtonCancelEdit.Name = "uxButtonCancelEdit";
            this.uxButtonCancelEdit.Size = new System.Drawing.Size(202, 40);
            this.uxButtonCancelEdit.TabIndex = 28;
            this.uxButtonCancelEdit.Text = "Cancel Edit";
            this.uxButtonCancelEdit.UseVisualStyleBackColor = true;
            // 
            // uxNumericUpDownStepNumber
            // 
            this.uxNumericUpDownStepNumber.Increment = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.uxNumericUpDownStepNumber.InterceptArrowKeys = false;
            this.uxNumericUpDownStepNumber.Location = new System.Drawing.Point(251, 20);
            this.uxNumericUpDownStepNumber.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.uxNumericUpDownStepNumber.Name = "uxNumericUpDownStepNumber";
            this.uxNumericUpDownStepNumber.ReadOnly = true;
            this.uxNumericUpDownStepNumber.Size = new System.Drawing.Size(202, 26);
            this.uxNumericUpDownStepNumber.TabIndex = 30;
            this.uxNumericUpDownStepNumber.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // AddStepForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(465, 265);
            this.Controls.Add(this.uxNumericUpDownStepNumber);
            this.Controls.Add(this.uxButtonCancelEdit);
            this.Controls.Add(this.uxButtonSaveStep);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.uxTextBoxDescription);
            this.Controls.Add(this.label2);
            this.Name = "AddStepForm";
            this.Text = "AddStepForm";
            ((System.ComponentModel.ISupportInitialize)(this.uxNumericUpDownStepNumber)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox uxTextBoxDescription;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button uxButtonSaveStep;
        private System.Windows.Forms.Button uxButtonCancelEdit;
        private System.Windows.Forms.NumericUpDown uxNumericUpDownStepNumber;
    }
}