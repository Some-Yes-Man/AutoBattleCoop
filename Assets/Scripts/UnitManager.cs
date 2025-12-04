using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace AutoBattleCoop {
    // just holds units and informs the battlefieldManager if someone died after evaluation 
    public class UnitManager : MonoBehaviour {

        public static UnitManager Instance;
        private readonly HashSet<Unit> units = new();
        private BattlefieldManager battlefieldManager;

        private void Awake() {
            Debug.Log("UnitManager Awake");
            if (Instance != null) {
                Destroy(Instance);
            }

            Instance = this;

            //DontDestroyOnLoad(gameObject);
        }

        void Start() {
            battlefieldManager = FindFirstObjectByType<BattlefieldManager>();
            if (battlefieldManager == null) {
                Debug.LogError("BattlefieldManager not found.");
            }
            Debug.Log("UnitManager Started.");
        }

        public void RemoveUnit(Unit unit) {
            Debug.Log("Removed Unit.");
            units.Remove(unit);
            if (battlefieldManager != null) {
                battlefieldManager.RemoveUnit(unit);
            }
        }

        public void AddUnit(Unit unit) {
            Debug.Log("Added Unit.");
            units.Add(unit);
        }

        public IEnumerable<Unit> GetUnitsInFraction(EUnitFraction fraction) {
            return units.Where(x => x.fraction == fraction).ToList();
        }

        public HashSet<Unit> GetAllUnits() {
            return units;
        }

    }

}
