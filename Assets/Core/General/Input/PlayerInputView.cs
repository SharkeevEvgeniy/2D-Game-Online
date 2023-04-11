using UnityEngine;
using Zenject;
using UnityEngine.EventSystems;

namespace App.Input
{
    public class PlayerInputView : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler
    {
        [SerializeField] private RectTransform _joystick;
        [SerializeField] private RectTransform _background;

        #region Dependencies
        private PlayerInputService _playerInputService;
        #endregion

        [Inject]
        private void Construct(PlayerInputService playerInputService)
        {
            _playerInputService = playerInputService;
            _playerInputService.SetView(this);
        }

        public void SetJoystickPosition(Vector3 position)
        {
            _joystick.anchoredPosition = position;
        }

        public RectTransform GetBackgroundRectTransform()
        {
            return _background;
        }

        public void OnDrag(PointerEventData pointerEventData)
        {
            _playerInputService.OnDragHandle(pointerEventData, _background);
        }

        public void OnPointerDown(PointerEventData pointerEventData)
        {
            OnDrag(pointerEventData);
        }

        public void OnPointerUp(PointerEventData pointerEventData)
        {
            _playerInputService.ResetDirection();
            _joystick.anchoredPosition = Vector3.zero;
        }
    }
}
