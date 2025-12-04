using System.Collections.Generic;
using UnityEngine;

namespace AutoBattleCoop {
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

        public IEnumerable<Unit> GetUnitsInPattern(int originX, int originY, bool[,] pattern, EDirection direction) {
            for (int py = 0; py < pattern.GetLength(1); py++) {
                for (int px = 0; px < pattern.GetLength(0); px++) {
                    if (!pattern[px, py]) continue;

                    int targetX;
                    int targetY;
                    switch (direction) {
                        case EDirection.Right:
                            if (pattern.GetLength(1) % 2 == 0) {
                                Debug.LogWarning("GetUnitsInPattern: Right direction requires odd-sized pattern height.");
                                yield break;
                            }
                            targetX = originX + px + 1;
                            targetY = originY + py - (pattern.GetLength(1) / 2);
                            break;
                        case EDirection.Left:
                            if (pattern.GetLength(0) % 2 == 0) {
                                Debug.LogWarning("GetUnitsInPattern: Left direction requires odd-sized pattern width.");
                                yield break;
                            }
                            targetX = originX - px - 1;
                            targetY = originY - py + (pattern.GetLength(0) / 2);
                            break;
                        case EDirection.Up:
                            targetX = originX + py - (pattern.GetLength(0) / 2);
                            targetY = originY - px - 1;
                            break;
                        case EDirection.Down:
                            targetX = originX - py + (pattern.GetLength(0) / 2);
                            targetY = originY + px + 1;
                            break;
                        case EDirection.Center:
                            if (pattern.GetLength(0) % 2 == 0 || pattern.GetLength(1) % 2 == 0) {
                                Debug.LogWarning("GetUnitsInPattern: Center direction requires odd-sized pattern.");
                                yield break;
                            }
                            targetX = originX + px - (pattern.GetLength(0) / 2);
                            targetY = originY + py - (pattern.GetLength(1) / 2);
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

        public void ClearBattlefield() {
            for (int x = 0; x < width; x++) {
                for (int y = 0; y < height; y++) {
                    battlefield[x, y] = null;
                }
            }
        }

    }
}
