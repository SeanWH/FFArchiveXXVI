namespace FFArchiveXXVI.UI;

partial class ImportBookmarkDialog
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
        tableLayoutPanel1 = new TableLayoutPanel();
        groupBox1 = new GroupBox();
        tableLayoutPanel2 = new TableLayoutPanel();
        PathToImportFileTextBox = new TextBox();
        ChooseImportFileButton = new Button();
        groupBox2 = new GroupBox();
        ImportProgressBar = new ProgressBar();
        flowLayoutPanel1 = new FlowLayoutPanel();
        CancelButton = new Button();
        OkButton = new Button();
        tableLayoutPanel1.SuspendLayout();
        groupBox1.SuspendLayout();
        tableLayoutPanel2.SuspendLayout();
        groupBox2.SuspendLayout();
        flowLayoutPanel1.SuspendLayout();
        SuspendLayout();
        // 
        // tableLayoutPanel1
        // 
        tableLayoutPanel1.ColumnCount = 1;
        tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        tableLayoutPanel1.Controls.Add(groupBox1, 0, 0);
        tableLayoutPanel1.Controls.Add(groupBox2, 0, 1);
        tableLayoutPanel1.Controls.Add(flowLayoutPanel1, 0, 2);
        tableLayoutPanel1.Dock = DockStyle.Fill;
        tableLayoutPanel1.Location = new Point(0, 0);
        tableLayoutPanel1.Name = "tableLayoutPanel1";
        tableLayoutPanel1.RowCount = 3;
        tableLayoutPanel1.RowStyles.Add(new RowStyle());
        tableLayoutPanel1.RowStyles.Add(new RowStyle());
        tableLayoutPanel1.RowStyles.Add(new RowStyle());
        tableLayoutPanel1.Size = new Size(406, 174);
        tableLayoutPanel1.TabIndex = 0;
        // 
        // groupBox1
        // 
        groupBox1.Controls.Add(tableLayoutPanel2);
        groupBox1.Dock = DockStyle.Fill;
        groupBox1.Location = new Point(3, 3);
        groupBox1.Name = "groupBox1";
        groupBox1.Size = new Size(400, 52);
        groupBox1.TabIndex = 0;
        groupBox1.TabStop = false;
        groupBox1.Text = "Path to Import File:";
        // 
        // tableLayoutPanel2
        // 
        tableLayoutPanel2.ColumnCount = 2;
        tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 88.3248749F));
        tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 11.675127F));
        tableLayoutPanel2.Controls.Add(PathToImportFileTextBox, 0, 0);
        tableLayoutPanel2.Controls.Add(ChooseImportFileButton, 1, 0);
        tableLayoutPanel2.Dock = DockStyle.Fill;
        tableLayoutPanel2.Location = new Point(3, 19);
        tableLayoutPanel2.Name = "tableLayoutPanel2";
        tableLayoutPanel2.RowCount = 1;
        tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
        tableLayoutPanel2.Size = new Size(394, 30);
        tableLayoutPanel2.TabIndex = 0;
        // 
        // PathToImportFileTextBox
        // 
        PathToImportFileTextBox.Dock = DockStyle.Fill;
        PathToImportFileTextBox.Location = new Point(3, 3);
        PathToImportFileTextBox.Name = "PathToImportFileTextBox";
        PathToImportFileTextBox.Size = new Size(342, 23);
        PathToImportFileTextBox.TabIndex = 0;
        // 
        // ChooseImportFileButton
        // 
        ChooseImportFileButton.Dock = DockStyle.Fill;
        ChooseImportFileButton.Location = new Point(351, 3);
        ChooseImportFileButton.Name = "ChooseImportFileButton";
        ChooseImportFileButton.Size = new Size(40, 24);
        ChooseImportFileButton.TabIndex = 1;
        ChooseImportFileButton.Text = "...";
        ChooseImportFileButton.UseVisualStyleBackColor = true;
        ChooseImportFileButton.Click += ChooseImportFileButton_Click;
        // 
        // groupBox2
        // 
        groupBox2.Controls.Add(ImportProgressBar);
        groupBox2.Dock = DockStyle.Fill;
        groupBox2.Location = new Point(3, 61);
        groupBox2.Name = "groupBox2";
        groupBox2.Size = new Size(400, 44);
        groupBox2.TabIndex = 1;
        groupBox2.TabStop = false;
        groupBox2.Text = "Import Progress";
        // 
        // ImportProgressBar
        // 
        ImportProgressBar.Dock = DockStyle.Fill;
        ImportProgressBar.Location = new Point(3, 19);
        ImportProgressBar.Name = "ImportProgressBar";
        ImportProgressBar.Size = new Size(394, 22);
        ImportProgressBar.TabIndex = 0;
        // 
        // flowLayoutPanel1
        // 
        flowLayoutPanel1.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
        flowLayoutPanel1.Controls.Add(CancelButton);
        flowLayoutPanel1.Controls.Add(OkButton);
        flowLayoutPanel1.Location = new Point(3, 135);
        flowLayoutPanel1.Name = "flowLayoutPanel1";
        flowLayoutPanel1.RightToLeft = RightToLeft.Yes;
        flowLayoutPanel1.Size = new Size(400, 36);
        flowLayoutPanel1.TabIndex = 2;
        // 
        // CancelButton
        // 
        CancelButton.Dock = DockStyle.Right;
        CancelButton.Location = new Point(325, 3);
        CancelButton.Name = "CancelButton";
        CancelButton.Size = new Size(72, 26);
        CancelButton.TabIndex = 1;
        CancelButton.Text = "Cancel";
        CancelButton.UseVisualStyleBackColor = true;
        CancelButton.Click += CancelButton_Click;
        // 
        // OkButton
        // 
        OkButton.Dock = DockStyle.Top;
        OkButton.Location = new Point(247, 3);
        OkButton.Name = "OkButton";
        OkButton.Size = new Size(72, 26);
        OkButton.TabIndex = 0;
        OkButton.Text = "OK";
        OkButton.UseVisualStyleBackColor = true;
        OkButton.Click += OkButton_Click;
        // 
        // ImportBookmarkDialog
        // 
        AcceptButton = OkButton;
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        CancelButton = CancelButton;
        ClientSize = new Size(406, 174);
        Controls.Add(tableLayoutPanel1);
        FormBorderStyle = FormBorderStyle.FixedDialog;
        MaximizeBox = false;
        MinimizeBox = false;
        Name = "ImportBookmarkDialog";
        Text = "Import Bookmarks";
        tableLayoutPanel1.ResumeLayout(false);
        groupBox1.ResumeLayout(false);
        tableLayoutPanel2.ResumeLayout(false);
        tableLayoutPanel2.PerformLayout();
        groupBox2.ResumeLayout(false);
        flowLayoutPanel1.ResumeLayout(false);
        ResumeLayout(false);
    }

    #endregion

    private TableLayoutPanel tableLayoutPanel1;
    private GroupBox groupBox1;
    private TableLayoutPanel tableLayoutPanel2;
    private GroupBox groupBox2;
    private FlowLayoutPanel flowLayoutPanel1;
    private Button OkButton;
    private Button CancelButton;
    private TextBox PathToImportFileTextBox;
    private Button ChooseImportFileButton;
    private ProgressBar ImportProgressBar;
}