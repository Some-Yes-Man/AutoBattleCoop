using UnityEngine;

public class BattlefieldManager : MonoBehaviour {

    public static BattlefieldManager Instance;

    private void Awake() {
        Debug.Log("BattlefieldManager Awake");
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
