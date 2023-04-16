using Assets.Scripts.Common;
using UnityEngine;

namespace Assets.Scripts.Managers
{
    public class GameManager : Singleton<GameManager>
    {
        [SerializeField] private AudioSource _spawnSound;

        public void PlaySpawnSound()
        {
            _spawnSound.Play();
        }
    }
}