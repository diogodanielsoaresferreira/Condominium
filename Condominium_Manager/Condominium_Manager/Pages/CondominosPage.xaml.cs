using Condominium_Manager.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace Condominium_Manager.Pages
{
    /// <summary>
    /// Interaction logic for FractionsPage.xaml
    /// </summary>
    public partial class CondominosPage : UserControl
    {
        WindowViewModel vm;
        private Predio p;
        private ObservableCollection<CondominoQuotaView> _Items = new ObservableCollection<CondominoQuotaView>();
        public ObservableCollection<Condomino> AllCondominos { get; set; }

        public ObservableCollection<CondominoQuotaView> Items
        {
            get { return _Items; }
        }

        public CondominosPage(WindowViewModel vm, Predio p)
        {
            InitializeComponent();
            this.vm = vm;
            this.p = p;

            List<CondominoQuotaView> condominos = CondominoQuotaView.get_All_Current_Condominos(p.ID);
 
            foreach(var condomino in condominos)
            {
                _Items.Add(condomino);
            }

            AllCondominos = new ObservableCollection<Condomino>(Condomino.get_All_Condominos(p.ID));


        }

        private void AddCondomino(object sender, RoutedEventArgs e)
        {
            vm.changeViewAddCondomino();
        }

        public int QuotasAtraso {
            get
            {
                return Pagamentos_Quota.numberQuotasAtrasadas(p.ID);
            }
        }

        public int TotalCondominos
        {
            get
            {
                return Condomino.get_All_Current_Condominos(p.ID).Count;
            }
        }

        private void Pay_Quota(object sender, RoutedEventArgs e)
        {
            vm.changeViewPayQuota(((CondominoQuotaView)CondominoGrid.SelectedItem).f.ID, p, ApplicationPage.Condominos_Page);
        }
    }
}
