using Xamarin.Forms;

namespace webviewsample
{
    public partial class webviewsamplePage : ContentPage
    {
        private Abstractions.INativeBrowserService service;

        public webviewsamplePage()
        {
            InitializeComponent();

            service = DependencyService.Get<Abstractions.INativeBrowserService>();

            Launch_Button.Clicked += (sender, e) => 
            {
                if (service == null) return;

                service.LaunchNativeEmbeddedBrowser("https://iwritecodesometimes.net/");
            };
        }
    }
}
