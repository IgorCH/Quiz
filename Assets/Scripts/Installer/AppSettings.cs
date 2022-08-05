using UnityEngine;

namespace Installer
{
    public class AppSettings
    {
        public RectTransform WindowsRoot { get; }
        public RectTransform WidgetsRoot { get; }
        public static AppSettings Instance { get; internal set; }

        public AppSettings(RectTransform windowsRoot, RectTransform widgetsRoot)
        {
            WindowsRoot = windowsRoot;
            WidgetsRoot = widgetsRoot;
        }
    }
}