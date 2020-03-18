using System;
using System.ComponentModel;

namespace CodWarzoneCrashFixer
{
    partial class MainWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.pathInputBox = new System.Windows.Forms.TextBox();
            this.addPath = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.welcomeBox = new System.Windows.Forms.TextBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.autoDetectButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // pathInputBox
            // 
            this.pathInputBox.Location = new System.Drawing.Point(12, 179);
            this.pathInputBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.pathInputBox.Name = "pathInputBox";
            this.pathInputBox.Size = new System.Drawing.Size(460, 23);
            this.pathInputBox.TabIndex = 0;
            // 
            // addPath
            // 
            this.addPath.Anchor =
                ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Bottom |
                                                       System.Windows.Forms.AnchorStyles.Left)));
            this.addPath.Location = new System.Drawing.Point(12, 208);
            this.addPath.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.addPath.Name = "addPath";
            this.addPath.Size = new System.Drawing.Size(85, 42);
            this.addPath.TabIndex = 1;
            this.addPath.Text = "Add Path";
            this.addPath.UseVisualStyleBackColor = true;
            this.addPath.Click += new System.EventHandler(this.onPathButtonClick);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // welcomeBox
            // 
            this.welcomeBox.Location = new System.Drawing.Point(12, 32);
            this.welcomeBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.welcomeBox.Multiline = true;
            this.welcomeBox.Name = "welcomeBox";
            this.welcomeBox.ReadOnly = true;
            this.welcomeBox.Size = new System.Drawing.Size(460, 52);
            this.welcomeBox.TabIndex = 2;
            this.welcomeBox.Text =
                "Welcome to Call of Duty Modern Warfare Crashfixer!\r\nPlease set the path to your M" +
                "odernWarfare.exe!\r\nYou can also try to autodetect it (the game needs to be runni" + "ng for this)";
            this.welcomeBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // checkBox1
            // 
            this.checkBox1.Anchor =
                ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Bottom |
                                                       System.Windows.Forms.AnchorStyles.Left)));
            this.checkBox1.Location = new System.Drawing.Point(12, 145);
            this.checkBox1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(99, 28);
            this.checkBox1.TabIndex = 3;
            this.checkBox1.Text = "Enable";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // autoDetectButton
            // 
            this.autoDetectButton.Anchor =
                ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Bottom |
                                                       System.Windows.Forms.AnchorStyles.Right)));
            this.autoDetectButton.Location = new System.Drawing.Point(103, 208);
            this.autoDetectButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.autoDetectButton.Name = "autoDetectButton";
            this.autoDetectButton.Size = new System.Drawing.Size(102, 42);
            this.autoDetectButton.TabIndex = 4;
            this.autoDetectButton.Text = "Auto Detect";
            this.autoDetectButton.UseVisualStyleBackColor = true;
            this.autoDetectButton.Click += new System.EventHandler(this.onAutoDetectButtonClick);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 261);
            this.Controls.Add(this.autoDetectButton);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.welcomeBox);
            this.Controls.Add(this.addPath);
            this.Controls.Add(this.pathInputBox);
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "MainWindow";
            this.Text = "MainWindow";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Button addPath;


        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.TextBox welcomeBox;
        private System.Windows.Forms.TextBox pathInputBox;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Button autoDetectButton;
    }
}