using System.Threading.Tasks;
using Example.Models;
using Fluxamarin.Actions;
using Fluxamarin.Stores;

namespace Example.Actions
{
	public class CounterAction : ActionBase<AppState>
	{
		public CounterAction(Store<AppState> store) : base(store)
		{
		}
		public override async void Execute(object data)
		{
			var state = Store.AppState;
			state.Counter = (int)data;
			await Store.SetNewState(state);
		}

		public override Task ExecuteAsync(object data = null)
		{
			throw new System.NotImplementedException();
		}
	}
}