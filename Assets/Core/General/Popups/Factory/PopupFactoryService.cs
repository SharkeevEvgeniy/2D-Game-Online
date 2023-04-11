using Zenject;

public interface IPopup
{
	bool IsVisible { get; }
}

public interface IPopupFactory<T>
{
	T ShowPopup<T>(params object[] args) where T : IPopup;
}

public class PopupFactoryService : IPopupFactory<PopupFactoryService>
{
	private readonly DiContainer _container;

	public PopupFactoryService(DiContainer container)
	{
		_container = container;
	}

    public T ShowPopup<T>(params object[] args) where T : IPopup
	{
		var popupService = _container.Resolve<T>();
		if (popupService != null && (!popupService.IsVisible))
		{
			//var view = (IPopupView)_container.Resolve(popupService.ViewType);
			/*if (view is MonoBehaviour component)
			{
				var uipopup = component.GetComponent<UIPopup>();
				if (uipopup != null)
				{
					popupService.Init(view, uipopup, args);
					uipopup.Show();
				}
			}*/
		}

		return popupService;
	}
}
