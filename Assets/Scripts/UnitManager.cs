using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;
using System.Linq;

public class UnitManager : MonoBehaviour
{
    public static UnitManager Instance;
    private HashSet<Unit> units;
    private BattlefieldManager battlefieldManager;

    private void Awake()
    {
        Debug.Log("UnitManager Awake");
        if (Instance != null)
        {
            Destroy(Instance);
        }

        Instance = this;

        //DontDestroyOnLoad(gameObject);
    }
    
    void Start()
    {
        battlefieldManager = FindFirstObjectByType<BattlefieldManager>();
        if (battlefieldManager == null)
        {
            Debug.LogError("BattlefieldManager not found.");
        }
        Debug.Log("UnitManager Started.");
    }

    void RemoveUnit(Unit unit)
    {
        Debug.Log("Removed Unit.");
        units.Remove(unit);
        if (battlefieldManager != null)
        {
            battlefieldManager.RemoveUnit(unit);
        }
    }

    void AddUnit(Unit unit)
    {
        Debug.Log("Added Unit.");
        units.Add(unit);
    }
    
    IEnumerable<Unit> GetUnitsInFraction(EUnitFraction fraction)
    {
        return units.Where(x => x.fraction == fraction).ToList();
    }

    HashSet<Unit> GetAllUnits()
    {
        return units;
    }
}
