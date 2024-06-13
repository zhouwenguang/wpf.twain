using Prism.Ioc;
using Prism.Modularity;
using System.Windows;
using wpf.twain.demo.Modules.ModuleName;
using wpf.twain.demo.Services;
using wpf.twain.demo.Services.Interfaces;
using wpf.twain.demo.Views;

namespace wpf.twain.demo
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        protected override Window CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<IMessageService, MessageService>();
        }

        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            moduleCatalog.AddModule<ModuleNameModule>();
        }
    }
}
