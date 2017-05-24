using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using QuadroSoft.Enose.DataModel;
using QuadroSoft.Enose.Statistics;

namespace Plotters
{
    public partial class ExtendedPlotterBox : UserControl
    {
        public Color[] Colors = new Color[] {Color.Red, Color.Green, Color.Blue, Color.Yellow, Color.Lime, Color.Violet, Color.Tomato,
                                                    Color.Wheat, Color.SkyBlue, Color.SeaGreen};

        private double zoom = 1.3d;

        private double[][] data = null;
        private Bitmap bitmap;
        private Graphics graphics2;
        private Graphics graphics;
        private int alpha = 140;
        private Brush brush = new Pen(Color.FromArgb(140, Color.FromArgb(Color.Cyan.R + 100, Color.Cyan.G - 120, 255))).Brush;

        private Brush backGround = Brushes.White;
        private Pen pen = Pens.Gray;
        private double maximum = 10;
        private double minimum = 0;
        private int gap = 60;

        public bool gradesCount = false;
        public double gradeVal = 10d;
        private int grades = 4;

        private string[] notes = null;
        private Font font = new Font("Courier", 8);
        private Brush fontColor = Brushes.Black;
        private double textDist = 1.1d;
        private double xFontCorrection = 5;

        private int markerStart = 0;
        private int markerGap = 10;

        private bool drawThin = true;
        private bool drawBold = true;

        /// <summary>
        /// Рисовать тонкие отсчёты
        /// </summary>
        public bool DrawThinLines
        {
            set { drawThin = value; Refresh(); }
            get { return drawThin; }
        }

        /// <summary>
        /// Рисовать жирные отсчёты
        /// </summary>
        public bool DrawBoldLines
        {
            set { drawBold = value; Refresh(); }
            get { return drawBold; }
        }

        public int MarkerStart
        {
            set { markerStart = value; }
            get { return markerStart; }
        }

        public int MarkerGap
        {
            set { markerGap = value; }
            get { return markerGap; }
        }

        public double XFontCorrection
        {
            set { xFontCorrection = value; }
            get { return xFontCorrection; }
        }

        public double TextDist
        {
            set { textDist = value; }
            get { return textDist; }
        }

        public override Font Font
        {
            set { font = value; }
            get { return font; }
        }

        public Pen Pen
        {
            set { pen = value; }
            get { return pen; }
        }

        public Brush FontColor
        {
            set { fontColor = value; }
            get { return fontColor; }
        }

        public Brush Brush
        {
            set { brush = value; Pen p = new Pen(brush); Color b = p.Color; brush = new Pen(Color.FromArgb(alpha, b)).Brush; }
            get { return brush; }
        }

        public Brush BackGround
        {
            set { backGround = value; }
            get { return backGround; }
        }

        public double Maximum
        {
            set { maximum = value; }
            get { return maximum; }
        }

        public double Minimum
        {
            set { minimum = value; }
            get { return minimum; }
        }

        public int Gap
        {
            set { gap = value; }
            get { return gap; }
        }

        public int Grades
        {
            set { grades = value; }
            get { return grades; }
        }

        public string[] Notes
        {
            set { notes = value; }
            get
            {
                return notes;
            }
        }

        public double[][] Data
        {
            set { data = value; }
            get { return data; }
        }

        public void Empty()
        {
            int h = Height;
            int w = Width;
            GC.Collect();

            graphics2.FillRectangle(BackGround, new Rectangle(0, 0, w, h));
        }

        private void WheelHandler(object sender, MouseEventArgs args)
        {
            if (args.Delta < 0)
            {
                Maximum *= zoom;
                Refresh();
            }
            else
                if (args.Delta > 0)
                {
                    Maximum /= zoom;
                    Refresh();
                }

        }

        public ExtendedPlotterBox()
        {
            for (int i = 0; i < Colors.Length; i++)
                Colors[i] = Color.FromArgb(250 - i * 25, 100, 100);

            InitializeComponent();

            this.MouseWheel += new MouseEventHandler(WheelHandler);
            graphics = Canvas.CreateGraphics();
            graphics2 = Graphics.FromImage(bitmap = new Bitmap(Width, Height));
            Empty();
        }

