using UnityEngine;

namespace Manager
{
    public class GlobalData : MonoBehaviour
    {
        public static GlobalData instance;

        public bool IsVictory { get; set; }

        private void Awake()
        {
            if (instance != null)
            {
                Destroy(gameObject);
                return;
            }
            instance = this;
        
            DontDestroyOnLoad(this);
        }
    }
}
