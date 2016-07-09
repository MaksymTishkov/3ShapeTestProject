using GalaSoft.MvvmLight;
using _3ShapeTestProject.Model;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Windows.Media;
using System;
using System.Windows;
using System.Windows.Input;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Media.Animation;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Xml;
using System.Xml.Linq;
using Microsoft.Win32;

namespace _3ShapeTestProject.ViewModel
{
    public class MainViewModel : ViewModelBase, INotifyPropertyChanged
    {
        #region Constructors
        public MainViewModel()
        {
            Figures = new ObservableCollection<PathData>();
        }
        #endregion

        #region PrivateFields

        //Current action to create figure
        Func<Point, PathData> _createAction;
        
        //default size of rectangles
        Size rectSize = new Size(30, 30);
        
        //default length of the triangle's side
        double tringleSideSize = 30;
        
        //default length of the smaller side of trapeze 
        double trapezeSideSize = 30;
        
        //default sizes of horizontal and vertical semiaxes of ellipse
        Size ellipseSize = new Size(60, 30);
        
        //default circle radius
        Size circleSize = new Size(30, 30);

        //collection of all created objects
        ObservableCollection<PathData> _figures;

        //type of figure: 0 - rectangle, 1 - triangle, 2 - trapeze, 3 - ellipse, 4 - circle
        int _typeOfFigure;

        #endregion

        #region Properties
        public ObservableCollection<PathData> Figures
        {
            get
            {
                return _figures;
            }
            set
            {
                _figures = value;
                NotifyPropertyChanged("Figures");
            }
        }
        
        //setter set current create action depending on selected radio button
        public int TypeOfFigure
        {
            get
            {
                return _typeOfFigure;
            }
            set
            {
                _typeOfFigure = value;
                switch (value)
                {
                    case 0:
                        _createAction = CreateRectangle;
                        break;
                    case 1:
                        _createAction = CreateTriangle;
                        break;
                    case 2:
                        _createAction = CreateTrapeze;
                        break;
                    case 3:
                        _createAction = CreateEllipse;
                        break;
                    case 4:
                        _createAction = CreateCircle;
                        break;
                }
            }
        }
        #endregion

        #region CreateFigures

        /// <summary>
        /// Return context menu of created object
        /// </summary>
        /// <param name="data">object that will be sent to view model</param>
        /// <returns></returns>
        ContextMenu GetContextMenu(PathData data)
        {
            ContextMenu menu = new ContextMenu();
            menu.Items.Add(new MenuItem() { Header = "Rotate", Command = RotateFigure, CommandParameter = data });
            menu.Items.Add(new MenuItem() { Header = "Delete", Command = DeleteFigure, CommandParameter = data });
            return menu;
        }

        /// <summary>
        /// Return new PathData object with rectangle Geometry
        /// </summary>
        /// <param name="point">left top point of rectangle</param>
        /// <returns></returns>
        PathData CreateRectangle(Point point)
        {

            PathData result = new PathData(new RectangleGeometry(new Rect(point, rectSize)),
                Brushes.Purple, Brushes.LightCyan, 2, null, 
                new Point(point.X + rectSize.Width / 2, point.Y + rectSize.Height / 2), point, FigureType.Rectangle);
            result.Menu = GetContextMenu(result);
            return result;
        }

        /// <summary>
        /// Return new PathData object with triangle Geometry
        /// </summary>
        /// <param name="point">top point of triangle</param>
        /// <returns></returns>
        PathData CreateTriangle(Point point)
        {
            StreamGeometry streamGeometry = new StreamGeometry();
            using (StreamGeometryContext geometryContext = streamGeometry.Open())
            {
                geometryContext.BeginFigure(new Point(point.X, point.Y), true, true);
                PointCollection points = new PointCollection
                    {
                        new Point(point.X + tringleSideSize/2,
                        point.Y + Math.Sqrt(3)*tringleSideSize/2),
                        new Point(point.X - tringleSideSize/2, point.Y +
                        Math.Sqrt(3)*tringleSideSize/2)
                    };
                geometryContext.PolyLineTo(points, true, true);
            }
            PathData result = new PathData(streamGeometry,
                Brushes.Orange, Brushes.Chocolate, 2, null,
                new Point(point.X, point.Y + tringleSideSize / Math.Sqrt(3)), point, FigureType.Triangle);
            result.Menu = GetContextMenu(result);
            return result;
        }

