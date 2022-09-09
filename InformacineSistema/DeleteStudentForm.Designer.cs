
namespace InformacineSistema
{
    partial class IstrintiStudentaForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.IDbox = new System.Windows.Forms.ComboBox();
            this.DeleteStudentbutton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label1.Location = new System.Drawing.Point(139, 108);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "ID:";
            // 
            // IDbox
            // 
            this.IDbox.FormattingEnabled = true;
            this.IDbox.Location = new System.Drawing.Point(197, 108);
            this.IDbox.Name = "IDbox";
            this.IDbox.Size = new System.Drawing.Size(413, 24);
            this.IDbox.TabIndex = 1;
            // 
            // DeleteStudentbutton
            // 
            this.DeleteStudentbutton.Location = new System.Drawing.Point(282, 230);
            this.DeleteStudentbutton.Name = "DeleteStudentbutton";
            this.DeleteStudentbutton.Size = new System.Drawing.Size(220, 115);
            this.DeleteStudentbutton.TabIndex = 2;
            this.DeleteStudentbutton.Text = "Istrinti studenta";
            this.DeleteStudentbutton.UseVisualStyleBackColor = true;
            this.DeleteStudentbutton.Click += new System.EventHandler(this.DeleteStudentbutton_Click);
            // 
            // IstrintiStudentaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.DeleteStudentbutton);
            this.Controls.Add(this.IDbox);
            this.Controls.Add(this.label1);
            this.Name = "IstrintiStudentaForm";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.IstrintiStudentaForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox IDbox;
        private System.Windows.Forms.Button DeleteStudentbutton;
    }
}