namespace BTree
{
    partial class Form
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
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.textBox = new System.Windows.Forms.TextBox();
            this.buttonRemoveKey = new System.Windows.Forms.Button();
            this.buttonAddKey = new System.Windows.Forms.Button();
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.tableLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox
            // 
            this.pictureBox.BackColor = System.Drawing.Color.White;
            this.tableLayoutPanel.SetColumnSpan(this.pictureBox, 3);
            this.pictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox.Location = new System.Drawing.Point(3, 43);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(128, 128);
            this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox.TabIndex = 3;
            this.pictureBox.TabStop = false;
            // 
            // textBox
            // 
            this.textBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox.Font = new System.Drawing.Font("Lucida Console", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox.Location = new System.Drawing.Point(203, 3);
            this.textBox.Name = "textBox";
            this.textBox.Size = new System.Drawing.Size(594, 34);
            this.textBox.TabIndex = 0;
            // 
            // buttonRemoveKey
            // 
            this.buttonRemoveKey.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonRemoveKey.Location = new System.Drawing.Point(103, 3);
            this.buttonRemoveKey.Name = "buttonRemoveKey";
            this.buttonRemoveKey.Size = new System.Drawing.Size(94, 34);
            this.buttonRemoveKey.TabIndex = 2;
            this.buttonRemoveKey.Text = "Remove Key";
            this.buttonRemoveKey.UseVisualStyleBackColor = true;
            this.buttonRemoveKey.Click += new System.EventHandler(this.buttonRemoveKey_Click);
            // 
            // buttonAddKey
            // 
            this.buttonAddKey.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonAddKey.Location = new System.Drawing.Point(3, 3);
            this.buttonAddKey.Name = "buttonAddKey";
            this.buttonAddKey.Size = new System.Drawing.Size(94, 34);
            this.buttonAddKey.TabIndex = 1;
            this.buttonAddKey.Text = "Add Key";
            this.buttonAddKey.UseVisualStyleBackColor = true;
            this.buttonAddKey.Click += new System.EventHandler(this.buttonAddKey_Click);
            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.ColumnCount = 3;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel.Controls.Add(this.buttonAddKey, 0, 0);
            this.tableLayoutPanel.Controls.Add(this.pictureBox, 0, 1);
            this.tableLayoutPanel.Controls.Add(this.buttonRemoveKey, 1, 0);
            this.tableLayoutPanel.Controls.Add(this.textBox, 2, 0);
            this.tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.RowCount = 2;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel.Size = new System.Drawing.Size(510, 495);
            this.tableLayoutPanel.TabIndex = 4;
            // 
            // Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(510, 495);
            this.Controls.Add(this.tableLayoutPanel);
            this.Name = "Form";
            this.Text = "B-Tree Demo";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.tableLayoutPanel.ResumeLayout(false);
            this.tableLayoutPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
        private System.Windows.Forms.Button buttonAddKey;
        private System.Windows.Forms.Button buttonRemoveKey;
        private System.Windows.Forms.TextBox textBox;
    }
}

