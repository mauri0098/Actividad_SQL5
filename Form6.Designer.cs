namespace Actividad_SQL5
{
    partial class Form6
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
            this.Grila = new System.Windows.Forms.DataGridView();
            this.Chofer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotalLitros = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.Grila)).BeginInit();
            this.SuspendLayout();
            // 
            // Grila
            // 
            this.Grila.AllowUserToAddRows = false;
            this.Grila.AllowUserToDeleteRows = false;
            this.Grila.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Grila.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Chofer,
            this.AA,
            this.TotalLitros});
            this.Grila.Location = new System.Drawing.Point(21, 12);
            this.Grila.Name = "Grila";
            this.Grila.ReadOnly = true;
            this.Grila.Size = new System.Drawing.Size(401, 234);
            this.Grila.TabIndex = 1;
            // 
            // Chofer
            // 
            this.Chofer.HeaderText = "Chofer";
            this.Chofer.Name = "Chofer";
            this.Chofer.ReadOnly = true;
            // 
            // AA
            // 
            this.AA.HeaderText = "AA";
            this.AA.Name = "AA";
            this.AA.ReadOnly = true;
            // 
            // TotalLitros
            // 
            this.TotalLitros.HeaderText = "Total litros";
            this.TotalLitros.Name = "TotalLitros";
            this.TotalLitros.ReadOnly = true;
            // 
            // Form6
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(508, 289);
            this.Controls.Add(this.Grila);
            this.Name = "Form6";
            this.Text = "Form6";
            this.Load += new System.EventHandler(this.Form6_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Grila)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView Grila;
        private System.Windows.Forms.DataGridViewTextBoxColumn Chofer;
        private System.Windows.Forms.DataGridViewTextBoxColumn AA;
        private System.Windows.Forms.DataGridViewTextBoxColumn TotalLitros;
    }
}