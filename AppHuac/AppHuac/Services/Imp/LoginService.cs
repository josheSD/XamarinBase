using AppHuac.Models;
using AppHuac.Repository;
using AppHuac.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

[assembly:Dependency(typeof(LoginService))]
namespace AppHuac.Services
{
    public class LoginService : ILoginService
    {
        private readonly ILoginRepository _loginRepository;

        public LoginService()
        {
            this._loginRepository = DependencyService.Get<ILoginRepository>();
        }

        public Task<Response<User>> LoginAd(string correo)
        {
            return _loginRepository.LoginAd(correo);
        }
    }
}
