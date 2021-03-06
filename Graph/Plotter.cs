using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using diplom.Enose.DataModel;

namespace GUI
{
    /// <summary>
    /// Класс отрисовки данных
    /// </summary>
    public partial class Plotter : UserControl
    {
        public static Color[] Colors = new Color[9] { Color.Red, Color.Orange, Color.Lime, Color.DarkGreen, Color.LightBlue, Color.Purple, Color.DeepPink, Color.Black, Color.Aquamarine};

        /// <summary>
        /// Вертикальное расширение при подстройке относительно максимума-минимума
        /// </summary>
        private static double abris = 1.4d;
        /// <summary>
        /// Шаг скролла
        /// </summary>
        private static double scrollStep = 1.1d;
        //-------------------------------- private variables -------------- //
        
        /// <summary>
        /// цвета, используемые в компоненте
        /// </summary>
        Color backColor = Color.White;
        Color[] curve = new Color[9] { Color.Red, Color.Orange, Color.Lime, Color.DarkGreen, Color.LightBlue, Color.Purple, Color.DeepPink, Color.Black, Color.Aquamarine};
        Color dot = Color.OrangeRed;
        Color axescolor = Color.Black;
        Color levels = Color.Gray;
        Color sublevels = Color.LightGray;
        Color extem = Color.Coral;
        Color selectingColor = Color.Gray;
        Pen baseLinePen = Pens.Green;

        string label = "";
        string downlabel = "";
        string cornerLabel = "";

        bool vert = true;
        bool vertbold = true;
        bool baseLine = false;
        double baseValue = 0d;

        bool reactOnScroll = true;
        
        public string ordinateMask = "0.0";
        public string abscissMask = "0.00";
        public string extremumMask = "0.0";
        
        /// <summary>
        /// ширина линии
        /// </summary>
        int penWidth = 1;

        /// <summary>
        /// Шрифт, используемый для надписей
        /// </summary>
        Font font = new Font("Courier New", 8);

        /// <summary>
        /// Подписи к осям
        /// </summary>
        string ytext = "Гц";
        string xtext = "с";

        /// <summary>
        /// Логические пременные отрисовки
        /// </summary>
        bool adjusting = false;
        bool drawPoints = false;
        bool drawExtremum = false;

        /// <summary>
        /// флаги нажатых клавиш
        /// </summary>
        bool ctrlPressed = false;
        bool shiftPressed = false;

        /// <summary>
        /// Область выделяется
        /// </summary>
        bool selecting = false;

        /// <summary>
        /// двигается изображение
        /// </summary>
        bool moving = false;

        /// <summary>
        /// Видимое окно. Настоящее м предыдущее
        /// </summary>
        RectangleD viewport = new RectangleD(5, 800000, 2000, 400000);
        RectangleD lastviewport = new RectangleD(5, 800000, 2000, 400000);

        /// <summary>
        /// Канва для отрисовки точке и осей
        /// </summary>
        Graphics graphics, axesGraphics;
        Bitmap bitmap, axesBitmap;

        /// <summary>
        /// Координаты области выделения
        /// </summary>
        Point areaCorner1, areaCorner2;
        
        /// <summary>
        /// Массив данных
        /// </summary>
        PointD[][] data = null;

        //-------------------------------- properties -------------------------//

        public Color Indicator
        {
            get
            {
                return indicator.BackColor;
            }
            set
            {
                indicator.BackColor = value;
            }
        }

        /// <summary>
        /// Надпись вверху
        /// </summary>
        public string Label
        {
            get { return label; }
            set { label = value; RePaint(); }
        }

        /// <summary>
        /// Надпись внизу
        /// </summary>
        public string DownLabel
        {
            get { return downlabel; }
            set { downlabel = value; RePaint(); }
        }


        /// <summary>
        /// Текст на Label'е в левом верхнем углу
        /// </summary>
        public string CornerLabel
        {
            get { return cornerLabel; }
            set { cornerLabel = value; RePaint(); }
        }

        /// <summary>
        /// Работает ли триггер на колесо прокрутки
        /// </summary>
        public bool ReactOnScroll
        {
            get { return reactOnScroll; }
            set { reactOnScroll = value; }
        }

        /// <summary>
        /// Рисовать вертикальную сетку
        /// </summary>
        public bool DrawVertical
        {
            get { return vert; }
            set { vert = value; }
        }

