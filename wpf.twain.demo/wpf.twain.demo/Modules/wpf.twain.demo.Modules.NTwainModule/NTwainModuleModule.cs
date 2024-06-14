using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using wpf.twain.demo.Core;
using wpf.twain.demo.Modules.NTwainModule.Views;

namespace wpf.twain.demo.Modules.NTwainModule
{
    public class NTwainModuleModule : IModule
    {
        private readonly IRegionManager _regionManager;

        public NTwainModuleModule(IRegionManager regionManager)
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