using System.Threading.Tasks;
using Newtonsoft.Json;
using Xamarin.Essentials;

namespace Fluxamarin.Stores
{
	public class Store<T> : ReadonlyStore<T>
	{
		private bool _saveState;
		private const string Key = "AppStateKey";

		public async Task SetNewState(T newState, bool notify = true)
		{
			AppState = newState;
			if (_saveState)
			{
				var jsonState = JsonConvert.SerializeObject(AppState);
				await SecureStorage.SetAsync(Key, jsonState);
			}

			if (!notify) return;
			NotifyStateChanged();
		}

		public async void Setup(bool saveState = false, bool restoreState = false)
		{
			_saveState = saveState;
			if (restoreState)
			{
				var jsonState = await SecureStorage.GetAsync(Key);

				if (string.IsNullOrEmpty(jsonState)) return;
				AppState = JsonConvert.DeserializeObject<T>(jsonState);

			}
		}

		public async void SetInitialState(T initialState)
		{
			await SetNewState(initialState, false);
		}
	}
}