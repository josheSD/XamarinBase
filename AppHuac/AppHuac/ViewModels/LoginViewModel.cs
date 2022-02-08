using Acr.UserDialogs;
using AppHuac.Models;
using AppHuac.Services;
using AppHuac.Views;
using Microsoft.Identity.Client;
using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace AppHuac.ViewModel
{
    public class LoginViewModel : BaseViewModel
    {
        public INavigation Navigation { get; set; }

        private ILoginService _loginService;

        public LoginViewModel(INavigation navigation)
        {
            this._loginService = DependencyService.Get<ILoginService>();
            Navigation = navigation;
        }

        public ICommand LoginAd
        {
            get
            {
                return new RelayCommand(SignInAsync);
            }
        }

        public ICommand SignUp
        {
            get
            {
                return new RelayCommand(EventSignUp);
            }
        }

        private async void SignInAsync()
        {
            UserDialogs.Instance.ShowLoading("Procesando");
            AuthenticationResult authResult = null;
            IEnumerable<IAccount> accounts = await App.PCA.GetAccountsAsync();

            try
            {
                try
                {

                    IAccount firstAccount = accounts.FirstOrDefault();

                    if (firstAccount != null)
                    {
                        RedirectToDashboard(firstAccount.Username);
                    }
                    else
                    {
                        authResult = await App.PCA.AcquireTokenInteractive(Constants.Scopes)
                                                  .WithParentActivityOrWindow(App.ParentWindow)
                                                  .WithUseEmbeddedWebView(true)
                                                  .ExecuteAsync();

                        RedirectToDashboard(authResult.Account.Username);
                    }

                }
                catch (MsalUiRequiredException ex)
                {
                    try
                    {
                        authResult = await App.PCA.AcquireTokenInteractive(Constants.Scopes)
                                                  .WithParentActivityOrWindow(App.ParentWindow)
                                                  .WithUseEmbeddedWebView(true)
                                                  .ExecuteAsync();

                        RedirectToDashboard(authResult.Account.Username);

                    }
                    catch (Exception ex2)
                    {
                        UserDialogs.Instance.HideLoading();
                    }
                }

            }
            catch (Exception ex)
            {
                UserDialogs.Instance.HideLoading();
            }
        }

        private async void EventSignUp()
        {
            IEnumerable<IAccount> accounts = await App.PCA.GetAccountsAsync();
            await App.PCA.RemoveAsync(accounts.FirstOrDefault());
        }

        private async void RedirectToDashboard(string username)
        {
            Response<User> response = await this._loginService.LoginAd(username);
            User userResponse = response.Dato;

            if (response.Success)
            {
                string codigoUser = Enums.Enums.TypeLocalStorage.USER;
                UserDb user = new UserDb(codigoUser,userResponse.Nombres, userResponse.Correo);
                await App.Database.SaveUserAsync(user);
                Application.Current.MainPage = new NavigationPage(new Dashboard());
                UserDialogs.Instance.HideLoading();
            }
            else
            {
                UserDialogs.Instance.HideLoading();
                UserDialogs.Instance.AlertAsync(response.Mensaje,"Mensaje","Ok");
            }

        }

    }
}
