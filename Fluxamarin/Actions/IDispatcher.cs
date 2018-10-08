using System;
using System.Threading.Tasks;

namespace Fluxamarin.Actions
{
	public interface IDispatcher
	{
		void Dispatch(Type actionType, object data = null);
		Task DispatchAsync(Type actionType, object data = null);
	}
}