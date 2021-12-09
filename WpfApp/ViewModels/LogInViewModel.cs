using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using BusinessLogic.Interfaces;
using BusinessLogic.Realization;
using DAL.DTO;
using DAL.Realization;
using WpfApp.Commands;

namespace WpfApp.ViewModels
{
    public class LogInViewModel : INotifyPropertyChanged
    {
        // Manager and UserDTO
        private readonly IAuthManager authManager;
        private readonly IAuctionManager aucManager;
        public UserDTO user;

        // Properties and INotifyPropertyChanged
        private string login;
        public string Login
        {
            get
            {
                return login;
            }
            set
            {
                login = value;
                OnPropertyChanged(nameof(login));
            }
        }
        private string password;
        public string Password
        {
            get
            {
                return password;
            }
            set
            {
                password = value;
                OnPropertyChanged(nameof(Password));
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string v)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(v));
        }
        // Commands functionality
        public Action LoginSuccess;
        public Action LoginFail;
        public Action Close;
        public CloseCommand CloseCommand { get; }
        public LogInCommand logInCommand { get; }

        // Constructor and misc.
        public LogInViewModel(IAuthManager authmanager, IAuctionManager aucmanager) : base()
        {
            authManager = authmanager;
            aucManager = aucmanager;
            logInCommand = new LogInCommand(this);
            CloseCommand = new CloseCommand(this);
            Login = "adventuretime@gmail.com";
            Password = "12345678";
        }
        public bool LogIn()
        {
            (bool, bool) res = authManager.LogIn(login, password);
            if (res.Item1 && res.Item2)
            {
                user = aucManager.GetAuthorisedUser(login);
            }
            return res.Item1 && res.Item2;
        }
    }
}
