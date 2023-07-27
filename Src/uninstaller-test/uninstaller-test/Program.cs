using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace uninstaller_test
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"c:\test";
            System.IO.Directory.Delete(path, true);
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            System.IO.File.Delete(System.IO.Path.Combine(desktopPath, "test.lnk"));
            Environment.Exit(0);
        }
    }
}
