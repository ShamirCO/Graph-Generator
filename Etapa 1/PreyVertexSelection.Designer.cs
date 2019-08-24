namespace Final_Project
{
    partial class FormPreyVertexSelection
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
            this.ButtonCancel = new System.Windows.Forms.Button();
            this.ButtonAccept = new System.Windows.Forms.Button();
            this.LabelOriginVertex = new System.Windows.Forms.Label();
            this.ComboBoxOriginVertex = new System.Windows.Forms.ComboBox();
            this.LabelDestinationVertex = new System.Windows.Forms.Label();
            this.ComboBoxDestinationVertex = new System.Windows.Forms.ComboBox();
            this.LabelPrey = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ButtonCancel
            // 
            this.ButtonCancel.Location = new System.Drawing.Point(96, 109);
            this.ButtonCancel.Name = "ButtonCancel";
            this.ButtonCancel.Size = new System.Drawing.Size(75, 23);
            this.ButtonCancel.TabIndex = 7;
            this.ButtonCancel.Text = "Cancelar";
            this.ButtonCancel.UseVisualStyleBackColor = true;
            this.ButtonCancel.Click += new System.EventHandler(this.ButtonCancel_Click);
            // 
            // ButtonAccept
            // 
            this.ButtonAccept.Location = new System.Drawing.Point(15, 109);
            this.ButtonAccept.Name = "ButtonAccept";
            this.ButtonAccept.Size = new System.Drawing.Size(75, 23);
            this.ButtonAccept.TabIndex = 6;
            this.ButtonAccept.Text = "Aceptar";
            this.ButtonAccept.UseVisualStyleBackColor = true;
            this.ButtonAccept.Click += new System.EventHandler(this.ButtonAccept_Click);
            // 
            // LabelOriginVertex
            // 
            this.LabelOriginVertex.AutoSize = true;
            this.LabelOriginVertex.Location = new System.Drawing.Point(12, 26);
            this.LabelOriginVertex.Name = "LabelOriginVertex";
            this.LabelOriginVertex.Size = new System.Drawing.Size(77, 13);
            this.LabelOriginVertex.TabIndex = 5;
            this.LabelOriginVertex.Text = "Vértice Origen:";
            // 
            // ComboBoxOriginVertex
            // 
            this.ComboBoxOriginVertex.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBoxOriginVertex.FormattingEnabled = true;
            this.ComboBoxOriginVertex.Location = new System.Drawing.Point(15, 42);
            this.ComboBoxOriginVertex.Name = "ComboBoxOriginVertex";
            this.ComboBoxOriginVertex.Size = new System.Drawing.Size(156, 21);
            this.ComboBoxOriginVertex.TabIndex = 4;
            // 
            // LabelDestinationVertex
            // 
            this.LabelDestinationVertex.AutoSize = true;
            this.LabelDestinationVertex.Location = new System.Drawing.Point(12, 66);
            this.LabelDestinationVertex.Name = "LabelDestinationVertex";
            this.LabelDestinationVertex.Size = new System.Drawing.Size(82, 13);
            this.LabelDestinationVertex.TabIndex = 9;
            this.LabelDestinationVertex.Text = "Vértice Destino:";
            // 
            // ComboBoxDestinationVertex
            // 
            this.ComboBoxDestinationVertex.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBoxDestinationVertex.FormattingEnabled = true;
            this.ComboBoxDestinationVertex.Location = new System.Drawing.Point(15, 82);
            this.ComboBoxDestinationVertex.Name = "ComboBoxDestinationVertex";
            this.ComboBoxDestinationVertex.Size = new System.Drawing.Size(156, 21);
            this.ComboBoxDestinationVertex.TabIndex = 8;
            // 
            // LabelPrey
            // 
            this.LabelPrey.AutoSize = true;
            this.LabelPrey.Location = new System.Drawing.Point(12, 9);
            this.LabelPrey.Name = "LabelPrey";
            this.LabelPrey.Size = new System.Drawing.Size(37, 13);
            this.LabelPrey.TabIndex = 10;
            this.LabelPrey.Text = "Presa ";
            // 
            // FormPreyVertexSelection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(189, 147);
            this.Controls.Add(this.LabelPrey);
            this.Controls.Add(this.LabelDestinationVertex);
            this.Controls.Add(this.ComboBoxDestinationVertex);
            this.Controls.Add(this.ButtonCancel);
            this.Controls.Add(this.ButtonAccept);
            this.Controls.Add(this.LabelOriginVertex);
            this.Controls.Add(this.ComboBoxOriginVertex);
            this.Name = "FormPreyVertexSelection";
            this.Text = "Eleccion de Vértices";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ButtonCancel;
        private System.Windows.Forms.Button ButtonAccept;
        private System.Windows.Forms.Label LabelOriginVertex;
        private System.Windows.Forms.ComboBox ComboBoxOriginVertex;
        private System.Windows.Forms.Label LabelDestinationVertex;
        private System.Windows.Forms.ComboBox ComboBoxDestinationVertex;
        private System.Windows.Forms.Label LabelPrey;
    }
}