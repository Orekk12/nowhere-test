using System;
using Assets.Scripts.Common;
using UnityEngine;

namespace Assets.Scripts.Managers
{
    public class GameManager : Singleton<GameManager>
    {
        [SerializeField] private AudioSource _spawnSound;

        protected override void Awake()
        {
            base.Awake();
            _spawnSound = GetComponent<AudioSource>();
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
            _spawnSound.Play();
        }
    }
}