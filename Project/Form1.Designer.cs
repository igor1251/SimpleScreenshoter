
namespace MyLightShot
{
    partial class MainForm
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
            this.screenshotPictureBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.screenshotPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // screenshotPictureBox
            // 
            this.screenshotPictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.screenshotPictureBox.Location = new System.Drawing.Point(0, 0);
            this.screenshotPictureBox.Name = "screenshotPictureBox";
            this.screenshotPictureBox.Size = new System.Drawing.Size(800, 450);
            this.screenshotPictureBox.TabIndex = 0;
            this.screenshotPictureBox.TabStop = false;
            this.screenshotPictureBox.Paint += new System.Windows.Forms.PaintEventHandler(this.screenshotPictureBox_Paint);
            this.screenshotPictureBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.screenshotPictureBox_MouseDown);
            this.screenshotPictureBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.screenshotPictureBox_MouseMove);
            this.screenshotPictureBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.screenshotPictureBox_MouseUp);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.screenshotPictureBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MainForm";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.screenshotPictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox screenshotPictureBox;
    }
}

