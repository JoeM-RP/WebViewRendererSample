using System;
using Android.App;
using Android.Content;
using Android.Support.CustomTabs;
using webviewsample.Abstractions;
using webviewsample.Droid.Services;
using Xamarin.Forms;

[assembly: Dependency(typeof(AndroidNativeBrowserService))]
namespace webviewsample.Droid.Services
{
    public class AndroidNativeBrowserService : INativeBrowserService
    {
        CustomTabsActivityManager customTabs;

        public void LaunchNativeEmbeddedBrowser(string url)
        {
            // TODO: We need the current actiivty. Forms.Context is deprecated, but I had issues
            // trying to use Android.App.Appllication.Context when castign to Activity, sooo...?
            var activity = Forms.Context as Activity;

            if (activity == null) return;

            customTabs = new CustomTabsActivityManager(activity);
            customTabs.CustomTabsServiceConnected += (name, client) =>
            {
                // Add custom options here, such as Share
            };

            var mgr = new CustomTabsActivityManager(activity);
            mgr.CustomTabsServiceConnected += delegate {
                mgr.LaunchUrl(url);
            };

            mgr.BindService();
        }
    }
}
