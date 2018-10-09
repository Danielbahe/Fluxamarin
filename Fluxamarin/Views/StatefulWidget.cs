using System.ComponentModel;
using Fluxamarin.Actions;
using Fluxamarin.Stores;
using Xamarin.Forms;

namespace Fluxamarin.Views
{
	public abstract class StatefulWidget<T> : ContentView, INotifyPropertyChanged
	{
		public readonly string StateListenerId;
		private IDispatcher _dispatcher;
		public T CurrentState { get; set; }
		public ReadonlyStore<T> Store { get; set; }

		protected IDispatcher Dispatcher
		{
			get => _dispatcher;
			set
			{
				if (_dispatcher != null) return;
				_dispatcher = value;
			}
		}

		protected StatefulWidget(BasePage<T> parentPage)
		{
			Store = parentPage.Store;
			StateListenerId = parentPage.Id.ToString();
			ListenEvents();
			GetDispatcher();
		}

		protected StatefulWidget(StatefulWidget<T> parentWidget)
		{
			Store = parentWidget.Store;
			StateListenerId = parentWidget.StateListenerId;
			ListenEvents();
			GetDispatcher();
		}

		protected StatefulWidget(string mockStateListenerId = null, IDispatcher mockDispatcher = null)
		{
			StateListenerId = mockStateListenerId;
			ListenEvents();
			Dispatcher = mockDispatcher;
		}

		private void ListenEvents()
		{
			MessagingCenter.Subscribe<ReadonlyStore<T>, T>(this, "AppStateChanged", OnStateChanged);
			MessagingCenter.Subscribe<BasePage<T>, WidgetState>(this, StateListenerId, ChangeSetup);
		}

		private void ChangeSetup(BasePage<T> arg1, WidgetState newWidgetState)
		{
			switch (newWidgetState)
			{
				case WidgetState.Active:
					MessagingCenter.Subscribe<ReadonlyStore<T>, T>(this, "AppStateChanged", OnStateChanged);
					break;
				case WidgetState.Inactive:
					MessagingCenter.Unsubscribe<ReadonlyStore<T>>(this, "AppStateChanged");
					break;
				case WidgetState.Destroyed:
					MessagingCenter.Unsubscribe<ReadonlyStore<T>>(this, "AppStateChanged");
					MessagingCenter.Unsubscribe<BasePage<T>>(this, StateListenerId);
					break;
			}
		}

		protected abstract void OnStateChanged(ReadonlyStore<T> store, T newState);


		private void GetDispatcher()
		{
			Dispatcher = new Dispatcher<T>((Store<T>)Store);
		}
	}
}