        /// <summary>
        /// Рисовать вертикальные жирные отсчёты.
        /// </summary>
        public bool DrawVerticalBold
        {
            get { return vertbold; }
            set { vertbold = value; }
        }

        /// <summary>
        /// Рисовать базовую линию некоторое значение BaseValue
        /// </summary>
        public bool DrawBaseLine
        {
            get { return baseLine; }
            set { baseLine = value; RePaint(); }
        }

        /// <summary>
        /// Значение базовой линии
        /// </summary>
        public double BaseValue
        {
            get { return baseValue; }
            set { baseValue = value; RePaint(); }
        }

        /// <summary>
        /// Цвет фона изображения
        /// </summary>
        public override Color BackColor
        {
            get { return backColor; }
            set { backColor = value; RePaint(); }
        }

        /// <summary>
        /// Цвет кривой
        /// </summary>
        public Color[] CurveColor
        {
            get { return curve; }
            set { curve = value; RePaint(); }
        }

        /// <summary>
        /// Цвет линий уровня
        /// </summary>
        public Color LevelsColor
        {
            get { return levels; }
            set { levels = value; RePaint(); }
        }

        /// <summary>
        /// Цвет линий поуровня
        /// </summary>
        public Color SubLevelsColor
        {
            get { return sublevels; }
            set { sublevels = value; RePaint(); }
        }

        /// <summary>
        /// Цвет отрисовки точек
        /// </summary>
        public Color DotColor
        {
            get { return dot; }
            set { dot = value; RePaint(); }
        }

        /// <summary>
        /// Цвет осей
        /// </summary>
        public Color AxesColor
        {
            get { return axescolor; }
            set { axescolor = value; RePaint(); }
        }

        /// <summary>
        /// Цвет линий и данных экстремумов
        /// </summary>
        public Color ExtremumColor
        {
            get { return extem; }
            set { extem = value; RePaint(); }
        }

        /// <summary>
        /// Цвет линий области выделения
        /// </summary>
        public Color SelectingColor
        {
            get { return selectingColor; }
            set { selectingColor = value; RePaint(); }
        }

        /// <summary>
        /// Шрифт надписей
        /// </summary>
        public override Font Font
        {
            get { return font; }
            set { font = value; RePaint(); }
        }

        /// <summary>
        /// Зажат ctrl
        /// </summary>
        public bool CtrlPressed
        {
            get { return ctrlPressed; }
            set { ctrlPressed = value; }
        }

        /// <summary>
        /// Зажат Shift
        /// </summary>
        public bool ShiftPressed
        {
            get { return shiftPressed; }
            set { shiftPressed = value; }
        }

        /// <summary>
        /// Рисовать линии экстремума
        /// </summary>
        public bool DrawExtremum
        {
            get { return drawExtremum; }
            set { drawExtremum = value; RePaint(); }
        }

        /// <summary>
        /// Отображать точки
        /// </summary>
        public bool DrawPoints
        {
            get { return drawPoints; }
            set { drawPoints = value; RePaint(); }
        }

        /// <summary>
        /// Подстраиваться по высоте
        /// </summary>
        public bool Adjusting
        {
            get { return adjusting; }
            set { adjusting = value; RePaint(); }
        }
        
        /// <summary>
        /// Подпись к оси X
        /// </summary>
        public string Xtext
        {
            get { return xtext; }
            set { xtext = value; RePaint(); }
        }
        
        /// <summary>
        /// Подпись к оси Y
        /// </summary>
        public string Ytext
        {
            get { return ytext; }
            set { ytext = value; RePaint(); }
        }

        /// <summary>
        /// предыдущий фрейм
        /// </summary>
        public RectangleD LastViewport
        {
            get { return lastviewport; }
            set { lastviewport = value; }
        }

        /// <summary>
        /// Массив данных для отображения
        /// </summary>
        public PointD[][] Data
        {
            get { return data; }
            set { data = value; RePaint();  }
        }

        /// <summary>
        /// Окно отображения
        /// </summary>
        public RectangleD Viewport
        {
            get { return viewport; }
            set
            {
                lastviewport = viewport;
                viewport = value;
                RePaint();
            }
        }

        /// <summary>
        /// Ширина линии
        /// </summary>
        public int PenWidth
        {
            get { return penWidth; }
            set { penWidth = value; RePaint(); }
        }

        //---------------------------------------Конструктор ---------------------------------//

        /// <summary>
        /// Конструктор
        /// </summary>
        public Plotter()
        {
            InitializeComponent();
            canvas.MouseWheel += new MouseEventHandler(wheel);
            RePaint();
        }

