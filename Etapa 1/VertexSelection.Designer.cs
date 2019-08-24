namespace Final_Project
{
    partial class FormVertexSelection
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
            this.ComboBoxVertexes = new System.Windows.Forms.ComboBox();
            this.LabelVertex = new System.Windows.Forms.Label();
            this.ButtonAccept = new System.Windows.Forms.Button();
            this.ButtonCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ComboBoxVertexes
            // 
            this.ComboBoxVertexes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBoxVertexes.FormattingEnabled = true;
            this.ComboBoxVertexes.Location = new System.Drawing.Point(15, 25);
            this.ComboBoxVertexes.Name = "ComboBoxVertexes";
            this.ComboBoxVertexes.Size = new System.Drawing.Size(156, 21);
            this.ComboBoxVertexes.TabIndex = 0;
            // 
            // LabelVertex
            // 
            this.LabelVertex.AutoSize = true;
            this.LabelVertex.Location = new System.Drawing.Point(12, 9);
            this.LabelVertex.Name = "LabelVertex";
            this.LabelVertex.Size = new System.Drawing.Size(43, 13);
            this.LabelVertex.TabIndex = 1;
            this.LabelVertex.Text = "Vértice ";
            // 
            // ButtonAccept
            // 
            this.ButtonAccept.Location = new System.Drawing.Point(177, 23);
            this.ButtonAccept.Name = "ButtonAccept";
            this.ButtonAccept.Size = new System.Drawing.Size(75, 23);
            this.ButtonAccept.TabIndex = 2;
            this.ButtonAccept.Text = "Aceptar";
            this.ButtonAccept.UseVisualStyleBackColor = true;
            this.ButtonAccept.Click += new System.EventHandler(this.ButtonAccept_Click);
            // 
            // ButtonCancel
            // 
            this.ButtonCancel.Location = new System.Drawing.Point(258, 23);
            this.ButtonCancel.Name = "ButtonCancel";
            this.ButtonCancel.Size = new System.Drawing.Size(75, 23);
            this.ButtonCancel.TabIndex = 3;
            this.ButtonCancel.Text = "Cancelar";
            this.ButtonCancel.UseVisualStyleBackColor = true;
            this.ButtonCancel.Click += new System.EventHandler(this.ButtonCancel_Click);
            // 
            // FormVertexSelection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(347, 57);
            this.Controls.Add(this.ButtonCancel);
            this.Controls.Add(this.ButtonAccept);
            this.Controls.Add(this.LabelVertex);
            this.Controls.Add(this.ComboBoxVertexes);
            this.Name = "FormVertexSelection";
            this.Text = "Elección de Vértice ";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox ComboBoxVertexes;
        private System.Windows.Forms.Label LabelVertex;
        private System.Windows.Forms.Button ButtonAccept;
        private System.Windows.Forms.Button ButtonCancel;
    }
}