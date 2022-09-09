
namespace InformacineSistema
{
    partial class AddGroup
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
            this.groupNameBox = new System.Windows.Forms.TextBox();
            this.textbox1 = new System.Windows.Forms.Label();
            this.destytojoBox = new System.Windows.Forms.ComboBox();
            this.irasytiGrupe = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(160, 87);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(142, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Grupes pavadinimas:";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // groupNameBox
            // 
            this.groupNameBox.Location = new System.Drawing.Point(331, 87);
            this.groupNameBox.Name = "groupNameBox";
            this.groupNameBox.Size = new System.Drawing.Size(247, 22);
            this.groupNameBox.TabIndex = 1;
            // 
            // textbox1
            // 
            this.textbox1.AutoSize = true;
            this.textbox1.Location = new System.Drawing.Point(160, 185);
            this.textbox1.Name = "textbox1";
            this.textbox1.Size = new System.Drawing.Size(78, 17);
            this.textbox1.TabIndex = 2;
            this.textbox1.Text = "Destytojas:";
            // 
            // destytojoBox
            // 
            this.destytojoBox.FormattingEnabled = true;
            this.destytojoBox.Location = new System.Drawing.Point(331, 176);
            this.destytojoBox.Name = "destytojoBox";
            this.destytojoBox.Size = new System.Drawing.Size(247, 24);
            this.destytojoBox.TabIndex = 3;
            // 
            // irasytiGrupe
            // 
            this.irasytiGrupe.Location = new System.Drawing.Point(287, 268);
            this.irasytiGrupe.Name = "irasytiGrupe";
            this.irasytiGrupe.Size = new System.Drawing.Size(220, 112);
            this.irasytiGrupe.TabIndex = 4;
            this.irasytiGrupe.Text = "Irasyti grupe";
            this.irasytiGrupe.UseVisualStyleBackColor = true;
            this.irasytiGrupe.Click += new System.EventHandler(this.irasytiGrupe_Click);
            // 
            // AddGroup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.irasytiGrupe);
            this.Controls.Add(this.destytojoBox);
            this.Controls.Add(this.textbox1);
            this.Controls.Add(this.groupNameBox);
            this.Controls.Add(this.label1);
            this.Name = "AddGroup";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox groupNameBox;
        private System.Windows.Forms.Label textbox1;
        private System.Windows.Forms.ComboBox destytojoBox;
        private System.Windows.Forms.Button irasytiGrupe;
    }
}