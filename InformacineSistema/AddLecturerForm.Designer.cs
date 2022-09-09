
namespace InformacineSistema
{
    partial class AddLecturerForm
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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.vardoBox = new System.Windows.Forms.TextBox();
            this.pavardesBox = new System.Windows.Forms.TextBox();
            this.dalykoBox = new System.Windows.Forms.TextBox();
            this.grupesBox = new System.Windows.Forms.ComboBox();
            this.Ivedimobutton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(162, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Vardas:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(165, 98);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Pavarde:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(165, 142);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "Dalykas:";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(168, 196);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 17);
            this.label4.TabIndex = 3;
            this.label4.Text = "Grupe:";
            // 
            // vardoBox
            // 
            this.vardoBox.Location = new System.Drawing.Point(278, 59);
            this.vardoBox.Name = "vardoBox";
            this.vardoBox.Size = new System.Drawing.Size(250, 22);
            this.vardoBox.TabIndex = 4;
            // 
            // pavardesBox
            // 
            this.pavardesBox.Location = new System.Drawing.Point(278, 98);
            this.pavardesBox.Name = "pavardesBox";
            this.pavardesBox.Size = new System.Drawing.Size(250, 22);
            this.pavardesBox.TabIndex = 5;
            // 
            // dalykoBox
            // 
            this.dalykoBox.Location = new System.Drawing.Point(278, 142);
            this.dalykoBox.Name = "dalykoBox";
            this.dalykoBox.Size = new System.Drawing.Size(250, 22);
            this.dalykoBox.TabIndex = 6;
            // 
            // grupesBox
            // 
            this.grupesBox.FormattingEnabled = true;
            this.grupesBox.Location = new System.Drawing.Point(278, 196);
            this.grupesBox.Name = "grupesBox";
            this.grupesBox.Size = new System.Drawing.Size(250, 24);
            this.grupesBox.TabIndex = 7;
            // 
            // Ivedimobutton
            // 
            this.Ivedimobutton.Location = new System.Drawing.Point(278, 298);
            this.Ivedimobutton.Name = "Ivedimobutton";
            this.Ivedimobutton.Size = new System.Drawing.Size(250, 92);
            this.Ivedimobutton.TabIndex = 8;
            this.Ivedimobutton.Text = "Ivesti destytoja";
            this.Ivedimobutton.UseVisualStyleBackColor = true;
            this.Ivedimobutton.Click += new System.EventHandler(this.Ivedimobutton_Click);
            // 
            // AddLecturerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Ivedimobutton);
            this.Controls.Add(this.grupesBox);
            this.Controls.Add(this.dalykoBox);
            this.Controls.Add(this.pavardesBox);
            this.Controls.Add(this.vardoBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "AddLecturerForm";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox vardoBox;
        private System.Windows.Forms.TextBox pavardesBox;
        private System.Windows.Forms.TextBox dalykoBox;
        private System.Windows.Forms.ComboBox grupesBox;
        private System.Windows.Forms.Button Ivedimobutton;
    }
}