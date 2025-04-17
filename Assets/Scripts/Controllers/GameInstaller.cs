using Player;
using UI;
using UnityEngine;
using Zenject;

namespace Controllers
{
    public class GameInstaller : MonoInstaller
    {
        [SerializeField] private SoundOnTrigger _soundOnTrigger;
        [SerializeField] private PauseMenu _pauseMenu;

        public override void InstallBindings()
        {
            Container.Bind<SoundOnTrigger>().FromComponentInHierarchy().AsSingle();
        }
    }
}