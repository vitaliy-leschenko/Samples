using System;
using System.Collections.Generic;
using System.Globalization;
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

namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private bool needToDataSetup;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void OnSourceMouseMove(object sender, MouseEventArgs e)
        {
            if (needToDataSetup)
            {
                var obj = DateTime.Now.ToString(CultureInfo.CurrentCulture);
                var data = new DataObject("TestAppFormat", obj);
                DragDrop.DoDragDrop(this, data, DragDropEffects.Copy);

                needToDataSetup = false;
            }
        }

        private void OnSourceMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            needToDataSetup = true;
        }

        private void OnTargetDargEnter(object sender, DragEventArgs e)
        {
            e.Effects = e.Data.GetFormats().Contains("TestAppFormat") ? DragDropEffects.Copy : DragDropEffects.None;
        }

        private void OnTargetDrop(object sender, DragEventArgs e)
        {
            var data = e.Data.GetData("TestAppFormat");
            ((TextBlock) sender).Text = data.ToString();
            e.Handled = true;
        }
    }
}
