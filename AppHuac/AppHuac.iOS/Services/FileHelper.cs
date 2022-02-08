using AppHuac.iOS.Services;
using AppHuac.Services;
using System;
using System.IO;
using Xamarin.Forms;

[assembly:Dependency(typeof(FileHelper))]
namespace AppHuac.iOS.Services
{
    public class FileHelper : IFileHelper
    {
        public string GetLocalFilePath(string fileName)
        {
            string docFolder = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            string libFolder = Path.Combine(docFolder, "..", "Databases");
            if (!Directory.Exists(libFolder))
            {
                Directory.CreateDirectory(libFolder);
            }
            return Path.Combine(libFolder, fileName);
        }
    }
}