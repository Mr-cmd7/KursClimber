using CommunityToolkit.Mvvm.Input;
using KursClimber.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KursClimber.ViewModel
{
    public partial class HomePageViewModel
    {
        

        [RelayCommand]
        private void ClickOne(object obj)
        {
            ClimberView climberView = new ClimberView();
            climberView.Show();
        }
        [RelayCommand]
        private void ClickTwo(object obj)
        {
            ClimbingGroupView groupView = new ClimbingGroupView();
            groupView.Show();
        }
        [RelayCommand]
        private void ClickThree(object obj)
        {
            MountainView mountainView = new MountainView();
            mountainView.Show();
        }
        private HomePageView _window;
        [RelayCommand]
        private void Exit(object obj)
        {
            LoginView loginView = new LoginView();
            loginView.Show();
            _window.Close();

        }
    }
}
