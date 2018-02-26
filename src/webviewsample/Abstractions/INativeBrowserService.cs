using System;
namespace webviewsample.Abstractions
{
    public interface INativeBrowserService
    {
        void LaunchNativeEmbeddedBrowser(string url);
    }
}
