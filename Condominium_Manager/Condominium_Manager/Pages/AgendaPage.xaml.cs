using Condominium_Manager.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Media;

namespace Condominium_Manager.Pages
{
    /// <summary>
    /// Interaction logic for AgendaPage.xaml
    /// </summary>
    public partial class AgendaPage : UserControl, INotifyPropertyChanged
    {
        private WindowViewModel vm;
        private Predio p;
        public ObservableCollection<Evento> Eventos { get; set; }
        public ObservableCollection<Evento> DayEvents { get; set; }

        /// <summary>
        /// Cache to prevent the retrieval of date already in memory
        /// </summary>
        public Dictionary<DateTime, bool> cache = new Dictionary<DateTime, bool>();

        public AgendaPage(WindowViewModel vm, Predio p)
        {
            InitializeComponent();
            this.vm = vm;
            this.p = p;
            Eventos = new ObservableCollection<Evento>(Evento.get_Next_Events(p.ID));

        }

        private void Calendar_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {
            DateTime dt = ((DateTime)(sender as Calendar).SelectedDate);
            DayEvents = new ObservableCollection<Evento>(Evento.get_Day_Events(p.ID, dt));
            PropertyChanged(this, new PropertyChangedEventArgs("DayEvents"));
        }

        private void calendarButton_Loaded(object sender, EventArgs e)
        {
            CalendarDayButton button = (CalendarDayButton)sender;
            DateTime date = (DateTime)button.DataContext;
            HighlightDay(button, date);
            button.DataContextChanged += new DependencyPropertyChangedEventHandler(calendarButton_DataContextChanged);
        }

        private void HighlightDay(CalendarDayButton button, DateTime date)
        {

            if (cache.ContainsKey(date))
            {
                if (cache[date])
                {
                    button.Background = Brushes.LightBlue;
                    
                }
                else
                {
                    button.Background = Brushes.White;
                }
                return;
            }

            if (Evento.get_Day_Events(p.ID, date).Count>0)
            {
                cache.Add(date, true);
                button.Background = Brushes.LightBlue;
            }
            else{
                cache.Add(date, false);
                button.Background = Brushes.White;
            }
            

        }

        private void calendarButton_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            CalendarDayButton button = (CalendarDayButton)sender;
            DateTime date = (DateTime)button.DataContext;
            HighlightDay(button, date);
        }

        #region INotifyPropertyChanged Members
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        private void AddNota(object sender, RoutedEventArgs e)
        {
            if (calendar.SelectedDate == null)
                MessageBox.Show("Selecione uma data no calendário", "Selecione uma data", MessageBoxButton.OK, MessageBoxImage.Warning);
            else
                vm.changeViewAddNota((DateTime)calendar.SelectedDate, p);
        }

        private void AddAviso(object sender, RoutedEventArgs e)
        {
            if (calendar.SelectedDate == null)
                MessageBox.Show("Selecione uma data no calendário", "Selecione uma data", MessageBoxButton.OK, MessageBoxImage.Warning);
            else
                vm.changeViewAddAviso((DateTime)calendar.SelectedDate, p);
        }

        private void AddReuniao(object sender, RoutedEventArgs e)
        {
            if (calendar.SelectedDate == null)
                MessageBox.Show("Selecione uma data no calendário", "Selecione uma data", MessageBoxButton.OK, MessageBoxImage.Warning);
            else
                vm.changeViewAddReuniao((DateTime)calendar.SelectedDate, p);
        }

        private void AddManutencao(object sender, RoutedEventArgs e)
        {
            if (calendar.SelectedDate == null)
                MessageBox.Show("Selecione uma data no calendário", "Selecione uma data", MessageBoxButton.OK, MessageBoxImage.Warning);
            else
                vm.changeViewAddManutencao((DateTime)calendar.SelectedDate, p);
        }
    }
}
