namespace FFArchiveXXVI.UI;

partial class TextDocument
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
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TextDocument));
        EditingStrip = new ToolStrip();
        EditStatus = new StatusStrip();
        DocumentText = new RichTextBox();
        toolStripButton1 = new ToolStripButton();
        toolStripSeparator1 = new ToolStripSeparator();
        toolStripButton2 = new ToolStripButton();
        toolStripButton3 = new ToolStripButton();
        toolStripButton4 = new ToolStripButton();
        toolStripSeparator2 = new ToolStripSeparator();
        toolStripLabel1 = new ToolStripLabel();
        FontNameComboBox = new ToolStripComboBox();
        FontSizeComboBox = new ToolStripComboBox();
        EditingStrip.SuspendLayout();
        SuspendLayout();
        // 
        // EditingStrip
        // 
        EditingStrip.Items.AddRange(new ToolStripItem[] { toolStripButton1, toolStripSeparator1, toolStripButton2, toolStripButton3, toolStripButton4, toolStripSeparator2, toolStripLabel1, FontNameComboBox, FontSizeComboBox });
        EditingStrip.Location = new Point(0, 0);
        EditingStrip.Name = "EditingStrip";
        EditingStrip.Size = new Size(800, 25);
        EditingStrip.TabIndex = 0;
        EditingStrip.Text = "toolStrip1";
        // 
        // EditStatus
        // 
        EditStatus.Location = new Point(0, 428);
        EditStatus.Name = "EditStatus";
        EditStatus.Size = new Size(800, 22);
        EditStatus.TabIndex = 1;
        EditStatus.Text = "statusStrip1";
        // 
        // DocumentText
        // 
        DocumentText.Dock = DockStyle.Fill;
        DocumentText.Location = new Point(0, 25);
        DocumentText.Name = "DocumentText";
        DocumentText.Size = new Size(800, 403);
        DocumentText.TabIndex = 2;
        DocumentText.Text = "";
        // 
        // toolStripButton1
        // 
        toolStripButton1.DisplayStyle = ToolStripItemDisplayStyle.Image;
        toolStripButton1.Image = (Image)resources.GetObject("toolStripButton1.Image");
        toolStripButton1.ImageTransparentColor = Color.Magenta;
        toolStripButton1.Name = "toolStripButton1";
        toolStripButton1.Size = new Size(23, 22);
        toolStripButton1.Text = "toolStripButton1";
        // 
        // toolStripSeparator1
        // 
        toolStripSeparator1.Name = "toolStripSeparator1";
        toolStripSeparator1.Size = new Size(6, 25);
        // 
        // toolStripButton2
        // 
        toolStripButton2.DisplayStyle = ToolStripItemDisplayStyle.Image;
        toolStripButton2.Image = (Image)resources.GetObject("toolStripButton2.Image");
        toolStripButton2.ImageTransparentColor = Color.Magenta;
        toolStripButton2.Name = "toolStripButton2";
        toolStripButton2.Size = new Size(23, 22);
        toolStripButton2.Text = "toolStripButton2";
        // 
        // toolStripButton3
        // 
        toolStripButton3.DisplayStyle = ToolStripItemDisplayStyle.Image;
        toolStripButton3.Image = (Image)resources.GetObject("toolStripButton3.Image");
        toolStripButton3.ImageTransparentColor = Color.Magenta;
        toolStripButton3.Name = "toolStripButton3";
        toolStripButton3.Size = new Size(23, 22);
        toolStripButton3.Text = "toolStripButton3";
        // 
        // toolStripButton4
        // 
        toolStripButton4.DisplayStyle = ToolStripItemDisplayStyle.Image;
        toolStripButton4.Image = (Image)resources.GetObject("toolStripButton4.Image");
        toolStripButton4.ImageTransparentColor = Color.Magenta;
        toolStripButton4.Name = "toolStripButton4";
        toolStripButton4.Size = new Size(23, 22);
        toolStripButton4.Text = "toolStripButton4";
        // 
        // toolStripSeparator2
        // 
        toolStripSeparator2.Name = "toolStripSeparator2";
        toolStripSeparator2.Size = new Size(6, 25);
        // 
        // toolStripLabel1
        // 
        toolStripLabel1.Name = "toolStripLabel1";
        toolStripLabel1.Size = new Size(34, 22);
        toolStripLabel1.Text = "Font:";
        // 
        // FontNameComboBox
        // 
        FontNameComboBox.Name = "FontNameComboBox";
        FontNameComboBox.Size = new Size(121, 25);
        // 
        // FontSizeComboBox
        // 
        FontSizeComboBox.Name = "FontSizeComboBox";
        FontSizeComboBox.Size = new Size(121, 25);
        // 
        // TextDocument
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(800, 450);
        Controls.Add(DocumentText);
        Controls.Add(EditStatus);
        Controls.Add(EditingStrip);
        Name = "TextDocument";
        Text = "TextDocument";
        EditingStrip.ResumeLayout(false);
        EditingStrip.PerformLayout();
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private ToolStrip EditingStrip;
    private StatusStrip EditStatus;
    private RichTextBox DocumentText;
    private ToolStripButton toolStripButton1;
    private ToolStripSeparator toolStripSeparator1;
    private ToolStripButton toolStripButton2;
    private ToolStripButton toolStripButton3;
    private ToolStripButton toolStripButton4;
    private ToolStripSeparator toolStripSeparator2;
    private ToolStripLabel toolStripLabel1;
    private ToolStripComboBox FontNameComboBox;
    private ToolStripComboBox FontSizeComboBox;
}