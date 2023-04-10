using UnityEngine;
using Zenject;
using App.Network;

namespace App 
{
    public class LobbyInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<LobbyService>().AsSingle();
        }
    }
}