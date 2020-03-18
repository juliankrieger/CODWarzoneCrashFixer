using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;


namespace CodWarzoneCrashFixer
{
    
    
    static class Program {

        public static NotifyIcon trayIcon;

        private static MainWindow mainWindow;

        public static void notifyIcon_MouseDoubleClick(object sender, EventArgs e) {

            MouseEventArgs mouseEventArgs = (MouseEventArgs) e;

           
            mainWindow.Show();
            mainWindow.WindowState = FormWindowState.Normal;
            Program.trayIcon.Visible = false;
                
            
        }  
        
        private static void Init()
        {
            trayIcon = new NotifyIcon();
            trayIcon.Text = "Modern Warfare Crash Fixer";
            trayIcon.Icon = new Icon(Icon.ExtractAssociatedIcon( Application.ExecutablePath ), 40, 40);

            ContextMenu trayMenu = new ContextMenu();
            
            trayMenu.MenuItems.Add("Exit", OnExit);
            trayIcon.ContextMenu = trayMenu;
            
            trayIcon.DoubleClick += new EventHandler(notifyIcon_MouseDoubleClick);

            Config config = Config.GetConfig();
          
            MainLogic.runThread.Start();
            if (config.Enabled) {
                MainLogic.threadState.Set();
            }
        }
        
        
        
        private static void OnExit(object sender, EventArgs e)
        {
            Application.Exit();
            Process.GetCurrentProcess().Kill(); //Failsafe
        }
        
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            
          
           
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Init();

            mainWindow = new MainWindow();
            
            Application.Run(mainWindow);
            
        }
    }
}