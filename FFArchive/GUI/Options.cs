using FFArchive.Settings;

using System;
using System.Windows.Forms;

namespace FFArchive.GUI
{
    public partial class Options : Form
    {
        private readonly XmlConfig _config;

        public Options()
        {
            InitializeComponent();
            _config = new XmlConfig(XmlConfig.IoState.Read);
            AppSettings settings = _config.Settings;
            propertyGrid1.SelectedObject = settings;
        }

        private void btOk_Click(object sender, EventArgs e)
        {
            _config.Settings = (AppSettings)propertyGrid1.SelectedObject;
            _config.WriteConfig();
            Close();
        }

        private void btApply_Click(object sender, EventArgs e)
        {
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}