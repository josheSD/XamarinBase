using AppHuac.Data;
using AppHuac.Repository;
using AppHuac.Services;
using AppHuac.Views;
using Microsoft.Identity.Client;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppHuac
{
    public partial class App : Application
    {
        public static IPublicClientApplication PCA = null;
        public static object ParentWindow { get; set; }

        private static HuacDatabase database;

        public App()
        {
            InitializeComponent();

            PCA = PublicClientApplicationBuilder.Create(Constants.ClientID)
                        .WithRedirectUri($"msal{Constants.ClientID}://auth")
                        .Build();

            DependencyService.Register<ILoginRepository,LoginRepository>();
            DependencyService.Register<ILoginService,LoginService>();

            MainPage = new Logged();
        }
        public static HuacDatabase Database
        {
            get
            {
                if (database == null)
                {
                    database = new HuacDatabase(DependencyService.Get<IFileHelper>().GetLocalFilePath("huacdb.db3"));
                }
                return database;
            }
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
