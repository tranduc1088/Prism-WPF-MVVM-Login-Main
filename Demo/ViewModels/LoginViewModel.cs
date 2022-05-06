using Demo.Common.Model;
using Demo.Common.ViewModels;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Demo.ViewModels
{
	public class LoginViewModel : BaseViewModel
	{
		public bool IsLogin { get; set; }
		private string _UserName;
		public string UserName
		{ get => _UserName; set { _UserName = value; } }
		private string _Password;
		public string Password { get => _Password; set { _Password = value; } }
		public ICommand PasswordChangedCommand { get; set; }
		public ICommand LoginCommand { get; set; }
		ObservableCollection<Demo.Common.Model.Users> users;
		public LoginViewModel()
		{
			users = new ObservableCollection<Users>()
			{
				new  Users () {Username = "admin" , Password = "1", UserDisplayName="Hữu Đức" },

				new  Users () {Username = "staff" , Password = "2",UserDisplayName="Nhân viên"}
			};
			LoginCommand = new RelayCommand<Window>((p) => { return true; }, (p) =>
			{
				Login(p);

			});
			PasswordChangedCommand = new RelayCommand<PasswordBox>((p) => { return true; }, (p) =>
			{
				Password = p.Password;
			});
		}
		void Login(Window p)
		{
			if (p == null)
				return;
			var accCount = users.Where(x => x.Username == UserName && x.Password == Password).Count();
			if (accCount > 0)
			{
				IsLogin = true;
				p.Close();
			}
			else
			{
				IsLogin = false;
				MessageBox.Show("Sai tài khoản hoặc mật khẩu!", "HDCSoft - Thông Báo");
			}
		}
	}
}
