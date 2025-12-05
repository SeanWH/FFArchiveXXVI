namespace FFArchiveXXVI.UI;

partial class LocalFileNavPanel
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
        var resources = new System.ComponentModel.ComponentResourceManager(typeof(LocalFileNavPanel));
        LocalFileToolStrip = new ToolStrip();
        LocalFileTreeView = new TreeView();
        toolStripButton1 = new ToolStripButton();
        toolStripButton2 = new ToolStripButton();
        toolStripButton3 = new ToolStripButton();
        toolStripLabel1 = new ToolStripLabel();
        LocalFileToolStrip.SuspendLayout();
        SuspendLayout();
        // 
        // LocalFileToolStrip
        // 
        LocalFileToolStrip.GripStyle = ToolStripGripStyle.Hidden;
        LocalFileToolStrip.Items.AddRange(new ToolStripItem[] { toolStripLabel1, toolStripButton1, toolStripButton2, toolStripButton3 });
        LocalFileToolStrip.Location = new Point(0, 0);
        LocalFileToolStrip.Name = "LocalFileToolStrip";
        LocalFileToolStrip.Size = new Size(238, 25);
        LocalFileToolStrip.TabIndex = 0;
        LocalFileToolStrip.Text = "LocalFileToolStrip";
        // 
        // LocalFileTreeView
        // 
        LocalFileTreeView.Dock = DockStyle.Fill;
        LocalFileTreeView.Location = new Point(0, 25);
        LocalFileTreeView.Name = "LocalFileTreeView";
        LocalFileTreeView.Size = new Size(238, 425);
        LocalFileTreeView.TabIndex = 1;
        // 
        // toolStripButton1
        // 
        toolStripButton1.CheckOnClick = true;
        toolStripButton1.DisplayStyle = ToolStripItemDisplayStyle.Text;
        toolStripButton1.Image = (Image)resources.GetObject("toolStripButton1.Image");
        toolStripButton1.ImageTransparentColor = Color.Magenta;
        toolStripButton1.Name = "toolStripButton1";
        toolStripButton1.Size = new Size(32, 22);
        toolStripButton1.Text = "TXT";
        // 
        // toolStripButton2
        // 
        toolStripButton2.CheckOnClick = true;
        toolStripButton2.DisplayStyle = ToolStripItemDisplayStyle.Text;
        toolStripButton2.Image = (Image)resources.GetObject("toolStripButton2.Image");
        toolStripButton2.ImageTransparentColor = Color.Magenta;
        toolStripButton2.Name = "toolStripButton2";
        toolStripButton2.Size = new Size(30, 22);
        toolStripButton2.Text = "RTF";
        // 
        // toolStripButton3
        // 
        toolStripButton3.Checked = true;
        toolStripButton3.CheckOnClick = true;
        toolStripButton3.CheckState = CheckState.Checked;
        toolStripButton3.DisplayStyle = ToolStripItemDisplayStyle.Text;
        toolStripButton3.Image = (Image)resources.GetObject("toolStripButton3.Image");
        toolStripButton3.ImageTransparentColor = Color.Magenta;
        toolStripButton3.Name = "toolStripButton3";
        toolStripButton3.Size = new Size(44, 22);
        toolStripButton3.Text = "HTML";
        toolStripButton3.TextImageRelation = TextImageRelation.TextAboveImage;
        // 
        // toolStripLabel1
        // 
        toolStripLabel1.Name = "toolStripLabel1";
        toolStripLabel1.Size = new Size(36, 22);
        toolStripLabel1.Text = "Filter:";
        // 
        // LocalFileNavPanel
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(238, 450);
        Controls.Add(LocalFileTreeView);
        Controls.Add(LocalFileToolStrip);
        Name = "LocalFileNavPanel";
        Text = "Local Files";
        LocalFileToolStrip.ResumeLayout(false);
        LocalFileToolStrip.PerformLayout();
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private ToolStrip LocalFileToolStrip;
    private TreeView LocalFileTreeView;
    private ToolStripButton toolStripButton1;
    private ToolStripButton toolStripButton2;
    private ToolStripButton toolStripButton3;
    private ToolStripLabel toolStripLabel1;
}