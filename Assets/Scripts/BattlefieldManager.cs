using AutoBattleCoop;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts {
    public class BattlefieldManager : MonoBehaviour {

        public static BattlefieldManager Instance;

        [field: SerializeField]
        public int Width { get; private set; } = 10;
        [field: SerializeField]
        public int Height { get; private set; } = 10;

        private AbstractUnit[,] battlefield;

        void Awake() {
            Debug.Log("BattlefieldManager Awake");
            if (Instance != null) {
                Destroy(Instance);
            }
            Instance = this;

            battlefield = new AbstractUnit[Width, Height];

            //DontDestroyOnLoad(gameObject);
        }

        public bool AddUnit(AbstractUnit unit, int x, int y) {
            if ((x < 0) || (x >= Width) || (y < 0) || (y >= Height)) {
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
            if ((x < 0) || (x >= Width) || (y < 0) || (y >= Height)) {
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

        public bool RemoveUnit(AbstractUnit unit) {
            for (int x = 0; x < Width; x++) {
                for (int y = 0; y < Height; y++) {
                    if (battlefield[x, y] == unit) {
                        battlefield[x, y] = null;
                        return true;
                    }
                }
            }
            Debug.LogWarning("RemoveUnit: Unit not found on battlefield.");
            return false;
        }

        public AbstractUnit GetUnitAt(int x, int y) {
            if ((x < 0) || (x >= Width) || (y < 0) || (y >= Height)) {
                Debug.LogWarning("GetUnitAt: Position out of bounds.");
                return null;
            }

            return battlefield[x, y];
        }

        public IEnumerable<AbstractUnit> GetAllUnits() {
            for (int x = 0; x < Width; x++) {
                for (int y = 0; y < Height; y++) {
                    if (battlefield[x, y] != null) {
                        yield return battlefield[x, y];
                    }
                }
            }
        }

        public IEnumerable<AbstractUnit> GetUnitsInPattern(int originX, int originY, bool[,] pattern, EDirection direction) {
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

                    if ((targetX >= 0) && (targetX < Width) && (targetY >= 0) && (targetY < Height)) {
                        AbstractUnit unit = battlefield[targetX, targetY];
                        if (unit != null) {
                            yield return unit;
                        }
                    }
                }
            }
        }

        public void ClearBattlefield() {
            for (int x = 0; x < Width; x++) {
                for (int y = 0; y < Height; y++) {
                    battlefield[x, y] = null;
                }
            }
        }

    }
}
