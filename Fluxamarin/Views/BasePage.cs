using Fluxamarin.Stores;
using Xamarin.Forms;

namespace Fluxamarin.Views
{
	public abstract class BasePage<T> : ContentPage
	{
		public new INavigation Navigation { get; set; }
		public ReadonlyStore<T> Store { get; set; }

		protected BasePage(ReadonlyStore<T> store)
		{
			BindingContext = this;
			Store = store;
			Navigation = new FluxNavigation(base.Navigation, this);
		}

		protected override void OnAppearing()
		{
			OnStateChanged(Store, Store.AppState);
			MessagingCenter.Subscribe<ReadonlyStore<T>, T>(this, "AppStateChanged", OnStateChanged);
			MessagingCenter.Send(this, Id.ToString(), WidgetState.Active);
			base.OnAppearing();
		}

		protected override void OnDisappearing()
		{
			MessagingCenter.Unsubscribe<ReadonlyStore<T>>(this, "AppStateChanged");
			MessagingCenter.Send(this, Id.ToString(), WidgetState.Inactive);
			base.OnDisappearing();
		}

		protected abstract void OnStateChanged(ReadonlyStore<T> store, T newState);
	}
}