using UnityEngine;

namespace RS {
    public abstract class StaticInstance<T> : MonoBehaviour where T : Component {
        public static T Instance { get; private set; }
        protected virtual void Awake() => Instance = FindAnyObjectByType<T>();
    }

    public class Singleton<T> : StaticInstance<T> where T: Component {
        protected override void Awake() {
            if (Instance != null) Destroy(gameObject);
            base.Awake();
        }
    }

    public abstract class PersistentSingleton<T> : Singleton<T> where T : Component {
        protected override void Awake() {
            base.Awake();
            DontDestroyOnLoad(gameObject);
        }
    }
}