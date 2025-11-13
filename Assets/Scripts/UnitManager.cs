using UnityEngine;

public class UnitManager : MonoBehaviour {

    public static UnitManager Instance;

    private void Awake() {
        Debug.Log("UnitManager Awake");
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
