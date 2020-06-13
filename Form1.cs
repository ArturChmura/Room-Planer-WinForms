using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;
using System.Threading;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using System.IO;
using System.Runtime.InteropServices;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.Resources;




namespace WinFormsLab1
{



    public partial class Form1 : Form
    {
        MyObjectList images = new MyObjectList();

        Button selectedButton;
        Segment selectedImage;
        int selectedImageIndex;

        (Point start, Point end) lastWallPiece;
        bool isWallPainting;

        Point mousePositionWhenClicked;
        Point imagePositionWhenClicked;

        // ========================================  CRATING OBJECTS  ====================================
        public Form1()
        {
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");
            InitializeComponent();
            LoadStartImages();
            CreatNewBluePrint();
        }
      
        void CreatNewBluePrint()
        {
            ClearPanel();
            NewPanel(panel.Size);
        }
        void NewPanel(Size pictureBoxSize)
        {
            panel.Size = splitContainer.Panel1.ClientSize;
            pictureBox.Size = pictureBoxSize;
            pictureBox.BackColor = Color.White;
            panel.Refresh();
            pictureBox.MouseWheel += disableMouseWheel;
            pictureBox.MouseWheel += RotateSelectedObject;
        }
        void ClearPanel()
        {
            createdListView.Items.Clear();
            images.List.Clear();
            isWallPainting = false;
            selectedImage = null;
        }

        public void FillCreatedListView()
        {
            createdListView.Items.Clear();
            foreach (Segment item in images.List)
            {
                ListViewItem listViewItem = new ListViewItem(item.Name);
                listViewItem.SubItems.Add(item.Location.X.ToString() + "x" + item.Location.Y.ToString());
                createdListView.Items.Add(listViewItem);
            }
        }

        private void LoadStartImages()
        {
            coffee_table.BackgroundImage = Resource1.coffee_table;
            double_bed.BackgroundImage = Resource1.double_bed;
            sofa.BackgroundImage = Resource1.sofa;
            wall.BackgroundImage = Resource1.wall;
            table.BackgroundImage = Resource1.table;
        }

        // ========================================  MOUSE EVENTS  ====================================
        void disableMouseWheel(object sender, MouseEventArgs e)
        {
            ((HandledMouseEventArgs)e).Handled = true;
        }

        private void button_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            if (selectedButton == button)
            {
                UncheckButton();
            }
            else
            {
                CheckButton(button);
            }
            DeselectImage();
            pictureBox.Refresh();
        }

