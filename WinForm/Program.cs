using System;
using System.Windows.Forms;
using Unity;
using DAL.Interfaces;
using DAL.Realization;
using BusinessLogic.Interfaces;
using BusinessLogic.Realization;
using WinForm.Forms;

namespace WinForm
{
    
    static class Program
    {
        public static UnityContainer Container;
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ConfigureUnity();

            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            bool check = true;
            while (check)
            {
                MainForm form = Container.Resolve<MainForm>();
                Application.Run(form);
                check = form.isLogOut;
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
    }
}
