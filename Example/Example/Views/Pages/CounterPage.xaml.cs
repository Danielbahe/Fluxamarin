using Example.Models;
using Fluxamarin.Stores;
using Fluxamarin.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Example.Views.Pages
{
	public partial class CounterPage : BasePage<AppState>
	{
		public CounterPage(ReadonlyStore<AppState> store) : base(store)
		{
			InitializeComponent();

			Content = new StackLayout()
			{
				Children = { new CounterWidget(this) }
			};
		}

		protected override void OnStateChanged(ReadonlyStore<AppState> store, AppState newState)
		{

		}
	}
}