        /// <summary>
        /// Return new PathData object with trapeze Geometry
        /// </summary>
        /// <param name="point">seft top point of trapeze</param>
        /// <returns></returns>
        PathData CreateTrapeze(Point point)
        {
            StreamGeometry streamGeometry = new StreamGeometry();
            using (StreamGeometryContext geometryContext = streamGeometry.Open())
            {
                geometryContext.BeginFigure(new Point(point.X, point.Y), true, true);
                PointCollection points = new PointCollection
                    {
                        new Point(point.X + trapezeSideSize, point.Y),
                        new Point(point.X + trapezeSideSize*3/2,
                        point.Y + trapezeSideSize),
                        new Point(point.X - trapezeSideSize/2,
                        point.Y + trapezeSideSize)
                    };
                geometryContext.PolyLineTo(points, true, true);
            }
            PathData result = new PathData(streamGeometry,
               Brushes.OrangeRed, Brushes.Chocolate, 2, null,
               new Point(point.X + trapezeSideSize / 2, point.Y + trapezeSideSize / 2), point, FigureType.Trapeze);
            result.Menu = GetContextMenu(result);
            return result;
        }

        /// <summary>
        /// Return new PathData object with ellipse Geometry
        /// </summary>
        /// <param name="point">Center of ellipse</param>
        /// <returns></returns>
        PathData CreateEllipse(Point point)
        {
            PathData result = new PathData(new EllipseGeometry(point, ellipseSize.Width, ellipseSize.Height),
              Brushes.CadetBlue, Brushes.Chocolate, 2, null,
              point, point, FigureType.Ellipse);
            result.Menu = GetContextMenu(result);
            return result;
        }

        /// <summary>
        /// Return new PathData object with circle Geometry
        /// </summary>
        /// <param name="point">Center of the circle</param>
        /// <returns></returns>
        PathData CreateCircle(Point point)
        {
            PathData result = new PathData(new EllipseGeometry(point, circleSize.Width, circleSize.Height),
              Brushes.Violet, Brushes.Chocolate, 2, null,
              point, point, FigureType.Circle);
            result.Menu = GetContextMenu(result);
            return result;
        }
        #endregion

        #region Animation functions
        /// <summary>
        /// Rotate Geometry object of "figure"
        /// </summary>
        /// <param name="figure">PathData object</param>
        void AnimateFigure(PathData figure)
        {
            ((MenuItem)figure.Menu.Items[0]).Header = "Stop rotation";
            ((MenuItem)figure.Menu.Items[0]).Command = StopRotation;
            var da = new DoubleAnimation(figure.RotationState.Angle, figure.RotationState.Angle + 360, new Duration(TimeSpan.FromSeconds(1)));
            var rt = new RotateTransform();
            rt.CenterX = figure.FigureCenter.X;
            rt.CenterY = figure.FigureCenter.Y;
            figure.Geometry.Transform = rt;
            da.RepeatBehavior = RepeatBehavior.Forever;
            rt.BeginAnimation(RotateTransform.AngleProperty, da);
            figure.RotationState = rt;
            figure.IsAnimated = true;
        }

        /// <summary>
        /// Stop rotating of Geometry object of "figure"
        /// </summary>
        /// <param name="figure">PathData object</param>
        void StopAnimate(PathData figure)
        {
            ((MenuItem)figure.Menu.Items[0]).Header = "Rotate";
            ((MenuItem)figure.Menu.Items[0]).Command = RotateFigure;
            double angle = figure.RotationState.Angle;
            figure.RotationState.BeginAnimation(RotateTransform.AngleProperty, null);
            figure.RotationState.Angle = angle;
            figure.IsAnimated = false;
        }
        #endregion

        #region Commands
        #region SelectRadioCommand
        /// <summary>
        /// Command on selected radio button change
        /// </summary>
        public ICommand SelectRadioCommand
        {
            get
            {
                return new MainCommand(o =>
                {
                    TypeOfFigure = int.Parse(o.ToString());
                }, x => true);
            }
        }
        #endregion

        #region CanvasLeftClick
        /// <summary>
        /// Command on left click on figures field
        /// </summary>
        public ICommand CanvasLeftClick
        {
            get
            {
                return new MainCommand(o =>
                {
                    if (_createAction != null)
                    {
                        Point point = (Point)o;
                        PathData pathData = _createAction(point);
                        if (!Figures.Any(x => pathData.Geometry.FillContainsWithDetail(x.Geometry) != IntersectionDetail.Empty))
                            Figures.Add(pathData);
                        else MessageBox.Show("Фігури не повинні перетинатись", "Повідомлення", MessageBoxButton.OK, MessageBoxImage.Warning);
                    }
                }, x => true);
            }
        }
        #endregion

        #region DeleteFigure
        /// <summary>
        /// Delete figure
        /// </summary>
        public ICommand DeleteFigure
        {
            get
            {
                return new MainCommand(o =>
                {
                    Figures.Remove(o as PathData);
                }, x => true);
            }
        }
        #endregion

