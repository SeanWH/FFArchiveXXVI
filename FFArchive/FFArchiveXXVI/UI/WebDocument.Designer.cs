namespace FFArchiveXXVI.UI;

partial class WebDocument
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
        var resources = new System.ComponentModel.ComponentResourceManager(typeof(WebDocument));
        WebNavToolStrip = new ToolStrip();
        toolStripButton1 = new ToolStripButton();
        toolStripButton2 = new ToolStripButton();
        toolStripButton3 = new ToolStripButton();
        toolStripSeparator1 = new ToolStripSeparator();
        WebStatusStrip = new StatusStrip();
        webView21 = new Microsoft.Web.WebView2.WinForms.WebView2();
        toolStripSpringComboBox1 = new ToolStripSpringComboBox();
        WebNavToolStrip.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)webView21).BeginInit();
        SuspendLayout();
        // 
        // WebNavToolStrip
        // 
        WebNavToolStrip.Items.AddRange(new ToolStripItem[] { toolStripButton1, toolStripButton2, toolStripButton3, toolStripSeparator1, toolStripSpringComboBox1 });
        WebNavToolStrip.Location = new Point(0, 0);
        WebNavToolStrip.Name = "WebNavToolStrip";
        WebNavToolStrip.Size = new Size(800, 25);
        WebNavToolStrip.TabIndex = 0;
        WebNavToolStrip.Text = "toolStrip1";
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
        // toolStripSeparator1
        // 
        toolStripSeparator1.Name = "toolStripSeparator1";
        toolStripSeparator1.Size = new Size(6, 25);
        // 
        // WebStatusStrip
        // 
        WebStatusStrip.Location = new Point(0, 428);
        WebStatusStrip.Name = "WebStatusStrip";
        WebStatusStrip.Size = new Size(800, 22);
        WebStatusStrip.TabIndex = 1;
        WebStatusStrip.Text = "statusStrip1";
        // 
        // webView21
        // 
        webView21.AllowExternalDrop = true;
        webView21.CreationProperties = null;
        webView21.DefaultBackgroundColor = Color.White;
        webView21.Dock = DockStyle.Fill;
        webView21.Location = new Point(0, 25);
        webView21.Name = "webView21";
        webView21.Size = new Size(800, 403);
        webView21.TabIndex = 2;
        webView21.ZoomFactor = 1D;
        // 
        // toolStripSpringComboBox1
        // 
        toolStripSpringComboBox1.Name = "toolStripSpringComboBox1";
        toolStripSpringComboBox1.Size = new Size(682, 25);
        // 
        // WebDocument
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(800, 450);
        Controls.Add(webView21);
        Controls.Add(WebStatusStrip);
        Controls.Add(WebNavToolStrip);
        Name = "WebDocument";
        Text = "WebDocument";
        WebNavToolStrip.ResumeLayout(false);
        WebNavToolStrip.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)webView21).EndInit();
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private ToolStrip WebNavToolStrip;
    private StatusStrip WebStatusStrip;
    private Microsoft.Web.WebView2.WinForms.WebView2 webView21;
    private ToolStripButton toolStripButton1;
    private ToolStripButton toolStripButton2;
    private ToolStripButton toolStripButton3;
    private ToolStripSeparator toolStripSeparator1;
    private ToolStripSpringComboBox toolStripSpringComboBox1;
}