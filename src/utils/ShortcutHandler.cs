using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IWshRuntimeLibrary;

namespace WinLauncher.src.utils
{
    class ShortcutHandler
    {
        public static IWshShortcut CurrentShortcutHandle;

        public static void CreateShortcut(string targetPath, string appName, string Description)
        {
            object shDesktop = (object)"Desktop";
            WshShell shell = new WshShell();
            string shortcutAddress = (string)shell.SpecialFolders.Item(ref shDesktop) + @"\" + appName + ".lnk";
            IWshShortcut shortcut = (IWshShortcut)shell.CreateShortcut(shortcutAddress);
            shortcut.Description = Description;
            shortcut.Hotkey = "Ctrl+Shift+N";
            shortcut.TargetPath = targetPath;
            shortcut.Save();

            CurrentShortcutHandle = shortcut;
        }
    }
}
