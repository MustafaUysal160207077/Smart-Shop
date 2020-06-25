namespace Face_Detection_Open_CV
{
    partial class Form1
    {
        /// <summary>
        ///Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///Kullanılan tüm kaynakları temizleyin.
        /// </summary>
        ///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer üretilen kod

        /// <summary>
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.cameraBox = new Emgu.CV.UI.ImageBox();
            this.button2 = new System.Windows.Forms.Button();
            this.textname = new System.Windows.Forms.TextBox();
            this.adi_label = new System.Windows.Forms.Label();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.Clearlist = new System.Windows.Forms.Button();
            this.kaydet_timer = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.gray_pictureBox = new System.Windows.Forms.PictureBox();
            this.permission = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.cameraBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gray_pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // cameraBox
            // 
            this.cameraBox.Location = new System.Drawing.Point(12, 12);
            this.cameraBox.Name = "cameraBox";
            this.cameraBox.Size = new System.Drawing.Size(545, 341);
            this.cameraBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.cameraBox.TabIndex = 2;
            this.cameraBox.TabStop = false;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(564, 63);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(166, 42);
            this.button2.TabIndex = 4;
            this.button2.Text = "Saveonly one Face";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // textname
            // 
            this.textname.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.textname.Location = new System.Drawing.Point(564, 28);
            this.textname.Name = "textname";
            this.textname.Size = new System.Drawing.Size(166, 29);
            this.textname.TabIndex = 5;
            // 
            // adi_label
            // 
            this.adi_label.AutoSize = true;
            this.adi_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.adi_label.Location = new System.Drawing.Point(561, 5);
            this.adi_label.Name = "adi_label";
            this.adi_label.Size = new System.Drawing.Size(105, 20);
            this.adi_label.TabIndex = 6;
            this.adi_label.Text = "Face Name:";
            // 
            // listBox1
            // 
            this.listBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 18;
            this.listBox1.Location = new System.Drawing.Point(564, 109);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(166, 166);
            this.listBox1.TabIndex = 7;
            this.listBox1.Click += new System.EventHandler(this.listBox1_Click);
            // 
            // Clearlist
            // 
            this.Clearlist.AutoSize = true;
            this.Clearlist.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Clearlist.Location = new System.Drawing.Point(622, 301);
            this.Clearlist.Name = "Clearlist";
            this.Clearlist.Size = new System.Drawing.Size(108, 52);
            this.Clearlist.TabIndex = 8;
            this.Clearlist.Text = "Delete Face";
            this.Clearlist.UseVisualStyleBackColor = true;
            this.Clearlist.Click += new System.EventHandler(this.Clearlist_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(561, 278);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(175, 20);
            this.label1.TabIndex = 10;
            this.label1.Text = "Trained Face Picture";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(12, 359);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(99, 21);
            this.comboBox1.TabIndex = 11;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(117, 360);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(244, 20);
            this.label2.TabIndex = 12;
            this.label2.Text = "Wellcome only for this person";
            // 
            // gray_pictureBox
            // 
            this.gray_pictureBox.Location = new System.Drawing.Point(565, 301);
            this.gray_pictureBox.Name = "gray_pictureBox";
            this.gray_pictureBox.Size = new System.Drawing.Size(52, 52);
            this.gray_pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.gray_pictureBox.TabIndex = 13;
            this.gray_pictureBox.TabStop = false;
            // 
            // permission
            // 
            this.permission.AutoSize = true;
            this.permission.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.permission.ForeColor = System.Drawing.Color.Red;
            this.permission.Location = new System.Drawing.Point(367, 360);
            this.permission.Name = "permission";
            this.permission.Size = new System.Drawing.Size(235, 20);
            this.permission.TabIndex = 14;
            this.permission.Text = "Face recognized succesfully";
            this.permission.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(748, 392);
            this.Controls.Add(this.permission);
            this.Controls.Add(this.gray_pictureBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Clearlist);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.adi_label);
            this.Controls.Add(this.textname);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.cameraBox);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Face Detection and Recognization";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.cameraBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gray_pictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Emgu.CV.UI.ImageBox cameraBox;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox textname;
        private System.Windows.Forms.Label adi_label;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button Clearlist;
        private System.Windows.Forms.Timer kaydet_timer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox gray_pictureBox;
        private System.Windows.Forms.Label permission;
    }
}

