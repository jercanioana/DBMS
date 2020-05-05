namespace Lab1_DBMS
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
            System.Windows.Forms.Label label1;
            this.dgvNurse = new System.Windows.Forms.DataGridView();
            this.dgvPatient = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.deleteBox = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNurse)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPatient)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvNurse
            // 
            this.dgvNurse.AccessibleName = "dgvPatient";
            this.dgvNurse.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvNurse.Location = new System.Drawing.Point(46, 32);
            this.dgvNurse.Name = "dgvNurse";
            this.dgvNurse.RowHeadersWidth = 51;
            this.dgvNurse.RowTemplate.Height = 24;
            this.dgvNurse.Size = new System.Drawing.Size(1072, 155);
            this.dgvNurse.TabIndex = 0;
            this.dgvNurse.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // dgvPatient
            // 
            this.dgvPatient.AccessibleName = "dgvNurse";
            this.dgvPatient.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPatient.Location = new System.Drawing.Point(46, 210);
            this.dgvPatient.Name = "dgvPatient";
            this.dgvPatient.RowHeadersWidth = 51;
            this.dgvPatient.RowTemplate.Height = 24;
            this.dgvPatient.Size = new System.Drawing.Size(1072, 150);
            this.dgvPatient.TabIndex = 1;
            this.dgvPatient.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView2_CellContentClick);
            // 
            // button1
            // 
            this.button1.AccessibleName = "btnUpdateDB";
            this.button1.Location = new System.Drawing.Point(46, 393);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Update DB";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // deleteBox
            // 
            this.deleteBox.Location = new System.Drawing.Point(362, 393);
            this.deleteBox.Name = "deleteBox";
            this.deleteBox.Size = new System.Drawing.Size(100, 22);
            this.deleteBox.TabIndex = 3;
            this.deleteBox.TextChanged += new System.EventHandler(this.deleteBox_TextChanged);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(492, 392);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 4;
            this.button2.Text = "Delete";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(327, 396);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(29, 17);
            label1.TabIndex = 5;
            label1.Text = "ID: ";
            label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1160, 450);
            this.Controls.Add(label1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.deleteBox);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dgvPatient);
            this.Controls.Add(this.dgvNurse);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvNurse)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPatient)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvNurse;
        private System.Windows.Forms.DataGridView dgvPatient;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox deleteBox;
        private System.Windows.Forms.Button button2;
    }
}

