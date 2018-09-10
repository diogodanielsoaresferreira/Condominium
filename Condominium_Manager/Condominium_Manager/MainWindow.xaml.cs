using Condominium_Manager.Pages;
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

namespace Condominium_Manager
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        WindowViewModel vm;

        public MainWindow()
        {
            InitializeComponent();
            vm = new WindowViewModel(this);
            this.DataContext = vm;
        }

        private void Choose_Building_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox cb = sender as ComboBox;


            if (cb.SelectedIndex < 0)
            {
                return;
            }
            
            if(vm.page == ApplicationPage.Buildings_Page)
            {
                (vm.CurrentPage as BuildingsPage).p = vm.Buildings[cb.SelectedIndex];
                (vm.CurrentPage as BuildingsPage).show_Building(vm.Buildings[cb.SelectedIndex]);
            }
            else if (vm.page == ApplicationPage.Add_Building || vm.page == ApplicationPage.Edit_Building)
            {
                vm.changeViewInitialPage(cb.SelectedIndex);
            }   
            else if (vm.page == ApplicationPage.Building_Main_Page)
            {
                vm.changeViewEnterB(vm.Buildings[cb.SelectedIndex]);
            }
            else
            {
                vm.changeViewEnterB(vm.Buildings[cb.SelectedIndex]);
            }

        }

        private void ChangeViewInitialPage(object sender, RoutedEventArgs e)
        {
            vm.page = ApplicationPage.Buildings_Page;
            vm.Column1Width = new GridLength(0, GridUnitType.Star);
        }
    }
}
