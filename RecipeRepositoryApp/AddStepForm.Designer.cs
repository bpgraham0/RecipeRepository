namespace RecipeRepositoryApp
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
            this.uxTextBoxName = new System.Windows.Forms.TextBox();
            this.uxButtonRemoveStep = new System.Windows.Forms.Button();
            this.uxButtonSaveStep = new System.Windows.Forms.Button();
            this.uxButtonCancelEdit = new System.Windows.Forms.Button();
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
            // uxTextBoxName
            // 
            this.uxTextBoxName.Location = new System.Drawing.Point(161, 17);
            this.uxTextBoxName.Name = "uxTextBoxName";
            this.uxTextBoxName.Size = new System.Drawing.Size(292, 26);
            this.uxTextBoxName.TabIndex = 5;
            // 
            // uxButtonRemoveStep
            // 
            this.uxButtonRemoveStep.DialogResult = System.Windows.Forms.DialogResult.Abort;
            this.uxButtonRemoveStep.Location = new System.Drawing.Point(318, 192);
            this.uxButtonRemoveStep.Name = "uxButtonRemoveStep";
            this.uxButtonRemoveStep.Size = new System.Drawing.Size(135, 40);
            this.uxButtonRemoveStep.TabIndex = 26;
            this.uxButtonRemoveStep.Text = "Remove Step";
            this.uxButtonRemoveStep.UseVisualStyleBackColor = true;
            // 
            // uxButtonSaveStep
            // 
            this.uxButtonSaveStep.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.uxButtonSaveStep.Location = new System.Drawing.Point(12, 192);
            this.uxButtonSaveStep.Name = "uxButtonSaveStep";
            this.uxButtonSaveStep.Size = new System.Drawing.Size(135, 40);
            this.uxButtonSaveStep.TabIndex = 27;
            this.uxButtonSaveStep.Text = "Save Step";
            this.uxButtonSaveStep.UseVisualStyleBackColor = true;
            // 
            // uxButtonCancelEdit
            // 
            this.uxButtonCancelEdit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.uxButtonCancelEdit.Location = new System.Drawing.Point(168, 192);
            this.uxButtonCancelEdit.Name = "uxButtonCancelEdit";
            this.uxButtonCancelEdit.Size = new System.Drawing.Size(135, 40);
            this.uxButtonCancelEdit.TabIndex = 28;
            this.uxButtonCancelEdit.Text = "Cancel Edit";
            this.uxButtonCancelEdit.UseVisualStyleBackColor = true;
            // 
            // AddStepForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(465, 265);
            this.Controls.Add(this.uxButtonCancelEdit);
            this.Controls.Add(this.uxButtonSaveStep);
            this.Controls.Add(this.uxButtonRemoveStep);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.uxTextBoxDescription);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.uxTextBoxName);
            this.Name = "AddStepForm";
            this.Text = "AddStepForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox uxTextBoxDescription;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox uxTextBoxName;
        private System.Windows.Forms.Button uxButtonRemoveStep;
        private System.Windows.Forms.Button uxButtonSaveStep;
        private System.Windows.Forms.Button uxButtonCancelEdit;
    }
}