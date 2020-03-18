using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace CodWarzoneCrashFixer
{
    public partial class MainWindow : Form {

        public MainWindow()
        {
            InitializeComponent();
            Init();
        }

        private void Init() {
            Config config = Config.GetConfig();
            if (config.ConfigPath != null) {
                this.pathInputBox.Text = config.ConfigPath;
            }

            if (config.Enabled) {
                this.checkBox1.Checked = true;
            }
            
            this.Resize += new EventHandler(this.Form1_Resize);
        }

        private void onPathButtonClick(object sender, EventArgs e)
        {
            
            DialogResult dialogResult = this.openFileDialog1.ShowDialog();
            if (dialogResult == DialogResult.OK)
            {
                this.pathInputBox.Text = this.openFileDialog1.FileName;
                Config.WriteConfig(new Config(this.openFileDialog1.FileName));
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e) {
            Config config = Config.GetConfig();
            config.Enabled = this.checkBox1.Checked;
            Config.WriteConfig(config);
            if (checkBox1.Checked) {
                Debug.WriteLine("Checkbox set, resuming thread");
                MainLogic.threadState.Set();
            }else {
                Debug.WriteLine("Checkbox not set, pausing thread");
                MainLogic.threadState.Reset();
            }
        }

        private void Form1_Resize(object sender, EventArgs e)  
        {  
            //if the form is minimized  
            //hide it from the task bar  
            //and show the system tray icon (represented by the NotifyIcon control)  
            if (this.WindowState == FormWindowState.Minimized)  
            {  
                Hide();  
                Program.trayIcon.Visible = true;                  
            }  
        }  

        private void onAutoDetectButtonClick(object sender, EventArgs e) {
       
            string fileName = MainLogic.getCodHandlePath();
            
            {

                if (fileName == null) {
                 
                    DialogResult dg;
                    using (DialogCenteringService centeringService = new DialogCenteringService(this)) // center message box
                    {
                        dg = MessageBox.Show(this, "Modern Warfare doesn't seem to be running!", 
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    
                }else{
                    this.pathInputBox.Text = fileName;
                }
            }

        }
        
    }
}