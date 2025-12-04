using UnityEngine;

namespace AutoBattleCoop {
    public class PatternGenerator {

        protected PatternGenerator() { }

        public static bool[,] GeneratePatternMap(EAttackPattern attackPattern, int attackDistance) {
            switch (attackPattern) {
                case EAttackPattern.Forward:
                    bool[,] patternMap = new bool[attackDistance, 1];
                    for (int i = 0; i < attackDistance; i++) {
                        patternMap[i, 0] = true;
                    }
                    return patternMap;
                case EAttackPattern.Manhattan:
                    int size = attackDistance * 2 + 1;
                    bool[,] manhattanMap = new bool[size, size];
                    int center = attackDistance;
                    for (int x = 0; x < size; x++) {
                        for (int y = 0; y < size; y++) {
                            if (Mathf.Abs(x - center) + Mathf.Abs(y - center) <= attackDistance) {
                                manhattanMap[x, y] = true;
                            }
                        }
                    }
                    manhattanMap[center, center] = false;
                    return manhattanMap;
                case EAttackPattern.Cross:
                    int crossSize = attackDistance * 2 + 1;
                    bool[,] crossMap = new bool[crossSize, crossSize];
                    int crossCenter = attackDistance;
                    for (int i = 0; i < crossSize; i++) {
                        crossMap[crossCenter, i] = true;
                        crossMap[i, crossCenter] = true;
                    }
                    crossMap[crossCenter, crossCenter] = false;
                    return crossMap;
                case EAttackPattern.Diagonals:
                    int diagSize = attackDistance * 2 + 1;
                    bool[,] diagMap = new bool[diagSize, diagSize];
                    for (int i = 0; i < diagSize; i++) {
                        diagMap[i, i] = true;
                        diagMap[i, diagSize - 1 - i] = true;
                    }
                    diagMap[attackDistance, attackDistance] = false;
                    return diagMap;
                case EAttackPattern.Star:
                    int starSize = attackDistance * 2 + 1;
                    bool[,] starMap = new bool[starSize, starSize];
                    int starCenter = attackDistance;
                    for (int i = 0; i < starSize; i++) {
                        starMap[starCenter, i] = true;
                        starMap[i, starCenter] = true;
                        starMap[i, i] = true;
                        starMap[i, starSize - 1 - i] = true;
                    }
                    starMap[starCenter, starCenter] = false;
                    return starMap;
                case EAttackPattern.Cone:
                    bool[,] coneMap = new bool[attackDistance, (attackDistance - 1) * 2 + 1];
                    int coneCenter = attackDistance - 1;
                    for (int i = 0; i < attackDistance; i++) {
                        for (int j = -i; j <= i; j++) {
                            coneMap[i, coneCenter + j] = true;
                        }
                    }
                    return coneMap;
                default:
                    Debug.LogWarning("GeneratePatternMap: Unknown attack pattern.");
                    return new bool[0, 0];
            }
        }

    }
}
