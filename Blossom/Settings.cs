using Microsoft.Win32;
using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace Blossom {

    public partial class Settings : Form {

        public Settings() {

            InitializeComponent();
            LoadSettings();
        }

        private void Settings_Load(object sender, EventArgs e) {

            LoadSettings();
        }

        private void okButton_Click(object sender, EventArgs e) {

            SaveSettings();
            Close();
        }

        private void cancelButton_Click(object sender, EventArgs e) {

            Close();
        }

        private void SaveSettings() {

            // Create or get existing Registry subkey
            RegistryKey key = Registry.CurrentUser.CreateSubKey("SOFTWARE\\Blossom_Screensaver");

            key.SetValue("cellSize", (int) cellSize.Value);
            key.SetValue("framerate", (int) framerate.Value);
            key.SetValue("sparsity", (float) sparsity.Value);
        }

        private void LoadSettings() {

            // Get the value stored in the Registry
            RegistryKey key = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Blossom_Screensaver");

            if (key == null) {

                cellSize.Value = 1;
                framerate.Value = 30;
                sparsity.Value = (decimal) 0.5f;
            }
            else {

                cellSize.Value = (int) key.GetValue("cellSize");
                framerate.Value = (int) key.GetValue("framerate");
                sparsity.Value = decimal.Parse((string) key.GetValue("sparsity"));
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {

            Process.Start("www.github.com/Serjpinski/Blossom");
        }
    }
}
