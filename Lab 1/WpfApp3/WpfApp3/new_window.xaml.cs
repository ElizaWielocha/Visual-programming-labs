using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WpfApp3
{
    /// <summary>
    /// Logika interakcji dla klasy new_window.xaml
    /// </summary>
    public partial class new_window : Window
    {
        System.Windows.Threading.DispatcherTimer dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
        DateTime time = new DateTime();

        public new_window()
        {
            InitializeComponent();
            dispatcherTimer.Tick += counter;
            dispatcherTimer.Interval = new TimeSpan(0, 0, 0, 0, 1);
        }

        private void counter(object sender, EventArgs e)
        {
            time = time.AddSeconds(1);
            right_stoper.Content = time.ToString("HH:mm:ss");

        }

        private void start_Click(object sender, RoutedEventArgs e)
        {
            dispatcherTimer.Start();
        }

        private void stop_Click(object sender, RoutedEventArgs e)
        {
            dispatcherTimer.Stop();
        }
    }
}
