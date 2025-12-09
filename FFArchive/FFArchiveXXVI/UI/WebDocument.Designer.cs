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
        BackButton = new ToolStripButton();
        ForwardButton = new ToolStripButton();
        ReloadButton = new ToolStripButton();
        toolStripSeparator1 = new ToolStripSeparator();
        WebAddressBox = new ToolStripSpringComboBox();
        GoButton = new ToolStripButton();
        WebStatusStrip = new StatusStrip();
        webView21 = new Microsoft.Web.WebView2.WinForms.WebView2();
        StatusLabel = new ToolStripStatusLabel();
        WebNavToolStrip.SuspendLayout();
        WebStatusStrip.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)webView21).BeginInit();
        SuspendLayout();
        // 
        // WebNavToolStrip
        // 
        WebNavToolStrip.Items.AddRange(new ToolStripItem[] { BackButton, ForwardButton, ReloadButton, toolStripSeparator1, WebAddressBox, GoButton });
        WebNavToolStrip.Location = new Point(0, 0);
        WebNavToolStrip.Name = "WebNavToolStrip";
        WebNavToolStrip.Size = new Size(800, 25);
        WebNavToolStrip.TabIndex = 0;
        WebNavToolStrip.Text = "toolStrip1";
        // 
        // BackButton
        // 
        BackButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
        BackButton.Image = (Image)resources.GetObject("BackButton.Image");
        BackButton.ImageTransparentColor = Color.Magenta;
        BackButton.Name = "BackButton";
        BackButton.Size = new Size(23, 22);
        BackButton.Text = "Back";
        // 
        // ForwardButton
        // 
        ForwardButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
        ForwardButton.Image = (Image)resources.GetObject("ForwardButton.Image");
        ForwardButton.ImageTransparentColor = Color.Magenta;
        ForwardButton.Name = "ForwardButton";
        ForwardButton.Size = new Size(23, 22);
        ForwardButton.Text = "Forward";
        // 
        // ReloadButton
        // 
        ReloadButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
        ReloadButton.Image = (Image)resources.GetObject("ReloadButton.Image");
        ReloadButton.ImageTransparentColor = Color.Magenta;
        ReloadButton.Name = "ReloadButton";
        ReloadButton.Size = new Size(23, 22);
        ReloadButton.Text = "Refresh";
        // 
        // toolStripSeparator1
        // 
        toolStripSeparator1.Name = "toolStripSeparator1";
        toolStripSeparator1.Size = new Size(6, 25);
        // 
        // WebAddressBox
        // 
        WebAddressBox.AutoCompleteMode = AutoCompleteMode.Suggest;
        WebAddressBox.AutoCompleteSource = AutoCompleteSource.AllUrl;
        WebAddressBox.Name = "WebAddressBox";
        WebAddressBox.Size = new Size(659, 25);
        // 
        // GoButton
        // 
        GoButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
        GoButton.Image = (Image)resources.GetObject("GoButton.Image");
        GoButton.ImageTransparentColor = Color.Magenta;
        GoButton.Name = "GoButton";
        GoButton.Size = new Size(23, 22);
        GoButton.Text = "toolStripButton1";
        // 
        // WebStatusStrip
        // 
        WebStatusStrip.Items.AddRange(new ToolStripItem[] { StatusLabel });
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
        // StatusLabel
        // 
        StatusLabel.Name = "StatusLabel";
        StatusLabel.Size = new Size(24, 17);
        StatusLabel.Text = "Init";
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
        WebStatusStrip.ResumeLayout(false);
        WebStatusStrip.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)webView21).EndInit();
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private ToolStrip WebNavToolStrip;
    private StatusStrip WebStatusStrip;
    private Microsoft.Web.WebView2.WinForms.WebView2 webView21;
    private ToolStripButton BackButton;
    private ToolStripButton ForwardButton;
    private ToolStripButton ReloadButton;
    private ToolStripSeparator toolStripSeparator1;
    private ToolStripSpringComboBox WebAddressBox;
    private ToolStripButton GoButton;
    private ToolStripStatusLabel StatusLabel;
}