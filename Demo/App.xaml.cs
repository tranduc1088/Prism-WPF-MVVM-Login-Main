using Demo.Views;
using Demo.ViewModels;
using Demo.Manual.Views;

using Prism.Ioc;
using Prism.Modularity;
using System.Globalization;
using System.Threading;
using System.Windows;
using System.Windows.Markup;

namespace Demo
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
		protected override Window CreateShell()
		{
            return Container.Resolve<Main>();

        }

		protected override void RegisterTypes(IContainerRegistry containerRegistry)
		{
			containerRegistry.RegisterForNavigation<Manual.Views.Manual>();
		}

		protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
		{
            moduleCatalog.AddModule <Demo.Navigation.NavigationModule>();
            moduleCatalog.AddModule<Manual.ManualModule>();

        }
        protected override void OnInitialized()
        {
            var login = Container.Resolve<Login>();
            var loginVM = login.DataContext as LoginViewModel;
            var result = login.ShowDialog();
            if (loginVM.IsLogin)
            {
                base.OnInitialized();
                loginVM.IsLogin = false;
            }    
            else
                Application.Current.Shutdown();
        }

    }
}