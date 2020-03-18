using System;
using System.Collections.Immutable;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;

namespace CodWarzoneCrashFixer {
    public class MainLogic {

        private static Process _codHandle;
        
        public static  ManualResetEvent threadState = new ManualResetEvent(false);

        public static Thread runThread = new Thread(() => {
           while(true)
           {
               mainLoop();
           }
        });
        
       

        public static Process GetCodHandleSync() {
            while (_codHandle == null) {
                Debug.WriteLine("Awaiting thread state");
                threadState.WaitOne(Timeout.Infinite);
                Debug.WriteLine("Thread continues");
                _codHandle = GetCodHandle();
                if (_codHandle == null) {
                    Debug.WriteLine("Modern Warfare not yet started");
                }
                Thread.Sleep(1000 * 5); // sleep for one minute
            }

            return _codHandle;
        }
        
        private static Process GetCodHandle()
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

        public static string getCodHandlePath() {
            if (_codHandle == null) {
                return null;
            }

            string fileName = null;

            if(_codHandle != null && _codHandle.MainModule?.FileName != null) {
                fileName = _codHandle.MainModule.FileName;
                Config config = Config.GetConfig();
                config.ConfigPath = fileName;
                Config.WriteConfig(config);
            }

            return fileName;
        }

        private static void failSafe() {
            string fullPath = Config.GetConfig().ConfigPath;
            string dirname = Path.GetDirectoryName(fullPath);
            ImmutableList<string> files = Directory.GetFiles(dirname).ToImmutableList();

            string oldFile = files.Find(file => { return file.Contains("ModernWarfare") && file.EndsWith(".exe"); });
            string newFile = files.Find(file => { return file.Contains("ModernWarfare") && file.EndsWith(".exe1"); });

            if (oldFile != null && newFile != null &&
                new FileInfo(oldFile).Length.Equals(new FileInfo(oldFile).Length)) {
                File.Delete(newFile);
            }
        }

        private static string  MoveToExe1(string fullPath) {
            string dirname = Path.GetDirectoryName(fullPath);
            string fullPathWithoutEnding = Path.GetFileNameWithoutExtension(fullPath);
            string ext = Path.GetExtension(fullPath);
            
            string newPath = Path.Combine(dirname, fullPathWithoutEnding + ".exe1");

            if (ext != ".exe1")
            {
                System.IO.File.Move(fullPath, newPath, true);
            }

            return newPath;
        }

        private static string MoveToExe(string fullPath) {
            string dirname = Path.GetDirectoryName(fullPath);
            string fullPathWithoutEnding = Path.GetFileNameWithoutExtension(fullPath);
            string ext = Path.GetExtension(fullPath);
            
            string oldPath = Path.Combine(dirname, fullPathWithoutEnding + ".exe");

            System.IO.File.Move(fullPath, oldPath, true);

            return oldPath;
        }

        public static void mainLoop() {

            Process codHandle = GetCodHandleSync();

            string fullPath = Config.GetConfig().ConfigPath;
            string newPath =  MoveToExe1(fullPath);

            Config config = Config.GetConfig();
            config.ConfigPath = newPath;
            Config.WriteConfig(config);
            
            codHandle.WaitForExit();

            string oldPath = MoveToExe(newPath);

            config = Config.GetConfig();
            config.ConfigPath = oldPath;
            Config.WriteConfig(config);
            
            failSafe();
            
        }
        
    }
}