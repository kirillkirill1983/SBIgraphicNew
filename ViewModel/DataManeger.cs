using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Legends;
using OxyPlot.Series;
using SBIgraphic.Model;
using SBIgraphic.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace SBIgraphic.ViewModel
{

    public class DataManeger : INotifyPropertyChanged
    {
        public DataManeger()
        {
            setUpModel();
        }
        public PlotModel MyModel { get; set; }


        private PlotModel setUpModel()
        {

            MyModel = new PlotModel { Title = "Example 1" };
            MyModel.Series.Add(new FunctionSeries(Math.Cos, 0, 10, 0.1, "cos(x)"));
            return MyModel;
        }





        private readonly LoaderDB loaderDB = new LoaderDB();

        private List<Plavka> allPlavka = DataWorker.GetAllPlavka();
        public List<Plavka> AllPlavka
        {
            get { return allPlavka; }
            set
            {
                allPlavka = value;
                NotifyPropertyChanged("AllPlavka");
            }
        }


        private List<ZamerHirina> allHirina = DataWorker.GetAllHirina();
        public List<ZamerHirina> AllHirina
        {
            get { return allHirina; }
            set
            {
                allHirina = value;
                NotifyPropertyChanged("AllHirina");
            }
        }


        private List<ZamerTolchina> allTolshina = DataWorker.GetAllTolshina();
        public List<ZamerTolchina> AllTolshina
        {
            get { return allTolshina; }
            set
            {
                allTolshina = value;
                NotifyPropertyChanged("AllHirina");
            }
        }
        //plot model



        //свойства для выделения элементов
        public TabItem SelecTabItem { get; set; }
        public Plavka? selectPlavka { get; set; }

        private RelayCommand updatePlavki;
        public RelayCommand UpdatePlavki
        {
            get
            {
                return updatePlavki ?? new RelayCommand(obj =>
                {
                    loaderDB.CreateDb();
                });
            }
        }
        private RelayCommand openPlavki;
        public RelayCommand OpenPlavki
        {
            get
            {
                return openPlavki ?? new RelayCommand(obj =>
                {
                    UpdateListPlavki();
                });
            }
        }
        private RelayCommand openShirina;
        public RelayCommand OpenShirina
        {
            get
            {
                return openShirina ?? new RelayCommand(obj =>
                {
                    if (selectPlavka.Id == null)
                    {
                        ShowMessageToUser("Error");
                    }
                    try
                    {
                        AllHirina = DataWorker.GetAllZamerHirinaByPlavkaId(selectPlavka.Id);
                        AllTolshina = DataWorker.GetAllZamerTolshinaByPlavkaId(selectPlavka.Id);
                        View.MainWindow.AllViewShirina.ItemsSource = AllHirina;
                        View.MainWindow.AllViewTolshina.ItemsSource = AllTolshina;

                    }
                    catch (Exception ex)
                    {

                        ShowMessageToUser(ex.ToString());
                    }


                });
            }
        }
        private void ShowMessageToUser(string message)
        {
            MessageView messageView = new MessageView(message);
            SetCenterPositionAndOpen(messageView);
        }

        private void SetCenterPositionAndOpen(Window window)
        {
            window.Owner = Application.Current.MainWindow;
            window.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            window.ShowDialog();
        }
        private void UpdateListPlavki()
        {

            AllPlavka = DataWorker.GetAllPlavka();

            View.MainWindow.AllViewPlavki.ItemsSource = AllPlavka;


        }
        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(String propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

    }
}
