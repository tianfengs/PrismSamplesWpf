using Prism.Ioc;
using Prism.Regions;
using Prism.Unity;
using Regions.Views;
using System.Windows;

namespace Regions
{
    using Regions.PrismDemo;
    using System.Windows.Controls;

    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : PrismApplication
    {
        protected override Window CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            
        }

        protected override void ConfigureRegionAdapterMappings(RegionAdapterMappings regionAdapterMappings)
        {
            base.ConfigureRegionAdapterMappings(regionAdapterMappings);
            regionAdapterMappings.RegisterMapping(typeof(StackPanel), 
                Container.Resolve<StackPanelRegionAdapter>());
        }
    }
}
