using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;

namespace _3ShapeTestProject.Converters
{
    //Used for determining mouse cursor position
    public class MultiValueConverter : IEventArgsConverter
    {
        /// <summary>
        /// Convert MouseEventArgs and FrameworkElement to relative cursor position
        /// </summary>
        /// <param name="value">MouseEventArgs</param>
        /// <param name="parameter">FrameworkElement - element against which cursor coordinates are determining</param>
        /// <returns></returns>
        public object Convert(object value, object parameter)
        {
            var args = (MouseEventArgs)value;
            var element = (FrameworkElement)parameter;
            var point = args.GetPosition(element);
            return point;
        }
    }
}
