using System;
using Assets.Scripts.Common;
using UnityEngine;

namespace Assets.Scripts.Managers
{
    [RequireComponent(typeof(AudioSource))]
    public class GameManager : Singleton<GameManager>
    {
        [SerializeField] private AudioClip spawnClip;
        private AudioSource _audioSource;

        protected override void Awake()
        {
            base.Awake();
            _audioSource = GetComponent<AudioSource>();

            if (spawnClip == null)
            {
                Debug.LogError("Spawn clip is not set!");
            }
        }

        private void Start()
        {
            SpawnManager.OnBallSpawn += PlaySpawnSound;
        }

        private void OnDestroy()
        {
            SpawnManager.OnBallSpawn -= PlaySpawnSound;
        }

        private void PlaySpawnSound()
        {
            _audioSource.PlayOneShot(spawnClip);
        }
    }
}