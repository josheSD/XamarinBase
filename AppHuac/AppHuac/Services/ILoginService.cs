using AppHuac.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AppHuac.Services
{
    public interface ILoginService
    {
        Task<Response<User>> LoginAd(string correo);
    }
}
