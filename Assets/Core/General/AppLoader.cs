using Photon.Pun;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace App
{
    public class AppLoader : MonoBehaviour
    {
        [Header("UI")]
        [SerializeField] private Image _progressor;
        [SerializeField] private TextMeshProUGUI _status;

        private IEnumerator Start()
        {
            while (InternetReachabilityVerifier.Instance.status != InternetReachabilityVerifier.Status.NetVerified)
            {
                _status.text = "Connection...";
                yield return null;
            }

            PhotonNetwork.ConnectUsingSettings();
            PhotonNetwork.ConnectToRegion(ProjectInfo.NetworkSettings.Region);

            _status.text = "Loading...";

            Debug.Log("[AppLoader] Success connection");

            using (SceneLoader sceneLoader = new SceneLoader())
            {
                sceneLoader.LoadSceneAsync(ProjectInfo.Scenes.LobbyScene);

                Debug.Log($"[AppLoader] Loading scene: {ProjectInfo.Scenes.LobbyScene}");

                while (sceneLoader.Progress < 0.9f)
                {
                    SetProgressorValue(sceneLoader.Progress);
                    yield return null;
                }

                SetProgressorValue(1f);

                Debug.Log($"[AppLoader] Scene: {ProjectInfo.Scenes.LobbyScene} successfully loaded");

                sceneLoader.AllowActivateScene();
            }
        }

        private void SetProgressorValue(float sceneLoadingProgress)
        {
            _progressor.fillAmount = Mathf.Clamp(sceneLoadingProgress, 0f, 1f);
        }
    }
}
