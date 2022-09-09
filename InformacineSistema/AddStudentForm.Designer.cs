
namespace InformacineSistema
{
    partial class AddStudentForm
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
            this.grupesBox = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dalykoBox = new System.Windows.Forms.ComboBox();
            this.vardoTextBox = new System.Windows.Forms.TextBox();
            this.pavardesTextBox = new System.Windows.Forms.TextBox();
            this.Ivedimobutton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(131, 77);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Vardas:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(134, 120);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Pavarde:";
            // 
            // grupesBox
            // 
            this.grupesBox.FormattingEnabled = true;
            this.grupesBox.Location = new System.Drawing.Point(230, 161);
            this.grupesBox.Name = "grupesBox";
            this.grupesBox.Size = new System.Drawing.Size(229, 24);
            this.grupesBox.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(134, 161);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 17);
            this.label3.TabIndex = 3;
            this.label3.Text = "Grupe:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(134, 214);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 17);
            this.label4.TabIndex = 4;
            this.label4.Text = "Dalykas:";
            // 
            // dalykoBox
            // 
            this.dalykoBox.FormattingEnabled = true;
            this.dalykoBox.Location = new System.Drawing.Point(230, 214);
            this.dalykoBox.Name = "dalykoBox";
            this.dalykoBox.Size = new System.Drawing.Size(229, 24);
            this.dalykoBox.TabIndex = 5;
            // 
            // vardoTextBox
            // 
            this.vardoTextBox.Location = new System.Drawing.Point(230, 77);
            this.vardoTextBox.Name = "vardoTextBox";
            this.vardoTextBox.Size = new System.Drawing.Size(229, 22);
            this.vardoTextBox.TabIndex = 6;
            // 
            // pavardesTextBox
            // 
            this.pavardesTextBox.Location = new System.Drawing.Point(230, 120);
            this.pavardesTextBox.Name = "pavardesTextBox";
            this.pavardesTextBox.Size = new System.Drawing.Size(229, 22);
            this.pavardesTextBox.TabIndex = 7;
            // 
            // Ivedimobutton
            // 
            this.Ivedimobutton.Location = new System.Drawing.Point(230, 312);
            this.Ivedimobutton.Name = "Ivedimobutton";
            this.Ivedimobutton.Size = new System.Drawing.Size(229, 75);
            this.Ivedimobutton.TabIndex = 8;
            this.Ivedimobutton.Text = "Ivesti studenta";
            this.Ivedimobutton.UseVisualStyleBackColor = true;
            this.Ivedimobutton.Click += new System.EventHandler(this.Ivedimobutton_Click);
            // 
            // AddStudentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Ivedimobutton);
            this.Controls.Add(this.pavardesTextBox);
            this.Controls.Add(this.vardoTextBox);
            this.Controls.Add(this.dalykoBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.grupesBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "AddStudentForm";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.AddStudentForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox grupesBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox dalykoBox;
        private System.Windows.Forms.TextBox vardoTextBox;
        private System.Windows.Forms.TextBox pavardesTextBox;
        private System.Windows.Forms.Button Ivedimobutton;
    }
}