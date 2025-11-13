using System.Collections.Generic;
using UnityEngine;

public class BattlefieldManager : MonoBehaviour {

    public static BattlefieldManager Instance;

    private const int width = 10;
    private const int height = 10;

    private readonly Unit[,] battlefield = new Unit[width, height];

    void Awake() {
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

    public bool AddUnit(Unit unit, int x, int y) {
        if ((x < 0) || (x >= width) || (y < 0) || (y >= height)) {
            Debug.LogWarning("AddUnit: Position out of bounds.");
            return false;
        }

        if (battlefield[x, y] != null) {
            Debug.LogWarning("AddUnit: Position already occupied.");
            return false;
        }

        battlefield[x, y] = unit;
        return true;
    }

    public bool ClearCoordinate(int x, int y) {
        if ((x < 0) || (x >= width) || (y < 0) || (y >= height)) {
            Debug.LogWarning("RemoveUnit: Position out of bounds.");
            return false;
        }
        if (battlefield[x, y] == null) {
            Debug.LogWarning("RemoveUnit: No unit at given position.");
            return false;
        }

        battlefield[x, y] = null;
        return true;
    }

    public bool RemoveUnit(Unit unit) {
        for (int x = 0; x < width; x++) {
            for (int y = 0; y < height; y++) {
                if (battlefield[x, y] == unit) {
                    battlefield[x, y] = null;
                    return true;
                }
            }
        }
        Debug.LogWarning("RemoveUnit: Unit not found on battlefield.");
        return false;
    }

    public Unit GetUnitAt(int x, int y) {
        if ((x < 0) || (x >= width) || (y < 0) || (y >= height)) {
            Debug.LogWarning("GetUnitAt: Position out of bounds.");
            return null;
        }

        return battlefield[x, y];
    }

    public IEnumerable<Unit> GetAllUnits() {
        for (int x = 0; x < width; x++) {
            for (int y = 0; y < height; y++) {
                if (battlefield[x, y] != null) {
                    yield return battlefield[x, y];
                }
            }
        }
    }

    public IEnumerable<Unit> GetUnitsInPattern(int originX, int originY, EAttackPattern attackPattern, int attackDistance, EDirection direction) {
        bool[,] pattern = GeneratePatternMap(attackPattern, attackDistance);

        for (int px = 0; px < pattern.GetLength(0); px++) {
            for (int py = 0; py < pattern.GetLength(1); py++) {
                if (!pattern[px, py]) continue;

                int targetX;
                int targetY;
                switch (direction) {
                    case EDirection.Right:
                        targetX = originX + px;
                        targetY = originY + py;
                        break;
                    case EDirection.Left:
                        targetX = originX - px;
                        targetY = originY - py;
                        break;
                    case EDirection.Up:
                        targetX = originX + py;
                        targetY = originY - px;
                        break;
                    case EDirection.Down:
                        targetX = originX - py;
                        targetY = originY + px;
                        break;
                    default:
                        Debug.LogWarning("GetUnitsInPattern: Unknown direction.");
                        yield break;
                }

                if ((targetX >= 0) && (targetX < width) && (targetY >= 0) && (targetY < height)) {
                    Unit unit = battlefield[targetX, targetY];
                    if (unit != null) {
                        yield return unit;
                    }
                }
            }
        }
    }

    // FIXME : this should probably live somewhere else
    private bool[,] GeneratePatternMap(EAttackPattern attackPattern, int attackDistance) {
        switch (attackPattern) {
            case EAttackPattern.Neighbor:
                return new bool[,] {
                    { true }
                };
            default:
                Debug.LogWarning("GeneratePatternMap: Unknown attack pattern.");
                return new bool[0, 0];
        }
    }

    public void ClearBattlefield() {
        for (int x = 0; x < width; x++) {
            for (int y = 0; y < height; y++) {
                battlefield[x, y] = null;
            }
        }
    }

}
