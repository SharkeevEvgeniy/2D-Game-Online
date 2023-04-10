using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

[RequireComponent(typeof(PhotonView))]
public class PlayerView : MonoBehaviour
{
    private PhotonView _photonView;

    private void Awake()
    {
        _photonView = GetComponent<PhotonView>();
    }


    void Update()
    {
        //if (!_photonView.IsMine)
        //    return;

        float h = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        Debug.LogError($"{h} /// {y}");


    }
}
