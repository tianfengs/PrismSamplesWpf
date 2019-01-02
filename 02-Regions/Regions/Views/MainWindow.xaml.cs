using Prism.Regions;
using System.Windows;
using Unity;

namespace Regions.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        ///// <summary>
        ///// view discovery方式
        ///// </summary>
        ///// <param name="regionManager"></param>
        //public MainWindow(IRegionManager regionManager)
        //{
        //    InitializeComponent();

        //    regionManager.RegisterViewWithRegion("ContentRegion", typeof(ViewA));
        //}

        //////////////////////////////////////////////////////////
        /// View Injection方式
        IUnityContainer container;
        IRegionManager regionManager;
        IRegion region;
        ViewA view;
        /// <summary>
        /// View Injection方式
        /// </summary>
        /// <param name="container"></param>
        /// <param name="regionManager"></param>
        public MainWindow(IUnityContainer container, IRegionManager regionManager)
        {
            InitializeComponent();
            this.container = container;
            this.regionManager = regionManager;            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            view = container.Resolve<ViewA>();
            region = regionManager.Regions["ContentRegion"];
            region.Add(view);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            region.Activate(view);
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            region.Deactivate(view);
        }
    }
}
