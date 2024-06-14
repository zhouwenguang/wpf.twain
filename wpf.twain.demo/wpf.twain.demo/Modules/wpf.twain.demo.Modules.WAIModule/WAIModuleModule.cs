using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using wpf.twain.demo.Core;
using wpf.twain.demo.Modules.WAIModule.Views;

namespace wpf.twain.demo.Modules.WAIModule
{
    public class WAIModuleModule : IModule
    {
        private readonly IRegionManager _regionManager;

        public WAIModuleModule(IRegionManager regionManager)
        {
            _regionManager = regionManager;
        }

        public void OnInitialized(IContainerProvider containerProvider)
        {
            _regionManager.RequestNavigate(RegionNames.ContentRegion, "ViewA");
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<ViewA>();
        }
    }
}