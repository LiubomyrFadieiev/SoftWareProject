using BusinessLogic.Interfaces;
using BusinessLogic.Realization;
using DAL.DTO;
using DAL.Interfaces;
using DAL.Realization;
using System;
using System.Configuration;
using System.Windows;
using Unity;
using Unity.Resolution;
using WpfApp.Windows;

namespace WpfApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static UnityContainer Container;
        public static UserDTO user;
        //private void Application_Startup(object sender, StartupEventArgs e)
        //{
        //    ConfigureUnity();
        //    bool loggedOut = true;
        //    while (loggedOut)
        //    {
        //        this.ShutdownMode = ShutdownMode.OnExplicitShutdown;
        //        var login = Container.Resolve<LogInWindow>();
        //        login.ShowDialog();
        //        if (login.DialogResult.GetValueOrDefault())
        //        {
        //            user = login.GetAuthUser();
        //            var mainWindow = Container.Resolve<MainWindow>(new ParameterOverride("user", user));
        //            this.ShutdownMode = ShutdownMode.OnMainWindowClose;
        //            this.MainWindow = mainWindow;
        //            mainWindow.Show();
        //            loggedOut = mainWindow.isLoggedOut;
        //        }
        //        else
        //        {
        //            loggedOut = false;
        //        }
        //    }
        //    if (!loggedOut)
        //    {
        //        this.Shutdown();
        //    }


        //}
        [STAThread]
        static void Main()
        {
            App app = new App();
            ConfigureUnity();
            bool loggedOut = true;
            while (loggedOut)
            {
                app.ShutdownMode = ShutdownMode.OnExplicitShutdown;
                var login = Container.Resolve<LogInWindow>();
                login.ShowDialog();
                if (login.DialogResult.GetValueOrDefault())
                {
                    user = login.GetAuthUser();
                    var mainWindow = Container.Resolve<MainWindow>(new ParameterOverride("user", user));
                    app.ShutdownMode = ShutdownMode.OnMainWindowClose;
                    app.MainWindow = mainWindow;
                    mainWindow.Show();
                    loggedOut = mainWindow.isLoggedOut;
                }
                else
                {
                    loggedOut = false;
                }
            }
            if (!loggedOut)
            {
                app.Shutdown();
            }
        }
        private static void ConfigureUnity()
        {
            Container = new UnityContainer();
            Container.RegisterInstance<IGoodDal>(new GoodDal(ConnectionString.connString))
                .RegisterInstance<IUserDal>(new UserDal(ConnectionString.connString))
                .RegisterInstance<IBoughtGoodDal>(new BoughtGoodDal(ConnectionString.connString))
                .RegisterInstance<IBidDal>(new BidDal(ConnectionString.connString))
                .RegisterType<IAuthManager, AuthManager>()
                .RegisterType<IAuctionManager, AuctionManager>();

        }
        public static class ConnectionString
        {
            public static readonly string connString = ConfigurationManager.ConnectionStrings["Auction"].ConnectionString;
        }
    }
}