        #region RotateFigure
        /// <summary>
        /// Command start figure rotation
        /// </summary>
        public ICommand RotateFigure
        {
            get
            {
                return new MainCommand(o =>
                {
                    AnimateFigure((PathData)o);
                }, x => true);
            }
        }
        #endregion

        #region StopRotation
        /// <summary>
        /// Command stop figure rotation
        /// </summary>
        public ICommand StopRotation
        {
            get
            {
                return new MainCommand(o =>
                {
                    StopAnimate((PathData)o);
                }, x => true);
            }
        }
        #endregion

        #region Save
        /// <summary>
        /// Command save all figures and their state to xml file
        /// </summary>
        public ICommand Save
        {
            get
            {
                return new MainCommand(o =>
                {
                    SaveFileDialog dlg = new SaveFileDialog();
                    dlg.FileName = "Save"; 
                    dlg.DefaultExt = ".xml"; 
                    dlg.Filter = "Text documents (.xml)|*.xml"; 

                    // Show save file dialog box
                    bool? result = dlg.ShowDialog();
                    if (result == true)
                    {
                        using (XmlWriter writer = XmlWriter.Create(dlg.FileName, new XmlWriterSettings() { ConformanceLevel = ConformanceLevel.Fragment }))
                        {
                            writer.WriteStartElement("Figures");

                            foreach (var item in Figures)
                            {
                                writer.WriteStartElement("Figure");

                                writer.WriteElementString("FigureType", ((int)item.FigureType).ToString());
                                writer.WriteElementString("CreationPointX", item.CreationPoint.X.ToString());
                                writer.WriteElementString("CreationPointY", item.CreationPoint.Y.ToString());
                                writer.WriteElementString("RotationStateAngle", item.RotationState.Angle.ToString());
                                writer.WriteElementString("IsAnimated", item.IsAnimated.ToString());

                                writer.WriteEndElement();
                            }
                            writer.WriteEndElement();
                        }
                    }
                }, x => true);
            }
        }
        #endregion

        #region Load
        /// <summary>
        /// Copmmand calls OpenFileDialog and load saved objects from xml file
        /// </summary>
        public ICommand Load
        {
            get
            {
                return new MainCommand(o =>
                {
                    OpenFileDialog dlg = new OpenFileDialog();
                    dlg.Filter = "Text documents (.xml)|*.xml";

                    bool? result = dlg.ShowDialog();
                    if (result == true)
                    {
                        try
                        {
                            XDocument doc = XDocument.Load(dlg.FileName);
                            IEnumerable<PathData> data = doc.Descendants("Figure").Select(x =>
                            {
                                PathData pathData;
                                switch ((FigureType)int.Parse(x.Element("FigureType").Value))
                                {
                                    case FigureType.Rectangle:
                                        pathData = CreateRectangle(new Point(double.Parse(x.Element("CreationPointX").Value),
                                            double.Parse(x.Element("CreationPointY").Value)));
                                        break;
                                    case FigureType.Triangle:
                                        pathData = CreateTriangle(new Point(double.Parse(x.Element("CreationPointX").Value),
                                            double.Parse(x.Element("CreationPointY").Value)));
                                        break;
                                    case FigureType.Trapeze:
                                        pathData = CreateTrapeze(new Point(double.Parse(x.Element("CreationPointX").Value),
                                            double.Parse(x.Element("CreationPointY").Value)));
                                        break;
                                    case FigureType.Ellipse:
                                        pathData = CreateEllipse(new Point(double.Parse(x.Element("CreationPointX").Value),
                                            double.Parse(x.Element("CreationPointY").Value)));
                                        break;
                                    case FigureType.Circle:
                                        pathData = CreateCircle(new Point(double.Parse(x.Element("CreationPointX").Value),
                                            double.Parse(x.Element("CreationPointY").Value)));
                                        break;
                                    default:
                                        pathData = null;
                                        break;
                                }
                                pathData.RotationState.Angle = double.Parse(x.Element("RotationStateAngle").Value);
                                pathData.IsAnimated = bool.Parse(x.Element("IsAnimated").Value);
                                return pathData;
                            });
                            Figures = null;
                            Figures = new ObservableCollection<PathData>(data);
                            foreach (PathData item in Figures)
                            {
                                if (item.IsAnimated)
                                {
                                    AnimateFigure(item);
                                }
                            }
                        }
                        catch
                        {
                            MessageBox.Show("Некоректний формат вмісту файлу");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Некоректний файлу");
                    }
                }, x => true);
            }
        }
        #endregion
        #endregion

        #region HotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}