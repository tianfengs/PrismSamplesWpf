using Prism.Ioc;
using Prism.Unity;
using System.Windows;
using ViewModelLocator.Views;

namespace ViewModelLocator
{
    using System;
    using System.Globalization;
    using System.Reflection;
    using Prism.Mvvm;
    using ViewModelLocator.ViewModels;

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

        /// <summary>
        /// 不用默认的名称命名规则配对Views和ViewModels
        /// 1. 用ViewModelLocationProvider.SetDefaultViewTypeToViewModelTypeResolver建立新的规则
        /// 2. 用ViewModelLocationProvider.Register<>直接配对
        /// </summary>
        protected override void ConfigureViewModelLocator()
        {
            base.ConfigureViewModelLocator();

            //ViewModelLocationProvider.SetDefaultViewTypeToViewModelTypeResolver(
            //    (viewType) =>
            //    {
            //        var viewName = viewType.FullName;
            //        var viewAssemblyName = viewType.GetType().Assembly.FullName;
            //        var viewModelName = $"{viewName}VM, {viewAssemblyName}"; //viewName 中引用了Views地址而不是ViewModels，所以找不到
            //        return Type.GetType(viewModelName);
            //    });

            // 1. 设置加VM的规则
            ViewModelLocationProvider.SetDefaultViewTypeToViewModelTypeResolver(
                (viewType) =>
                {
                    var viewName = viewType.FullName;
                    viewName = viewName.Replace(".Views.", ".ViewModels.");
                    var viewAssemblyName = viewType.GetTypeInfo().Assembly.FullName;
                    var suffix = viewName.EndsWith("View") ? "Model" : "VM";
                    var viewModelName = String.Format(CultureInfo.InvariantCulture,
                        "{0}{1}, {2}", viewName, suffix, viewAssemblyName);
                    //var viewModelName = $"{viewName}VM";
                    return Type.GetType(viewModelName);
                });

            // 2. 直接绑定MainWindowVM
            //ViewModelLocationProvider.Register<MainWindow, MainWindowVM>();
        }

       
    }
}
