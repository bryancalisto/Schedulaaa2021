using Schedulaaa2021_1._0.Models;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Timers;
using System.Windows.Forms;

namespace Schedulaaa2021_1._0
{
    class Program : Form
    {
        static ManualResetEvent _quitEvent = new ManualResetEvent(false);
        static WindowController wndCtl = new WindowController();
        static NotifyIcon notifyIcon = new NotifyIcon();
        static System.Timers.Timer timer = new System.Timers.Timer();
        static Config config;

        static void Main(string[] args)
        {
            // Prepare app to run in the background
            Console.CancelKeyPress += (sender, eArgs) =>
            {
                _quitEvent.Set();
                eArgs.Cancel = true;
            };

            Utilidades.updateConfig(ref config);

            timer.Elapsed += new ElapsedEventHandler(OnElapsedTime);
            timer.Interval = config.intervNotificacion;
            timer.Enabled = true;

            // From now on, window is hidden until it's killed
            setNotifyIcon(notifyIcon);
            wndCtl.hide();
            _quitEvent.WaitOne();

            // Exit cleanly
            timer.Dispose();
            notifyIcon.Visible = true;
        }

        /* Update everything according to config.json and show toast*/
        private static void OnElapsedTime(object source, ElapsedEventArgs e)
        {
            Utilidades.updateConfig(ref config);

            timer.Interval = config.intervNotificacion * 1000;

            string hora = DateTime.Now.TimeOfDay.ToString().Substring(0, 5);
            Toast.show(new List<string> { hora, config.msgGenerico },
                new Dictionary<string, string> { { "time", hora } });
        }

        //protected override void OnActivated(IActivatedEventArgs e)
        //{
        //    Console.WriteLine("HOLA");
        //    // Handle notification activation
        //    if (e is ToastNotificationActivatedEventArgs toastActivationArgs)
        //    {
        //        ToastArguments args = ToastArguments.Parse(toastActivationArgs.Argument);
        //        wndCtl.show();
        //    }
        //}


        static void setNotifyIcon(NotifyIcon notifyIcon)
        {
            notifyIcon.Icon = new System.Drawing.Icon(@"..\..\Icon.ico"); // COLOCAR ESTE ICONO EN LA MISMA RUTA DEL .EXE
            notifyIcon.Visible = true;
            notifyIcon.Text = "Schedulaaa2021";
        }
    }
}
