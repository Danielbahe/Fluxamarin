using System.Threading.Tasks;
using Fluxamarin.Stores;

namespace Fluxamarin.Actions
{
	public abstract class ActionBase<T>
	{
		protected Store<T> Store { get; }

		protected ActionBase(Store<T> store)
		{
			Store = store;
		}

		public abstract void Execute(object data = null);
		public abstract Task ExecuteAsync(object data = null);
	}
}