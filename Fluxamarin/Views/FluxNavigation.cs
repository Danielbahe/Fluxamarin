using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Fluxamarin.Views
{
	public class FluxNavigation : INavigation
	{
		private readonly INavigation _navigation;
		private readonly Page _page;

		public FluxNavigation(INavigation navigation, Page page)
		{
			_navigation = navigation;
			_page = page;
		}

		public IReadOnlyList<Page> ModalStack => _navigation.ModalStack;

		public IReadOnlyList<Page> NavigationStack => _navigation.ModalStack;

		public void InsertPageBefore(Page page, Page before)
		{
			_navigation.InsertPageBefore(page, before);
		}

		public Task<Page> PopAsync()
		{
			MessagingCenter.Send(_page, _page.Id.ToString(), WidgetState.Destroyed);
			return _navigation.PopAsync();
		}

		public Task<Page> PopAsync(bool animated)
		{
			MessagingCenter.Send(_page, _page.Id.ToString(), WidgetState.Destroyed);
			return _navigation.PopAsync(animated);
		}

		public Task<Page> PopModalAsync()
		{
			MessagingCenter.Send(_page, _page.Id.ToString(), WidgetState.Destroyed);
			return _navigation.PopModalAsync();
		}

		public Task<Page> PopModalAsync(bool animated)
		{
			MessagingCenter.Send(_page, _page.Id.ToString(), WidgetState.Destroyed);
			return _navigation.PopModalAsync(animated);
		}

		public Task PopToRootAsync()
		{
			//todo unsubscribe all pages events
			throw new NotImplementedException();
		}

		public Task PopToRootAsync(bool animated)
		{
			//todo unsubscribe all pages events
			throw new NotImplementedException();
		}

		public Task PushAsync(Page page)
		{
			return _navigation.PushAsync(page);
		}

		public Task PushAsync(Page page, bool animated)
		{
			return _navigation.PushAsync(page, animated);
		}

		public Task PushModalAsync(Page page)
		{
			return _navigation.PushModalAsync(page);
		}

		public Task PushModalAsync(Page page, bool animated)
		{
			return _navigation.PushModalAsync(page, animated);
		}

		public void RemovePage(Page page)
		{
			MessagingCenter.Send(page, page.Id.ToString(), WidgetState.Destroyed);
			_navigation.RemovePage(page);
		}
	}
}