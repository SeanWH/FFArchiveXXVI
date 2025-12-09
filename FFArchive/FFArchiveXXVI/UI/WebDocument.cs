using System.ComponentModel;

namespace FFArchiveXXVI.UI;

using System;
using System.Windows.Forms;

using FFArchiveXXVI.Model;

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
        return;
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
        throw new NotImplementedException();
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
        throw new NotImplementedException();
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
}