using Condominium_Manager.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Condominium_Manager.Pages
{
    /// <summary>
    /// Interaction logic for FractionPage.xaml
    /// </summary>
    public partial class FractionPage : UserControl
    {

        private WindowViewModel vm;
        public Fracao f { get; set; }
        private Predio p;
        public ObservableCollection<Compra> Compras { get; set; }
        private DateTime DateStart;
        private DateTime DateEnd;

        public FractionPage(WindowViewModel vm, Fracao f, Predio p)
        {
            InitializeComponent();
            this.vm = vm;
            this.f = f;
            this.p = p;
            Compras = new ObservableCollection<Compra>(f.getAllCompras());
            

            if (Compras.Count>0 && Compras.Last()._Data_Venda == DateTime.MaxValue)
                Compra = true;
            else
                Compra = false;

            IntervalTimer = Convert.ToInt32(ConfigurationManager.AppSettings["IntervalTime"]);
            strImagePath = ConfigurationManager.AppSettings["ImagePath"] + "/Fracao_" + f.ID;
            ImageControls = new[] { myImage, myImage2 };

            LoadImages();
            

            timerImageChange = new DispatcherTimer();
            timerImageChange.Interval = new TimeSpan(0, 0, IntervalTimer);
            timerImageChange.Tick += new EventHandler(timerImageChange_Tick);
        }

        public bool Compra { get; set; }

        public bool Venda
        {
            get
            {
                return !Compra;
            }
        }

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

        private void EditarInfo(object sender, RoutedEventArgs e)
        {
            vm.changeViewEditFraction(p, f);
        }

        private void FractionsPage(object sender, RoutedEventArgs e)
        {
            vm.changeViewFractions(p);
        }

        private void CompraButton(object sender, RoutedEventArgs e)
        {
            if(Compras.Count>0)
                vm.changeViewCompraPage(p, f, Compras.Last()._Data_Venda.AddDays(1));
            else
                vm.changeViewCompraPage(p, f, DateTime.MinValue);
        }

        private void VendaButton(object sender, RoutedEventArgs e)
        {
            vm.changeViewVendaPage(p, f, Compras.Last(), Compras.Last()._Data_Compra.AddDays(1));
        }

        private void LoadImages()
        {
            ErrorText.Visibility = Visibility.Collapsed;

            List<string> images = f.getImages();

            List<ImageSource> sources = new List<ImageSource>();
            foreach (var image in images)
            {
                if (File.Exists(image))
                {
                    sources.Add(CreateImageSource(image, true));
                }
            }

            if (images.Count == 0)
            {
                ErrorText.Text = "Sem imagens para esta fração";
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
                {
                    return;
                }
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
    }
}
