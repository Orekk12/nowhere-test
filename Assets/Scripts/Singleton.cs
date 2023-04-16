using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Common
{
    public class Singleton<T> : MonoBehaviour where T : Component
    {
        private static T _instance;

        public static T Instance => _instance;

        private void Awake()
        {
            if (_instance != null && _instance != this)
            {
                Destroy(this.gameObject);
            } else {
                _instance = this as T;
            }
        }
    }
}