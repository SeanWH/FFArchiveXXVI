namespace FFArchiveXXVI.UI;

using System.Windows.Forms;

using FFArchiveXXVI.Model;

public partial class Settings : Form
{
    private AppSettings AppSettings => AppSettings.Current;

    public Settings()
    {
        InitializeComponent();
        PathTextBox.Text = AppSettings.SavePath;
        ArchiveHtmlCheckBox.Checked = AppSettings.UseCompression;
        SaveHtmlFilesCheckBox.Checked = AppSettings.SaveDocumentAsHtml;
        SaveTxtFilesCheckBox.Checked = AppSettings.SaveDocumentAsText;
        ThemeComboBox.SelectedIndex = AppSettings.CurrentThemeIndex;
        AutoSaveBookmarksCheckBox.Checked = AppSettings.AutoSaveBookmarks;
    }

    private void ThemeComboBox_SelectedIndexChanged(object sender, EventArgs e)
    {
        AppSettings.CurrentThemeIndex = AppSettings.CurrentThemeIndex ==
            ThemeComboBox.SelectedIndex ?
            AppSettings.CurrentThemeIndex :
            ThemeComboBox.SelectedIndex;
    }

    private void DirPickerButton_Click(object sender, EventArgs e)
    {
        using FolderBrowserDialog folderBrowserDialog = new();
        if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
        {
            PathTextBox.Text = folderBrowserDialog.SelectedPath;
            AppSettings.SavePath = folderBrowserDialog.SelectedPath;
        }
    }

    private void SaveHtmlFilesCheckBox_CheckedChanged(object sender, EventArgs e)
    {
        AppSettings.SaveDocumentAsHtml = SaveHtmlFilesCheckBox.Checked;
    }

    private void SaveTxtFilesCheckBox_CheckedChanged(object sender, EventArgs e)
    {
        AppSettings.SaveDocumentAsText = SaveTxtFilesCheckBox.Checked;
    }

    private void AutoSaveBookmarksCheckBox_CheckedChanged(object sender, EventArgs e)
    {
        AppSettings.AutoSaveBookmarks = AutoSaveBookmarksCheckBox.Checked;
    }

    private void ArchiveHtmlCheckBox_CheckedChanged(object sender, EventArgs e)
    {
        AppSettings.UseCompression = ArchiveHtmlCheckBox.Checked;
    }

    private void ButtonOk_Click(object sender, EventArgs e)
    {
        AppSettings.Serialize();
        DialogResult = DialogResult.OK;
        Close();
    }

    private void ButtonApply_Click(object sender, EventArgs e)
    {
    }
}