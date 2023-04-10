using Photon.Pun;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace App.Network
{
    public enum MessageType
    {
        Message,
        Error
    }

    public class LobbyView : MonoBehaviourPunCallbacks
    {
        [Header("Button")]
        [SerializeField] private Button _createRoomButton;
        [SerializeField] private Button _joinRoomButton;

        [Header("Input Field")]
        [SerializeField] private TMP_InputField _createRoomField;
        [SerializeField] private TMP_InputField _joinRoomField;

        [Header("Text")]
        [SerializeField] private TextMeshProUGUI _errorText;

        #region Dependencies
        private LobbyService _lobbyService;
        #endregion

        [Inject]
        private void Construct(LobbyService lobbyService)
        {
            _lobbyService = lobbyService;
        }

        private void Start()
        {
            #region Button handlers
            _createRoomButton.onClick.AddListener(OnCreateRoomButtonPressed);
            _joinRoomButton.onClick.AddListener(OnJoinRoomButtonPressed);
            #endregion
        }

        public override void OnCreatedRoom()
        {
            ShowMessage("Room created successfully", MessageType.Message);
        }

        public override void OnCreateRoomFailed(short returnCode, string message)
        {
            ShowMessage("Failed to create room", MessageType.Error);
        }

        public override void OnJoinedRoom()
        {
            PhotonNetwork.LoadLevel(ProjectInfo.Scenes.GameScene);
        }

        private void OnCreateRoomButtonPressed()
        {
            string roomName = _createRoomField.text;

            if (string.IsNullOrEmpty(roomName))
            {
                ShowMessage("Room name can't be empty", MessageType.Error);
            }
            else
            {
                _lobbyService.CreateRoom(roomName);
            }
        }

        private void OnJoinRoomButtonPressed()
        {
            string roomName = _joinRoomField.text;

            if (string.IsNullOrEmpty(roomName))
            {
                ShowMessage("Room name can't be empty", MessageType.Error);
            }
            else
            {
                _lobbyService.JoinToRoom(roomName);
            }
        }

        private void ShowMessage(string message, MessageType messageType)
        {
            if (string.IsNullOrEmpty(message))
                throw new ArgumentNullException("Message can't be null or empty");

            _errorText.enabled = true;
            _errorText.text = message;
            _errorText.color = (messageType == MessageType.Message)
                ? Color.white
                : Color.red;
        }
    }
}