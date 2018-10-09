using System;
using System.Threading.Tasks;
using Fluxamarin.Stores;

namespace Fluxamarin.Actions
{
	public class Dispatcher<T> : IDispatcher
	{
		private Store<T> _store;
		public Dispatcher(Store<T> store)
		{
			_store = store;
		}
		public void Dispatch(Type actionType, object data = null)
		{
			var action = (ActionBase<T>) Activator.CreateInstance(actionType, _store);
			action.Execute(data);
		}

		public async Task DispatchAsync(Type actionType, object data = null)
		{
			var action = (ActionBase<T>) Activator.CreateInstance(actionType);
			await action.ExecuteAsync(data);
		}
	}
}