        //--------------------------------общие методы рисования -----------------------------//

        /// <summary>
        /// Обновить канву
        /// </summary>
        private void emptyCanvas()
        {
            graphics = Graphics.FromImage(canvas.Image = bitmap = new Bitmap(canvas.Width, canvas.Height));
            graphics.Clear(backColor);

            axesGraphics = Graphics.FromImage(axes.Image = axesBitmap = new Bitmap(axes.Width, axes.Height));
            axesGraphics.Clear(backColor);
        }

        /// <summary>
        /// Нарисовать прямоугольник выделения
        /// </summary>
        private void drawRect()
        {
            int x, y, w, h;
            x = Math.Min(areaCorner1.X, areaCorner2.X);
            y = Adjusting ? 0 : Math.Min(areaCorner1.Y, areaCorner2.Y);
            w = Math.Abs(areaCorner1.X - areaCorner2.X);
            h = Adjusting ? canvas.Height : Math.Abs(areaCorner1.Y - areaCorner2.Y);
            graphics.DrawRectangle(Pens.Gray, x, y, w, h);
        }

        /// <summary>
        /// Перерисовать график 
        /// </summary>
        private void RePaint()
        {
            if (adjusting) viewport = calcAdjustingViewPort();
            
            emptyCanvas();
            
            drawAxes();

            drawData(data);

            if (selecting) drawRect();

            axes.Refresh();
            canvas.Refresh();
        }

        /// <summary>
        /// Вернуть предыдущее состояние
        /// </summary>
        public void Undo()
        {
            Viewport = lastviewport;
        }

        /// <summary>
        /// Приведение координаты из реальных данных к экранным
        /// </summary>
        /// <param name="x">абсцисса из Data</param>
        /// <returns>абсцисса на экране в canvas</returns>
        private int DataXtoScreenX(double x)
        {
            try
            {
                return (int)((x - viewport.Left) / viewport.Width * canvas.Width + 0.5d);
               
            }
            catch { return 0; }
        }

        /// <summary>
        /// Приведение координаты из реальных данных к экранным
        /// </summary>
        /// <param name="y">ордината из Data</param>
        /// <returns>ордината на экране в canvas</returns>
        private int DataYtoScreenY(double y)
        {
            try
            {
                return (int)((viewport.Bottom - y) / viewport.Height * canvas.Height + 0.5d);
            }
            catch { return 0; }
        }

        /// <summary>
        /// Приведение точки данных к экранной
        /// </summary>
        /// <param name="point">точка данных</param>
        /// <returns>координаты в canvas</returns>
        private Point DataPointToScreen(PointD point)
        {
            return new Point(DataXtoScreenX(point.X), DataYtoScreenY(point.Y));
        }

        /// <summary>
        /// Преобразование экранной координаты к данным
        /// </summary>
        /// <param name="x">абсцисса</param>
        /// <returns></returns>
        private double ScreenXtoDataX(int x)
        {
            try
            {
                return  (-1d + x) * viewport.Width / canvas.Width + viewport.X;
            }
            catch { return 0d; }
        }

        /// <summary>
        /// Преобразование экранной координаты к данным
        /// </summary>
        /// <param name="y">ордината</param>
        /// <returns></returns>
        private double ScreenYtoDataY(int y)
        {
            try
            {
                return (1d + canvas.Height - y) * viewport.Height / canvas.Height + viewport.Y;
            }
            catch { return 0d; }
        }

        /// <summary>
        /// Точку экрана в реальные координаты
        /// </summary>
        /// <param name="point">screen point</param>
        /// <returns>data point</returns>
        private PointD ScreenPointToDataPoint(Point point)
        {
            return new PointD(ScreenXtoDataX(point.X), ScreenYtoDataY(point.Y));
        }

        /// <summary>
        /// координата лежит в пределах компонента по X
        /// </summary>
        /// <param name="p">точка</param>
        /// <returns>да/нет</returns>
        private bool seenByX(Point p)
        {
            return p.X >= 0 && p.X < canvas.Width;
        }

        /// <summary>
        /// координата лежит в пределах компонента по Y
        /// </summary>
        /// <param name="p">точка</param>
        /// <returns>да/нет</returns>
        private bool seenByY(Point p)
        {
            return p.Y >= 0 && p.Y < canvas.Height;
        }
       
