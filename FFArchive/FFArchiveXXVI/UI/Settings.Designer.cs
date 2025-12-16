namespace FFArchiveXXVI.UI;

partial class Settings
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
        components = new System.ComponentModel.Container();
        tableLayoutPanel1 = new TableLayoutPanel();
        flowLayoutPanel1 = new FlowLayoutPanel();
        ButtonCancel = new Button();
        ButtonApply = new Button();
        ButtonOk = new Button();
        groupBox1 = new GroupBox();
        tableLayoutPanel2 = new TableLayoutPanel();
        groupBox3 = new GroupBox();
        tableLayoutPanel3 = new TableLayoutPanel();
        PathTextBox = new TextBox();
        DirPickerButton = new Button();
        flowLayoutPanel2 = new FlowLayoutPanel();
        SaveHtmlFilesCheckBox = new CheckBox();
        SaveTxtFilesCheckBox = new CheckBox();
        AutoSaveBookmarksCheckBox = new CheckBox();
        ArchiveHtmlCheckBox = new CheckBox();
        UseNewWindowCheckBox = new CheckBox();
        groupBox2 = new GroupBox();
        tableLayoutPanel4 = new TableLayoutPanel();
        label1 = new Label();
        ThemeComboBox = new ComboBox();
        toolTip1 = new ToolTip(components);
        tableLayoutPanel1.SuspendLayout();
        flowLayoutPanel1.SuspendLayout();
        groupBox1.SuspendLayout();
        tableLayoutPanel2.SuspendLayout();
        groupBox3.SuspendLayout();
        tableLayoutPanel3.SuspendLayout();
        flowLayoutPanel2.SuspendLayout();
        groupBox2.SuspendLayout();
        tableLayoutPanel4.SuspendLayout();
        SuspendLayout();
        // 
        // tableLayoutPanel1
        // 
        tableLayoutPanel1.ColumnCount = 2;
        tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle());
        tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle());
        tableLayoutPanel1.Controls.Add(flowLayoutPanel1, 0, 2);
        tableLayoutPanel1.Controls.Add(groupBox1, 0, 0);
        tableLayoutPanel1.Controls.Add(groupBox2, 0, 1);
        tableLayoutPanel1.Dock = DockStyle.Fill;
        tableLayoutPanel1.Location = new Point(0, 0);
        tableLayoutPanel1.Name = "tableLayoutPanel1";
        tableLayoutPanel1.RowCount = 3;
        tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 60.07067F));
        tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 27.5618382F));
        tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 12.2499695F));
        tableLayoutPanel1.Size = new Size(435, 283);
        tableLayoutPanel1.TabIndex = 0;
        // 
        // flowLayoutPanel1
        // 
        flowLayoutPanel1.AutoSize = true;
        tableLayoutPanel1.SetColumnSpan(flowLayoutPanel1, 2);
        flowLayoutPanel1.Controls.Add(ButtonCancel);
        flowLayoutPanel1.Controls.Add(ButtonApply);
        flowLayoutPanel1.Controls.Add(ButtonOk);
        flowLayoutPanel1.Dock = DockStyle.Fill;
        flowLayoutPanel1.Location = new Point(3, 251);
        flowLayoutPanel1.Name = "flowLayoutPanel1";
        flowLayoutPanel1.RightToLeft = RightToLeft.Yes;
        flowLayoutPanel1.Size = new Size(429, 29);
        flowLayoutPanel1.TabIndex = 0;
        // 
        // ButtonCancel
        // 
        ButtonCancel.Location = new Point(351, 3);
        ButtonCancel.Name = "ButtonCancel";
        ButtonCancel.Size = new Size(75, 23);
        ButtonCancel.TabIndex = 0;
        ButtonCancel.Text = "Cancel";
        ButtonCancel.UseVisualStyleBackColor = true;
        // 
        // ButtonApply
        // 
        ButtonApply.Location = new Point(270, 3);
        ButtonApply.Name = "ButtonApply";
        ButtonApply.Size = new Size(75, 23);
        ButtonApply.TabIndex = 1;
        ButtonApply.Text = "Apply";
        ButtonApply.UseVisualStyleBackColor = true;
        ButtonApply.Click += ButtonApply_Click;
        // 
        // ButtonOk
        // 
        ButtonOk.Location = new Point(189, 3);
        ButtonOk.Name = "ButtonOk";
        ButtonOk.Size = new Size(75, 23);
        ButtonOk.TabIndex = 2;
        ButtonOk.Text = "OK";
        ButtonOk.UseVisualStyleBackColor = true;
        ButtonOk.Click += ButtonOk_Click;
        // 
        // groupBox1
        // 
        tableLayoutPanel1.SetColumnSpan(groupBox1, 2);
        groupBox1.Controls.Add(tableLayoutPanel2);
        groupBox1.Dock = DockStyle.Fill;
        groupBox1.Location = new Point(3, 3);
        groupBox1.Name = "groupBox1";
        groupBox1.Size = new Size(429, 164);
        groupBox1.TabIndex = 1;
        groupBox1.TabStop = false;
        groupBox1.Text = "General";
        // 
        // tableLayoutPanel2
        // 
        tableLayoutPanel2.ColumnCount = 2;
        tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
        tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
        tableLayoutPanel2.Controls.Add(groupBox3, 0, 0);
        tableLayoutPanel2.Controls.Add(flowLayoutPanel2, 0, 1);
        tableLayoutPanel2.Dock = DockStyle.Fill;
        tableLayoutPanel2.Location = new Point(3, 19);
        tableLayoutPanel2.Name = "tableLayoutPanel2";
        tableLayoutPanel2.RowCount = 2;
        tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 42.53731F));
        tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 57.46269F));
        tableLayoutPanel2.Size = new Size(423, 142);
        tableLayoutPanel2.TabIndex = 0;
        // 
        // groupBox3
        // 
        tableLayoutPanel2.SetColumnSpan(groupBox3, 2);
        groupBox3.Controls.Add(tableLayoutPanel3);
        groupBox3.Dock = DockStyle.Fill;
        groupBox3.Location = new Point(3, 3);
        groupBox3.Name = "groupBox3";
        groupBox3.Size = new Size(417, 54);
        groupBox3.TabIndex = 0;
        groupBox3.TabStop = false;
        groupBox3.Text = "Save Files To:";
        // 
        // tableLayoutPanel3
        // 
        tableLayoutPanel3.ColumnCount = 2;
        tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 89.2944F));
        tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10.705596F));
        tableLayoutPanel3.Controls.Add(PathTextBox, 0, 0);
        tableLayoutPanel3.Controls.Add(DirPickerButton, 1, 0);
        tableLayoutPanel3.Dock = DockStyle.Fill;
        tableLayoutPanel3.Location = new Point(3, 19);
        tableLayoutPanel3.Name = "tableLayoutPanel3";
        tableLayoutPanel3.RowCount = 1;
        tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
        tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
        tableLayoutPanel3.Size = new Size(411, 32);
        tableLayoutPanel3.TabIndex = 0;
        // 
        // PathTextBox
        // 
        PathTextBox.Dock = DockStyle.Fill;
        PathTextBox.Location = new Point(3, 3);
        PathTextBox.Name = "PathTextBox";
        PathTextBox.Size = new Size(361, 23);
        PathTextBox.TabIndex = 0;
        // 
        // DirPickerButton
        // 
        DirPickerButton.Dock = DockStyle.Fill;
        DirPickerButton.Location = new Point(370, 3);
        DirPickerButton.Name = "DirPickerButton";
        DirPickerButton.Size = new Size(38, 26);
        DirPickerButton.TabIndex = 1;
        DirPickerButton.Text = "...";
        toolTip1.SetToolTip(DirPickerButton, "Select directory to save files to");
        DirPickerButton.UseVisualStyleBackColor = true;
        DirPickerButton.Click += DirPickerButton_Click;
        // 
        // flowLayoutPanel2
        // 
        tableLayoutPanel2.SetColumnSpan(flowLayoutPanel2, 2);
        flowLayoutPanel2.Controls.Add(SaveHtmlFilesCheckBox);
        flowLayoutPanel2.Controls.Add(SaveTxtFilesCheckBox);
        flowLayoutPanel2.Controls.Add(AutoSaveBookmarksCheckBox);
        flowLayoutPanel2.Controls.Add(ArchiveHtmlCheckBox);
        flowLayoutPanel2.Controls.Add(UseNewWindowCheckBox);
        flowLayoutPanel2.Dock = DockStyle.Fill;
        flowLayoutPanel2.FlowDirection = FlowDirection.TopDown;
        flowLayoutPanel2.Location = new Point(3, 63);
        flowLayoutPanel2.Name = "flowLayoutPanel2";
        flowLayoutPanel2.Size = new Size(417, 76);
        flowLayoutPanel2.TabIndex = 1;
        // 
        // SaveHtmlFilesCheckBox
        // 
        SaveHtmlFilesCheckBox.AutoSize = true;
        SaveHtmlFilesCheckBox.Location = new Point(3, 3);
        SaveHtmlFilesCheckBox.Name = "SaveHtmlFilesCheckBox";
        SaveHtmlFilesCheckBox.Size = new Size(112, 19);
        SaveHtmlFilesCheckBox.TabIndex = 0;
        SaveHtmlFilesCheckBox.Text = "Save HTML Files";
        SaveHtmlFilesCheckBox.UseVisualStyleBackColor = true;
        SaveHtmlFilesCheckBox.CheckedChanged += SaveHtmlFilesCheckBox_CheckedChanged;
        // 
        // SaveTxtFilesCheckBox
        // 
        SaveTxtFilesCheckBox.AutoSize = true;
        SaveTxtFilesCheckBox.Location = new Point(3, 28);
        SaveTxtFilesCheckBox.Name = "SaveTxtFilesCheckBox";
        SaveTxtFilesCheckBox.Size = new Size(116, 19);
        SaveTxtFilesCheckBox.TabIndex = 1;
        SaveTxtFilesCheckBox.Text = "Save As Text Files";
        SaveTxtFilesCheckBox.UseVisualStyleBackColor = true;
        SaveTxtFilesCheckBox.CheckedChanged += SaveTxtFilesCheckBox_CheckedChanged;
        // 
        // AutoSaveBookmarksCheckBox
        // 
        AutoSaveBookmarksCheckBox.AutoSize = true;
        AutoSaveBookmarksCheckBox.Location = new Point(3, 53);
        AutoSaveBookmarksCheckBox.Name = "AutoSaveBookmarksCheckBox";
        AutoSaveBookmarksCheckBox.Size = new Size(141, 19);
        AutoSaveBookmarksCheckBox.TabIndex = 2;
        AutoSaveBookmarksCheckBox.Text = "Auto Save Bookmarks";
        AutoSaveBookmarksCheckBox.UseVisualStyleBackColor = true;
        AutoSaveBookmarksCheckBox.CheckedChanged += AutoSaveBookmarksCheckBox_CheckedChanged;
        // 
        // ArchiveHtmlCheckBox
        // 
        ArchiveHtmlCheckBox.AutoSize = true;
        ArchiveHtmlCheckBox.Location = new Point(150, 3);
        ArchiveHtmlCheckBox.Name = "ArchiveHtmlCheckBox";
        ArchiveHtmlCheckBox.Size = new Size(182, 19);
        ArchiveHtmlCheckBox.TabIndex = 3;
        ArchiveHtmlCheckBox.Text = "Archive HTML Files in Zip File";
        ArchiveHtmlCheckBox.UseVisualStyleBackColor = true;
        ArchiveHtmlCheckBox.CheckedChanged += ArchiveHtmlCheckBox_CheckedChanged;
        // 
        // UseNewWindowCheckBox
        // 
        UseNewWindowCheckBox.AutoSize = true;
        UseNewWindowCheckBox.Location = new Point(150, 28);
        UseNewWindowCheckBox.Name = "checkBoxUseNewWindow";
        UseNewWindowCheckBox.Size = new Size(226, 19);
        UseNewWindowCheckBox.TabIndex = 4;
        UseNewWindowCheckBox.Text = "Open Each Web Page in New Window";
        UseNewWindowCheckBox.UseVisualStyleBackColor = true;
        UseNewWindowCheckBox.CheckedChanged += UseNewWindowCheckBox_CheckedChanged;
        // 
        // groupBox2
        // 
        tableLayoutPanel1.SetColumnSpan(groupBox2, 2);
        groupBox2.Controls.Add(tableLayoutPanel4);
        groupBox2.Dock = DockStyle.Fill;
        groupBox2.Location = new Point(3, 173);
        groupBox2.Name = "groupBox2";
        groupBox2.Size = new Size(429, 72);
        groupBox2.TabIndex = 2;
        groupBox2.TabStop = false;
        groupBox2.Text = "Appearance";
        // 
        // tableLayoutPanel4
        // 
        tableLayoutPanel4.ColumnCount = 2;
        tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle());
        tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle());
        tableLayoutPanel4.Controls.Add(label1, 0, 0);
        tableLayoutPanel4.Controls.Add(ThemeComboBox, 1, 0);
        tableLayoutPanel4.Dock = DockStyle.Fill;
        tableLayoutPanel4.Location = new Point(3, 19);
        tableLayoutPanel4.Name = "tableLayoutPanel4";
        tableLayoutPanel4.RowCount = 2;
        tableLayoutPanel4.RowStyles.Add(new RowStyle());
        tableLayoutPanel4.RowStyles.Add(new RowStyle());
        tableLayoutPanel4.Size = new Size(423, 50);
        tableLayoutPanel4.TabIndex = 0;
        // 
        // label1
        // 
        label1.AutoSize = true;
        label1.Dock = DockStyle.Fill;
        label1.Location = new Point(3, 0);
        label1.Name = "label1";
        label1.Size = new Size(47, 29);
        label1.TabIndex = 0;
        label1.Text = "Theme:";
        label1.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // ThemeComboBox
        // 
        ThemeComboBox.Dock = DockStyle.Fill;
        ThemeComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
        ThemeComboBox.FormattingEnabled = true;
        ThemeComboBox.Items.AddRange(new object[] { "Visual Studio 2003", "Visual Studio 2005", "Visual Studio 2012 Light", "Visual Studio 2012 Blue", "Visual Studio 2012 Dark", "Visual Studio 2013 Light", "Visual Studio 2013 Blue", "Visual Studio 2013 Dark", "Visual Studio 2015 Light", "Visual Studio 2015 Blue", "Visual Studio 2015 Dark" });
        ThemeComboBox.Location = new Point(56, 3);
        ThemeComboBox.Name = "ThemeComboBox";
        ThemeComboBox.Size = new Size(364, 23);
        ThemeComboBox.TabIndex = 1;
        ThemeComboBox.SelectedIndexChanged += ThemeComboBox_SelectedIndexChanged;
        // 
        // Settings
        // 
        AcceptButton = ButtonOk;
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        CancelButton = ButtonCancel;
        ClientSize = new Size(435, 283);
        Controls.Add(tableLayoutPanel1);
        FormBorderStyle = FormBorderStyle.FixedDialog;
        MaximizeBox = false;
        MinimizeBox = false;
        Name = "Settings";
        ShowIcon = false;
        ShowInTaskbar = false;
        Text = "Settings";
        tableLayoutPanel1.ResumeLayout(false);
        tableLayoutPanel1.PerformLayout();
        flowLayoutPanel1.ResumeLayout(false);
        groupBox1.ResumeLayout(false);
        tableLayoutPanel2.ResumeLayout(false);
        groupBox3.ResumeLayout(false);
        tableLayoutPanel3.ResumeLayout(false);
        tableLayoutPanel3.PerformLayout();
        flowLayoutPanel2.ResumeLayout(false);
        flowLayoutPanel2.PerformLayout();
        groupBox2.ResumeLayout(false);
        tableLayoutPanel4.ResumeLayout(false);
        tableLayoutPanel4.PerformLayout();
        ResumeLayout(false);
    }

    #endregion

    private TableLayoutPanel tableLayoutPanel1;
    private FlowLayoutPanel flowLayoutPanel1;
    private Button ButtonCancel;
    private Button ButtonApply;
    private Button ButtonOk;
    private GroupBox groupBox1;
    private GroupBox groupBox2;
    private TableLayoutPanel tableLayoutPanel2;
    private GroupBox groupBox3;
    private ToolTip toolTip1;
    private TableLayoutPanel tableLayoutPanel3;
    private TextBox PathTextBox;
    private Button DirPickerButton;
    private FlowLayoutPanel flowLayoutPanel2;
    private CheckBox SaveHtmlFilesCheckBox;
    private CheckBox SaveTxtFilesCheckBox;
    private TableLayoutPanel tableLayoutPanel4;
    private Label label1;
    private ComboBox ThemeComboBox;
    private CheckBox AutoSaveBookmarksCheckBox;
    private CheckBox ArchiveHtmlCheckBox;
    private CheckBox UseNewWindowCheckBox;
}