        private Point getCoord(double alpha, double value)
        {
            Point p = new Point();
            double ratio = (value - minimum) / (0d + maximum - minimum) / 2;
            int s = Math.Min(this.Width, this.Height);
            p.X = Convert.ToInt32(Math.Cos(alpha) * (s - 2 * gap) * ratio);
            p.Y = Convert.ToInt32(Math.Sin(alpha) * (s - 2 * gap) * ratio);
            return p;
        }

        private double getValue(int x, int y, out double alpha)
        {
            double _x, _y;

            _x = x - Width / 2;
            _y = Height / 2 - y;
            int s = Math.Min(this.Width, this.Height);
            double k = (this.Width - 2 * gap) / (s - 2 * gap);
            _x = _x / k;
            if (Math.Abs(_x) <= 1)
            {
                alpha = (_y > 0) ? 3 * Math.PI / 2d : Math.PI / 2d;
            }
            else
            {
                alpha = Math.Atan2(_y, _x);
            }

            double dist = Math.Sqrt(_x * _x + _y * _y);
            double h = s / 2 - gap;
            return minimum + (dist / h) * (maximum - minimum);
        }

        private double getAlpha(int count, int i)
        {
            return Math.PI * 2 * i / (0d + count) - Math.PI / 2;
        }

        private void Canvas_Paint(object sender, PaintEventArgs e)
        {
            Empty();

            Point prev, act, top, topprev;
            int size = Math.Min(Canvas.Width, Canvas.Height);
            gradeVal = Math.Pow(10d, (int)Math.Log10(maximum - minimum)) * (size > 200 ? 0.5d : 0.25d);
            double c;
            double k;

            if (data != null)
            {
                List<List<Point>> Points = new List<List<Point>>();
                List<Point> tops = new List<Point>();
                int count = 0;

                for (int lev = 0; lev < data.Length; lev++)
                {
                    Points.Add(new List<Point>());

                    if (data[lev] != null && data[lev].Length >= 3)
                    {
                        count = data[lev].Length;

                        prev = getCoord(getAlpha(count, count - 1), data[lev][count - 1]);
                        topprev = getCoord(getAlpha(count, count - 1), maximum);

                        for (int i = 0; i < count; i++)
                        {
                            act = getCoord(getAlpha(count, i), data[lev][i]);
                            act.X = size / 2 + act.X;
                            act.Y = size / 2 + act.Y;
                            Points[lev].Add(act);
                        }
                    }
                }

                if (count > 0)
                {
                    topprev = getCoord(getAlpha(count, count - 1), maximum);

                    for (int i = 0; i < count; i++)
                        tops.Add(getCoord(getAlpha(count, i), maximum));

                    for (int lev = 0; lev < data.Length; lev++)
                        graphics2.FillPolygon(new SolidBrush(Colors[lev % Colors.Length]), Points[lev].ToArray());

                    for (int i = 0; i < count; i++)
                    {

                        top = tops[i];
                        if (gradesCount)
                        {
                            for (int j = 0; j < grades; j++)
                                graphics2.DrawLine(pen,
                                                                       size / 2 + ((j + 1f) / (0f + grades)) * topprev.X,
                                                                       size / 2 + ((j + 1f) / (0f + grades)) * topprev.Y,
                                                                       size / 2 + ((j + 1f) / (0f + grades)) * top.X,
                                                                       size / 2 + ((j + 1f) / (0f + grades)) * top.Y);
                        }
                        else
                        {
                            c = 0;
                            while (c < maximum)
                            {
                                k = ((c - minimum) / (maximum - minimum));
                                graphics2.DrawLine(pen,
                                                            (float)(size / 2 + topprev.X * k),
                                                            (float)(size / 2 + topprev.Y * k),
                                                            (float)(size / 2 + top.X * k),
                                                            (float)(size / 2 + top.Y * k)
                                );
                                c += gradeVal;
                            }

                            c = -gradeVal;
                            while (c > minimum)
                            {
                                k = ((0d + c - minimum) / (0d + maximum - minimum));
                                graphics2.DrawLine(pen,
                                                            (float)(size / 2 + topprev.X * k),
                                                            (float)(size / 2 + topprev.Y * k),
                                                            (float)(size / 2 + top.X * k),
                                                            (float)(size / 2 + top.Y * k)
                                );
                                c -= gradeVal;
                            }
                        }

                        graphics2.DrawLine(pen,
                            size / 2 + topprev.X,
                            size / 2 + topprev.Y,
                            size / 2 + top.X,
                            size / 2 + top.Y
                          );
                        if (drawThin)
                            graphics2.DrawLine(pen,
                                size / 2,
                                size / 2,
                                size / 2 + top.X,
                                size / 2 + top.Y);

                        topprev = top;
                    }

                    Pen npen = new Pen(pen.Color, 2);

                    if (drawBold)
                        for (int i = 0; i < tops.Count; i++)
                            if ((i - markerStart) % markerGap == 0)
                                graphics2.DrawLine(npen,
                                    size / 2,
                                    size / 2,
                                    size / 2 + tops[i].X,
                                size / 2 + tops[i].Y);




                    for (int i = 0; i < count; i++)
                    {

                        top = tops[i];

                        if (notes != null)
                        {
                            if (notes.Length > i)
                            {
                                double corr = Math.Abs((float)(xFontCorrection * top.X / Math.Sqrt(top.X * top.X + top.Y * top.Y)));
                                double x = size / 2 + (textDist * top.X) - corr;
                                double y = size / 2 + (textDist * top.Y) - font.Size / 2;

                                graphics2.DrawString(notes[i], font, fontColor, (float)x, (float)y);
                            }
                        }
                    }
                    top = tops[0];
                    string s;

                    if (gradesCount)
                    {
                        for (int j = 0; j < grades; j++)
                        {
                            s = (minimum + (j + 1d) * (maximum - minimum) / grades).ToString("0.0").Replace(",", ".");
                            graphics2.DrawString(s, font, fontColor,
                                 size / 2 + ((j + 1f) / (0f + grades)) * top.X,
                                 size / 2 + ((j + 1f) / (0f + grades)) * top.Y);
                        }
                    }
                    else
                    {
                        c = 0;

                        while (c < maximum)
                        {
                            k = ((c - minimum) / (maximum - minimum));
                            s = c.ToString().Replace(",", ".");
                            graphics2.DrawString(s, font, fontColor,
                                                        (float)(size / 2 + top.X * k),
                                                        (float)(size / 2 + top.Y * k)
                            );
                            c += gradeVal;
                        }

                        c = -gradeVal;
                        while (c > minimum)
                        {
                            k = ((c - minimum) / (maximum - minimum));
                            s = c.ToString().Replace(",", ".");
                            graphics2.DrawString(s, font, fontColor,
                                                        (float)(size / 2 + top.X * k),
                                                        (float)(size / 2 + top.Y * k)
                            );
                            c -= gradeVal;
                        }

                    }
                    graphics.DrawImageUnscaled(bitmap, new Point(0, 0));

                }
                else
                {
                    Empty();
                }
            }
        }

        public void SaveToFile(string filename, System.Drawing.Imaging.ImageFormat format)
        {
            int size = Math.Min(this.Width, this.Height); Size now = new Size(Width, Height);
            Bitmap b = new Bitmap(size, size);
            Graphics g = Graphics.FromImage(b);
            g.DrawImageUnscaled(bitmap, 0, 0);
            b.Save(filename, format);
            b = null;
            GC.Collect();
        }

        private void PlotterBox_Resize(object sender, EventArgs e)
        {
            Refresh();
        }

        private void Canvas_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            double alpha;
            try
            {
                double k = getValue(e.X, e.Y, out alpha);
                int d = Convert.ToInt32(Math.Round(k + 1));
                if (d < int.MaxValue / 2 && d > int.MinValue / 2)
                {
                    Maximum = d;
                    Refresh();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Вы перестарались: " + ex.Message);
            }

        }

        private void Canvas_MouseClick(object sender, MouseEventArgs e)
        {
            this.Focus();
        }

    }
}
