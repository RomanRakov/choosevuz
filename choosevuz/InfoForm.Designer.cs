namespace choosevuz
{
    partial class InfoForm
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
            this.ImageUniversity = new System.Windows.Forms.PictureBox();
            this.NameTextBox = new System.Windows.Forms.TextBox();
            this.CityTextBox = new System.Windows.Forms.TextBox();
            this.LabelName = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.ImageUniversity)).BeginInit();
            this.SuspendLayout();
            // 
            // ImageUniversity
            // 
            this.ImageUniversity.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ImageUniversity.Location = new System.Drawing.Point(37, 215);
            this.ImageUniversity.Name = "ImageUniversity";
            this.ImageUniversity.Size = new System.Drawing.Size(733, 242);
            this.ImageUniversity.TabIndex = 3;
            this.ImageUniversity.TabStop = false;
            // 
            // NameTextBox
            // 
            this.NameTextBox.Location = new System.Drawing.Point(342, 67);
            this.NameTextBox.Name = "NameTextBox";
            this.NameTextBox.Size = new System.Drawing.Size(428, 20);
            this.NameTextBox.TabIndex = 4;
            // 
            // CityTextBox
            // 
            this.CityTextBox.Location = new System.Drawing.Point(342, 154);
            this.CityTextBox.Name = "CityTextBox";
            this.CityTextBox.Size = new System.Drawing.Size(428, 20);
            this.CityTextBox.TabIndex = 5;
            // 
            // LabelName
            // 
            this.LabelName.AutoSize = true;
            this.LabelName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LabelName.Location = new System.Drawing.Point(117, 67);
            this.LabelName.Name = "LabelName";
            this.LabelName.Size = new System.Drawing.Size(192, 20);
            this.LabelName.TabIndex = 7;
            this.LabelName.Text = "Название университета";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(187, 154);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 20);
            this.label1.TabIndex = 8;
            this.label1.Text = "Город";
            // 
            // InfoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.LabelName);
            this.Controls.Add(this.CityTextBox);
            this.Controls.Add(this.NameTextBox);
            this.Controls.Add(this.ImageUniversity);
            this.Name = "InfoForm";
            this.Text = "InfoForm";
            ((System.ComponentModel.ISupportInitialize)(this.ImageUniversity)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.PictureBox ImageUniversity;
        public System.Windows.Forms.TextBox NameTextBox;
        public System.Windows.Forms.TextBox CityTextBox;
        private System.Windows.Forms.Label LabelName;
        private System.Windows.Forms.Label label1;
    }
}