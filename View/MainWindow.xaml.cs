using SBIgraphic.Model;
using SBIgraphic.ReadFile;
using SBIgraphic.ViewModel;
using System;
using System.Globalization;
using System.Linq;
using System.Windows;
using SBIgraphic.ViewModel;
using System.Windows.Controls;
using OxyPlot;
using OxyPlot.Series;

namespace SBIgraphic.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static ListView AllViewPlavki;
        public static ListView AllViewShirina;
        public static ListView AllViewTolshina;
        private MainWindow GetMainWindow;


        public MainWindow()
        {

            InitializeComponent();

            DataContext = new DataManeger();
            AllViewPlavki = ViewAllPlavki;
            AllViewShirina = ViewAllShirina;
            AllViewTolshina = ViewAllTolshina;


        }

        private void ConnectBD_Click(object sender, RoutedEventArgs e)
        {
            ConnectBD.IsEnabled = false;
        }
    }
}
