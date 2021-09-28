
namespace MyScreenshot
{
    partial class ToolWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ToolWindow));
            this.flowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.pencilButton = new System.Windows.Forms.Button();
            this.lineButton = new System.Windows.Forms.Button();
            this.cropButton = new System.Windows.Forms.Button();
            this.rectangleButton = new System.Windows.Forms.Button();
            this.arrowButton = new System.Windows.Forms.Button();
            this.textButton = new System.Windows.Forms.Button();
            this.colorSelectButton = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            this.flowLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanel
            // 
            this.flowLayoutPanel.Controls.Add(this.pencilButton);
            this.flowLayoutPanel.Controls.Add(this.lineButton);
            this.flowLayoutPanel.Controls.Add(this.cropButton);
            this.flowLayoutPanel.Controls.Add(this.rectangleButton);
            this.flowLayoutPanel.Controls.Add(this.arrowButton);
            this.flowLayoutPanel.Controls.Add(this.textButton);
            this.flowLayoutPanel.Controls.Add(this.colorSelectButton);
            this.flowLayoutPanel.Controls.Add(this.saveButton);
            this.flowLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel.Name = "flowLayoutPanel";
            this.flowLayoutPanel.Size = new System.Drawing.Size(93, 185);
            this.flowLayoutPanel.TabIndex = 0;
            // 
            // pencilButton
            // 
            this.pencilButton.Image = ((System.Drawing.Image)(resources.GetObject("pencilButton.Image")));
            this.pencilButton.Location = new System.Drawing.Point(3, 3);
            this.pencilButton.Name = "pencilButton";
            this.pencilButton.Size = new System.Drawing.Size(40, 40);
            this.pencilButton.TabIndex = 0;
            this.pencilButton.UseVisualStyleBackColor = true;
            // 
            // lineButton
            // 
            this.lineButton.Image = ((System.Drawing.Image)(resources.GetObject("lineButton.Image")));
            this.lineButton.Location = new System.Drawing.Point(49, 3);
            this.lineButton.Name = "lineButton";
            this.lineButton.Size = new System.Drawing.Size(40, 40);
            this.lineButton.TabIndex = 1;
            this.lineButton.UseVisualStyleBackColor = true;
            // 
            // cropButton
            // 
            this.cropButton.Image = ((System.Drawing.Image)(resources.GetObject("cropButton.Image")));
            this.cropButton.Location = new System.Drawing.Point(3, 49);
            this.cropButton.Name = "cropButton";
            this.cropButton.Size = new System.Drawing.Size(40, 40);
            this.cropButton.TabIndex = 2;
            this.cropButton.UseVisualStyleBackColor = true;
            // 
            // rectangleButton
            // 
            this.rectangleButton.Image = ((System.Drawing.Image)(resources.GetObject("rectangleButton.Image")));
            this.rectangleButton.Location = new System.Drawing.Point(49, 49);
            this.rectangleButton.Name = "rectangleButton";
            this.rectangleButton.Size = new System.Drawing.Size(40, 40);
            this.rectangleButton.TabIndex = 3;
            this.rectangleButton.UseVisualStyleBackColor = true;
            // 
            // arrowButton
            // 
            this.arrowButton.Image = ((System.Drawing.Image)(resources.GetObject("arrowButton.Image")));
            this.arrowButton.Location = new System.Drawing.Point(3, 95);
            this.arrowButton.Name = "arrowButton";
            this.arrowButton.Size = new System.Drawing.Size(40, 40);
            this.arrowButton.TabIndex = 4;
            this.arrowButton.UseVisualStyleBackColor = true;
            // 
            // textButton
            // 
            this.textButton.Image = ((System.Drawing.Image)(resources.GetObject("textButton.Image")));
            this.textButton.Location = new System.Drawing.Point(49, 95);
            this.textButton.Name = "textButton";
            this.textButton.Size = new System.Drawing.Size(40, 40);
            this.textButton.TabIndex = 5;
            this.textButton.UseVisualStyleBackColor = true;
            // 
            // colorSelectButton
            // 
            this.colorSelectButton.Image = ((System.Drawing.Image)(resources.GetObject("colorSelectButton.Image")));
            this.colorSelectButton.Location = new System.Drawing.Point(3, 141);
            this.colorSelectButton.Name = "colorSelectButton";
            this.colorSelectButton.Size = new System.Drawing.Size(40, 40);
            this.colorSelectButton.TabIndex = 6;
            this.colorSelectButton.UseVisualStyleBackColor = true;
            // 
            // saveButton
            // 
            this.saveButton.Image = ((System.Drawing.Image)(resources.GetObject("saveButton.Image")));
            this.saveButton.Location = new System.Drawing.Point(49, 141);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(40, 40);
            this.saveButton.TabIndex = 7;
            this.saveButton.UseVisualStyleBackColor = true;
            // 
            // ToolWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(93, 185);
            this.Controls.Add(this.flowLayoutPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "ToolWindow";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Инструменты";
            this.TopMost = true;
            this.flowLayoutPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel;
        internal System.Windows.Forms.Button pencilButton;
        internal System.Windows.Forms.Button lineButton;
        internal System.Windows.Forms.Button cropButton;
        internal System.Windows.Forms.Button rectangleButton;
        internal System.Windows.Forms.Button arrowButton;
        internal System.Windows.Forms.Button textButton;
        internal System.Windows.Forms.Button colorSelectButton;
        internal System.Windows.Forms.Button saveButton;
    }
}