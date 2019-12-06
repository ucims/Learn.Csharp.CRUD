namespace Learn.CRUD.MsSQL
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
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxRoll = new System.Windows.Forms.TextBox();
            this.buttonLihat = new System.Windows.Forms.Button();
            this.textBoxScience = new System.Windows.Forms.TextBox();
            this.textBoxEnglish = new System.Windows.Forms.TextBox();
            this.textBoxBahasa = new System.Windows.Forms.TextBox();
            this.buttonSimpan = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.buttonUpdate = new System.Windows.Forms.Button();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(28, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Roll ";
            // 
            // textBoxRoll
            // 
            this.textBoxRoll.Location = new System.Drawing.Point(86, 13);
            this.textBoxRoll.Name = "textBoxRoll";
            this.textBoxRoll.Size = new System.Drawing.Size(237, 20);
            this.textBoxRoll.TabIndex = 1;
            // 
            // buttonLihat
            // 
            this.buttonLihat.Location = new System.Drawing.Point(86, 39);
            this.buttonLihat.Name = "buttonLihat";
            this.buttonLihat.Size = new System.Drawing.Size(75, 23);
            this.buttonLihat.TabIndex = 2;
            this.buttonLihat.Text = "Lihat";
            this.buttonLihat.UseVisualStyleBackColor = true;
            this.buttonLihat.Click += new System.EventHandler(this.buttonLihat_Click);
            // 
            // textBoxScience
            // 
            this.textBoxScience.Location = new System.Drawing.Point(86, 91);
            this.textBoxScience.Name = "textBoxScience";
            this.textBoxScience.Size = new System.Drawing.Size(237, 20);
            this.textBoxScience.TabIndex = 3;
            // 
            // textBoxEnglish
            // 
            this.textBoxEnglish.Location = new System.Drawing.Point(86, 117);
            this.textBoxEnglish.Name = "textBoxEnglish";
            this.textBoxEnglish.Size = new System.Drawing.Size(237, 20);
            this.textBoxEnglish.TabIndex = 4;
            // 
            // textBoxBahasa
            // 
            this.textBoxBahasa.Location = new System.Drawing.Point(86, 143);
            this.textBoxBahasa.Name = "textBoxBahasa";
            this.textBoxBahasa.Size = new System.Drawing.Size(237, 20);
            this.textBoxBahasa.TabIndex = 5;
            // 
            // buttonSimpan
            // 
            this.buttonSimpan.Location = new System.Drawing.Point(86, 169);
            this.buttonSimpan.Name = "buttonSimpan";
            this.buttonSimpan.Size = new System.Drawing.Size(75, 23);
            this.buttonSimpan.TabIndex = 6;
            this.buttonSimpan.Text = "Simpan";
            this.buttonSimpan.UseVisualStyleBackColor = true;
            this.buttonSimpan.Click += new System.EventHandler(this.buttonSimpan_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 98);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Science";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 124);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "English";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 150);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Bahasa";
            // 
            // buttonUpdate
            // 
            this.buttonUpdate.Location = new System.Drawing.Point(167, 169);
            this.buttonUpdate.Name = "buttonUpdate";
            this.buttonUpdate.Size = new System.Drawing.Size(75, 23);
            this.buttonUpdate.TabIndex = 7;
            this.buttonUpdate.Text = "Update";
            this.buttonUpdate.UseVisualStyleBackColor = true;
            this.buttonUpdate.Click += new System.EventHandler(this.button1_Click);
            // 
            // buttonDelete
            // 
            this.buttonDelete.Location = new System.Drawing.Point(248, 169);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(75, 23);
            this.buttonDelete.TabIndex = 8;
            this.buttonDelete.Text = "Delete";
            this.buttonDelete.UseVisualStyleBackColor = true;
            this.buttonDelete.Click += new System.EventHandler(this.buttonUpdate_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(348, 213);
            this.Controls.Add(this.buttonDelete);
            this.Controls.Add(this.buttonUpdate);
            this.Controls.Add(this.buttonSimpan);
            this.Controls.Add(this.buttonLihat);
            this.Controls.Add(this.textBoxBahasa);
            this.Controls.Add(this.textBoxEnglish);
            this.Controls.Add(this.textBoxScience);
            this.Controls.Add(this.textBoxRoll);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxRoll;
        private System.Windows.Forms.Button buttonLihat;
        private System.Windows.Forms.TextBox textBoxScience;
        private System.Windows.Forms.TextBox textBoxEnglish;
        private System.Windows.Forms.TextBox textBoxBahasa;
        private System.Windows.Forms.Button buttonSimpan;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button buttonUpdate;
        private System.Windows.Forms.Button buttonDelete;
    }
}

