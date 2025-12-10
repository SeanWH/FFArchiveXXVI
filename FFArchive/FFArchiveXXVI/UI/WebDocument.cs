using System.ComponentModel;

namespace FFArchiveXXVI.UI;

using System;
using System.Text;
using System.Windows.Forms;

using FFArchiveXXVI.Model;
using FFArchiveXXVI.Model.Addresses;

using Microsoft.Web.WebView2.Core;
using Microsoft.Web.WebView2.WinForms;

using WeifenLuo.WinFormsUI.Docking;

public partial class WebDocument : DockContent
{
    private string _lastInitializeScriptId;
    private List<CoreWebView2Frame> _webView2Frames = new();

    private void WebView_HandleIFrames(object sender, CoreWebView2FrameCreatedEventArgs args)
    {
        _webView2Frames.Add(args.Frame);
        args.Frame.Destroyed += WebViewFrames_DestroyNestedIFrames;
    }

    private void WebViewFrames_DestroyNestedIFrames(object? sender, object e)
    {
        try
        {
            var frameToRemove = _webView2Frames.SingleOrDefault(r => r.IsDestroyed() == 1);
            if (frameToRemove != null)
            {
                _webView2Frames.Remove(frameToRemove);
            }
        }
        catch (InvalidOperationException ex)
        {
            MessageBox.Show($"Error removing destroyed frame: {ex.Message}");
        }
    }

    private string WebViewFrames_ToString()
    {
        string result = "";
        for (var i = 0; i < _webView2Frames.Count; i++)
        {
            if (i > 0) result += "; ";
            result += i.ToString() + " " +
                (String.IsNullOrEmpty(_webView2Frames[i].Name) ? "<empty_name>" : _webView2Frames[i].Name);
        }
        return String.IsNullOrEmpty(result) ? "no iframes available." : result;
    }

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public CoreWebView2CreationProperties CreationProperties
    {
        get
        {
            if (field == null)
            {
                field = new CoreWebView2CreationProperties();
            }
            return field;
        }
        set
        {
            field = value;
            webView21.CreationProperties = value;
        }
    } = null;

    private CoreWebView2Settings _webViewSettings;

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    private CoreWebView2Settings WebViewSettings
    {
        get
        {
            if (_webViewSettings == null && webView21?.CoreWebView2 != null)
            {
                _webViewSettings = webView21.CoreWebView2.Settings;
            }
            return _webViewSettings;
        }
    }

    private CoreWebView2Environment _webViewEnvironment;

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    private CoreWebView2Environment WebViewEnvironment
    {
        get
        {
            if (_webViewEnvironment == null && webView21?.CoreWebView2 != null)
            {
                _webViewEnvironment = webView21.CoreWebView2.Environment;
            }
            return _webViewEnvironment;
        }
    }

    public WebDocument()
    {
        InitializeComponent();
        AttachControlEventHandlers(webView21);
        NavigateToUrl("https://www.fanfiction.net");
        HandleResize();
    }

    public WebDocument(CoreWebView2CreationProperties creationProperties = null) : this()
    {
        CreationProperties = creationProperties;
    }

    private void UpdateTitleWithEvent(string message)
    {
        UpdateStatusLabelWithEvent(message);
    }

    private void UpdateStatusLabelWithEvent(string message)
    {
        StatusLabel.Text = $"Event: {message}";
    }

    private void HandleResize()
    {
        // Resize the webview
        webView21.Size = this.ClientSize - new System.Drawing.Size(webView21.Location);
    }

    private void AttachControlEventHandlers(WebView2 webView)
    {
        webView.NavigationStarting += WebView_NavigationStarting;
        webView.NavigationCompleted += WebView_NavigationCompleted;
        webView.CoreWebView2InitializationCompleted += WebView_CoreWebView2InitializationCompleted;
        webView.SourceChanged += WebView_SourceChanged;
        webView.KeyDown += WebView_KeyDown;
        webView.KeyUp += WebView_KeyUp;
        webView.Disposed += WebView_Disposed;
    }

    private void WebView_Disposed(object? sender, EventArgs e)
    {
        return;
    }

    private void WebView_KeyUp(object? sender, KeyEventArgs e)
    {
        UpdateTitleWithEvent($"KeyUp key={e.KeyCode}");
    }

    private void WebView_KeyDown(object? sender, KeyEventArgs e)
    {
        UpdateTitleWithEvent($"KeyDown key={e.KeyCode}");
    }

    private void WebView_SourceChanged(object? sender, CoreWebView2SourceChangedEventArgs e)
    {
        WebAddressBox.Text = webView21?.Source.AbsoluteUri ?? "";
    }

