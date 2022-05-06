using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.Navigation
{
   public class NavigationModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {
            var regionManager = containerProvider.Resolve<IRegionManager>();
            regionManager.RegisterViewWithRegion("LeftRegion", typeof(Demo.Navigation.Views.Navigation));
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {

        }
    }
}