        /// <summary>
        /// Точка видна в компоненте
        /// </summary>
        /// <param name="p">точка</param>
        /// <returns>да/нет</returns>
        private bool seen(Point p)
        {
            return seenByX(p) && seenByY(p);
        }

        /// <summary>
        /// При подстройке размера по ширине перерасчёт viewport'а
        /// </summary>
        /// <returns>новое окно отрисовки</returns>
        private RectangleD calcAdjustingViewPort()
        {
            double  w, x;
            x = viewport.X;
            w = viewport.Width;

            double max = double.MinValue;
            double min = double.MaxValue;

            if (data == null || data.Length == 0) 
                return viewport;

            for (int crv = 0; crv < data.Length; crv++)
                if (data[crv] != null)
                {
                    for (int i = 0; i < data[crv].Length; i++)
                        if (data[crv][i].X >= x && (data[crv][i].X <= x + w))
                        {
                            max = Math.Max(max, data[crv][i].Y);
                            min = Math.Min(min, data[crv][i].Y);
                        }
                }
                else { }

            double avg = (max + min) / 2d;
            double amp = (max - min) / 2d;
            
            if (amp < 4d) amp = 4d;
            min = avg - amp * abris;

            return new RectangleD(x, min, w, amp * abris * 2);
        }

        /// <summary>
        /// Расчитать краевую точку для пары видимая-невидимая
        /// </summary>
        /// <param name="seenPoint">видимая</param>
        /// <param name="unseenPoint">невидимая</param>
        /// <returns>краевая</returns>
        private Point GetEdgePointForUnseen(Point seenPoint, Point unseenPoint, int curveNum)
        {
            Pen curvePen = new Pen(curve[curveNum]);
            Pen dotPen = new Pen(dot);

            double dx = unseenPoint.X - seenPoint.X;
            double dy = unseenPoint.Y - seenPoint.Y;

            ///Если это горизонтальный отрезок
            if (Math.Abs(dy) <= 1d && !seenByX(unseenPoint))
                if (unseenPoint.X > 0)
                    return new Point(canvas.Width - 1, seenPoint.Y);
                else
                    return new Point(0, seenPoint.Y);


            ///Если вертикальный отрезок
            if (Math.Abs(dx) <= 1d && !seenByY(unseenPoint))
                if (unseenPoint.Y > 0)
                    return new Point(seenPoint.X, canvas.Height - 1);
                else
                    new Point(seenPoint.X, 0);

            ///И общий случай
            if (dx != 0d)
            {
                double k = dy / dx;

                if (dy > 0)
                {
                    if (dx > 0)
                    {
                        double dxx = canvas.Width - seenPoint.X - 1;
                        double dyx = dxx * k;

                        double dyy = canvas.Height - seenPoint.Y - 1;
                        double dxy = dyy / k;

                        Point px, py;
                        px = new Point(seenPoint.X + (int)dxx, seenPoint.Y + (int)dyx);
                        py = new Point(seenPoint.X + (int)dxy, seenPoint.Y + (int)dyy);

                        if (!seen(px))
                        {
                            dx = dxy;
                            dy = dyy;
                        }
                        else
                        {
                            if (!seen(py))
                            {
                                dx = dxx;
                                dy = dyx;
                            }
                            else
                            {
                                if (dyx > dyy)
                                {
                                    dx = dxx;
                                    dy = dyx;
                                }
                                else
                                {
                                    dx = dxy;
                                    dy = dyy;
                                }
                            }
                        }

                        //dx = Math.Min(canvas.Width - seenPoint.X - 1, 0d + canvas.Width - seenPoint.X - 1) / k);
                    }
                    else
                    {

                        double dxx =  - seenPoint.X;
                        double dyx = dxx * k;

                        double dyy = canvas.Height - seenPoint.Y - 1;
                        double dxy = dyy / k; ///!!!! тонко


                        Point px, py;
                        px = new Point(seenPoint.X + (int)dxx, seenPoint.Y + (int)dyx);
                        py = new Point(seenPoint.X + (int)dxy, seenPoint.Y + (int)dyy);

                        if (!seen(px))
                        {
                            dx = dxy;
                            dy = dyy;
                        }
                        else
                        {
                            if (!seen(py))
                            {
                                dx = dxx;
                                dy = dyx;
                            }
                            else
                            {
                                if (dyx > dyy)
                                {
                                    dx = dxx;
                                    dy = dyx;
                                }
                                else
                                {
                                    dx = dxy;
                                    dy = dyy;
                                }
                            }
                        }
                        
                        //dx = Math.Max(seenPoint.X, (0d + canvas.Height - seenPoint.Y - 1) / k);
                    }
                }
                else
                {
                    if (dx > 0)
                    {
                        double dxx = canvas.Width - seenPoint.X - 1;
                        double dyx = dxx * k;

                        double dyy = - seenPoint.Y;
                        double dxy = dyy / k;

                        Point px, py;
                        px = new Point(seenPoint.X + (int)dxx, seenPoint.Y + (int)dyx);
                        py = new Point(seenPoint.X + (int)dxy, seenPoint.Y + (int)dyy);

                        if (!seen(px))
                        {
                            dx = dxy;
                            dy = dyy;
                        }
                        else
                        {
                            if (!seen(py))
                            {
                                dx = dxx;
                                dy = dyx;
                            }
                            else
                            {
                                if (dyx < dyy)
                                {
                                    dx = dxx;
                                    dy = dyx;
                                }
                                else
                                {
                                    dx = dxy;
                                    dy = dyy;
                                }
                            }
                        }


                        // dx = Math.Min(canvas.Width - seenPoint.X - 1, -dx * dy / seenPoint.Y);
                    }
                    else
                    {
                        double dxx = -seenPoint.X;
                        double dyx = dxx * k;

                        double dyy = -seenPoint.Y;
                        double dxy = dyy / k; ///!!!! тонко


                        Point px, py;
                        px = new Point(seenPoint.X + (int)dxx, seenPoint.Y + (int)dyx);
                        py = new Point(seenPoint.X + (int)dxy, seenPoint.Y + (int)dyy);

                        if (!seen(px))
                        {
                            dx = dxy;
                            dy = dyy;
                        }
                        else
                        {
                            if (!seen(py))
                            {
                                dx = dxx;
                                dy = dyx;
                            }
                            else
                            {
                                if (dyx < dyy)
                                {
                                    dx = dxx;
                                    dy = dyx;
                                }
                                else
                                {
                                    dx = dxy;
                                    dy = dyy;
                                }
                            }
                        }
                        

                        //dx = Math.Max(-seenPoint.X, -dx * dy / seenPoint.Y);
                    }
                    //dy = k * dx;
                }
                //dy = k * dx;

                return new Point(seenPoint.X + (int)dx, seenPoint.Y + (int)dy);
            }
            else
                return seenPoint;

        }
        
