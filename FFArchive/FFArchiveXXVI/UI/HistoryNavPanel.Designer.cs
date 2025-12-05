namespace FFArchiveXXVI.UI;

partial class HistoryNavPanel
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
        HistoryTreeView = new TreeView();
        SuspendLayout();
        // 
        // HistoryTreeView
        // 
        HistoryTreeView.Dock = DockStyle.Fill;
        HistoryTreeView.Location = new Point(0, 0);
        HistoryTreeView.Name = "HistoryTreeView";
        HistoryTreeView.Size = new Size(259, 450);
        HistoryTreeView.TabIndex = 0;
        // 
        // HistoryNavPanel
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(259, 450);
        Controls.Add(HistoryTreeView);
        Name = "HistoryNavPanel";
        Text = "History";
        ResumeLayout(false);
    }

    #endregion

    private TreeView HistoryTreeView;
}