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
using System.Windows.Threading;

namespace Awooo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void button_start_Click(object sender, RoutedEventArgs e)
        {
            button_start.IsEnabled = false;

            label_started.Content = (string)FindResource("label_wip");

            DispatcherTimer timer = new DispatcherTimer();
            timer.Tick += Timer_Tick;
            timer.Interval = new TimeSpan(0, 0, 1);
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if(progress.Value < progress.Maximum)
            {
                progress.Value++;
                label_actual.Content = (string)FindResource("label_progress_" + progress.Value);
            }
            else if (progress.Value == progress.Maximum)
            {
                if (sender is DispatcherTimer)
                    ((DispatcherTimer)sender).Stop();

                int awooCount = Environment.TickCount % 8 + 1;
                for (int i = 0; i < awooCount; i++)
                {
                    AwoooInProgress aip = new AwoooInProgress();
                    aip.Show();
                }
            }
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