        /// <summary>
        /// Отрисовка точек на канве. Оч. важно.
        /// </summary>
        /// <param name="points"></param>
        private void drawData(PointD[][] points)
        {
            double MaxValue, MinValue;
            MaxValue = double.MinValue;
            MinValue = double.MaxValue;
            if (points != null)
            for (int crv = 0; crv < points.Length; crv++)
            {
                Pen curvePen = new Pen(curve[crv]);
                curvePen.Width = penWidth;
                Pen dotPen = new Pen(dot);
                bool seenPrev, seenThis;
                double max = double.MinValue;
                double min = double.MaxValue;

                Point p1, p2;

                ///Если точек нет - ничего не рисуем
                if (points[crv] == null || points[crv].Length == 0) return;

                ///Если точка одна - рисуем её.
                if (points[crv].Length == 1 && seen(p1 = DataPointToScreen(points[crv][0])))
                {
                    bitmap.SetPixel(p1.X, p1.Y, curve[crv]);
                    if (drawPoints) graphics.DrawRectangle(dotPen, p1.X - 2, p1.Y - 2, 4, 4);
                    return;
                }

                seenPrev = seen(p1 = DataPointToScreen(points[crv][0]));

                if (seenPrev)
                    max = min = points[crv][0].Y;

                for (int i = 1; i < points[crv].Length; i++)
                {

                    if (seenThis = seen(p2 = DataPointToScreen(points[crv][i])))
                    {
                        max = Math.Max(max, points[crv][i].Y);
                        min = Math.Min(min, points[crv][i].Y);
                        MaxValue = Math.Max(MaxValue, points[crv][i].Y);
                        MinValue = Math.Min(MinValue, points[crv][i].Y);
                    }

                    if (seenPrev)
                    {
                        bitmap.SetPixel(p1.X, p1.Y, curve[crv]);
                        ///Если видно обе точки - рисуем меж ними отрезок
                        if (seenThis)
                            graphics.DrawLine(curvePen, p1, p2);
                        ///Или рассчитываем новый отрезок
                        else
                            graphics.DrawLine(curvePen, p1, GetEdgePointForUnseen(p1, p2, crv));
                    }
                    else
                        ///Если видно только текущую
                        if (seenThis)
                            graphics.DrawLine(curvePen, p2, GetEdgePointForUnseen(p2, p1, crv));
                        else
                        {
                            ///TODO: на ленувую. Если вдруг пробьёт отрисовывать отрезок между 2 невидимыми точками
                        }

                    seenPrev = seenThis;
                    p1 = p2;
                }


                #region Рисовать обрамления точек
                if (drawPoints)
                    for (int i = 0; i < points[crv].Length; i++)
                        if (seen(p1 = DataPointToScreen(points[crv][i])))
                            graphics.DrawRectangle(dotPen, p1.X - 2, p1.Y - 2, 4, 4);
                #endregion
            }

            #region Рисовать линии локальных экстремумов
            if (drawExtremum)
            {
                if (MaxValue > double.MinValue && MinValue < double.MaxValue)
                {
                    Pen extremPen = new Pen(extem);
                    int minLevel, maxLevel;
                    minLevel = DataYtoScreenY(MinValue);
                    maxLevel = DataYtoScreenY(MaxValue);

                    graphics.DrawLine(extremPen, new Point(0, minLevel + 1), new Point(canvas.Width, minLevel + 1));
                    graphics.DrawString(MinValue.ToString(extremumMask), font, extremPen.Brush, 1, minLevel + 1);

                    graphics.DrawLine(extremPen, new Point(0, maxLevel - 1), new Point(canvas.Width, maxLevel - 1));
                    graphics.DrawString(MaxValue.ToString(extremumMask), font, extremPen.Brush, 1, maxLevel - font.Size * 2);
                }
            }
            #endregion

            #region Вазелин
            if (DrawBaseLine)
            {
                string _label = baseValue.ToString(extremumMask);
                double bv = baseValue;
                bool fromup = true;

                int bvs = DataYtoScreenY(bv);

                if (BaseValue < viewport.Top)
                {
                    _label += "↓";
                    bvs = canvas.Height - 1;
                    fromup = false;
                }
                else if (BaseValue > viewport.Bottom)
                {
                    _label += "↑";
                    bvs = 1;
                }

                Point lastP =  new Point(canvas.Width, bvs);
                graphics.DrawLine(baseLinePen, new Point(0, bvs),lastP);
                if (fromup)
                    graphics.DrawString(_label, font, baseLinePen.Brush, canvas.Width - _label.Length * font.Size - 4, lastP.Y + 1);
                else
                    graphics.DrawString(_label, font, baseLinePen.Brush, canvas.Width - _label.Length * font.Size - 4, lastP.Y - font.Size * 2);
            }
            #endregion
        }