    private void WebView_CoreWebView2InitializationCompleted(object? sender, CoreWebView2InitializationCompletedEventArgs e)
    {
        if (!e.IsSuccess)
        {
            MessageBox.Show($"WebView2 creation failed with exception = {e.InitializationException}");
            UpdateTitleWithEvent("CoreWebView2InitializationCompleted failed");
            return;
        }

        // Setup host resource mapping for local files
        this.webView21.CoreWebView2.SetVirtualHostNameToFolderMapping("appassets.example", "assets", CoreWebView2HostResourceAccessKind.DenyCors);
        this.webView21.Source = new Uri(WebViewTools.GetStartPageUri(this.webView21.CoreWebView2));

        this.webView21.CoreWebView2.SourceChanged += CoreWebView2_SourceChanged;
        this.webView21.CoreWebView2.HistoryChanged += CoreWebView2_HistoryChanged;
        this.webView21.CoreWebView2.DocumentTitleChanged += CoreWebView2_DocumentTitleChanged;
        this.webView21.CoreWebView2.AddWebResourceRequestedFilter("*", CoreWebView2WebResourceContext.Image, CoreWebView2WebResourceRequestSourceKinds.Document);
        this.webView21.CoreWebView2.ProcessFailed += CoreWebView2_ProcessFailed;
        this.webView21.CoreWebView2.FrameCreated += WebView_HandleIFrames;

        UpdateTitleWithEvent("CoreWebView2InitializationCompleted succeeded");

        EnableButtons();
    }

    private void CoreWebView2_ProcessFailed(object? sender, CoreWebView2ProcessFailedEventArgs e)
    {
        void ReinitIfSelectedByUser(string caption, string message)
        {
            this.webView21.BeginInvoke(new Action(() =>
            {
                var selection = MessageBox.Show(this, message, caption, MessageBoxButtons.YesNo);
                if (selection == DialogResult.Yes)
                {
                    this.Controls.Remove(this.webView21);
                    this.webView21.Dispose();
                    this.webView21 = GetReplacementControl(false);
                    // Set background transparent
                    this.webView21.DefaultBackgroundColor = System.Drawing.Color.Transparent;
                    this.Controls.Add(this.webView21);
                    HandleResize();
                }
            }));
        }

        void ReloadIfSelectedByUser(string caption, string message)
        {
            this.webView21.BeginInvoke(new Action(() =>
            {
                var selection = MessageBox.Show(this, message, caption, MessageBoxButtons.YesNo);
                if (selection == DialogResult.Yes)
                {
                    this.webView21.CoreWebView2.Reload();
                }
            }));
        }

        this.webView21.Invoke(new Action(() =>
        {
            StringBuilder messageBuilder = new StringBuilder();
            messageBuilder.AppendLine($"Process kind: {e.ProcessFailedKind}");
            messageBuilder.AppendLine($"Reason: {e.Reason}");
            messageBuilder.AppendLine($"Exit code: {e.ExitCode}");
            messageBuilder.AppendLine($"Process description: {e.ProcessDescription}");
            MessageBox.Show(messageBuilder.ToString(), "Child process failed", MessageBoxButtons.OK);
        }));

        if (e.ProcessFailedKind == CoreWebView2ProcessFailedKind.BrowserProcessExited)
        {
            ReinitIfSelectedByUser("Browser process exited",
                "Browser process exited unexpectedly. Recreate webview?");
        }
        else if (e.ProcessFailedKind == CoreWebView2ProcessFailedKind.RenderProcessUnresponsive)
        {
            ReinitIfSelectedByUser("Web page unresponsive",
                "Browser render process has stopped responding. Recreate webview?");
        }
        else if (e.ProcessFailedKind == CoreWebView2ProcessFailedKind.RenderProcessExited)
        {
            ReloadIfSelectedByUser("Web page unresponsive",
                "Browser render process exited unexpectedly. Reload page?");
        }
    }

    private WebView2 GetReplacementControl(bool useNewEnvironment)
    {
        WebView2 webView = this.webView21;
        WebView2 replacementControl = new WebView2();
        ((System.ComponentModel.ISupportInitialize)(replacementControl)).BeginInit();
        // Setup properties.
        if (useNewEnvironment)
        {
            // Create a new CoreWebView2CreationProperties instance so the environment
            // is made anew.
            replacementControl.CreationProperties = new CoreWebView2CreationProperties();
            replacementControl.CreationProperties.BrowserExecutableFolder = webView.CreationProperties.BrowserExecutableFolder;
            replacementControl.CreationProperties.Language = webView.CreationProperties.Language;
            replacementControl.CreationProperties.UserDataFolder = webView.CreationProperties.UserDataFolder;
            replacementControl.CreationProperties.AdditionalBrowserArguments = webView.CreationProperties.AdditionalBrowserArguments;
        }
        else
        {
            replacementControl.CreationProperties = webView.CreationProperties;
        }
        AttachControlEventHandlers(replacementControl);
        replacementControl.Source = webView.Source ?? new Uri("https://www.fanfiction.net");
        ((System.ComponentModel.ISupportInitialize)(replacementControl)).EndInit();

        return replacementControl;
    }

