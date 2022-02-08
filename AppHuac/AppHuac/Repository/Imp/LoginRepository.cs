using AppHuac.Repository;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Newtonsoft.Json;
using AppHuac.Models;

[assembly:Dependency(typeof(LoginRepository))]
namespace AppHuac.Repository
{
    public class LoginRepository : ILoginRepository
    {
        private readonly string UrlPersonal;
        private readonly HttpClient Client;
        public LoginRepository()
        {
            this.UrlPersonal = Constants.UrlPersonal;
            this.Client = new HttpClient();
        }

        public async Task<Response<User>> LoginAd(string correo)
        {
            var url = UrlPersonal + "/personal/api/login/user?correo=" + correo;
            try
            {
                var response = await Client.GetAsync(url);
                if (!response.IsSuccessStatusCode)
                {
                    return new Response<User>
                    {
                        Success = false,
                        Mensaje = response.StatusCode.ToString(),
                    };
                }

                var result = await response.Content.ReadAsStringAsync();
                var resultConvert = JsonConvert.DeserializeObject<Response<User>>(result);
                    resultConvert.Success = true;
                return resultConvert;
            }
            catch(Exception ex)
            {
                return new Response<User>
                {
                    Success = false,
                    Mensaje = ex.Message
                };
            }
        }
    }
}
