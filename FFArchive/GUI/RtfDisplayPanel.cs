using System;
using System.Drawing;
using System.Drawing.Text;
using System.Windows.Forms;

namespace FFArchive.GUI
{
    public sealed class RtfDisplayPanel : TableLayoutPanel, IDisposable
    {
        private readonly RichTextBox _richTextBox = new RichTextBox();
        private readonly ToolStrip _richTextBoxToolStrip = new ToolStrip();
        private readonly ToolStripLabel _toolStripFontLabel = new ToolStripLabel("Font:");
        private readonly ToolStripLabel _toolStripSizeLabel = new ToolStripLabel("Size:");
        private readonly ToolStripLabel _toolStripZoomLabel = new ToolStripLabel("Zoom:");
        private readonly ToolStripComboBox _name = new ToolStripComboBox();
        private readonly ToolStripComboBox _size = new ToolStripComboBox();
        private readonly ToolStripComboBox _zoom = new ToolStripComboBox();

        private readonly int[] _fontSizes = { 8, 9, 10, 11, 12, 14, 16, 18, 20, 22, 24, 26, 28, 36, 48, 72 };
        private readonly double[] _zoomLevels = { .015626, .03125, .0625, .125, .25, .5, 1, 2, 4, 8, 16, 32, 63 };

        private readonly bool _init;

        public RtfDisplayPanel()
        {
            _init = true;
            ColumnCount = 1;
            RowCount = 2;
            Dock = DockStyle.Fill;
            _richTextBox.Dock = DockStyle.Fill;
            Controls.Add(_richTextBox, 0, 1);

            _name.SelectedIndexChanged += _name_SelectedIndexChanged;
            _size.SelectedIndexChanged += _size_SelectedIndexChanged;
            _zoom.SelectedIndexChanged += _zoom_SelectedIndexChanged;

            InitFontInfo();

            _richTextBoxToolStrip.Items.Add(_toolStripFontLabel);
            _richTextBoxToolStrip.Items.Add(_name);
            _richTextBoxToolStrip.Items.Add(_toolStripSizeLabel);
            _richTextBoxToolStrip.Items.Add(_size);
            _richTextBoxToolStrip.Items.Add(_toolStripZoomLabel);
            _richTextBoxToolStrip.Items.Add(_zoom);
            Controls.Add(_richTextBoxToolStrip, 0, 0);

            _init = false;
        }

        private void _zoom_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!_init)
            {
                _richTextBox.ZoomFactor = (float)Convert.ToDouble(_zoom.Text);
            }
        }

        private void _size_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!_init)
            {
                FontFamily ff = new FontFamily(_name.Text);
                float size = (float)Convert.ToDouble(_size.Text);
                Font font = new Font(ff, size, FontStyle.Regular, GraphicsUnit.Point);
                _richTextBox.Font = font;
            }
        }

        private void _name_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!_init)
            {
                FontFamily ff = new FontFamily(_name.Text);
                float size = (float)Convert.ToDouble(_size.Text);
                Font font = new Font(ff, size, FontStyle.Regular, GraphicsUnit.Point);
                _richTextBox.Font = font;
            }
        }

        private void InitFontInfo()
        {
            InstalledFontCollection ifc = new InstalledFontCollection();
            FontFamily[] families = ifc.Families;
            int cnt = families.Length;
            for (int i = 0; i < cnt; i++)
            {
                _name.Items.Add(families[i].Name);
            }

            _name.SelectedIndex = 0;

            for (int i = 0; i < 16; i++)
            {
                _size.Items.Add(_fontSizes[i]);
            }

            _size.SelectedIndex = 0;

            for (int i = 0; i < 13; i++)
            {
                _zoom.Items.Add(_zoomLevels[i]);
            }

            _zoom.SelectedIndex = 6;
        }

        public void SetPlainText(string text)
        {
            _richTextBox.Text = text;
        }

        public void SetRichText(string richText)
        {
            _richTextBox.Rtf = richText;
        }

        public void LoadRtfFile(string address)
        {
            _richTextBox.LoadFile(address, RichTextBoxStreamType.RichText);
        }

        void IDisposable.Dispose()
        {
            _richTextBox.Dispose();
            _richTextBoxToolStrip.Dispose();
        }
    }
}