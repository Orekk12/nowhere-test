using Assets.Scripts.Common;
using UnityEngine;
using UnityEngine.Pool;

namespace Assets.Scripts
{
    public class BallPool : Singleton<BallPool>
    {
        [SerializeField] private GameObject ballPrefab;

        [SerializeField] private int defaultCapacity = 10;
        [SerializeField] private int maxPoolSize = 30;

        public IObjectPool<Ball> Pool { get; private set; }

        protected override void Awake()
        {
            base.Awake();
            Pool = new ObjectPool<Ball>(CreatePooledItem, OnTakeFromPool, OnReturnedToPool,
                OnDestroyPoolObject, true, defaultCapacity, maxPoolSize);
        }

        private Ball CreatePooledItem()
        {
            var ball = Instantiate(ballPrefab.gameObject);

            return ball.GetComponent<Ball>();
        }

        private void OnTakeFromPool(Ball ballComponent) => ballComponent.gameObject.SetActive(true);

        private void OnReturnedToPool(Ball ballComponent) =>  ballComponent.gameObject.SetActive(false);

        private void OnDestroyPoolObject(Ball ballComponent) => Destroy(ballComponent.gameObject);
    }
}