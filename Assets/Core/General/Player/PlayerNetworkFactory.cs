using Photon.Pun;
using System.IO;
using UnityEngine;
using Zenject;

namespace App.Network
{
    public class PlayerNetworkFactory : IGenericFactory<GameObject>
    {
        [Inject]
        private DiContainer _container;

        public GameObject CreateInstance()
        {
            // Searching by prefab name is bad execution. But Photon doesn't allow instantiation in other ways
            string prefabPath = Path.Combine("Core", "UI", "Prefabs", "Player (NET)");

            var instance = PhotonNetwork.Instantiate(prefabPath, Vector3.zero, Quaternion.identity);
            _container.InjectGameObject(instance);

            return instance;
        }
    }
}
