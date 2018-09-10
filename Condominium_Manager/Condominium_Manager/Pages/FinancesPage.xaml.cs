using Condominium_Manager.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
    /// Interaction logic for FinancesPage.xaml
    /// </summary>
    public partial class FinancesPage : UserControl, INotifyPropertyChanged
    {
        private WindowViewModel vm;
        private Predio p;

        private DateTime _startDate = DateTime.Now.AddMonths(-1);
        private DateTime _endDate = DateTime.Now;

        public event PropertyChangedEventHandler PropertyChanged = (sender, e) => { };

        private ObservableCollection<Transacao> _Transacoes { get; set; }

        public ObservableCollection<Transacao> Transacoes
        {
            get
            {
                return _Transacoes;
            }
            set
            {
                _Transacoes = value;
            }
        }

        public DateTime StartDate
        {
            get
            {
                return _startDate;
            }
            set
            {
                _startDate = value;
                Transacoes = new ObservableCollection<Transacao>(Outros_Pagamentos.get_OutrosPagamentos(p, EndDate, StartDate).Union(new ObservableCollection<Transacao>(Pagamentos_Quota.get_Quotas(p.ID, EndDate, StartDate))));
                PropertyChanged(this, new PropertyChangedEventArgs("Transacoes"));
            }
        }
        public DateTime EndDate
        {
            get
            {
                return _endDate;
            }
            set
            {
                _endDate = value;
                Transacoes = new ObservableCollection<Transacao>(Outros_Pagamentos.get_OutrosPagamentos(p, EndDate, StartDate).Union(new ObservableCollection<Transacao>(Pagamentos_Quota.get_Quotas(p.ID, EndDate, StartDate))));
                PropertyChanged(this, new PropertyChangedEventArgs("Transacoes"));
            }
        }

        public FinancesPage(WindowViewModel vm, Predio p)
        {
            InitializeComponent();
            this.vm = vm;
            this.p = p;
            showColumnChart();
            Transacoes = new ObservableCollection<Transacao>(Outros_Pagamentos.get_OutrosPagamentos(p, EndDate, StartDate).Union(new ObservableCollection<Transacao>(Pagamentos_Quota.get_Quotas(p.ID, EndDate, StartDate))));
            PropertyChanged(this, new PropertyChangedEventArgs("Transacoes"));
        }

        private void showColumnChart()
        {
            List<KeyValuePair<string, double>> valueList = new List<KeyValuePair<string, double>>();

            double ov_value = Transacao.get_Sum_Transactions(p.ID, DateTime.Now.AddMonths(-11), new DateTime(1800, 1, 1));

            valueList.Add(new KeyValuePair<string, double>(DateTime.Now.AddMonths(-11).ToString("MM/yy"), ov_value));
            ov_value += Transacao.get_Sum_Transactions(p.ID, DateTime.Now.AddMonths(-10), DateTime.Now.AddMonths(-11));
            valueList.Add(new KeyValuePair<string, double>(DateTime.Now.AddMonths(-10).ToString("MM/yy"), ov_value));
            ov_value += Transacao.get_Sum_Transactions(p.ID, DateTime.Now.AddMonths(-9), DateTime.Now.AddMonths(-10));
            valueList.Add(new KeyValuePair<string, double>(DateTime.Now.AddMonths(-9).ToString("MM/yy"), ov_value));
            ov_value += Transacao.get_Sum_Transactions(p.ID, DateTime.Now.AddMonths(-8), DateTime.Now.AddMonths(-9));
            valueList.Add(new KeyValuePair<string, double>(DateTime.Now.AddMonths(-8).ToString("MM/yy"), ov_value));
            ov_value += Transacao.get_Sum_Transactions(p.ID, DateTime.Now.AddMonths(-7), DateTime.Now.AddMonths(-8));
            valueList.Add(new KeyValuePair<string, double>(DateTime.Now.AddMonths(-7).ToString("MM/yy"), ov_value));
            ov_value += Transacao.get_Sum_Transactions(p.ID, DateTime.Now.AddMonths(-6), DateTime.Now.AddMonths(-7));
            valueList.Add(new KeyValuePair<string, double>(DateTime.Now.AddMonths(-6).ToString("MM/yy"), ov_value));
            ov_value += Transacao.get_Sum_Transactions(p.ID, DateTime.Now.AddMonths(-5), DateTime.Now.AddMonths(-6));
            valueList.Add(new KeyValuePair<string, double>(DateTime.Now.AddMonths(-5).ToString("MM/yy"), ov_value));
            ov_value += Transacao.get_Sum_Transactions(p.ID, DateTime.Now.AddMonths(-4), DateTime.Now.AddMonths(-5));
            valueList.Add(new KeyValuePair<string, double>(DateTime.Now.AddMonths(-4).ToString("MM/yy"), ov_value));
            ov_value += Transacao.get_Sum_Transactions(p.ID, DateTime.Now.AddMonths(-3), DateTime.Now.AddMonths(-4));
            valueList.Add(new KeyValuePair<string, double>(DateTime.Now.AddMonths(-3).ToString("MM/yy"), ov_value));
            ov_value += Transacao.get_Sum_Transactions(p.ID, DateTime.Now.AddMonths(-2), DateTime.Now.AddMonths(-3));
            valueList.Add(new KeyValuePair<string, double>(DateTime.Now.AddMonths(-2).ToString("MM/yy"), ov_value));
            ov_value += Transacao.get_Sum_Transactions(p.ID, DateTime.Now.AddMonths(-1), DateTime.Now.AddMonths(-2));
            valueList.Add(new KeyValuePair<string, double>(DateTime.Now.AddMonths(-1).ToString("MM/yy"), ov_value));
            ov_value += Transacao.get_Sum_Transactions(p.ID, DateTime.Now, DateTime.Now.AddMonths(-1));
            valueList.Add(new KeyValuePair<string, double>(DateTime.Now.ToString("MM/yy"), ov_value));
            

            //Setting data for line chart
            lineChart.DataContext = valueList;
        }
    }
}
