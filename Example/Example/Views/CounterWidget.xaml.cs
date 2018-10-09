using System;
using Example.Actions;
using Example.Models;
using Fluxamarin.Stores;
using Fluxamarin.Views;
using Xamarin.Forms.Xaml;

namespace Example.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CounterWidget : StatefulWidget<AppState>
	{
		private int _counter;

		public int Counter
		{
			get => _counter;
			set
			{
				_counter = value;
				OnPropertyChanged(nameof(Counter));
			}
		}

		public CounterWidget(BasePage<AppState> parentPage) : base(parentPage)
		{
			BindingContext = this;
			InitializeComponent();
			Initialize();
		}

		private void Initialize()
		{
			//In this example is the same that  state changed
			OnStateChanged(Store, Store.AppState);
		}

		private void Button_OnClicked(object sender, EventArgs e)
		{
			Counter++;
		}

		protected override void OnStateChanged(ReadonlyStore<AppState> store, AppState newState)
		{
			Counter = newState.Counter;
		}

		private void Button_OnClickedWithState(object sender, EventArgs e)
		{
			Dispatcher.Dispatch(typeof(CounterAction), Counter + 1);
		}
	}
}