        /// <summary>
        /// Отрисовка осей
        /// </summary>
        private void drawAxes()
        {
            graphics.Clear(backColor);
        
            Pen pen = new Pen(axescolor);
            Pen lpen = new Pen(levels);
            Pen slpen = new Pen(sublevels);
            int dx = canvas.Left - axes.Left - 1;
            int dy = axes.Bottom - canvas.Bottom;

            Point tl = new Point(dx, canvas.Top - axes.Top);
            Point dr = new Point(canvas.Right - axes.Left, axes.Height - dy);

            #region Axes Lines

            axesGraphics.DrawLine(pen, tl.X, tl.Y, tl.X, dr.Y);
            axesGraphics.DrawLine(pen, tl.X, dr.Y, dr.X, dr.Y);

            #endregion

            #region arrows
            
            axesGraphics.DrawPolygon(pen, new Point[] { new Point(tl.X + 2, tl.Y - 1), new Point(tl.X, tl.Y - 6), new Point(tl.X - 2, tl.Y - 1)});
            axesGraphics.DrawPolygon(pen, new Point[] { new Point(dr.X + 1, dr.Y - 2), new Point(dr.X + 6, dr.Y), new Point(dr.X + 1, dr.Y + 2) });

            #endregion

            #region Labels
            LabelNum.Text = cornerLabel;
            axesGraphics.DrawString(ytext, font, pen.Brush, tl.X + 1, tl.Y - font.Size * 2);
            axesGraphics.DrawString(xtext, font, pen.Brush, dr.X + font.Size, dr.Y - font.Size);
            axesGraphics.DrawString(label, font, new Pen(axescolor).Brush, new PointF(LabelNum.Width, 0));
            axesGraphics.DrawString(downlabel, font, new SolidBrush(axescolor), new PointF(0, this.Height - 2 * font.Size - 5));
            #endregion

            #region VerticalMagic
            double ds = 1d;

            if (canvas.Height > 200) ds = 2d;
            if (canvas.Height > 500) ds = 4d;

            int power = (int)Math.Log10(viewport.Height);
            double basis = Math.Pow(10d, (double)power);
            double mantiss = viewport.Height / basis;
            double dd = (basis < 5) ? 2d: 1d;

            double step = basis / (dd * ds);
            
            double start = ((int)(viewport.Y / step)) * step;
            
            while (start <= viewport.Y) start += step;

            do
            {
                Point p = new Point(0, DataYtoScreenY(start));
                Point p2 = new Point(0, DataYtoScreenY(start + step / 2d));
                axesGraphics.DrawLine(pen, tl.X, tl.Y + p.Y, tl.X - 3, tl.Y + p.Y);
                string toprn = start.ToString(ordinateMask);
                int dp = toprn.Length;
                axesGraphics.DrawString(toprn, font, pen.Brush, tl.X - (dp + 1) * font.Size, tl.Y + p.Y - font.Size);
                
                graphics.DrawLine(lpen, 0, p.Y, bitmap.Width - 1, p.Y);
                
                if (p2.Y >= 0) graphics.DrawLine(slpen, 0, p2.Y, bitmap.Width - 1, p2.Y);

                start += step;
            }
            while (start < viewport.Bottom);

            #endregion

            #region HorisontalMagic

            ds = 1d;
            if (canvas.Width > 150) ds = 2d;

            power = (int)Math.Log10(viewport.Width);
            basis = Math.Pow(10d, (double)power);
            mantiss = viewport.Width / basis;

            
            dd = (mantiss < 5) ? 1d : 0.5d;


            step = basis / (ds * dd);
            start = ((int)(viewport.X / step)) * step;

            while (start < viewport.X) start += step;

            do
            {

                Point p = new Point(DataXtoScreenX(start), 0);
                Point p2 = new Point(DataXtoScreenX(start + step / 5d), 0);
                Point p3 = new Point(DataXtoScreenX(start + step * 2d / 5d), 0);
                Point p4 = new Point(DataXtoScreenX(start + step * 3d / 5d), 0);
                Point p5 = new Point(DataXtoScreenX(start + step * 4d / 5d), 0);

                
                if (vert)
                {
                    if (p.X < bitmap.Width) graphics.DrawLine(slpen, p.X, 0, p.X, bitmap.Height - 1);
                    if (p2.X < bitmap.Width) graphics.DrawLine(slpen, p2.X, 0, p2.X, bitmap.Height - 1);
                    if (p3.X < bitmap.Width) graphics.DrawLine(slpen, p3.X, 0, p3.X, bitmap.Height - 1);
                    if (p4.X < bitmap.Width) graphics.DrawLine(slpen, p4.X, 0, p4.X, bitmap.Height - 1);
                    if (p5.X < bitmap.Width) graphics.DrawLine(slpen, p5.X, 0, p5.X, bitmap.Height - 1);
                }
                if (vertbold)
                    if (p.X < bitmap.Width) graphics.DrawLine(lpen, p.X, 0, p.X, bitmap.Height - 1);

                axesGraphics.DrawLine(pen, tl.X + p.X, dr.Y, tl.X + p.X, dr.Y + 3);
                
                string toprn = start.ToString(abscissMask);
                int dp = toprn.Length;
                axesGraphics.DrawString(toprn, font, pen.Brush, tl.X + p.X - dp * font.Size / 2, dr.Y + 4);
                start += step;

            }
            while (start < viewport.Right);

            #endregion
        }

