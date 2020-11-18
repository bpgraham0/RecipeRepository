namespace RecipeRepositoryApp
{
    partial class PantryForm
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
            this.uxButtonSave = new System.Windows.Forms.Button();
            this.uxDataGridViewPantry = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.uxDataGridViewPantry)).BeginInit();
            this.SuspendLayout();
            // 
            // uxButtonSave
            // 
            this.uxButtonSave.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.uxButtonSave.Location = new System.Drawing.Point(12, 12);
            this.uxButtonSave.Name = "uxButtonSave";
            this.uxButtonSave.Size = new System.Drawing.Size(436, 40);
            this.uxButtonSave.TabIndex = 0;
            this.uxButtonSave.Text = "Return to Main";
            this.uxButtonSave.UseVisualStyleBackColor = true;
            // 
            // uxDataGridViewPantry
            // 
            this.uxDataGridViewPantry.AllowUserToAddRows = false;
            this.uxDataGridViewPantry.AllowUserToDeleteRows = false;
            this.uxDataGridViewPantry.AllowUserToOrderColumns = true;
            this.uxDataGridViewPantry.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.uxDataGridViewPantry.Location = new System.Drawing.Point(13, 59);
            this.uxDataGridViewPantry.Name = "uxDataGridViewPantry";
            this.uxDataGridViewPantry.ReadOnly = true;
            this.uxDataGridViewPantry.RowHeadersWidth = 62;
            this.uxDataGridViewPantry.RowTemplate.Height = 28;
            this.uxDataGridViewPantry.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.uxDataGridViewPantry.Size = new System.Drawing.Size(435, 379);
            this.uxDataGridViewPantry.TabIndex = 2;
            this.uxDataGridViewPantry.Click += new System.EventHandler(this.uxDataGridViewPantry_Click);
            // 
            // PantryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(459, 450);
            this.Controls.Add(this.uxDataGridViewPantry);
            this.Controls.Add(this.uxButtonSave);
            this.Name = "PantryForm";
            this.Text = "PantryForm";
            this.Load += new System.EventHandler(this.PantryForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.uxDataGridViewPantry)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button uxButtonSave;
        private System.Windows.Forms.DataGridView uxDataGridViewPantry;
    }
}