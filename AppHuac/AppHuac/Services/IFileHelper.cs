using System;
using System.Collections.Generic;
using System.Text;

namespace AppHuac.Services
{
    public interface IFileHelper
    {
        string GetLocalFilePath(string fileName);
    }
}
