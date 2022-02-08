
using AppHuac.Droid.Services;
using AppHuac.Services;
using Xamarin.Forms;
using System.IO;
using System;

[assembly:Dependency(typeof(FileHelper))]
namespace AppHuac.Droid.Services
{
    public class FileHelper : IFileHelper
    {
        public string GetLocalFilePath(string fileName)
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            return Path.Combine(path, fileName);
        }
    }
}