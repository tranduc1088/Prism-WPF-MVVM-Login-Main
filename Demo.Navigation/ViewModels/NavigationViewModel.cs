using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.Navigation.ViewModels
{
	public class NavigationViewModel : BindableBase
	{
		private readonly IRegionManager _regionManager;
		public DelegateCommand ShowManualButton { get; }
		public NavigationViewModel(IRegionManager regionManager)
		{
			_regionManager = regionManager;
			ShowManualButton = new DelegateCommand(ShowManualButtonExecute);
		}
		private void ShowManualButtonExecute()
		{
			_regionManager.RequestNavigate("MainRegion", nameof(Demo.Manual.Views.Manual));
		}
	}
}
