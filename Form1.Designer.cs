namespace PeopleDataLabs
{
    partial class Form1
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
            this.Fname_tb = new System.Windows.Forms.TextBox();
            this.Fname_lbl = new System.Windows.Forms.Label();
            this.Lname_lbl = new System.Windows.Forms.Label();
            this.Lname_tb = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // Fname_tb
            // 
            this.Fname_tb.Location = new System.Drawing.Point(106, 60);
            this.Fname_tb.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Fname_tb.Name = "Fname_tb";
            this.Fname_tb.Size = new System.Drawing.Size(171, 20);
            this.Fname_tb.TabIndex = 0;
            // 
            // Fname_lbl
            // 
            this.Fname_lbl.AutoSize = true;
            this.Fname_lbl.Location = new System.Drawing.Point(39, 60);
            this.Fname_lbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Fname_lbl.Name = "Fname_lbl";
            this.Fname_lbl.Size = new System.Drawing.Size(60, 13);
            this.Fname_lbl.TabIndex = 1;
            this.Fname_lbl.Text = "First Name:";
            // 
            // Lname_lbl
            // 
            this.Lname_lbl.AutoSize = true;
            this.Lname_lbl.Location = new System.Drawing.Point(39, 109);
            this.Lname_lbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Lname_lbl.Name = "Lname_lbl";
            this.Lname_lbl.Size = new System.Drawing.Size(61, 13);
            this.Lname_lbl.TabIndex = 3;
            this.Lname_lbl.Text = "Last Name:";
            // 
            // Lname_tb
            // 
            this.Lname_tb.Location = new System.Drawing.Point(106, 109);
            this.Lname_tb.Margin = new System.Windows.Forms.Padding(2);
            this.Lname_tb.Name = "Lname_tb";
            this.Lname_tb.Size = new System.Drawing.Size(171, 20);
            this.Lname_tb.TabIndex = 2;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(772, 411);
            this.Controls.Add(this.Lname_lbl);
            this.Controls.Add(this.Lname_tb);
            this.Controls.Add(this.Fname_lbl);
            this.Controls.Add(this.Fname_tb);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox Fname_tb;
        private System.Windows.Forms.Label Fname_lbl;
        private System.Windows.Forms.Label Lname_lbl;
        private System.Windows.Forms.TextBox Lname_tb;
    }
}

