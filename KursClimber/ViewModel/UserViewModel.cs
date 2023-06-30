using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using KursClimber.Model;
using KursClimber.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using XSystem.Security.Cryptography;

namespace KursClimber.ViewModel
{
    public partial class UserViewModel : ObservableValidator
    {
        private DateBaseClimberContext db;
        private LoginView window;

        public UserViewModel(LoginView window)
        {
            this.window = window;
            db = new DateBaseClimberContext();
        }

        [RelayCommand]
        private void Login(object obj)
        {
            string login = window.LoginBox.Text;
            string password = Hash(window.PasswordBox.Password);
            User user = db.Users.Where(p => p.Login == login && p.Password == password).FirstOrDefault();
            if (user != null)
            {
                HomePageView homePageView = new HomePageView();
                homePageView.Show();
                window.Close();
            }
            else
            {
                MessageBox.Show("Не правильный логин или пароль");
            }
        }
        [RelayCommand]
        private void Register(object obj)
        {
            try
            {
                User user = new User();
                user.Login = window.LoginBox.Text;
                user.Password = Hash(window.PasswordBox.Password);
                db.Users.Add(user);
                int res = db.SaveChanges();
                if (res == 1) MessageBox.Show("Пользователь успешно создан");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private string Hash(string stringToHash)
        {
            using (var sha1 = new SHA1Managed())
            {
                return BitConverter.ToString(sha1.ComputeHash(Encoding.UTF8.GetBytes(stringToHash)));
            }
        }
    } 
}