    private void CoreWebView2_DocumentTitleChanged(object? sender, object e)
    {
        Text = webView21?.CoreWebView2.DocumentTitle ?? "Web Document";
    }

    private void CoreWebView2_HistoryChanged(object? sender, object e)
    {
        BackButton.Enabled = webView21 != null && webView21.CanGoBack;
        ForwardButton.Enabled = webView21 != null && webView21.CanGoForward;
        UpdateStatusLabelWithEvent("History Changed");
    }

    private void CoreWebView2_SourceChanged(object? sender, CoreWebView2SourceChangedEventArgs e)
    {
        WebAddressBox.Text = webView21?.Source.AbsoluteUri ?? "";
        UpdateStatusLabelWithEvent("Source Changed");
    }

    private void WebView_NavigationCompleted(object? sender, CoreWebView2NavigationCompletedEventArgs e)
    {
        UpdateStatusLabelWithEvent("Navigation Completed");
        SavePage();
    }

    private void WebView_NavigationStarting(object? sender, CoreWebView2NavigationStartingEventArgs e)
    {
        UpdateStatusLabelWithEvent("Navigation Starting");
    }

    private void UpdateButtons(bool isEnabled)
    {
        BackButton.Enabled = isEnabled && webView21 != null && webView21.CanGoBack;
        ForwardButton.Enabled = isEnabled && webView21 != null && webView21.CanGoForward;
        ReloadButton.Enabled = isEnabled;
        StopButton.Enabled = isEnabled;
        AddBookmarkButton.Enabled = isEnabled;
        GoButton.Enabled = isEnabled;
    }

    private void EnableButtons()
    {
        UpdateButtons(true);
    }

    private void DisableButtons(object sender, EventArgs e)
    {
        UpdateButtons(false);
    }

    private void StopButton_Click(object sender, EventArgs e)
    {
        webView21?.Stop();
    }

    private void BackButton_Click(object sender, EventArgs e)
    {
        webView21?.GoBack();
    }

    private void ForwardButton_Click(object sender, EventArgs e)
    {
        webView21?.GoForward();
    }

    private void ReloadButton_Click(object sender, EventArgs e)
    {
        webView21?.Reload();
    }

    private void GoButton_Click(object sender, EventArgs e)
    {
        NavigateToUrl(WebAddressBox.Text.Trim());
    }

    private void NavigateToUrl(string rawUrl)
    {
        Uri uri = null;

        if (Uri.IsWellFormedUriString(rawUrl, UriKind.Absolute))
        {
            uri = new Uri(rawUrl);
        }
        else if (!rawUrl.Contains(" ") && rawUrl.Contains("."))
        {
            // An invalid URI contains a dot and no spaces, try tacking http:// on the front.
            uri = new Uri("http://" + rawUrl);
        }
        else
        {
            // Otherwise treat it as a web search.
            uri = new Uri("https://bing.com/search?q=" +
                String.Join("+", Uri.EscapeDataString(rawUrl).Split(new string[] { "%20" }, StringSplitOptions.RemoveEmptyEntries)));
        }

        webView21.Source = uri;
    }

    private void WebAddressBox_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Enter)
        {
            e.Handled = true;
            e.SuppressKeyPress = true;
            NavigateToUrl(WebAddressBox.Text.Trim());
        }
    }

    private void WebAddressBox_LostFocus(object sender, EventArgs e)
    {
        if (webView21?.Source.AbsoluteUri != WebAddressBox.Text)
        {
            NavigateToUrl(WebAddressBox.Text.Trim());
        }
    }

    private void AddBookmarkButton_Click(object sender, EventArgs e)
    {
    }

    private async void SavePage()
    {
        if (webView21?.CoreWebView2 != null && ShouldSavePage())
        {
            string pageContent = await webView21.CoreWebView2.ExecuteScriptAsync("document.documentElement.outerHTML");
            string pageContentDecoded = System.Text.RegularExpressions.Regex.Unescape(pageContent.Trim('"'));

            var htmlFileData = HtmlFileDataParser.ParseHtml(
                webView21.CoreWebView2.DocumentTitle,
                pageContentDecoded);

            string savePath = Path.Combine(AppSettings.Current.SavePath, htmlFileData.SaveFolderName);
            if (!Directory.Exists(savePath))
            {
                Directory.CreateDirectory(savePath);
            }
            savePath = Path.Combine(savePath, htmlFileData.FileName);
            File.WriteAllText(savePath, htmlFileData.PageText, Encoding.UTF8);

            UpdateStatusLabelWithEvent($"Saving: {webView21.CoreWebView2.DocumentTitle}");
        }
    }

    private bool ShouldSavePage()
    {
        IFfnAddress ffnAddress = FfnAddressFactory.GetAddress(webView21?.Source.AbsoluteUri ?? "");
        if (ffnAddress is StoryAddress)
        {
            return true;
        }
        return false;
    }
}