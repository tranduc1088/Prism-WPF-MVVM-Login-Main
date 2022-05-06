using Demo.Common.ViewModels;
using Demo.Views;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Input;

namespace Demo.ViewModels
{
    public class MainViewModel : BindableBase
    {
        private readonly IRegionManager _regionManager;
        public string Title => "Dashboard - HDCSoft";
        public DelegateCommand ShowManualButton { get; }
        public DelegateCommand LoadeddWindowCommand { get; set; }
        public ICommand LogoutCommand { get; set; }
        public MainViewModel(IRegionManager regionManager)
        {
            _regionManager = regionManager;
            ShowManualButton = new DelegateCommand(ShowManualButtonExecute);
            LogoutCommand = new RelayCommand<Window>((p) => { return true; }, (p) =>
            {
                Logout(p);

            });
        }
        private void ShowLoginExcute()
        {

        }
        private void ShowManualButtonExecute()
        {
            _regionManager.RequestNavigate("MainRegion", nameof(Demo.Manual.Views.Manual));
        }
        void Logout(Window p)
        {

            //kiểm tra p nếu null return
            if (p == null)
                return;
            p.Hide();
            Login loginWindow = new Login();
            //kiểm tra DataContext nếu null return
            if (loginWindow.DataContext == null)
                return;
            var loginVM = loginWindow.DataContext as LoginViewModel;
            loginVM.Password = "";
            loginWindow.ShowDialog();
            if (loginVM.IsLogin)
            {
                p.Show();
            }
            else
            {
                p.Close();

            }
        }
    }
}
