using UnityEngine;

namespace App
{
    public interface IGenericFactory<T>
    {
        T Spawn(Vector2 position, Quaternion rotation);
    }
}
