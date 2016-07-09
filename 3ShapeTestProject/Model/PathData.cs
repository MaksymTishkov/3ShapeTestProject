using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace _3ShapeTestProject.Model
{
    public class PathData//: IXmlSerializable
    {
        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="geom">Geometry object</param>
        /// <param name="fill">Color of object</param>
        /// <param name="stroke">Border's color</param>
        /// <param name="strokeThikness">Border's thikness</param>
        /// <param name="menu">Context menu</param>
        /// <param name="figureCenter">Point of the figure center</param>
        /// <param name="creationPoint">Point where figure created</param>
        /// <param name="type">FigureType</param>
        public PathData(Geometry geom, Brush fill, Brush stroke, double strokeThikness, ContextMenu menu, Point figureCenter, Point creationPoint, FigureType type)
        {
            Geometry = geom;
            Fill = fill;
            Stroke = stroke;
            StrokeThickness = strokeThikness;
            Menu = menu;
            FigureCenter = figureCenter;
            CreationPoint = creationPoint;
            RotationState = new RotateTransform();
            FigureType = type;
            IsAnimated = false;
        }
        #endregion

        #region Properties
        //Geometry object
        public Geometry Geometry { get; set; }

        //Color of the object
        public Brush Fill { get; set; }

        //Color of the border
        public Brush Stroke { get; set; }

        //Border's thikness
        public double StrokeThickness { get; set; }

        //Context menu
        public ContextMenu Menu{ get; set; }

        //Figure's center point
        public Point FigureCenter { get; set; }

        //point in which a figure created
        public Point CreationPoint { get; set; }

        //Used for determining figure rotation angle
        public RotateTransform RotationState{ get; set; }

        //Type of figure
        public FigureType FigureType { get; set; }

        //Is figure animated when user save figures. Used for Save/Load
        public bool IsAnimated { get; set; }
        #endregion
    }

    //Enum of figure types
    public enum FigureType
    {
        Rectangle = 0,
        Triangle = 1,
        Trapeze = 2,
        Ellipse = 3,
        Circle = 4
    }
}
