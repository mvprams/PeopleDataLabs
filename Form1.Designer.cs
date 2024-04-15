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
            this.email_lbl = new System.Windows.Forms.Label();
            this.Email_tb = new System.Windows.Forms.TextBox();
            this.linkedin_lbl = new System.Windows.Forms.Label();
            this.LinkedIn_tb = new System.Windows.Forms.TextBox();
            this.Search_btn = new System.Windows.Forms.Button();
            this.enrich_btn = new System.Windows.Forms.Button();
            this.results_tb = new System.Windows.Forms.RichTextBox();
            this.isFound_tb = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Fname_tb
            // 
            this.Fname_tb.Location = new System.Drawing.Point(89, 26);
            this.Fname_tb.Margin = new System.Windows.Forms.Padding(2);
            this.Fname_tb.Name = "Fname_tb";
            this.Fname_tb.Size = new System.Drawing.Size(171, 20);
            this.Fname_tb.TabIndex = 0;
            // 
            // Fname_lbl
            // 
            this.Fname_lbl.AutoSize = true;
            this.Fname_lbl.Location = new System.Drawing.Point(22, 26);
            this.Fname_lbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Fname_lbl.Name = "Fname_lbl";
            this.Fname_lbl.Size = new System.Drawing.Size(60, 13);
            this.Fname_lbl.TabIndex = 1;
            this.Fname_lbl.Text = "First Name:";
            // 
            // Lname_lbl
            // 
            this.Lname_lbl.AutoSize = true;
            this.Lname_lbl.Location = new System.Drawing.Point(22, 75);
            this.Lname_lbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Lname_lbl.Name = "Lname_lbl";
            this.Lname_lbl.Size = new System.Drawing.Size(61, 13);
            this.Lname_lbl.TabIndex = 3;
            this.Lname_lbl.Text = "Last Name:";
            // 
            // Lname_tb
            // 
            this.Lname_tb.Location = new System.Drawing.Point(89, 75);
            this.Lname_tb.Margin = new System.Windows.Forms.Padding(2);
            this.Lname_tb.Name = "Lname_tb";
            this.Lname_tb.Size = new System.Drawing.Size(171, 20);
            this.Lname_tb.TabIndex = 2;
            // 
            // email_lbl
            // 
            this.email_lbl.AutoSize = true;
            this.email_lbl.Location = new System.Drawing.Point(281, 26);
            this.email_lbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.email_lbl.Name = "email_lbl";
            this.email_lbl.Size = new System.Drawing.Size(35, 13);
            this.email_lbl.TabIndex = 7;
            this.email_lbl.Text = "Email:";
            // 
            // Email_tb
            // 
            this.Email_tb.Location = new System.Drawing.Point(336, 26);
            this.Email_tb.Margin = new System.Windows.Forms.Padding(2);
            this.Email_tb.Name = "Email_tb";
            this.Email_tb.Size = new System.Drawing.Size(183, 20);
            this.Email_tb.TabIndex = 6;
            // 
            // linkedin_lbl
            // 
            this.linkedin_lbl.AutoSize = true;
            this.linkedin_lbl.Location = new System.Drawing.Point(281, 72);
            this.linkedin_lbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.linkedin_lbl.Name = "linkedin_lbl";
            this.linkedin_lbl.Size = new System.Drawing.Size(51, 13);
            this.linkedin_lbl.TabIndex = 9;
            this.linkedin_lbl.Text = "LinkedIn:";
            // 
            // LinkedIn_tb
            // 
            this.LinkedIn_tb.Location = new System.Drawing.Point(336, 72);
            this.LinkedIn_tb.Margin = new System.Windows.Forms.Padding(2);
            this.LinkedIn_tb.Name = "LinkedIn_tb";
            this.LinkedIn_tb.Size = new System.Drawing.Size(183, 20);
            this.LinkedIn_tb.TabIndex = 8;
            // 
            // Search_btn
            // 
            this.Search_btn.Location = new System.Drawing.Point(25, 124);
            this.Search_btn.Name = "Search_btn";
            this.Search_btn.Size = new System.Drawing.Size(75, 23);
            this.Search_btn.TabIndex = 10;
            this.Search_btn.Text = "Search";
            this.Search_btn.UseVisualStyleBackColor = true;
            this.Search_btn.Click += new System.EventHandler(this.Search_btn_Click);
            // 
            // enrich_btn
            // 
            this.enrich_btn.Location = new System.Drawing.Point(141, 124);
            this.enrich_btn.Name = "enrich_btn";
            this.enrich_btn.Size = new System.Drawing.Size(75, 23);
            this.enrich_btn.TabIndex = 11;
            this.enrich_btn.Text = "Enrich";
            this.enrich_btn.UseVisualStyleBackColor = true;
            this.enrich_btn.Click += new System.EventHandler(this.enrich_btn_Click);
            // 
            // results_tb
            // 
            this.results_tb.Location = new System.Drawing.Point(12, 182);
            this.results_tb.Name = "results_tb";
            this.results_tb.Size = new System.Drawing.Size(748, 217);
            this.results_tb.TabIndex = 13;
            this.results_tb.Text = "";
            // 
            // isFound_tb
            // 
            this.isFound_tb.AutoSize = true;
            this.isFound_tb.Location = new System.Drawing.Point(581, 54);
            this.isFound_tb.Name = "isFound_tb";
            this.isFound_tb.Size = new System.Drawing.Size(91, 13);
            this.isFound_tb.TabIndex = 14;
            this.isFound_tb.Text = "No Person Object";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(772, 411);
            this.Controls.Add(this.isFound_tb);
            this.Controls.Add(this.results_tb);
            this.Controls.Add(this.enrich_btn);
            this.Controls.Add(this.Search_btn);
            this.Controls.Add(this.linkedin_lbl);
            this.Controls.Add(this.LinkedIn_tb);
            this.Controls.Add(this.email_lbl);
            this.Controls.Add(this.Email_tb);
            this.Controls.Add(this.Lname_lbl);
            this.Controls.Add(this.Lname_tb);
            this.Controls.Add(this.Fname_lbl);
            this.Controls.Add(this.Fname_tb);
            this.Margin = new System.Windows.Forms.Padding(2);
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
        private System.Windows.Forms.Label email_lbl;
        private System.Windows.Forms.TextBox Email_tb;
        private System.Windows.Forms.Label linkedin_lbl;
        private System.Windows.Forms.TextBox LinkedIn_tb;
        private System.Windows.Forms.Button Search_btn;
        private System.Windows.Forms.Button enrich_btn;
        private System.Windows.Forms.RichTextBox results_tb;
        private System.Windows.Forms.Label isFound_tb;
    }
}

