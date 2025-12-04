using UnityEngine;

namespace AutoBattleCoop {
    public class GameManager : MonoBehaviour {

        public static GameManager Instance;

        private void Awake() {
            Debug.Log("GameManager Awake");
            if (Instance != null) {
                Destroy(Instance);
            }
            Instance = this;

            //DontDestroyOnLoad(gameObject);
        }

        void Start() {

        }

        // Update is called once per frame
        void Update() {

        }

    }
}
