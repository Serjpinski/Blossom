using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        }

        private void LoadSettings() {

            // Get the value stored in the Registry
            RegistryKey key = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Blossom_Screensaver");

            if (key == null) cellSize.Value = 1;
            else cellSize.Value = (int) key.GetValue("cellSize");
        }
    }
}