        /// <summary>
        /// Обработчик скролла
        /// </summary>
        /// <param name="up">увеличиваем?</param>
        /// <param name="mouse">координаты курсора</param>
        private void doScroll(bool up, Point mouse)
        {
            double w = viewport.Width;
            double h = viewport.Height;

            if ((!up) && (w < 1 || h < 1))
            {
                RePaint();
                return;
            }

            double kw = (!CtrlPressed) ? (up ? scrollStep : (1d / scrollStep)) : 1d;
            double kh = (!ShiftPressed) ? (up ? scrollStep : (1d / scrollStep)) : 1d;

            PointD c = ScreenPointToDataPoint(mouse);

            double w_ = w * kw;
            double h_ = h * kh;

            double x_ = viewport.X + (c.X - viewport.Left) * (1d - kw);
            double y_ = viewport.Top + (c.Y - viewport.Top) * (1d - kh);

            Viewport = new RectangleD(x_, y_, w_, h_);

            RePaint();
        }

        /// <summary>
        /// Получить снимок графика с экрана
        /// </summary>
        /// <returns>Картинка как там =)</returns>
        public Bitmap getSnap()
        {
            Bitmap bmp = new Bitmap(axesBitmap.Width, axesBitmap.Height);
            Graphics grph = Graphics.FromImage(bmp);
            grph.DrawImageUnscaled(axesBitmap, new Point(0, 0));
            grph.DrawImageUnscaled(bitmap, new Point(canvas.Left - axes.Left, canvas.Top - axes.Top));
            return bmp;
        }

