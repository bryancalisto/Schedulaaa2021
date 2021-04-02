using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Notifications;

namespace Schedulaaa2021_1._0
{
    public class WindowController
    {
        const int SW_HIDE = 0;
        const int SW_SHOW = 5;
        IntPtr consoleHandle = IntPtr.Zero;
        WindowController instance;

        public WindowController()
        {
            this.consoleHandle = GetConsoleWindow();
        }

        public WindowController Instance
        {
            get
            {
                return instance != null ? instance : new WindowController();
            }
            set { instance = value; }
        }

        [DllImport("kernel32.dll")]
        static extern IntPtr GetConsoleWindow();

        [DllImport("user32.dll")]
        static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        public void show()
        {
            ShowWindow(this.consoleHandle, SW_SHOW);
        }

        public void hide()
        {
            ShowWindow(this.consoleHandle, SW_HIDE);
        }
    }
}
