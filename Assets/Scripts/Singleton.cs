using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Common
{
    public class Singleton<T> : MonoBehaviour where T : Component
    {
        //This singleton implementation lacks the ability to persist between scenes and it does not create a new instance if one does not exist.
        //However it prevents duplicates from being created.
        private static T _instance;

        public static T Instance => _instance;

        protected virtual void Awake()
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