        private void pictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                PictureBox pictureBox = sender as PictureBox;
                Point point = e.Location;
                if (selectedButton != null)
                {
                    if (selectedButton.Name == "wall")
                    {
                        if (isWallPainting)
                        {
                            Wall myWall = images.List[images.List.Count - 1] as Wall;
                            myWall.Path.AddLine(lastWallPiece.start, lastWallPiece.end);
                            lastWallPiece.start = e.Location;
                        }
                        else
                        {
                            StartPaintingWall(e.Location);
                        }
                    }
                    else
                    {
                        point.X -= selectedButton.BackgroundImage.Width / 2;
                        point.Y -= selectedButton.BackgroundImage.Height / 2;

                        Furniture image = new Furniture(selectedButton.BackgroundImage, selectedButton.Name, point);


                        images.List.Add(image);

                        ResourceManager rm = new ResourceManager(typeof(Form1));
                        ListViewItem listViewItem = new ListViewItem(image.Name);
                        listViewItem.SubItems.Add(point.X.ToString() + "x" + point.Y.ToString());

                        createdListView.Items.Add(listViewItem);


                        UncheckButton();
                    }

                }
                else
                {
                    if(selectedImage != null)
                    {
                        createdListView.Items[images.List.IndexOf(selectedImage)].Selected = false;
                    }
                    SelectImage(GetImageFromPosition(point));
                    if (selectedImage != null)
                    {
                        ActivateDragImage();
                        SelectOnList();
                    }
                }
            }
            else if (e.Button == MouseButtons.Right)
            {
                if (isWallPainting)
                {
                    StopPaintingWall();
                    UncheckButton();

                }
            }

            pictureBox.Refresh();
        }

        private void SelectOnList()
        {
            int index = images.List.IndexOf(selectedImage);
            createdListView.Items[index].Selected = true;
            foreach (ListViewItem item in createdListView.SelectedItems)
            {
                Console.WriteLine(item.SubItems[0].Text);
            }
            createdListView.Select();

        }

        private void SelectImage(Segment myObject)
        {
            DeselectImage();
            selectedImage = myObject;
            if (selectedImage != null)
            {
                selectedImageIndex = images.List.IndexOf(selectedImage);
                myObject.Alpha = 120;

            }

        }

        private void DeselectImage()
        {
            if (selectedImage != null)
            {
                selectedImage.Alpha = 255;
                
            }
            StopPaintingWall();
        }

        private void pictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            pictureBox.MouseMove -= DragImage;
        }

        private Segment GetImageFromPosition(Point point)
        {
            if (images.List.Count == 0) return null;
            Segment closest = null;
            double minDistance = double.MaxValue;
            foreach (Segment myObject in images.List)
            {
                (bool contain, double distance) = myObject.ContainPoint(point);
                if (contain && distance < minDistance)
                {
                    minDistance = distance;
                    closest = myObject;
                    if(minDistance == 0)
                    {
                        break;
                    }
                }
            }
            return closest;
        }

        private void ActivateDragImage()
        {
            mousePositionWhenClicked = Cursor.Position;
            imagePositionWhenClicked = selectedImage.Location;
            pictureBox.MouseMove += DragImage;

        }

        private void DragImage(object sender, MouseEventArgs e)
        {
            selectedImage.Location = imagePositionWhenClicked.Add(Cursor.Position.Subtract(mousePositionWhenClicked));
            createdListView.Items[selectedImageIndex].SubItems[1].Text =
                selectedImage.Location.X.ToString() + "x" + selectedImage.Location.Y.ToString();
            pictureBox.Refresh();

            createdListView.Select();
        }

        private void RotateSelectedObject(object sender, MouseEventArgs e)
        {
            if (selectedImage != null)
            {
                selectedImage.Rotate(e.Delta / 20);
                pictureBox.Refresh();
            }

        }

        private void CheckButton(Button button)
        {
            if (selectedButton != null)
            {
                UncheckButton();
            }
            button.BackColor = Color.Yellow;
            selectedButton = button;
        }

        private void UncheckButton()
        {
            if (selectedButton == null) return;
            selectedButton.BackColor = SystemColors.Control;
            selectedButton = null;
            
        }

        private void StopPaintingWall()
        {
            if(isWallPainting)
            {
                pictureBox.MouseMove -= DrawNewWall;
                isWallPainting = false;
                int index = images.List.Count - 1;
                Wall wall = images.List[index] as Wall;
                if (wall.Path.PointCount == 0)
                {
                    images.List.RemoveAt(index);
                    createdListView.Items.RemoveAt(index);
                }
            }
           
        }
        // ========================================  PAINTING  ====================================
        private void StartPaintingWall(Point location)
        {
            isWallPainting = true;
            pictureBox.MouseMove += DrawNewWall;

            Wall myWall = new Wall(new GraphicsPath(), location);
            images.List.Add(myWall);

            lastWallPiece.start = location;
            lastWallPiece.end = location;

            ListViewItem listViewItem = new ListViewItem(myWall.Name);
            listViewItem.SubItems.Add(location.X.ToString() + "x" + location.Y.ToString());
            createdListView.Items.Add(listViewItem);
        }

        private void DrawNewWall(object sender, MouseEventArgs e)
        {
            lastWallPiece.end = e.Location;
            pictureBox.Refresh();
            this.Text = lastWallPiece.end.ToString();
        }

        private void pictureBox_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            PictureBox pictureBox = sender as PictureBox;
            Graphics g = e.Graphics;
            g.InterpolationMode = InterpolationMode.HighQualityBilinear;
            g.CompositingQuality = CompositingQuality.HighQuality;
            g.PixelOffsetMode = PixelOffsetMode.HighQuality;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            foreach (Segment myObject in images.List)
            {
                myObject.Paint(g);
            }
            Pen pen = new Pen(Color.Black, 10);
            if (isWallPainting)
            {
                g.FillEllipse(new SolidBrush(Color.Black), new Rectangle(lastWallPiece.start.Subtract(5, 5), new Size(10, 10)));
                g.DrawLine(pen, lastWallPiece.start, lastWallPiece.end);
            }

        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            panel.Size = splitContainer.Panel1.ClientSize;
            if (pictureBox != null)
            {
                if (pictureBox.Size.Width < splitContainer.Panel1.ClientSize.Width)
                {
                    pictureBox.Size = new Size(splitContainer.Panel1.ClientSize.Width, pictureBox.Size.Height);
                }
                if (pictureBox.Size.Height < splitContainer.Panel1.ClientSize.Height)
                {
                    pictureBox.Size = new Size(pictureBox.Size.Width, splitContainer.Panel1.ClientSize.Height);
                }
            }
        }


        // ========================================  MENU  ====================================
        private void newBluprintToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreatNewBluePrint();
        }
        private void englishToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");
            Reload();
        }

        private void polishToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("pl");
            Reload();
        }

        private void Reload()
        {
            images.PictureBoxSize = pictureBox.Size;
            Size windowSize = this.Size;
            Size splitContainerSize = splitContainer.Size;
            this.Controls.Clear();
            this.InitializeComponent();
            this.Size = windowSize;
            splitContainer.Size = splitContainerSize;
            LoadStartImages();
            NewPanel(images.PictureBoxSize);
            FillCreatedListView();
            this.pictureBox.Refresh();
        }

        private void saveBlueprintToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog fileDialog = new SaveFileDialog();
            fileDialog.Filter = "BluePrint(*.bp)|*.bp";
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                ResourceManager rm = new ResourceManager(typeof(Form1));
                if (Serialize(fileDialog.FileName))
                {
                    MessageBox.Show(rm.GetString("BluePrint saved"));
                }
                else
                {
                    MessageBox.Show(rm.GetString("Cannot save BluePrint"));
                }
            }

        }

        private void openBlueprintToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Multiselect = false;
            fileDialog.Filter = "BluePrint(*.bp)|*.bp";
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                ResourceManager rm = new ResourceManager(typeof(Form1));
                if (Deserialize(fileDialog.FileName))
                {
                    MessageBox.Show( rm.GetString( "BluePrint opened"));
                }
                else
                {
                    MessageBox.Show(rm.GetString("Connot open BluePrint"));
                }

            }
        }

        bool Serialize(string filePath)
        {

            FileStream fs = new FileStream(filePath, FileMode.Create);
            foreach (Segment myObject in images.List)
            {
                myObject.PrepareToSerialization();
            }
            BinaryFormatter formatter = new BinaryFormatter();
            try
            {
                formatter.Serialize(fs, images);
            }
            catch (SerializationException e)
            {
                Console.WriteLine("Failed to serialize. Reason: " + e.Message);
                return false;
            }
            finally
            {
                fs.Close();
            }
            return true;
        }

        bool Deserialize(string filePath)
        {
            CreatNewBluePrint();

            FileStream fs = new FileStream(filePath, FileMode.Open);
            try
            {
                BinaryFormatter formatter = new BinaryFormatter();
                images = (MyObjectList)formatter.Deserialize(fs);
            }
            catch (SerializationException e)
            {
                Console.WriteLine("Failed to deserialize. Reason: " + e.Message);
                return false;
            }
            finally
            {
                fs.Close();
            }

            foreach (Segment item in images.List)
            {
                item.AfterSerialization();
            }
            FillCreatedListView();
            pictureBox.Refresh();
            return true;

        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                pictureBox.MouseMove -= DragImage;
                Console.WriteLine(e.KeyCode.ToString());
                if (selectedImage != null)
                {
                    createdListView.Items.RemoveAt(images.List.IndexOf(selectedImage));
                    images.List.Remove(selectedImage);
                    selectedImage = null;
                    pictureBox.Refresh();
                }
            }
        }

        private void konsolaDebugToolStripMenuItem_Click(object sender, EventArgs e)
        {

            konsolaDebugToolStripMenuItem.Checked = !konsolaDebugToolStripMenuItem.Checked;
            if (konsolaDebugToolStripMenuItem.Checked)
            {
                NativeMethods.AllocConsole();
            }
            else
            {
                NativeMethods.FreeConsole();
            }

        }

        private void createdListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListView listView = sender as ListView;
            foreach (ListViewItem item in listView.SelectedItems)
            {
                SelectImage(images.List[item.Index]);
            }
            pictureBox.Refresh();

        }

      
    }

    // ========================================  MY CLASES ====================================

    public interface Segment
    {
        string Name { get; }
        int Rotation { get; set; }
        Point Location { get; set; }
        int Alpha { get; set; }
        (bool Contain, double distanceFormMiddle) ContainPoint(Point point);
        void Paint(Graphics g);
        Point GetMiddle();
        void Rotate(int angle);
        void PrepareToSerialization();
        void AfterSerialization();
    }

    [Serializable]
    public class Furniture : Segment
    {
        public string Name
        {
            get
            {
                ResourceManager rm = new ResourceManager(typeof(Form1));
                string ret = rm.GetString(ImageKey);
                return ret;
            }
        }
        private int alphaField;
        public int Alpha
        {
            get { return alphaField; }
            set
            {
                alphaField = value;

                float[][] colorMatrixElements = {
                       new float[] {1,  0,  0,  0, 0},        // red scaling factor of 2
                       new float[] {0,  1,  0,  0, 0},        // green scaling factor of 1
                       new float[] {0,  0,  1,  0, 0},        // blue scaling factor of 1
                       new float[] {0,  0,  0, (float)alphaField / 255, 0},        // alpha scaling factor of 1
                       new float[] {0,0,0, 0, 1}};    // three translations of 0.2
                ColorMatrix colorMatrix = new ColorMatrix(colorMatrixElements);
                Attributes.SetColorMatrix(colorMatrix);
            }
        }
        [NonSerialized]
        public Image image;
        public string ImageKey { get; set; }

        [NonSerialized]
        protected ImageAttributes attributesField;
        protected ImageAttributes Attributes { get { return attributesField; } set { attributesField = value; } }
        public int Rotation { get; set; }
        public Point Location { get; set; }


        public void SetImage(Image image)
        {
            Attributes = new ImageAttributes();
            this.image = image;
        }
        public Furniture(Image image, string imageKey, Point location)
        {
            this.image = image;
            this.ImageKey = imageKey;
            this.Location = location;
            this.Rotation = 0;
            Attributes = new ImageAttributes();
            Alpha = 255;
        }

        public (bool Contain, double distanceFormMiddle) ContainPoint(Point point)
        {
            Rectangle rectangle = new Rectangle(this.Location.X, this.Location.Y, image.Width, image.Height);
            if (rectangle.Contains(point))
            {
                return (true, GetMiddle().DistanceFrom(point));
            }
            return (false, -1);
        }

        public void Rotate(int angle)
        {
            Rotation += angle;
        }
        public void Paint(Graphics g)
        {
            g.TranslateTransform(Location.X + image.Width / 2, Location.Y + image.Height / 2);
            g.RotateTransform(Rotation);
            Rectangle rectangle = new Rectangle(-image.Width / 2, -image.Height / 2, image.Width, image.Height);
            g.DrawImage(image, rectangle, 0, 0,
                    image.Width,
                    image.Height,
                    GraphicsUnit.Pixel,
                    Attributes);
            g.RotateTransform(-Rotation);
            g.TranslateTransform(-(Location.X + image.Width / 2), -(Location.Y + image.Height / 2));
        }

        public Point GetMiddle()
        {
            return new Point(Location.X + image.Width / 2, Location.Y + image.Height / 2);
        }

        public void PrepareToSerialization()
        {

        }

        public void AfterSerialization()
        {
            switch (this.ImageKey)
            {
                case "coffee_table":
                    SetImage(Resource1.coffee_table);
                    break;
                case "double_bed":
                    SetImage(Resource1.double_bed);
                    break;
                case "sofa":
                    SetImage(Resource1.sofa);
                    break;
                case "table":
                    SetImage(Resource1.table);
                    break;
                default:
                    break;
            }

        }
    }


    [Serializable]
    public class Wall : Segment
    {
        public string Name
        {
            get
            {
                ResourceManager rm = new ResourceManager(typeof(Form1));
                string ret = rm.GetString("wall");
                return ret;
            }
        }
        private Point locationField;
        public Point Location
        {
            get { return locationField; }
            set
            {
                Matrix matrix = new Matrix();
                matrix.Translate(value.X - locationField.X, value.Y - locationField.Y);
                Path.Transform(matrix);
                locationField = value;
            }
        }
        private PointF[] points;
        [NonSerialized]
        private GraphicsPath pathField;
        public GraphicsPath Path { get { return pathField; } set { pathField = value; } }
        public int Rotation { get; set; }
        public int Alpha { get; set; }


        public Wall(GraphicsPath graphicsPath, Point location)
        {
            this.Path = graphicsPath;
            this.Location = location;
            this.Rotation = 0;
            this.Alpha = 255;

        }

        public (bool Contain, double distanceFormMiddle) ContainPoint(Point point)
        {
            PointF[] points = this.Path.PathPoints;

            if (points.Length == 0) return (false, -1);
            for (int i = 1; i < points.Length; i++)
            {
                double distance = Distance(point, points[i - 1], points[i]);
                if (distance <= 5.0)
                {
                    return (true, distance);
                }
            }


            return (false, -1);
        }
        private static double Distance(Point point, PointF P1, PointF P2)
        {
            return Math.Abs((P2.Y - P1.Y) * point.X - (P2.X - P1.X) * point.Y + P2.X * P1.Y - P2.Y * P1.X) /
                Math.Sqrt(Math.Pow(P2.Y - P1.Y, 2) + Math.Pow(P2.X - P1.X, 2));
        }

        public void Paint(Graphics g)
        {

            Pen pen = new Pen(Color.FromArgb(Alpha, 0, 0, 0), 10);
            g.DrawPath(pen, this.Path);
        }

        public void Rotate(int angle)
        {
            Rotation += angle;
            Matrix translateMatrix = new Matrix();
            translateMatrix.RotateAt(angle, Location);
            this.Path.Transform(translateMatrix);
        }

        public Point GetMiddle()
        {
            return Location;
        }

        public void PrepareToSerialization()
        {
            this.points = Path.PathPoints;
        }

        public void AfterSerialization()
        {
            this.Path = new GraphicsPath();
            this.Path.AddLines(points);
        }


    }

    [Serializable]
    public class MyObjectList
    {
        public List<Segment> List { get; set; }
        public Size PictureBoxSize { get; set; }
        public MyObjectList()
        {
            this.List = new List<Segment>();
        }


    }

    public static class ExtensionMethods
    {
        public static Point Subtract(this Point a, Point b)
        {
            return new Point(a.X - b.X, a.Y - b.Y);
        }
        public static Point Subtract(this Point a, int dx, int dy)
        {
            return new Point(a.X - dx, a.Y - dy);
        }
        public static Point Add(this Point a, Point b)
        {
            return new Point(a.X + b.X, a.Y + b.Y);
        }
        public static Point Add(this Point a, int dx, int dy)
        {
            return new Point(a.X + dx, a.Y + dy);
        }

        public static double DistanceFrom(this Point a, Point b)
        {
            return Math.Sqrt(Math.Pow(a.X - b.X, 2) + Math.Pow(a.Y - b.Y, 2));
        }
        public static double DistanceFrom(this Point a, int x, int y)
        {
            return Math.Sqrt(Math.Pow(a.X - x, 2) + Math.Pow(a.Y - y, 2));
        }
    }
    internal static class NativeMethods
    {
        [DllImport("kernel32.dll", SetLastError = true)]
        internal static extern int AllocConsole();

        [DllImport("kernel32.dll", SetLastError = true)]
        internal static extern int FreeConsole();
    }
}
