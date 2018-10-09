using Example.Models;
using Example.Views.Pages;
using Fluxamarin.Stores;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace Example
{
	public partial class App : Application
	{
		public App()
		{
			InitializeComponent();

			//Initialize store
			var store = new Store<AppState>();
			store.Setup(true, true);
			if(store.AppState == null) store.SetInitialState(new AppState());

			MainPage = new CounterPage(store);
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
