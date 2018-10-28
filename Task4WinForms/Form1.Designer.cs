namespace Task4WinForms
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.PictureBox = new System.Windows.Forms.PictureBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.открытьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ModelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TextureToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.RenderBtn = new System.Windows.Forms.Button();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.TextureOpenFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.TransXtb = new System.Windows.Forms.TextBox();
            this.TransYtb = new System.Windows.Forms.TextBox();
            this.TransZtb = new System.Windows.Forms.TextBox();
            this.ScaleZtb = new System.Windows.Forms.TextBox();
            this.ScaleYtb = new System.Windows.Forms.TextBox();
            this.ScaleXtb = new System.Windows.Forms.TextBox();
            this.RotZtb = new System.Windows.Forms.TextBox();
            this.RotYtb = new System.Windows.Forms.TextBox();
            this.RotXtb = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.RedrawBtn = new System.Windows.Forms.Button();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox)).BeginInit();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.SuspendLayout();
            // 
            // PictureBox
            // 
            this.PictureBox.Location = new System.Drawing.Point(12, 95);
            this.PictureBox.Name = "PictureBox";
            this.PictureBox.Size = new System.Drawing.Size(1115, 713);
            this.PictureBox.TabIndex = 0;
            this.PictureBox.TabStop = false;
            this.PictureBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.PictureBox_MouseMove);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1139, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // файлToolStripMenuItem
            // 
            this.файлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.открытьToolStripMenuItem});
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            this.файлToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.файлToolStripMenuItem.Text = "Файл";
            // 
            // открытьToolStripMenuItem
            // 
            this.открытьToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ModelToolStripMenuItem,
            this.TextureToolStripMenuItem});
            this.открытьToolStripMenuItem.Name = "открытьToolStripMenuItem";
            this.открытьToolStripMenuItem.Size = new System.Drawing.Size(121, 22);
            this.открытьToolStripMenuItem.Text = "Открыть";
            // 
            // ModelToolStripMenuItem
            // 
            this.ModelToolStripMenuItem.Name = "ModelToolStripMenuItem";
            this.ModelToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
            this.ModelToolStripMenuItem.Text = "Модель";
            this.ModelToolStripMenuItem.Click += new System.EventHandler(this.ModelToolStripMenuItem_Click);
            // 
            // TextureToolStripMenuItem
            // 
            this.TextureToolStripMenuItem.Name = "TextureToolStripMenuItem";
            this.TextureToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
            this.TextureToolStripMenuItem.Text = "Текстура";
            this.TextureToolStripMenuItem.Click += new System.EventHandler(this.TextureToolStripMenuItem_Click);
            // 
            // RenderBtn
            // 
            this.RenderBtn.Location = new System.Drawing.Point(12, 66);
            this.RenderBtn.Name = "RenderBtn";
            this.RenderBtn.Size = new System.Drawing.Size(75, 23);
            this.RenderBtn.TabIndex = 2;
            this.RenderBtn.Text = "Render";
            this.RenderBtn.UseVisualStyleBackColor = true;
            this.RenderBtn.Click += new System.EventHandler(this.RenderBtn_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.Filter = "Object file | *.obj";
            // 
            // TextureOpenFileDialog
            // 
            this.TextureOpenFileDialog.Filter = "Image | *.jpg";
            // 
            // TransXtb
            // 
            this.TransXtb.Location = new System.Drawing.Point(288, 26);
            this.TransXtb.Margin = new System.Windows.Forms.Padding(2);
            this.TransXtb.Name = "TransXtb";
            this.TransXtb.Size = new System.Drawing.Size(76, 20);
            this.TransXtb.TabIndex = 3;
            this.TransXtb.Text = "0";
            // 
            // TransYtb
            // 
            this.TransYtb.Location = new System.Drawing.Point(288, 49);
            this.TransYtb.Margin = new System.Windows.Forms.Padding(2);
            this.TransYtb.Name = "TransYtb";
            this.TransYtb.Size = new System.Drawing.Size(76, 20);
            this.TransYtb.TabIndex = 4;
            this.TransYtb.Text = "0";
            // 
            // TransZtb
            // 
            this.TransZtb.Location = new System.Drawing.Point(288, 72);
            this.TransZtb.Margin = new System.Windows.Forms.Padding(2);
            this.TransZtb.Name = "TransZtb";
            this.TransZtb.Size = new System.Drawing.Size(76, 20);
            this.TransZtb.TabIndex = 5;
            this.TransZtb.Text = "0";
            // 
            // ScaleZtb
            // 
            this.ScaleZtb.Location = new System.Drawing.Point(488, 72);
            this.ScaleZtb.Margin = new System.Windows.Forms.Padding(2);
            this.ScaleZtb.Name = "ScaleZtb";
            this.ScaleZtb.Size = new System.Drawing.Size(76, 20);
            this.ScaleZtb.TabIndex = 8;
            this.ScaleZtb.Text = "1";
            // 
            // ScaleYtb
            // 
            this.ScaleYtb.Location = new System.Drawing.Point(488, 49);
            this.ScaleYtb.Margin = new System.Windows.Forms.Padding(2);
            this.ScaleYtb.Name = "ScaleYtb";
            this.ScaleYtb.Size = new System.Drawing.Size(76, 20);
            this.ScaleYtb.TabIndex = 7;
            this.ScaleYtb.Text = "1";
            // 
            // ScaleXtb
            // 
            this.ScaleXtb.Location = new System.Drawing.Point(488, 26);
            this.ScaleXtb.Margin = new System.Windows.Forms.Padding(2);
            this.ScaleXtb.Name = "ScaleXtb";
            this.ScaleXtb.Size = new System.Drawing.Size(76, 20);
            this.ScaleXtb.TabIndex = 6;
            this.ScaleXtb.Text = "1";
            // 
            // RotZtb
            // 
            this.RotZtb.Location = new System.Drawing.Point(676, 72);
            this.RotZtb.Margin = new System.Windows.Forms.Padding(2);
            this.RotZtb.Name = "RotZtb";
            this.RotZtb.Size = new System.Drawing.Size(76, 20);
            this.RotZtb.TabIndex = 11;
            this.RotZtb.Text = "0";
            // 
            // RotYtb
            // 
            this.RotYtb.Location = new System.Drawing.Point(676, 49);
            this.RotYtb.Margin = new System.Windows.Forms.Padding(2);
            this.RotYtb.Name = "RotYtb";
            this.RotYtb.Size = new System.Drawing.Size(76, 20);
            this.RotYtb.TabIndex = 10;
            this.RotYtb.Text = "0";
            // 
            // RotXtb
            // 
            this.RotXtb.Location = new System.Drawing.Point(676, 26);
            this.RotXtb.Margin = new System.Windows.Forms.Padding(2);
            this.RotXtb.Name = "RotXtb";
            this.RotXtb.Size = new System.Drawing.Size(76, 20);
            this.RotXtb.TabIndex = 9;
            this.RotXtb.Text = "0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(232, 49);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "Translate";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(433, 51);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "Scale";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(632, 51);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 13);
            this.label3.TabIndex = 14;
            this.label3.Text = "Rotate";
            // 
            // RedrawBtn
            // 
            this.RedrawBtn.Location = new System.Drawing.Point(93, 66);
            this.RedrawBtn.Name = "RedrawBtn";
            this.RedrawBtn.Size = new System.Drawing.Size(75, 23);
            this.RedrawBtn.TabIndex = 15;
            this.RedrawBtn.Text = "ReRender";
            this.RedrawBtn.UseVisualStyleBackColor = true;
            this.RedrawBtn.Click += new System.EventHandler(this.RedrawBtn_Click);
            // 
            // trackBar1
            // 
            this.trackBar1.Location = new System.Drawing.Point(757, 44);
            this.trackBar1.Maximum = 10000;
            this.trackBar1.Minimum = 1;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(370, 45);
            this.trackBar1.TabIndex = 16;
            this.trackBar1.Value = 4000;
            this.trackBar1.ValueChanged += new System.EventHandler(this.trackBar1_ValueChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1139, 819);
            this.Controls.Add(this.trackBar1);
            this.Controls.Add(this.RedrawBtn);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.RotZtb);
            this.Controls.Add(this.RotYtb);
            this.Controls.Add(this.RotXtb);
            this.Controls.Add(this.ScaleZtb);
            this.Controls.Add(this.ScaleYtb);
            this.Controls.Add(this.ScaleXtb);
            this.Controls.Add(this.TransZtb);
            this.Controls.Add(this.TransYtb);
            this.Controls.Add(this.TransXtb);
            this.Controls.Add(this.RenderBtn);
            this.Controls.Add(this.PictureBox);
            this.Controls.Add(this.menuStrip1);
            this.DoubleBuffered = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox PictureBox;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem открытьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ModelToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem TextureToolStripMenuItem;
        private System.Windows.Forms.Button RenderBtn;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.OpenFileDialog TextureOpenFileDialog;
        private System.Windows.Forms.TextBox TransXtb;
        private System.Windows.Forms.TextBox TransYtb;
        private System.Windows.Forms.TextBox TransZtb;
        private System.Windows.Forms.TextBox ScaleZtb;
        private System.Windows.Forms.TextBox ScaleYtb;
        private System.Windows.Forms.TextBox ScaleXtb;
        private System.Windows.Forms.TextBox RotZtb;
        private System.Windows.Forms.TextBox RotYtb;
        private System.Windows.Forms.TextBox RotXtb;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button RedrawBtn;
        private System.Windows.Forms.TrackBar trackBar1;
    }
}

