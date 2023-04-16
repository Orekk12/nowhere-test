using Assets.Scripts.Common;
using UnityEngine;
using UnityEngine.Pool;

namespace Assets.Scripts
{
    public class BallPool : Singleton<BallPool>//An extendable component pooler would be better, but this is enough for this project.
    {
        [SerializeField] private GameObject ballPrefab;

        [SerializeField] private int defaultCapacity = 10;
        [SerializeField] private int maxPoolSize = 30;

        public IObjectPool<Ball> Pool { get; private set; }

        protected override void Awake()
        {
            base.Awake();
            
            if (ballPrefab == null)
            {
                Debug.LogError("Ball prefab is not set!");
            }
            
            Pool = new ObjectPool<Ball>(CreatePooledItem, OnTakeFromPool, OnReturnedToPool,
                OnDestroyPoolObject, true, defaultCapacity, maxPoolSize);
        }

        private Ball CreatePooledItem()
        {
            var ballGameObject = Instantiate(ballPrefab.gameObject, transform);//Balls are stored under the BallPool object for cleaner hierarchy.
            return ballGameObject.GetComponent<Ball>();
        }

        private void OnTakeFromPool(Ball ballComponent) => ballComponent.gameObject.SetActive(true);

        private void OnReturnedToPool(Ball ballComponent) =>  ballComponent.gameObject.SetActive(false);

        private void OnDestroyPoolObject(Ball ballComponent) => Destroy(ballComponent.gameObject);
    }
}