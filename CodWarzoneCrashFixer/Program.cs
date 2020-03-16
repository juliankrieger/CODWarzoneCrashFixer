using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CodWarzoneCrashFixer
{
    static class Program
    {
        
        private static Process getCODHandle()
        {
            foreach (Process clsProcess in Process.GetProcesses())
            {

                string processName = clsProcess.ProcessName;
                
                if (processName.Contains("ModernWarfare"))
                {
                    return clsProcess;
                }
            }

            return null;
        }

        private static void mainLoop()
        {
            Process codProcess = getCODHandle();

            if (codProcess == null)
            {
                return;
            }

            if (codProcess.MainModule?.FileName != null)
            {
                string fullPath = codProcess.MainModule.FileName;
                string dirname = Path.GetDirectoryName(fullPath);
                string fullPathWithoutEnding = Path.GetFileNameWithoutExtension(fullPath);
                string ext = Path.GetExtension(fullPath);
                
                string newPath = Path.Combine(dirname, fullPathWithoutEnding + ".exe1");

                if (ext != ".exe1")
                {
                    System.IO.File.Move(fullPath, newPath, true);
    
                }
                
                codProcess.WaitForExit();

                string oldPath = Path.Combine(dirname, fullPathWithoutEnding + ".exe");
                
                System.IO.File.Move(newPath, oldPath, true);
            }
        }

        private static void init()
        {
            NotifyIcon trayIcon = new NotifyIcon();
            trayIcon.Text = "TestApp";
            trayIcon.Icon = new Icon(Icon.ExtractAssociatedIcon( Application.ExecutablePath ), 40, 40);

            ContextMenu trayMenu = new ContextMenu();



            trayMenu.MenuItems.Add("Exit", onExit);
            trayIcon.ContextMenu = trayMenu;
            trayIcon.Visible = true;
        }
        
        private static void onExit(object sender, EventArgs e)
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
            init();
            
            Thread thread = new Thread(() =>
            {
                mainLoop();
                Thread.Sleep(1000 * 60); // sleep for one minute
            });
            thread.Start();

            Application.Run();
            
        }
    }
}