        //---------------------------------------обработчкики -----------------------------------//
        private void Plotter_Resize(object sender, EventArgs e)
        {
            RePaint();
        }

        private void wheel(object sender, MouseEventArgs e)
        {
            if (reactOnScroll)
            {
                Cursor.Current = Cursors.SizeAll;
                doScroll(e.Delta < 0, new Point(e.X - canvas.Left, e.Y - canvas.Top));
                Cursor.Current = Cursors.Default;
            }
        }

        private void canvas_MouseDown(object sender, MouseEventArgs e)
        {
            if (!(selecting || moving))
            {
                areaCorner1 = e.Location;
                if (e.Button == MouseButtons.Left)
                {
                    selecting = true;
                    Cursor.Current = Cursors.Cross;
                }
                else if (e.Button == MouseButtons.Right)
                {
                    moving = true;
                    Cursor.Current = Cursors.NoMove2D;
                }
            }
        }

        private void canvas_MouseMove(object sender, MouseEventArgs e)
        {
            
            
            Point mp = e.Location;
            Point cp = Cursor.Position;

            if (selecting || moving)
            {
                if (mp.X  < 0)
                    Cursor.Position = new Point(cp.X - mp.X, cp.Y);

                if (mp.X > canvas.Width)
                    Cursor.Position = new Point(cp.X - mp.X + canvas.Width, cp.Y);
                 
                if (mp.Y < 0)
                    Cursor.Position = new Point(cp.X, cp.Y - mp.Y);

                if (mp.Y > canvas.Height)
                    Cursor.Position = new Point(cp.X, cp.Y - mp.Y + canvas.Height);

                areaCorner2 = e.Location;
            }

            if (selecting)
                RePaint();

            if (moving)
            {
                double dx = (0d + areaCorner2.X - areaCorner1.X) / canvas.Width * viewport.Width;
                double dy = (0d + areaCorner2.Y - areaCorner1.Y) / canvas.Height * viewport.Height;
                Viewport = new RectangleD(viewport.X - dx, viewport.Y +dy, viewport.Width, viewport.Height);
                RePaint();
                areaCorner1 = areaCorner2;
            }
        }

        private void canvas_MouseUp(object sender, MouseEventArgs e)
        {
            
            if (selecting)
            {
                selecting = false;
                Cursor.Current = Cursors.Default;
                areaCorner2 = e.Location;
                double w, h;

                w =( (0d + Math.Abs(areaCorner2.X - areaCorner1.X)) / canvas.Width) * viewport.Width;
                h =( (0d + Math.Abs(areaCorner2.Y - areaCorner1.Y)) / canvas.Height) * viewport.Height;


                //// !!!!! КОСТЫЛЬ!!!
                if (w > 0.5d && h > 0.5d && w < double.MaxValue / 2 && h < double.MaxValue / 2)
                {
                    if (Math.Abs(areaCorner2.X - areaCorner1.X) > 1 && Math.Abs(areaCorner2.Y - areaCorner1.Y) > 1)
                    {
                        PointD t = ScreenPointToDataPoint(new Point(Math.Min(areaCorner1.X, areaCorner2.X), Math.Max(areaCorner1.Y, areaCorner2.Y)));
                        viewport = new RectangleD(t.X, t.Y, w, h);
                    }
                }
                    RePaint();
            }
            selecting = moving = false;
        }

        private void Plotter_MouseEnter(object sender, EventArgs e)
        {
            //canvas.Focus();
        }

        private void canvas_Click(object sender, EventArgs e)
        {
            canvas.Focus();
        }

        private void canvas_DragDrop(object sender, DragEventArgs e)
        {
            MessageBox.Show(e.Data.GetType().ToString());
        }
    }
}
