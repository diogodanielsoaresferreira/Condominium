using Condominium_Manager.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Threading;
using System.Configuration;
using System.Globalization;
using System.IO;

namespace Condominium_Manager.Pages
{
    /// <summary>
    /// Interaction logic for BuildingMainPage.xaml
    /// </summary>
    public partial class BuildingMainPage : UserControl
    {
        WindowViewModel vm;
        public Predio p { get; set; }
        public ObservableCollection<Predio> CollP
        {
            get { return new ObservableCollection<Predio>() { p }; }
        }
        public ObservableCollection<Evento> Eventos { get; set; }
        public List<Fracao> Fractions = new List<Fracao>();
        int ocupacao = 0;

        public int QuotasDel
        {
            get
            {
                return Pagamentos_Quota.numberQuotasAtrasadas(p.ID);
            }
        }

        public double BalancoD
        {
            get
            {
                return Transacao.get_Sum_Transactions(p.ID, DateTime.Now, new DateTime(1800, 1, 1));
            }
        }

        public string Balanco {
            get
            {
                return string.Format("{0:N2} €", BalancoD);
            }
        }

        public double BalancoMesD
        {
            get
            {
                return Transacao.get_Sum_Transactions(p.ID, DateTime.Now, DateTime.Now.AddMonths(-1));
            }
        }


        public string BalancoMes
        {
            get
            {
                return string.Format("{0:N2} €", BalancoMesD);
            }
        }

        public double ReceitaMesD
        {
            get
            {
                return Transacao.get_Sum_Receita(p.ID, DateTime.Now, DateTime.Now.AddMonths(-1));
            }
        }

        public string ReceitaMes
        {
            get
            {
                return string.Format("{0:N2} €", ReceitaMesD);
            }
        }

        public double DespesaMesD
        {
            get
            {
                return Transacao.get_Sum_Despesa(p.ID, DateTime.Now, DateTime.Now.AddMonths(-1));
            }
        }

        public string DespesaMes
        {
            get
            {
                return string.Format("{0:N2} €",DespesaMesD);
            }
        }


        public string Fracoes_Text
        {
            get
            {
                if (Fractions.Count() != 0)
                    return "Frações: "+(Math.Round(100 * ocupacao / (double)Fractions.Count(), 2)).ToString() + "%  ocupado (" + ocupacao + "/" + Fractions.Count() + ")";
                else
                    return "Frações: 0 % ocupado (" + ocupacao + "/" + Fractions.Count() + ")";
            } 
        }

        public string Estacionamentos_Text
        {
            get
            {
                return "";
            }
        }

        public string Current_Condominos_Text
        {
            get
            {
                return "Condóminos Atuais: "+Condomino.get_Number_Current_Condominos(p.ID);
            }
        }
        

        public BuildingMainPage(WindowViewModel vm, Predio p)
        {
            InitializeComponent();
            this.vm = vm;
            this.p = p;
            
            Map.Center = p.Location;

            IntervalTimer = Convert.ToInt32(ConfigurationManager.AppSettings["IntervalTime"]);
            strImagePath = ConfigurationManager.AppSettings["ImagePath"]+"/Predio_"+p.ID;
            ImageControls = new[] { myImage, myImage2 };
            
            LoadImages();

            timerImageChange = new DispatcherTimer();
            timerImageChange.Interval = new TimeSpan(0, 0, IntervalTimer);
            timerImageChange.Tick += new EventHandler(timerImageChange_Tick);

            List<Fracao> fractions = Fracao.get_All_Fractions(p.ID);

            foreach (Fracao fraction in fractions)
            {
                Fractions.Add(fraction);
                if (fraction.CurrentCondomino != null)
                    ocupacao += 1;
            }
            Eventos = new ObservableCollection<Evento>(Evento.get_Next_Events(p.ID));
            showColumnChart();
            
        }

        private void showColumnChart()
        {
            List<KeyValuePair<string, int>> valueList = new List<KeyValuePair<string, int>>();
            valueList.Add(new KeyValuePair<string, int>("Habitação", Fracao.count_Fractions_ByType(p.ID, "Habitação")));
            valueList.Add(new KeyValuePair<string, int>("Estacionamento", Fracao.count_Fractions_ByType(p.ID, "Estacionamento")));
            valueList.Add(new KeyValuePair<string, int>("Comercial", Fracao.count_Fractions_ByType(p.ID, "Comercial")));
            

            // Setting data for pie chart
            pieChart.DataContext = valueList;
            
        }

        #region Image Loader

        private DispatcherTimer timerImageChange;
        private Image[] ImageControls;
        private List<ImageSource> Images = new List<ImageSource>();
        private static string[] ValidImageExtensions = new[] { ".png", ".jpg", ".jpeg", ".bmp", ".gif" };
        private static string[] TransitionEffects = new[] { "Fade" };
        private string TransitionType, strImagePath = "";
        private int CurrentSourceIndex, CurrentCtrlIndex, EffectIndex = 0, IntervalTimer = 1;

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            PlaySlideShow();
            timerImageChange.IsEnabled = true;
        }

        private void LoadImages()
        {
            ErrorText.Visibility = Visibility.Collapsed;

            List<string> images = p.getImages();
            
            List<ImageSource> sources = new List<ImageSource>();
            foreach(var image in p.getImages())
            {
                if (File.Exists(image)){
                    sources.Add(CreateImageSource(image, true));
                }
            }

            if (images.Count == 0)
            {
                ErrorText.Text = "Sem imagens para este prédio";
                ErrorText.Visibility = Visibility.Visible;
                return;
            }

            Images.Clear();
            Images.AddRange(sources);
        }

        private ImageSource CreateImageSource(string file, bool forcePreLoad)
        {
            if (forcePreLoad)
            {
                var src = new BitmapImage();
                src.BeginInit();
                src.UriSource = new Uri(file, UriKind.Relative);
                src.CacheOption = BitmapCacheOption.OnLoad;
                src.EndInit();
                src.Freeze();
                return src;
            }
            else
            {
                var src = new BitmapImage(new Uri(file, UriKind.Relative));
                src.Freeze();
                return src;
            }
        }

        private void timerImageChange_Tick(object sender, EventArgs e)
        {
            PlaySlideShow();
        }

        private void PlaySlideShow()
        {
            try
            {
                if (Images.Count == 0)
                    return;
                var oldCtrlIndex = CurrentCtrlIndex;
                CurrentCtrlIndex = (CurrentCtrlIndex + 1) % 2;
                CurrentSourceIndex = (CurrentSourceIndex + 1) % Images.Count;

                Image imgFadeOut = ImageControls[oldCtrlIndex];
                Image imgFadeIn = ImageControls[CurrentCtrlIndex];
                ImageSource newSource = Images[CurrentSourceIndex];
                imgFadeIn.Source = newSource;


                TransitionType = TransitionEffects[EffectIndex].ToString();

                Storyboard StboardFadeOut = (Resources[string.Format("{0}Out", TransitionType.ToString())] as Storyboard).Clone();
                StboardFadeOut.Begin(imgFadeOut);
                Storyboard StboardFadeIn = Resources[string.Format("{0}In", TransitionType.ToString())] as Storyboard;
                StboardFadeIn.Begin(imgFadeIn);
            }
            catch (Exception ex) { }
        }

        #endregion Image Loader
    }
}
