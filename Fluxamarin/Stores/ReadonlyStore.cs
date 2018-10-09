using Xamarin.Forms;

namespace Fluxamarin.Stores
{
	public class ReadonlyStore<T>
	{
		public T AppState { get; protected set; }

		protected void NotifyStateChanged()
		{
			MessagingCenter.Send(this, "AppStateChanged", AppState);
		}
	}
}