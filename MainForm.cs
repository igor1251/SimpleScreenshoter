using SimpleScreenshoter.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimpleScreenshoter
{
    public partial class MainForm : Form
    {

        ToolWindow toolWindow;

        Screenshot screenshot;

        EditMode editMode = EditMode.NotSet;
        ShapeType shapeType = ShapeType.Line;
        Pen pen, cropPen, arrowPen;
        Font font;

        CustomShape shape;

        Color selectedColor = Color.Aquamarine;

        bool drawing = false;

        public MainForm()
        {
            InitializeComponent();

            toolWindow = new ToolWindow();
            toolWindow.pencilButton.Click += PencilButton_Clicked;
            toolWindow.arrowButton.Click += ArrowButton_Clicked;
            toolWindow.lineButton.Click += LineButton_Clicked;
            toolWindow.rectangleButton.Click += RectangleButton_Clicked;
            toolWindow.cropButton.Click += CropButton_Clicked;
            toolWindow.textButton.Click += TextButton_Clicked;
            toolWindow.colorSelectButton.Click += ColorSelectButton_Clicked;
            toolWindow.saveButton.Click += SaveButton_Clicked;
            toolWindow.exitButton.Click += ExitButton_Clicked;

            pen = new Pen(selectedColor, 2.0f);
            
            arrowPen = new Pen(selectedColor, 3.0f);
            arrowPen.EndCap = System.Drawing.Drawing2D.LineCap.ArrowAnchor;
            
            cropPen = new Pen(Color.Red, 0.5f);
            cropPen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            
            font = new Font("Arial", 15);
            shape = new CustomShape(new Point(), new Point(), pen, shapeType);

            this.Width = Screen.PrimaryScreen.Bounds.Width;
            this.Height = Screen.PrimaryScreen.Bounds.Height;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            screenshot = new Screenshot();
            screenshotPictureBox.Image = screenshot.image;
            toolWindow.Show();
        }


        private void ExitButton_Clicked(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void SaveButton_Clicked(object sender, EventArgs e)
        {
            screenshot.SaveScreenshot();
            screenshot.image.Dispose();
            screenshotPictureBox.Image.Dispose();
            Application.Exit();
        }

        private void ColorSelectButton_Clicked(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                this.selectedColor = colorDialog.Color;
            }
        }

        private void TextButton_Clicked(object sender, EventArgs e)
        {
            editMode = EditMode.Text;
        }

        private void CropButton_Clicked(object sender, EventArgs e)
        {
            editMode = EditMode.Crop;
            shapeType = ShapeType.Rectangle;

        }

        private void RectangleButton_Clicked(object sender, EventArgs e)
        {
            editMode = EditMode.Shape;
            shapeType = ShapeType.Rectangle;
        }

        private void LineButton_Clicked(object sender, EventArgs e)
        {
            editMode = EditMode.Shape;
            shapeType = ShapeType.Line;
        }

        private void ArrowButton_Clicked(object sender, EventArgs e)
        {
            editMode = EditMode.Shape;
            shapeType = ShapeType.Arrow;
        }

        private void PencilButton_Clicked(object sender, EventArgs e)
        {
            editMode = EditMode.Shape;
            shapeType = ShapeType.Curve;
        }




        private void screenshotPictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (editMode != EditMode.Text)
            {
                drawing = true;
                pen.Color = selectedColor;
                arrowPen.Color = selectedColor;
                switch (editMode)
                {
                    case EditMode.Shape:
                        switch (shapeType)
                        {
                            case ShapeType.Line:
                                shape = new CustomShape(new Point(e.X, e.Y), new Point(), pen, ShapeType.Line);                               
                                break;
                            case ShapeType.Rectangle:
                                shape = new CustomShape(new Point(e.X, e.Y), new Point(), pen, ShapeType.Rectangle);
                                break;
                            case ShapeType.Arrow:
                                shape = new CustomShape(new Point(e.X, e.Y), new Point(), arrowPen, ShapeType.Arrow);
                                break;
                        }

                        break;
                    case EditMode.Crop:
                        shape = new CustomShape(new Point(e.X, e.Y), new Point(e.X, e.Y), cropPen, ShapeType.Rectangle);
                        break;
                }
                screenshotPictureBox.Refresh();
            }
            else
            {
                if (!textBox.Visible)
                {
                    textBox.Font = font;
                    textBox.Location = new Point(e.X, e.Y);
                    textBox.Visible = true;
                    textBox.Focus();
                }
                else
                {
                    screenshot.InsertText(new CustomText(textBox.Location, textBox.Text, font, new SolidBrush(selectedColor)));
                    screenshotPictureBox.Image = screenshot.image;
                    textBox.ResetText();
                    editMode = EditMode.NotSet;
                    textBox.Visible = false;
                }
            }
        }

        private void screenshotPictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (drawing)
            {
                //if (e.X > shape.start.X) shape.end.X = e.X;
                //else
                //{
                //    shape.end.X = shape.start.X;
                //    shape.start.X = e.X;
                //}

                //if (e.Y > shape.start.Y) shape.end.Y = e.Y;
                //else
                //{
                //    shape.end.Y = shape.start.Y;
                //    shape.start.Y = e.Y;
                //}

                shape.end.X = e.X;
                shape.end.Y = e.Y;
                screenshotPictureBox.Refresh();
            }
        }

        private void screenshotPictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            if (editMode != EditMode.Text)
            {
                drawing = false;
                shape.end.X = e.X;
                shape.end.Y = e.Y;
                switch (editMode)
                {
                    case EditMode.Shape:
                        screenshot.DrawShape(shape);
                        break;
                    case EditMode.Crop:
                        screenshot = new Screenshot(screenshot.CropImage(new Rectangle(shape.start.X, shape.start.Y, shape.end.X - shape.start.X, shape.end.Y - shape.start.Y)));                       
                        break;
                }
                screenshotPictureBox.Image = screenshot.image;
                editMode = EditMode.NotSet;
            }
           
        }

        private void screenshotPictureBox_Paint(object sender, PaintEventArgs e)
        {
            switch (editMode)
            {
                case EditMode.Shape:

                    switch (shapeType)
                    {
                        case ShapeType.Line:
                            e.Graphics.DrawLine(pen, shape.start, shape.end);
                            break;
                        case ShapeType.Rectangle:
                            e.Graphics.DrawRectangle(pen, shape.start.X, shape.start.Y, shape.end.X - shape.start.X, shape.end.Y - shape.start.Y);
                            break;
                        case ShapeType.Arrow:
                            e.Graphics.DrawLine(arrowPen, shape.start, shape.end);
                            break;
                        case ShapeType.Curve:
                            
                            break;
                    }

                    break;
                case EditMode.Crop:
                    e.Graphics.DrawRectangle(cropPen, shape.start.X, shape.start.Y, shape.end.X - shape.start.X, shape.end.Y - shape.start.Y);
                    break;
            }
        }
    }
}
