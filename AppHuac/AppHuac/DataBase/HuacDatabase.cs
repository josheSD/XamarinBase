using AppHuac.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AppHuac.Data
{
    public class HuacDatabase
    {
        private readonly SQLiteAsyncConnection database;
        public HuacDatabase(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<UserDb>().Wait();
        }

        public async Task<bool> GetUserByCode(string codigo)
        {
            List<UserDb> listaUser = await database.QueryAsync<UserDb>("SELECT * FROM User WHERE Codigo = ?",$"{codigo}");
            if(listaUser.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public Task<int> SaveUserAsync(UserDb user)
        {
            if(user.Id != 0)
            {
                return database.UpdateAsync(user);
            }
            else
            {
                return database.InsertAsync(user);
            }
        }

        public Task<int> DeleteUserAsyn(UserDb user)
        {
            return database.DeleteAsync(user);
        }
    }
}
