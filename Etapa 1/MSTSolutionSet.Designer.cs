namespace Final_Project
{
    partial class FormMSTSolutionSet
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
            this.DataGridViewSolutionSet = new System.Windows.Forms.DataGridView();
            this.ButtonContinue = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridViewSolutionSet)).BeginInit();
            this.SuspendLayout();
            // 
            // DataGridViewSolutionSet
            // 
            this.DataGridViewSolutionSet.AllowUserToAddRows = false;
            this.DataGridViewSolutionSet.AllowUserToDeleteRows = false;
            this.DataGridViewSolutionSet.AllowUserToResizeColumns = false;
            this.DataGridViewSolutionSet.AllowUserToResizeRows = false;
            this.DataGridViewSolutionSet.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DataGridViewSolutionSet.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridViewSolutionSet.Location = new System.Drawing.Point(12, 12);
            this.DataGridViewSolutionSet.Name = "DataGridViewSolutionSet";
            this.DataGridViewSolutionSet.ReadOnly = true;
            this.DataGridViewSolutionSet.RowHeadersVisible = false;
            this.DataGridViewSolutionSet.Size = new System.Drawing.Size(472, 132);
            this.DataGridViewSolutionSet.TabIndex = 0;
            // 
            // ButtonContinue
            // 
            this.ButtonContinue.Location = new System.Drawing.Point(409, 150);
            this.ButtonContinue.Name = "ButtonContinue";
            this.ButtonContinue.Size = new System.Drawing.Size(75, 23);
            this.ButtonContinue.TabIndex = 1;
            this.ButtonContinue.Text = "Continuar";
            this.ButtonContinue.UseVisualStyleBackColor = true;
            this.ButtonContinue.Click += new System.EventHandler(this.ButtonContinue_Click);
            // 
            // FormMSTSolutionSet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(496, 179);
            this.Controls.Add(this.ButtonContinue);
            this.Controls.Add(this.DataGridViewSolutionSet);
            this.Name = "FormMSTSolutionSet";
            this.Text = "Conjunto Solución de ARM con ";
            ((System.ComponentModel.ISupportInitialize)(this.DataGridViewSolutionSet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView DataGridViewSolutionSet;
        private System.Windows.Forms.Button ButtonContinue;
    }
}