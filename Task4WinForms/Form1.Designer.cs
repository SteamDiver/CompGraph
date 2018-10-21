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
            this.XRotate = new System.Windows.Forms.TrackBar();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox)).BeginInit();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.XRotate)).BeginInit();
            this.SuspendLayout();
            // 
            // PictureBox
            // 
            this.PictureBox.Location = new System.Drawing.Point(12, 95);
            this.PictureBox.Name = "PictureBox";
            this.PictureBox.Size = new System.Drawing.Size(785, 343);
            this.PictureBox.TabIndex = 0;
            this.PictureBox.TabStop = false;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
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
            // XRotate
            // 
            this.XRotate.LargeChange = 1;
            this.XRotate.Location = new System.Drawing.Point(315, 44);
            this.XRotate.Minimum = -10;
            this.XRotate.Name = "XRotate";
            this.XRotate.Size = new System.Drawing.Size(473, 45);
            this.XRotate.TabIndex = 3;
            this.XRotate.ValueChanged += new System.EventHandler(this.trackBar1_ValueChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.XRotate);
            this.Controls.Add(this.RenderBtn);
            this.Controls.Add(this.PictureBox);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.XRotate)).EndInit();
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
        private System.Windows.Forms.TrackBar XRotate;
    }
}

