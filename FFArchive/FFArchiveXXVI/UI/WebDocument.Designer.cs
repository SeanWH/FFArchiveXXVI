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
        WebNavToolStrip = new ToolStrip();
        WebStatusStrip = new StatusStrip();
        webView21 = new Microsoft.Web.WebView2.WinForms.WebView2();
        ((System.ComponentModel.ISupportInitialize)webView21).BeginInit();
        SuspendLayout();
        // 
        // WebNavToolStrip
        // 
        WebNavToolStrip.Location = new Point(0, 0);
        WebNavToolStrip.Name = "WebNavToolStrip";
        WebNavToolStrip.Size = new Size(800, 25);
        WebNavToolStrip.TabIndex = 0;
        WebNavToolStrip.Text = "toolStrip1";
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
        ((System.ComponentModel.ISupportInitialize)webView21).EndInit();
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private ToolStrip WebNavToolStrip;
    private StatusStrip WebStatusStrip;
    private Microsoft.Web.WebView2.WinForms.WebView2 webView21;
}