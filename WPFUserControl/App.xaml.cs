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
using WPFUserControl.Windows;

namespace WPFUserControl
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static UnityContainer Container;
        public static UserDTO authUser;
        [STAThread]
        static void Main()
        {
            App app = new App();
            ConfigureUnity();
            LogInWindow lw = Container.Resolve<LogInWindow>();
            lw.ShowDialog();
            if ((bool)lw.DialogResult)
            {
                MainWindow mw = Container.Resolve<MainWindow>(new ParameterOverride("user", lw.GetAuthUser()));
                app.Run(mw);
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

        private void Application_Startup(object sender, StartupEventArgs e)
        {

        }
    }
}
