using FreshMvvm;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using YouTubeEmbed.PageModels;
using YouTubeEmbed.Pages;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace YouTubeEmbed
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new FreshNavigationContainer(FreshPageModelResolver.ResolvePageModel<YouTubeChannelPageModel>());
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
