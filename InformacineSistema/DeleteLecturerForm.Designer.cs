
namespace InformacineSistema
{
    partial class DeleteLecturerForm
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
            this.IDBox = new System.Windows.Forms.ComboBox();
            this.istrintiDestytojabutton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label1.Location = new System.Drawing.Point(197, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "ID:";
            // 
            // IDBox
            // 
            this.IDBox.FormattingEnabled = true;
            this.IDBox.Location = new System.Drawing.Point(263, 63);
            this.IDBox.Name = "IDBox";
            this.IDBox.Size = new System.Drawing.Size(266, 24);
            this.IDBox.TabIndex = 1;
            // 
            // istrintiDestytojabutton
            // 
            this.istrintiDestytojabutton.Location = new System.Drawing.Point(263, 229);
            this.istrintiDestytojabutton.Name = "istrintiDestytojabutton";
            this.istrintiDestytojabutton.Size = new System.Drawing.Size(266, 99);
            this.istrintiDestytojabutton.TabIndex = 2;
            this.istrintiDestytojabutton.Text = "Istrinti destytoja";
            this.istrintiDestytojabutton.UseVisualStyleBackColor = true;
            this.istrintiDestytojabutton.Click += new System.EventHandler(this.istrintiDestytojabutton_Click);
            // 
            // DeleteLecturerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.istrintiDestytojabutton);
            this.Controls.Add(this.IDBox);
            this.Controls.Add(this.label1);
            this.Name = "DeleteLecturerForm";
            this.Text = "DeleteLecturerForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox IDBox;
        private System.Windows.Forms.Button istrintiDestytojabutton;
    }
}