using Photon.Pun;
using Photon.Realtime;
using System;
using UnityEngine;

namespace App.Network
{
    public class LobbyService
    {
        public void CreateRoom(string name)
        {
            if (PhotonNetwork.IsConnected)
            {
                RoomOptions roomOptions = new RoomOptions()
                {
                    MaxPlayers = ProjectInfo.NetworkSettings.MaxPlayersInRoom
                };

                try
                {
                    PhotonNetwork.CreateRoom(name, roomOptions, TypedLobby.Default);
                }
                catch (Exception e)
                {
                    Debug.LogError($"[LobbyService::CreateRoom] Failed to create room: {e.Message}");
                    return;
                }

                Debug.Log($"[LobbyService] Room: {name} successfully created");
            }
            else
            {
                throw new InvalidOperationException("[LobbyService::CreateRoom] Photon is not connected. Set connection before joining room");
            }
        }

        public void JoinToRoom(string name)
        {
            if (PhotonNetwork.IsConnected)
            {
                try
                {
                    PhotonNetwork.JoinRoom(name);
                }
                catch (Exception e)
                {
                    Debug.LogError($"[LobbyService::JoinToRoom] Failed to join room: {e.Message}");
                    return;
                }

                Debug.Log($"[LobbyService] Successfully joined to room: {name}");
            }
            else
            {
                throw new InvalidOperationException("[LobbyService::JoinToRoom] Photon is not connected. Set connection before joining room");
            }
        }
    }
}
