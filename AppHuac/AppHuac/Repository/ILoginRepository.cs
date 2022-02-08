using AppHuac.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AppHuac.Repository
{
    public interface ILoginRepository
    {
        Task<Response<User>> LoginAd(string correo);
    }
}
