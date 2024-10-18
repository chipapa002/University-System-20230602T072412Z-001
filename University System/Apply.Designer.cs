namespace University_System
{
    partial class Apply
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.coursebox = new System.Windows.Forms.ComboBox();
            this.id = new System.Windows.Forms.TextBox();
            this.submit = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("MS Reference Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(104, 107);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "Student ID";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("MS Reference Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(104, 152);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 18);
            this.label2.TabIndex = 1;
            this.label2.Text = "Course";
            // 
            // coursebox
            // 
            this.coursebox.FormattingEnabled = true;
            this.coursebox.Items.AddRange(new object[] {
            "BCom Information Systems",
            "BCom Information Management",
            "Bachelor of Architecture",
            "BA Fashion Design",
            "BEd Foundation Phase Teaching Gr R-3",
            "BEd Intermediate Phase Teaching Gr 4-7",
            "BEng Electrical and Electronic Engineering",
            "BEng Civil Engineering",
            "Bachelor of Environmental Health",
            "Bachelor of Nursing",
            "BA with specialisation in Economics and Technology",
            "Bachelor of Social Work",
            "BCom Law",
            "LLB",
            "BSc Computer Science and Informatics",
            "BSc Mathematical Science(Actuarial Science"});
            this.coursebox.Location = new System.Drawing.Point(186, 149);
            this.coursebox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.coursebox.Name = "coursebox";
            this.coursebox.Size = new System.Drawing.Size(266, 26);
            this.coursebox.TabIndex = 2;
            // 
            // id
            // 
            this.id.Location = new System.Drawing.Point(208, 107);
            this.id.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Size = new System.Drawing.Size(156, 24);
            this.id.TabIndex = 3;
            this.id.TextChanged += new System.EventHandler(this.id_TextChanged);
            // 
            // submit
            // 
            this.submit.BackColor = System.Drawing.Color.LightSteelBlue;
            this.submit.Location = new System.Drawing.Point(221, 243);
            this.submit.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.submit.Name = "submit";
            this.submit.Size = new System.Drawing.Size(121, 32);
            this.submit.TabIndex = 4;
            this.submit.Text = "Submit ";
            this.submit.UseVisualStyleBackColor = false;
            this.submit.Click += new System.EventHandler(this.submit_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(236, 202);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(0, 25);
            this.label3.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(139, 33);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(296, 29);
            this.label4.TabIndex = 6;
            this.label4.Text = "COURSE APPLICATION";
            // 
            // Apply
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightCyan;
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.submit);
            this.Controls.Add(this.id);
            this.Controls.Add(this.coursebox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("MS Reference Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "Apply";
            this.Size = new System.Drawing.Size(743, 516);
            this.Load += new System.EventHandler(this.Apply_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox coursebox;
        private System.Windows.Forms.TextBox id;
        private System.Windows.Forms.Button submit;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}
