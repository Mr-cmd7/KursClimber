using CommunityToolkit.Mvvm.Input;
using KursClimber.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace KursClimber.ViewModel
{
    public partial class HomePageViewModel
    {
        [RelayCommand]
        private void ClimberOpen(object obj)
        {
            ClimberView climberView = new ClimberView();
            climberView.Show();
        }
        [RelayCommand]
        private void GroupOpen(object obj)
        {
            ClimbingGroupView groupView = new ClimbingGroupView();
            groupView.Show();
        }
        [RelayCommand]
        private void MountainOpen(object obj)
        {
            MountainView mountainView = new MountainView();
            mountainView.Show();
        }
        [RelayCommand]
        private void ExitLogin(object obj)
        {
                LoginView loginView = new LoginView();
                loginView.Show();
        }
    }
}
