using Condominium_Manager.DataModels;
using Condominium_Manager.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.SqlClient;
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

namespace Condominium_Manager.Pages
{
    /// <summary>
    /// Interaction logic for QuotaPage.xaml
    /// </summary>
    public partial class QuotaPage : UserControl, INotifyPropertyChanged
    {
        private WindowViewModel vm;
        private Predio p;

        public ObservableCollection<QuotaView> Quotas { get; set; } = new ObservableCollection<QuotaView>();
        public event PropertyChangedEventHandler PropertyChanged;
        public ObservableCollection<string> Years { get; set; } = new ObservableCollection<string>();

        
        public QuotaPage(WindowViewModel vm, Predio p)
        {
            InitializeComponent();
            this.vm = vm;
            this.p = p;
            Years.Add(DateTime.Now.AddYears(-5).ToString("yyyy"));
            Years.Add(DateTime.Now.AddYears(-4).ToString("yyyy"));
            Years.Add(DateTime.Now.AddYears(-3).ToString("yyyy"));
            Years.Add(DateTime.Now.AddYears(-2).ToString("yyyy"));
            Years.Add(DateTime.Now.AddYears(-1).ToString("yyyy"));
            Years.Add(DateTime.Now.ToString("yyyy"));
            Years.Add(DateTime.Now.AddYears(1).ToString("yyyy"));
            Years.Add(DateTime.Now.AddYears(2).ToString("yyyy"));
            Years.Add(DateTime.Now.AddYears(3).ToString("yyyy"));
            Years.Add(DateTime.Now.AddYears(4).ToString("yyyy"));
            Years.Add(DateTime.Now.AddYears(5).ToString("yyyy"));
            Quotas = new ObservableCollection<QuotaView>(QuotaView.getAllQuotas(p, int.Parse(DateTime.Now.ToString("yyyy"))));

        }

        private void CB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(CB.SelectedValue != null)
            {
                Quotas = new ObservableCollection<QuotaView>(QuotaView.getAllQuotas(p, int.Parse(CB.SelectedValue.ToString())));
                PropertyChanged(this, new PropertyChangedEventArgs(nameof(Quotas)));
            }
        }

        private void PayQuota(object sender, RoutedEventArgs e)
        {
            QuotaView QuotaSelected = (QuotaView)QuotaGrid.SelectedItem;
            vm.changeViewPayQuota(QuotaSelected.Fracao_Id, p, ApplicationPage.Quota_Page);
        }
    }

    
}
