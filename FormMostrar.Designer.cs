namespace Programacion2Final
{
    partial class FormMostrar
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
            this.lbResumen = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // lbResumen
            // 
            this.lbResumen.FormattingEnabled = true;
            this.lbResumen.ItemHeight = 16;
            this.lbResumen.Location = new System.Drawing.Point(61, 39);
            this.lbResumen.Name = "lbResumen";
            this.lbResumen.Size = new System.Drawing.Size(1257, 340);
            this.lbResumen.TabIndex = 0;
            // 
            // FormMostrar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1343, 450);
            this.Controls.Add(this.lbResumen);
            this.Name = "FormMostrar";
            this.Text = "FormMostrar";
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.ListBox lbResumen;
    }
}