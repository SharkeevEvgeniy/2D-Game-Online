using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopupFactoryView : MonoBehaviour
{
    private PopupFactoryService _popupFactoryService;

    private void Construct(PopupFactoryService popupFactoryService)
    {
        _popupFactoryService = popupFactoryService;
    }
}
