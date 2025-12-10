namespace FFArchiveXXVI.Model;

using System;
using System.ComponentModel;
using System.Diagnostics;

using Microsoft.Web.WebView2.Core;

public static class WebViewTools
{
    public static string GetSdkBuildVersion()
    {
        CoreWebView2EnvironmentOptions options = new CoreWebView2EnvironmentOptions();
        var targetVersionMajorAndRest = options.TargetCompatibleBrowserVersion;
        var versionList = targetVersionMajorAndRest.Split('.');
        if (versionList.Length != 4)
        {
            return "Invalid SDK build version";
        }

        return versionList[2] + "." + versionList[3];
    }

    public static string GetRuntimeVersion(CoreWebView2 webView2)
    {
        return webView2.Environment.BrowserVersionString;
    }

    public static string GetRuntimePath(CoreWebView2 webView2)
    {
        int processId = (int)webView2.BrowserProcessId;
        try
        {
            Process process = System.Diagnostics.Process.GetProcessById(processId);
            var fileName = process.MainModule.FileName;
            return System.IO.Path.GetDirectoryName(fileName);
        }
        catch (ArgumentException e)
        {
            return e.Message;
        }
        catch (InvalidOperationException e)
        {
            return e.Message;
        }
        // Occurred when a 32-bit process wants to access the modules of a 64-bit process.
        catch (Win32Exception e)
        {
            return e.Message;
        }
    }

    public static string GetStartPageUri(CoreWebView2 webView2)
    {
        string uri = "https://www.fanfiction.net";
        if (webView2 == null)
        {
            return uri;
        }
        return webView2.Source;
    }

    private static string GetAppPath()
    {
        return System.AppDomain.CurrentDomain.SetupInformation.ApplicationBase;
    }

    internal static string GetSafeFileNameFromTitle(string documentTitle)
    {
        return string.Join("_", documentTitle.Split(
            System.IO.Path.GetInvalidFileNameChars()));
    }
}