﻿namespace Task4WinForms
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
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // PictureBox
            // 
            this.PictureBox.Location = new System.Drawing.Point(16, 117);
            this.PictureBox.Margin = new System.Windows.Forms.Padding(4);
            this.PictureBox.Name = "PictureBox";
            this.PictureBox.Size = new System.Drawing.Size(1567, 545);
            this.PictureBox.TabIndex = 0;
            this.PictureBox.TabStop = false;
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(8, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1599, 28);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // файлToolStripMenuItem
            // 
            this.файлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.открытьToolStripMenuItem});
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            this.файлToolStripMenuItem.Size = new System.Drawing.Size(57, 24);
            this.файлToolStripMenuItem.Text = "Файл";
            // 
            // открытьToolStripMenuItem
            // 
            this.открытьToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ModelToolStripMenuItem,
            this.TextureToolStripMenuItem});
            this.открытьToolStripMenuItem.Name = "открытьToolStripMenuItem";
            this.открытьToolStripMenuItem.Size = new System.Drawing.Size(142, 26);
            this.открытьToolStripMenuItem.Text = "Открыть";
            // 
            // ModelToolStripMenuItem
            // 
            this.ModelToolStripMenuItem.Name = "ModelToolStripMenuItem";
            this.ModelToolStripMenuItem.Size = new System.Drawing.Size(144, 26);
            this.ModelToolStripMenuItem.Text = "Модель";
            this.ModelToolStripMenuItem.Click += new System.EventHandler(this.ModelToolStripMenuItem_Click);
            // 
            // TextureToolStripMenuItem
            // 
            this.TextureToolStripMenuItem.Name = "TextureToolStripMenuItem";
            this.TextureToolStripMenuItem.Size = new System.Drawing.Size(144, 26);
            this.TextureToolStripMenuItem.Text = "Текстура";
            this.TextureToolStripMenuItem.Click += new System.EventHandler(this.TextureToolStripMenuItem_Click);
            // 
            // RenderBtn
            // 
            this.RenderBtn.Location = new System.Drawing.Point(16, 81);
            this.RenderBtn.Margin = new System.Windows.Forms.Padding(4);
            this.RenderBtn.Name = "RenderBtn";
            this.RenderBtn.Size = new System.Drawing.Size(100, 28);
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
            this.TransXtb.Location = new System.Drawing.Point(384, 32);
            this.TransXtb.Name = "TransXtb";
            this.TransXtb.Size = new System.Drawing.Size(100, 22);
            this.TransXtb.TabIndex = 3;
            this.TransXtb.Text = "0";
            // 
            // TransYtb
            // 
            this.TransYtb.Location = new System.Drawing.Point(384, 60);
            this.TransYtb.Name = "TransYtb";
            this.TransYtb.Size = new System.Drawing.Size(100, 22);
            this.TransYtb.TabIndex = 4;
            this.TransYtb.Text = "0";
            // 
            // TransZtb
            // 
            this.TransZtb.Location = new System.Drawing.Point(384, 88);
            this.TransZtb.Name = "TransZtb";
            this.TransZtb.Size = new System.Drawing.Size(100, 22);
            this.TransZtb.TabIndex = 5;
            this.TransZtb.Text = "0";
            // 
            // ScaleZtb
            // 
            this.ScaleZtb.Location = new System.Drawing.Point(651, 88);
            this.ScaleZtb.Name = "ScaleZtb";
            this.ScaleZtb.Size = new System.Drawing.Size(100, 22);
            this.ScaleZtb.TabIndex = 8;
            this.ScaleZtb.Text = "1";
            // 
            // ScaleYtb
            // 
            this.ScaleYtb.Location = new System.Drawing.Point(651, 60);
            this.ScaleYtb.Name = "ScaleYtb";
            this.ScaleYtb.Size = new System.Drawing.Size(100, 22);
            this.ScaleYtb.TabIndex = 7;
            this.ScaleYtb.Text = "1";
            // 
            // ScaleXtb
            // 
            this.ScaleXtb.Location = new System.Drawing.Point(651, 32);
            this.ScaleXtb.Name = "ScaleXtb";
            this.ScaleXtb.Size = new System.Drawing.Size(100, 22);
            this.ScaleXtb.TabIndex = 6;
            this.ScaleXtb.Text = "1";
            // 
            // RotZtb
            // 
            this.RotZtb.Location = new System.Drawing.Point(901, 88);
            this.RotZtb.Name = "RotZtb";
            this.RotZtb.Size = new System.Drawing.Size(100, 22);
            this.RotZtb.TabIndex = 11;
            this.RotZtb.Text = "0";
            // 
            // RotYtb
            // 
            this.RotYtb.Location = new System.Drawing.Point(901, 60);
            this.RotYtb.Name = "RotYtb";
            this.RotYtb.Size = new System.Drawing.Size(100, 22);
            this.RotYtb.TabIndex = 10;
            this.RotYtb.Text = "0";
            // 
            // RotXtb
            // 
            this.RotXtb.Location = new System.Drawing.Point(901, 32);
            this.RotXtb.Name = "RotXtb";
            this.RotXtb.Size = new System.Drawing.Size(100, 22);
            this.RotXtb.TabIndex = 9;
            this.RotXtb.Text = "0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(310, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 17);
            this.label1.TabIndex = 12;
            this.label1.Text = "Translate";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(577, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 17);
            this.label2.TabIndex = 13;
            this.label2.Text = "Scale";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(842, 63);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 17);
            this.label3.TabIndex = 14;
            this.label3.Text = "Rotate";
            // 
            // RedrawBtn
            // 
            this.RedrawBtn.Location = new System.Drawing.Point(124, 81);
            this.RedrawBtn.Margin = new System.Windows.Forms.Padding(4);
            this.RedrawBtn.Name = "RedrawBtn";
            this.RedrawBtn.Size = new System.Drawing.Size(100, 28);
            this.RedrawBtn.TabIndex = 15;
            this.RedrawBtn.Text = "ReRender";
            this.RedrawBtn.UseVisualStyleBackColor = true;
            this.RedrawBtn.Click += new System.EventHandler(this.RedrawBtn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1599, 677);
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
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
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
    }
}

