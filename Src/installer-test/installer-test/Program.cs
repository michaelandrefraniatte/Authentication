using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using IWshRuntimeLibrary;
namespace installer_test
{
    class Program
    {
        static void Main(string[] args)
        {
            string zipPath = Environment.CurrentDirectory + @"\test.zip";
            string extractPath = @"c:\test";
            System.IO.Compression.ZipFile.ExtractToDirectory(zipPath, extractPath);
            System.IO.File.Copy(Environment.CurrentDirectory + @"\auth.txt", @"c:\test\auth.txt");
            CreateShortcut();
            Environment.Exit(0);
        }
        private static void CreateShortcut()
        {
            object shDesktop = (object)"Desktop";
            WshShell shell = new WshShell();
            string shortcutAddress = (string)shell.SpecialFolders.Item(ref shDesktop) + @"\test.lnk";
            IWshShortcut shortcut = (IWshShortcut)shell.CreateShortcut(shortcutAddress);
            shortcut.Description = "Shortcut for a test";
            shortcut.TargetPath = @"c:\test\test.exe";
            shortcut.WorkingDirectory = @"c:\test";
            shortcut.Save();
        }
    }
}
