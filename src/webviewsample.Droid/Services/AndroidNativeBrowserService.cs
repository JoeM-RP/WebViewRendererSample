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
            var activity = Forms.Context as Activity;

            if (activity == null) return;

            customTabs = new CustomTabsActivityManager(activity);
            customTabs.CustomTabsServiceConnected += (name, client) =>
            {

            };

            var mgr = new CustomTabsActivityManager(activity);
            mgr.CustomTabsServiceConnected += delegate {
                mgr.LaunchUrl(url);
            };
            mgr.BindService();

            //activity.StartActivity(customTabs);
        }
    }
}
