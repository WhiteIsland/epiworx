using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.DataVisualization;
using System.Windows.Controls.DataVisualization.Charting;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace Epiworx.Silverlight.Helpers
{
    public class ChartHelper
    {
        public static Color ColorForInternalHours
        {
            get { return Color.FromArgb(255, 77, 189, 42); }
        }

        public static Color ColorForExternalHours
        {
            get { return Color.FromArgb(255, 42, 150, 189); }
        }

        public static Color ColorForRevenues
        {
            get { return Color.FromArgb(255, 223, 46, 53); }
        }

        public static LineSeries AddLineSeries(IEnumerable data,
            string title,
            string independentPathName,
            string dependentPathName)
        {
            var result = new LineSeries();

            result.ItemsSource = data;
            result.Title = title;
            result.IndependentValuePath = independentPathName;
            result.DependentValuePath = dependentPathName;

            return result;
        }

        public static void AddColor(ResourceDictionaryCollection palette,
            Color color)
        {
            var style = new Style(typeof(Control));

            style.Setters.Add(new Setter(Control.BackgroundProperty, new SolidColorBrush(color)));
            style.Setters.Add(new Setter(Control.BorderThicknessProperty, "0"));
            style.Setters.Add(new Setter(Control.BorderBrushProperty, new SolidColorBrush(Color.FromArgb(255, 255, 255, 255))));

            var dictionary = new ResourceDictionary();
            dictionary.Add("DataPointStyle", style);

            palette.Add(dictionary);
        }
    }
}
