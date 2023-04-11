using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace App.Input
{
    public class PlayerInputService
    {
        public PlayerInputService(PlayerService playerService)
        {
            _playerService = playerService;
        }

        private Vector2 _direction;

        #region Dependencies
        private PlayerInputView _view;
        private PlayerService _playerService;
        #endregion

        public void SetView(PlayerInputView playerInputView)
        {
            _view = playerInputView ?? throw new ArgumentNullException(nameof(playerInputView));
        }

        public void ResetDirection()
        {
            _direction = Vector2.zero;
        }

        public void OnDragHandle(PointerEventData pointerEventData,
                                 RectTransform background)
        {
            Vector2 position;

            if (RectTransformUtility.ScreenPointToLocalPointInRectangle
                    (background,
                    pointerEventData.position,
                    pointerEventData.pressEventCamera,
                    out position))
            {

                position.x = (position.x / background.sizeDelta.x);
                position.y = (position.y / background.sizeDelta.y);

                float x = (background.pivot.x == 1)
                    ? position.x * 2 + 1
                    : position.x * 2;

                float y = (background.pivot.y == 1)
                    ? position.y * 2 + 1
                    : position.y * 2;

                _direction = new Vector2(x, y);
                _direction = (_direction.magnitude > 1)
                    ? _direction.normalized
                    : _direction;

                Vector3 joystickPosition = new Vector3(_direction.x * (background.sizeDelta.x / 3),
                                                       _direction.y * (background.sizeDelta.y / 3));

                _view.SetJoystickPosition(joystickPosition);
                _playerService.Move(joystickPosition);
            }
        }
    }
}
