using Photon.Pun;
using UnityEngine;
using Zenject;

namespace App
{
    public class BulletFactoryService : IGenericFactory<GameObject>
    {
        [Inject]
        private DiContainer _container;

        public GameObject Spawn(Vector2 position, Quaternion rotation)
        {
            // Searching by prefab name is bad execution. But Photon doesn't allow instantiation in other ways
            string prefabPath = "Bullet";

            var instance = PhotonNetwork.Instantiate(prefabPath, position, rotation);
            _container.InjectGameObject(instance);

            return instance;
        }
    }
}
