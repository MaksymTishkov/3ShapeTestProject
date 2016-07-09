using _3ShapeTestProject.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Interactivity;

namespace _3ShapeTestProject.Controls
{
    public class StopRotationAction 
    {
        public static readonly RoutedEvent IntersectEvent =
            EventManager.RegisterRoutedEvent("Intersect", RoutingStrategy.Bubble, 
                typeof(RoutedEventHandler), typeof(StopRotationAction));

        //public event RoutedEventHandler Intersect
        //{
        //    add { AddHandler(IntersectEvent, value); }
        //    remove { RemoveHandler(IntersectEvent, value); }
        //}
        //void RaiseTapEvent()
        //{
        //    RoutedEventArgs newEventArgs = new RoutedEventArgs(StopRotationAction.IntersectEvent);
        //    RaiseEvent(newEventArgs);
        //}
        //protected override void OnClick()
        //{
        //    RaiseTapEvent();
        //}

    }
}
