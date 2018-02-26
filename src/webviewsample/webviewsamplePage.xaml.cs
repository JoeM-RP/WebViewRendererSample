using Xamarin.Forms;

namespace webviewsample
{
    public partial class webviewsamplePage : ContentPage
    {
        private Abstractions.INativeBrowserService service;

        public webviewsamplePage()
        {
            InitializeComponent();

            // We rely on the built-in service lcoator in this example, but you could just
            // as easily locate this service using DI and launch from your ViewModel
            service = DependencyService.Get<Abstractions.INativeBrowserService>();

            Launch_Button.Clicked += (sender, e) => 
            {
                if (service == null) return;

                service.LaunchNativeEmbeddedBrowser("https://iwritecodesometimes.net/");
            };
        }
    }
}
