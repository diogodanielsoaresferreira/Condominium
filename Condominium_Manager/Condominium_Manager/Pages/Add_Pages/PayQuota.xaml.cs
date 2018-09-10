using Condominium_Manager.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace Condominium_Manager.Pages.Add_Pages
{
    /// <summary>
    /// Interaction logic for PayQuota.xaml
    /// </summary>
    public partial class PayQuota : UserControl
    {
        private WindowViewModel vm;
        public Fracao f { get; set; }
        private Predio p;
        public DateTime DateStart { get; set; } = DateTime.Now.AddYears(-5);
        public DateTime DateEnd { get; set; } = DateTime.Now.AddYears(5);
        public int Month { get; set; } = DateTime.Now.Month - 1;
        public ApplicationPage pg;
        public string Data_Pagar
        {
            get
            {
                return data.ToString("MM/yyyy");
            }
        }
        private DateTime data { get; set; }

        public PayQuota(WindowViewModel vm, int fracao_id, Predio p, ApplicationPage ap)
        {
            InitializeComponent();
            f = Fracao.getFracaoByID(fracao_id);
            this.p = p;
            this.vm = vm;
            this.pg = ap;

            DateTime last_month_quota = f.getLastQuota();
            DateTime compra_date = f.getBuyDate();
            
            
            if (DateTime.MinValue == last_month_quota || compra_date.Year>last_month_quota.Year || (compra_date.Year == last_month_quota.Year && compra_date.Month > last_month_quota.Month))
            {
                data = compra_date;
            }
            else
            {
                data = last_month_quota.AddMonths(1);
            }

        }
        
        private void QuotaPageButton(object sender, RoutedEventArgs e)
        {
            if (pg == ApplicationPage.Quota_Page)
                vm.changeviewQuotaPage(p);
            else
                vm.changeViewCondominosPage();
        }

        private void PayQuotaButton(object sender, RoutedEventArgs e)
        {

            Pagamentos_Quota pq = new Pagamentos_Quota(DateTime.Now, f.Quota, f, new DateTime(data.Year, data.Month, 1));
            pq.save();
            if (pg == ApplicationPage.Quota_Page)
                vm.changeviewQuotaPage(p);
            else
                vm.changeViewCondominosPage();
        }
        
    }
}
