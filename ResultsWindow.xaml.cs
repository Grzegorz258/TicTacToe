using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TicTacToe
{
    /// <summary>
    /// Logika interakcji dla klasy ResultsWindow.xaml
    /// </summary>

    

    public partial class ResultsWindow : UserControl
    {



        public string PointsContent
        {
            get { return (string)GetValue(PointsContentProperty); }
            set { SetValue(PointsContentProperty, value); }
        }

        // Using a DependencyProperty as the backing store for PointsContent.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PointsContentProperty =
            DependencyProperty.Register("PointsContent", typeof(string), typeof(ResultsWindow),
            new FrameworkPropertyMetadata("Some content", new PropertyChangedCallback((s, e) =>
            {
                var window = s as ResultsWindow;
                window.Points.Content = (string)e.NewValue;
            }
            )));



        public string WhosePointsContent
        {
            get { return (string)GetValue(WhosePointsContentProperty); }
            set { SetValue(WhosePointsContentProperty, value); }
        }

        // Using a DependencyProperty as the backing store for WhosePointsContentProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty WhosePointsContentProperty =
            DependencyProperty.Register("WhosePointsContent", typeof(string), typeof(ResultsWindow),
            new FrameworkPropertyMetadata("Some content", new PropertyChangedCallback((s,e) =>
            {
                var window = s as ResultsWindow;
                window.WhosePoints.Content = (string)e.NewValue;
            }
            )));



        public ResultsWindow()
        {
            InitializeComponent();

            WhosePoints.Content = WhosePointsContent;
        }
    }
}
