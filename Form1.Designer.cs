using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IWshRuntimeLibrary;
using WinLauncher.src;

namespace WinLauncher
{
    partial class WinLauncher
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WinLauncher));
            this.btnInstall = new System.Windows.Forms.Button();
            this.InstallationProgressBar = new System.Windows.Forms.ProgressBar();
            this.appTitle = new System.Windows.Forms.Label();
            this.appSubLabel = new System.Windows.Forms.Label();
            this.shortcutCheckbox = new System.Windows.Forms.CheckBox();
            this.btnDefaultDir = new System.Windows.Forms.CheckBox();
            this.btnDirChoose = new System.Windows.Forms.Button();
            this.dirChoice = new System.Windows.Forms.FolderBrowserDialog();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.statusUpdateLabel = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.box_one = new System.Windows.Forms.GroupBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.box_one.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnInstall
            // 
            this.btnInstall.BackColor = System.Drawing.Color.Transparent;
            this.btnInstall.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnInstall.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnInstall.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInstall.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnInstall.Location = new System.Drawing.Point(334, 63);
            this.btnInstall.Name = "btnInstall";
            this.btnInstall.Size = new System.Drawing.Size(105, 27);
            this.btnInstall.TabIndex = 0;
            this.btnInstall.Text = "Install";
            this.btnInstall.UseVisualStyleBackColor = false;
            this.btnInstall.Click += new System.EventHandler(this.btnInstall_Click);
            // 
            // InstallationProgressBar
            // 
            this.InstallationProgressBar.Location = new System.Drawing.Point(12, 370);
            this.InstallationProgressBar.Name = "InstallationProgressBar";
            this.InstallationProgressBar.Size = new System.Drawing.Size(668, 23);
            this.InstallationProgressBar.TabIndex = 1;
            // 
            // appTitle
            // 
            this.appTitle.AutoSize = true;
            this.appTitle.BackColor = System.Drawing.Color.Transparent;
            this.appTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.appTitle.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.appTitle.Location = new System.Drawing.Point(12, 13);
            this.appTitle.Name = "appTitle";
            this.appTitle.Size = new System.Drawing.Size(238, 33);
            this.appTitle.TabIndex = 2;
            this.appTitle.Text = "WIN LAUNCHER";
            // 
            // appSubLabel
            // 
            this.appSubLabel.AutoSize = true;
            this.appSubLabel.BackColor = System.Drawing.Color.Transparent;
            this.appSubLabel.Font = new System.Drawing.Font("Microsoft YaHei", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.appSubLabel.Location = new System.Drawing.Point(13, 46);
            this.appSubLabel.Name = "appSubLabel";
            this.appSubLabel.Size = new System.Drawing.Size(443, 25);
            this.appSubLabel.TabIndex = 3;
            this.appSubLabel.Text = "Safely install the application on your computer";
            // 
            // shortcutCheckbox
            // 
            this.shortcutCheckbox.AutoSize = true;
            this.shortcutCheckbox.Checked = true;
            this.shortcutCheckbox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.shortcutCheckbox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.shortcutCheckbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.shortcutCheckbox.Location = new System.Drawing.Point(4, 20);
            this.shortcutCheckbox.Name = "shortcutCheckbox";
            this.shortcutCheckbox.Size = new System.Drawing.Size(169, 17);
            this.shortcutCheckbox.TabIndex = 4;
            this.shortcutCheckbox.Text = "Create desktop shortcut?";
            this.shortcutCheckbox.UseVisualStyleBackColor = true;
            // 
            // btnDefaultDir
            // 
            this.btnDefaultDir.AutoSize = true;
            this.btnDefaultDir.Checked = true;
            this.btnDefaultDir.CheckState = System.Windows.Forms.CheckState.Checked;
            this.btnDefaultDir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDefaultDir.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDefaultDir.Location = new System.Drawing.Point(4, 42);
            this.btnDefaultDir.Name = "btnDefaultDir";
            this.btnDefaultDir.Size = new System.Drawing.Size(144, 17);
            this.btnDefaultDir.TabIndex = 6;
            this.btnDefaultDir.Text = "Use default directory";
            this.btnDefaultDir.UseVisualStyleBackColor = true;
            this.btnDefaultDir.CheckedChanged += new System.EventHandler(this.btnDefaultDir_CheckedChanged);
            // 
            // btnDirChoose
            // 
            this.btnDirChoose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDirChoose.Location = new System.Drawing.Point(147, 42);
            this.btnDirChoose.Name = "btnDirChoose";
            this.btnDirChoose.Size = new System.Drawing.Size(74, 26);
            this.btnDirChoose.TabIndex = 5;
            this.btnDirChoose.Text = "Browse . . .";
            this.btnDirChoose.UseVisualStyleBackColor = true;
            this.btnDirChoose.Click += new System.EventHandler(this.btnDirChoose_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.appSubLabel);
            this.panel1.Controls.Add(this.appTitle);
            this.panel1.Location = new System.Drawing.Point(-4, -4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(705, 89);
            this.panel1.TabIndex = 8;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.statusUpdateLabel);
            this.panel2.Controls.Add(this.panel5);
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Controls.Add(this.box_one);
            this.panel2.Location = new System.Drawing.Point(-4, 80);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(250, 371);
            this.panel2.TabIndex = 9;
            // 
            // statusUpdateLabel
            // 
            this.statusUpdateLabel.AutoSize = true;
            this.statusUpdateLabel.BackColor = System.Drawing.Color.Gainsboro;
            this.statusUpdateLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.statusUpdateLabel.Location = new System.Drawing.Point(16, 316);
            this.statusUpdateLabel.Name = "statusUpdateLabel";
            this.statusUpdateLabel.Size = new System.Drawing.Size(49, 15);
            this.statusUpdateLabel.TabIndex = 6;
            this.statusUpdateLabel.Text = "<status>";
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.Black;
            this.panel5.Location = new System.Drawing.Point(242, 10);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(8, 253);
            this.panel5.TabIndex = 0;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.Black;
            this.panel4.Location = new System.Drawing.Point(3, 5);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(247, 5);
            this.panel4.TabIndex = 7;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.Controls.Add(this.btnInstall);
            this.panel3.Location = new System.Drawing.Point(241, 348);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(458, 103);
            this.panel3.TabIndex = 7;
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.Black;
            this.panel6.Location = new System.Drawing.Point(238, 343);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(458, 5);
            this.panel6.TabIndex = 8;
            // 
            // box_one
            // 
            this.box_one.Controls.Add(this.shortcutCheckbox);
            this.box_one.Controls.Add(this.btnDefaultDir);
            this.box_one.Controls.Add(this.btnDirChoose);
            this.box_one.Location = new System.Drawing.Point(9, 16);
            this.box_one.Name = "box_one";
            this.box_one.Size = new System.Drawing.Size(227, 74);
            this.box_one.TabIndex = 8;
            this.box_one.TabStop = false;
            this.box_one.Text = "default settings";
            // 
            // WinLauncher
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FloralWhite;
            this.ClientSize = new System.Drawing.Size(692, 450);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.InstallationProgressBar);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "WinLauncher";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "WinLauncher";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.box_one.ResumeLayout(false);
            this.box_one.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnInstall;
        public System.Windows.Forms.ProgressBar InstallationProgressBar;
        private System.Windows.Forms.Label appTitle;
        private System.Windows.Forms.Label appSubLabel;
        public System.Windows.Forms.CheckBox shortcutCheckbox;
        private System.Windows.Forms.CheckBox btnDefaultDir;
        private System.Windows.Forms.Button btnDirChoose;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        public System.Windows.Forms.Label statusUpdateLabel;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel6;
        public System.Windows.Forms.FolderBrowserDialog dirChoice;
        private System.Windows.Forms.GroupBox box_one;
    }
}

