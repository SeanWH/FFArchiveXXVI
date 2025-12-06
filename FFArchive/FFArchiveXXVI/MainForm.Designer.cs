namespace FFArchiveXXVI;

partial class MainForm
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
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
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        components = new System.ComponentModel.Container();
        menuStrip1 = new MenuStrip();
        fileToolStripMenuItem = new ToolStripMenuItem();
        exitToolStripMenuItem = new ToolStripMenuItem();
        toolsToolStripMenuItem = new ToolStripMenuItem();
        optionsToolStripMenuItem = new ToolStripMenuItem();
        statusStrip1 = new StatusStrip();
        dockPanel1 = new WeifenLuo.WinFormsUI.Docking.DockPanel();
        vS2005Theme1 = new WeifenLuo.WinFormsUI.Docking.VS2005Theme();
        vS2003Theme1 = new WeifenLuo.WinFormsUI.Docking.VS2003Theme();
        vS2013DarkTheme1 = new WeifenLuo.WinFormsUI.Docking.VS2013DarkTheme();
        vS2015BlueTheme1 = new WeifenLuo.WinFormsUI.Docking.VS2015BlueTheme();
        vS2015DarkTheme1 = new WeifenLuo.WinFormsUI.Docking.VS2015DarkTheme();
        vS2015LightTheme1 = new WeifenLuo.WinFormsUI.Docking.VS2015LightTheme();
        vS2012BlueTheme1 = new WeifenLuo.WinFormsUI.Docking.VS2012BlueTheme();
        vS2012DarkTheme1 = new WeifenLuo.WinFormsUI.Docking.VS2012DarkTheme();
        vS2012LightTheme1 = new WeifenLuo.WinFormsUI.Docking.VS2012LightTheme();
        vS2013BlueTheme1 = new WeifenLuo.WinFormsUI.Docking.VS2013BlueTheme();
        vS2013LightTheme1 = new WeifenLuo.WinFormsUI.Docking.VS2013LightTheme();
        visualStudioToolStripExtender1 = new WeifenLuo.WinFormsUI.Docking.VisualStudioToolStripExtender(components);
        menuStrip1.SuspendLayout();
        SuspendLayout();
        // 
        // menuStrip1
        // 
        menuStrip1.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem, toolsToolStripMenuItem });
        menuStrip1.Location = new Point(0, 0);
        menuStrip1.Name = "menuStrip1";
        menuStrip1.Size = new Size(800, 24);
        menuStrip1.TabIndex = 0;
        menuStrip1.Text = "menuStrip1";
        // 
        // fileToolStripMenuItem
        // 
        fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { exitToolStripMenuItem });
        fileToolStripMenuItem.Name = "fileToolStripMenuItem";
        fileToolStripMenuItem.Size = new Size(37, 20);
        fileToolStripMenuItem.Text = "&File";
        // 
        // exitToolStripMenuItem
        // 
        exitToolStripMenuItem.Name = "exitToolStripMenuItem";
        exitToolStripMenuItem.Size = new Size(92, 22);
        exitToolStripMenuItem.Text = "Exit";
        // 
        // toolsToolStripMenuItem
        // 
        toolsToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { optionsToolStripMenuItem });
        toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
        toolsToolStripMenuItem.Size = new Size(47, 20);
        toolsToolStripMenuItem.Text = "Tools";
        // 
        // optionsToolStripMenuItem
        // 
        optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
        optionsToolStripMenuItem.Size = new Size(116, 22);
        optionsToolStripMenuItem.Text = "Options";
        optionsToolStripMenuItem.Click += optionsToolStripMenuItem_Click;
        // 
        // statusStrip1
        // 
        statusStrip1.Location = new Point(0, 428);
        statusStrip1.Name = "statusStrip1";
        statusStrip1.Size = new Size(800, 22);
        statusStrip1.TabIndex = 2;
        statusStrip1.Text = "statusStrip1";
        // 
        // dockPanel1
        // 
        dockPanel1.Dock = DockStyle.Fill;
        dockPanel1.DockBackColor = Color.FromArgb(45, 45, 48);
        dockPanel1.DocumentStyle = WeifenLuo.WinFormsUI.Docking.DocumentStyle.DockingMdi;
        dockPanel1.Location = new Point(0, 24);
        dockPanel1.Name = "dockPanel1";
        dockPanel1.Size = new Size(800, 404);
        dockPanel1.TabIndex = 3;
        dockPanel1.Theme = vS2005Theme1;
        // 
        // visualStudioToolStripExtender1
        // 
        visualStudioToolStripExtender1.DefaultRenderer = null;
        // 
        // MainForm
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(800, 450);
        Controls.Add(dockPanel1);
        Controls.Add(statusStrip1);
        Controls.Add(menuStrip1);
        MainMenuStrip = menuStrip1;
        Name = "MainForm";
        Text = "Form1";
        FormClosing += MainForm_FormClosing;
        Load += MainForm_Load;
        menuStrip1.ResumeLayout(false);
        menuStrip1.PerformLayout();
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private MenuStrip menuStrip1;
    private StatusStrip statusStrip1;
    private WeifenLuo.WinFormsUI.Docking.DockPanel dockPanel1;
    private WeifenLuo.WinFormsUI.Docking.VS2003Theme vS2003Theme1;
    private WeifenLuo.WinFormsUI.Docking.VS2015BlueTheme vS2015BlueTheme1;
    private WeifenLuo.WinFormsUI.Docking.VS2015DarkTheme vS2015DarkTheme1;
    private WeifenLuo.WinFormsUI.Docking.VS2015LightTheme vS2015LightTheme1;
    private WeifenLuo.WinFormsUI.Docking.VS2012BlueTheme vS2012BlueTheme1;
    private WeifenLuo.WinFormsUI.Docking.VS2012DarkTheme vS2012DarkTheme1;
    private WeifenLuo.WinFormsUI.Docking.VS2012LightTheme vS2012LightTheme1;
    private WeifenLuo.WinFormsUI.Docking.VS2013BlueTheme vS2013BlueTheme1;
    private WeifenLuo.WinFormsUI.Docking.VS2013DarkTheme vS2013DarkTheme1;
    private WeifenLuo.WinFormsUI.Docking.VS2013LightTheme vS2013LightTheme1;
    private WeifenLuo.WinFormsUI.Docking.VS2005Theme vS2005Theme1;
    private WeifenLuo.WinFormsUI.Docking.VisualStudioToolStripExtender visualStudioToolStripExtender1;
    private ToolStripMenuItem fileToolStripMenuItem;
    private ToolStripMenuItem exitToolStripMenuItem;
    private ToolStripMenuItem toolsToolStripMenuItem;
    private ToolStripMenuItem optionsToolStripMenuItem;
}
