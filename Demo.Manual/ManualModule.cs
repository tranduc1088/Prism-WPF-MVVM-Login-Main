using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.Manual
{
   public class ManualModule : IModule
	{
		public void OnInitialized(IContainerProvider containerProvider)
		{
			containerProvider.Resolve<IRegionManager>();
		}

		public void RegisterTypes(IContainerRegistry containerRegistry)
		{

		}
	}
}
