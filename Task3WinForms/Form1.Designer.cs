namespace Task3WinForms
{
    sealed partial class Form1
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
            this.NewLineChB = new System.Windows.Forms.CheckBox();
            this.Submit = new System.Windows.Forms.Button();
            this.Field = new System.Windows.Forms.PictureBox();
            this.Clear = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.Field)).BeginInit();
            this.SuspendLayout();
            // 
            // NewLineChB
            // 
            this.NewLineChB.AutoSize = true;
            this.NewLineChB.Location = new System.Drawing.Point(12, 12);
            this.NewLineChB.Name = "NewLineChB";
            this.NewLineChB.Size = new System.Drawing.Size(83, 21);
            this.NewLineChB.TabIndex = 0;
            this.NewLineChB.Text = "New line";
            this.NewLineChB.UseVisualStyleBackColor = true;
            this.NewLineChB.CheckedChanged += new System.EventHandler(this.NewLineChB_CheckedChanged);
            // 
            // Submit
            // 
            this.Submit.Location = new System.Drawing.Point(101, 12);
            this.Submit.Name = "Submit";
            this.Submit.Size = new System.Drawing.Size(75, 57);
            this.Submit.TabIndex = 1;
            this.Submit.Text = "Do it!";
            this.Submit.UseVisualStyleBackColor = true;
            this.Submit.Click += new System.EventHandler(this.Submit_Click);
            // 
            // Field
            // 
            this.Field.Location = new System.Drawing.Point(12, 75);
            this.Field.Name = "Field";
            this.Field.Size = new System.Drawing.Size(1043, 467);
            this.Field.TabIndex = 2;
            this.Field.TabStop = false;
            this.Field.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Field_MouseDown);
            this.Field.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Field_MouseMove);
            this.Field.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Field_MouseUp);
            // 
            // Clear
            // 
            this.Clear.Location = new System.Drawing.Point(182, 10);
            this.Clear.Name = "Clear";
            this.Clear.Size = new System.Drawing.Size(75, 59);
            this.Clear.TabIndex = 3;
            this.Clear.Text = "Clear";
            this.Clear.UseVisualStyleBackColor = true;
            this.Clear.Click += new System.EventHandler(this.Clear_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Controls.Add(this.Clear);
            this.Controls.Add(this.Field);
            this.Controls.Add(this.Submit);
            this.Controls.Add(this.NewLineChB);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.Field)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox NewLineChB;
        private System.Windows.Forms.Button Submit;
        private System.Windows.Forms.PictureBox Field;
        private System.Windows.Forms.Button Clear;
    }
}

