using System;
using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

namespace App.PlayerInput
{
    public class PlayerInputService : ITickable
    {
        public PlayerInputService(PlayerService playerService)
        {
            _playerService = playerService;
        }

        private Vector2 _direction;
        private Vector2 _playerMoveDirection;

        private PlayerInputView _view;
        private PlayerService _playerService;

        public void SetView(PlayerInputView playerInputView)
        {
            _view = playerInputView ?? throw new ArgumentNullException(nameof(playerInputView));
        }

        public void ResetDirection()
        {
            _direction = Vector2.zero;
            _playerMoveDirection = Vector2.zero;
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

                _playerMoveDirection = new Vector3(_direction.x * (background.sizeDelta.x / 3),
                                                   _direction.y * (background.sizeDelta.y / 3));

                _view.SetJoystickPosition(_playerMoveDirection);
            }
        }

        public void Tick()
        {
            _playerService.Move(_playerMoveDirection);

#if UNITY_EDITOR
            if (Input.GetMouseButtonDown(1))
            {
                _playerService.Shoot();
            }
#else
            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);

                if (touch.phase == TouchPhase.Began)
                {
                    _playerService.Shoot();
                }
            }
        }
#endif
        }
    }
}
