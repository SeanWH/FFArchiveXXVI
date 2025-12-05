using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using FFArchive.Settings;

namespace FFArchive.GUI
{
    public partial class Options : Form
    {
        private XMLConfig config;
        private AppSettings settings;

        public Options()
        {
            InitializeComponent();
            config = new XMLConfig(XMLConfig.ioState.Read);
            settings = config.Settings;
            propertyGrid1.SelectedObject = settings;
        }

        private void btOk_Click(object sender, EventArgs e)
        {
            config.Settings = (AppSettings)propertyGrid1.SelectedObject;
            config.writeConfig();
            this.Close();
        }

        private void btApply_Click(object sender, EventArgs e)
        {

        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        
    }
}