using Assets.Scripts;
using NUnit.Framework;
using UnityEngine;

namespace AutoBattleCoop {
    public class BattlefieldManagerTest {

        [Test]
        public void AddUnit_EmptyPositionInsideBounds_ReturnsTrue() {
            // Arrange
            var battlefieldManager = new GameObject().AddComponent<BattlefieldManager>();
            var unit = new GameObject().AddComponent<TestUnit>();
            // Act
            bool result = battlefieldManager.AddUnit(unit, 5, 5);
            // Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void AddUnit_AfterRemovingUnit_ReturnsTrue() {
            // Arrange
            var battlefieldManager = new GameObject().AddComponent<BattlefieldManager>();
            var unit = new GameObject().AddComponent<TestUnit>();
            battlefieldManager.AddUnit(unit, 5, 5);
            battlefieldManager.RemoveUnit(unit);
            // Act
            bool result = battlefieldManager.AddUnit(unit, 5, 5);
            // Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void AddUnit_OccupiedPosition_ReturnsFalse() {
            // Arrange
            var battlefieldManager = new GameObject().AddComponent<BattlefieldManager>();
            var unit1 = new GameObject().AddComponent<TestUnit>();
            var unit2 = new GameObject().AddComponent<TestUnit>();
            battlefieldManager.AddUnit(unit1, 5, 5);
            // Act
            bool result = battlefieldManager.AddUnit(unit2, 5, 5);
            // Assert
            Assert.IsFalse(result);
        }

        [Test]
        public void AddUnit_OutOfBoundsPosition_ReturnsFalse() {
            // Arrange
            var battlefieldManager = new GameObject().AddComponent<BattlefieldManager>();
            var unit = new GameObject().AddComponent<TestUnit>();
            // Act
            bool result = battlefieldManager.AddUnit(unit, 9999, 9999);
            // Assert
            Assert.IsFalse(result);
        }

        [Test]
        public void ClearCoordinate_OccupiedPosition_ReturnsTrue() {
            // Arrange
            var battlefieldManager = new GameObject().AddComponent<BattlefieldManager>();
            var unit = new GameObject().AddComponent<TestUnit>();
            battlefieldManager.AddUnit(unit, 5, 5);
            // Act
            bool result = battlefieldManager.ClearCoordinate(5, 5);
            // Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void ClearCoordinate_EmptyPosition_ReturnsFalse() {
            // Arrange
            var battlefieldManager = new GameObject().AddComponent<BattlefieldManager>();
            // Act
            bool result = battlefieldManager.ClearCoordinate(5, 5);
            // Assert
            Assert.IsFalse(result);
        }

        [Test]
        public void ClearCoordinate_OutOfBoundsPosition_ReturnsFalse() {
            // Arrange
            var battlefieldManager = new GameObject().AddComponent<BattlefieldManager>();
            // Act
            bool result = battlefieldManager.ClearCoordinate(9999, 9999);
            // Assert
            Assert.IsFalse(result);
        }

        [Test]
        public void RemoveUnit_ExistingUnit_ReturnsTrue() {
            // Arrange
            var battlefieldManager = new GameObject().AddComponent<BattlefieldManager>();
            var unit = new GameObject().AddComponent<TestUnit>();
            battlefieldManager.AddUnit(unit, 5, 5);
            // Act
            bool result = battlefieldManager.RemoveUnit(unit);
            // Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void RemoveUnit_NonExistingUnit_ReturnsFalse() {
            // Arrange
            var battlefieldManager = new GameObject().AddComponent<BattlefieldManager>();
            var unit = new GameObject().AddComponent<TestUnit>();
            // Act
            bool result = battlefieldManager.RemoveUnit(unit);
            // Assert
            Assert.IsFalse(result);
        }

        [Test]
        public void RemoveUnit_AfterClearingCoordinate_ReturnsFalse() {
            // Arrange
            var battlefieldManager = new GameObject().AddComponent<BattlefieldManager>();
            var unit = new GameObject().AddComponent<TestUnit>();
            battlefieldManager.AddUnit(unit, 5, 5);
            battlefieldManager.ClearCoordinate(5, 5);
            // Act
            bool result = battlefieldManager.RemoveUnit(unit);
            // Assert
            Assert.IsFalse(result);
        }

        [Test]
        public void GetUnitAt_ExistingUnit_ReturnsUnit() {
            // Arrange
            var battlefieldManager = new GameObject().AddComponent<BattlefieldManager>();
            var unit = new GameObject().AddComponent<TestUnit>();
            battlefieldManager.AddUnit(unit, 5, 5);
            // Act
            var retrievedUnit = battlefieldManager.GetUnitAt(5, 5);
            // Assert
            Assert.AreEqual(unit, retrievedUnit);
        }

        [Test]
        public void GetUnitAt_EmptyPosition_ReturnsNull() {
            // Arrange
            var battlefieldManager = new GameObject().AddComponent<BattlefieldManager>();
            // Act
            var retrievedUnit = battlefieldManager.GetUnitAt(5, 5);
            // Assert
            Assert.IsNull(retrievedUnit);
        }

        [Test]
        public void GetUnitAt_OutOfBoundsPosition_ReturnsNull() {
            // Arrange
            var battlefieldManager = new GameObject().AddComponent<BattlefieldManager>();
            // Act
            var retrievedUnit = battlefieldManager.GetUnitAt(9999, 9999);
            // Assert
            Assert.IsNull(retrievedUnit);
        }

        [Test]
        public void GetAllUnits_ReturnsAllAddedUnits() {
            // Arrange
            var battlefieldManager = new GameObject().AddComponent<BattlefieldManager>();
            var unit1 = new GameObject().AddComponent<TestUnit>();
            var unit2 = new GameObject().AddComponent<TestUnit>();
            battlefieldManager.AddUnit(unit1, 2, 3);
            battlefieldManager.AddUnit(unit2, 4, 5);
            // Act
            var allUnits = battlefieldManager.GetAllUnits();
            // Assert
            CollectionAssert.AreEquivalent(new[] { unit1, unit2 }, allUnits);
        }

        [Test]
        public void GetAllUnits_AfterRemovingUnit_ReturnsRemainingUnits() {
            // Arrange
            var battlefieldManager = new GameObject().AddComponent<BattlefieldManager>();
            var unit1 = new GameObject().AddComponent<TestUnit>();
            var unit2 = new GameObject().AddComponent<TestUnit>();
            battlefieldManager.AddUnit(unit1, 2, 3);
            battlefieldManager.AddUnit(unit2, 4, 5);
            battlefieldManager.RemoveUnit(unit1);
            // Act
            var allUnits = battlefieldManager.GetAllUnits();
            // Assert
            CollectionAssert.AreEquivalent(new[] { unit2 }, allUnits);
        }

        [Test]
        public void GetAllUnits_EmptyBattlefield_ReturnsEmptyCollection() {
            // Arrange
            var battlefieldManager = new GameObject().AddComponent<BattlefieldManager>();
            // Act
            var allUnits = battlefieldManager.GetAllUnits();
            // Assert
            CollectionAssert.IsEmpty(allUnits);
        }

        [Test]
        public void ClearBattlefield_EmptyBattlefield_DoesNotThrow() {
            // Arrange
            var battlefieldManager = new GameObject().AddComponent<BattlefieldManager>();
            // Act & Assert
            Assert.DoesNotThrow(() => battlefieldManager.ClearBattlefield());
        }

        [Test]
        public void ClearBattlefield_WithUnits_ClearsAllUnits() {
            // Arrange
            var battlefieldManager = new GameObject().AddComponent<BattlefieldManager>();
            var unit1 = new GameObject().AddComponent<TestUnit>();
            var unit2 = new GameObject().AddComponent<TestUnit>();
            battlefieldManager.AddUnit(unit1, 2, 3);
            battlefieldManager.AddUnit(unit2, 4, 5);
            // Act
            battlefieldManager.ClearBattlefield();
            var allUnits = battlefieldManager.GetAllUnits();
            // Assert
            CollectionAssert.IsEmpty(allUnits);
        }

        private static bool[,] Transpose(bool[,] matrix) {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            bool[,] transposed = new bool[cols, rows];
            for (int i = 0; i < rows; i++) {
                for (int j = 0; j < cols; j++) {
                    transposed[j, i] = matrix[i, j];
                }
            }
            return transposed;
        }

        [Test]
        public void GetUnitsInPattern_PatternInBoundsAndNoUnitsInPattern_ReturnsEmptyCollection() {
            // Arrange
            var battlefieldManager = new GameObject().AddComponent<BattlefieldManager>();
            var pattern = Transpose(new bool[,] {
            { false, true, false },
            { true, true, true },
            { false, false, true }
        });
            // Act
            var unitsInPattern = battlefieldManager.GetUnitsInPattern(5, 5, pattern, EDirection.Right);
            // Assert
            CollectionAssert.IsEmpty(unitsInPattern);
        }

        [Test]
        public void GetUnitsInPattern_PatternInBoundsAndUnitsInPattern_ReturnsCorrectUnits() {
            // Arrange
            var battlefieldManager = new GameObject().AddComponent<BattlefieldManager>();
            var unit1 = new GameObject().AddComponent<TestUnit>();
            var unit2 = new GameObject().AddComponent<TestUnit>();
            battlefieldManager.AddUnit(unit1, 7, 4);
            battlefieldManager.AddUnit(unit2, 8, 6);
            var pattern = Transpose(new bool[,] {
            { false, true, false },
            { true, true, true },
            { false, false, true }
        });
            // Act
            var unitsInPattern = battlefieldManager.GetUnitsInPattern(5, 5, pattern, EDirection.Right);
            // Assert
            CollectionAssert.AreEquivalent(new[] { unit1, unit2 }, unitsInPattern);
        }

        [Test]
        public void GetUnitsInPattern_PatternOutOfBoundsAndNoUnitsInPattern_ReturnsEmptyCollection() {
            // Arrange
            var battlefieldManager = new GameObject().AddComponent<BattlefieldManager>();
            var pattern = Transpose(new bool[,] {
            { false, true, false },
            { true, true, true },
            { false, false, true }
        });
            // Act
            var unitsInPattern = battlefieldManager.GetUnitsInPattern(7, 5, pattern, EDirection.Right);
            // Assert
            CollectionAssert.IsEmpty(unitsInPattern);
        }

        [Test]
        public void GetUnitsInPattern_PatternOutOfBoundsAndUnitsInPattern_ReturnsCorrectUnits() {
            // Arrange
            var battlefieldManager = new GameObject().AddComponent<BattlefieldManager>();
            var unit1 = new GameObject().AddComponent<TestUnit>();
            var unit2 = new GameObject().AddComponent<TestUnit>();
            battlefieldManager.AddUnit(unit1, 9, 4);
            battlefieldManager.AddUnit(unit2, 9, 6);
            var pattern = Transpose(new bool[,] {
            { false, true, false },
            { true, true, true },
            { false, false, true }
        });
            // Act
            var unitsInPattern = battlefieldManager.GetUnitsInPattern(7, 5, pattern, EDirection.Right);
            // Assert
            CollectionAssert.AreEquivalent(new[] { unit1 }, unitsInPattern);
        }

        [Test]
        public void GetUnitsInPattern_PatternDirectionLeftAndUnitsInPattern_ReturnsCorrectUnits() {
            // Arrange
            var battlefieldManager = new GameObject().AddComponent<BattlefieldManager>();
            var unit1 = new GameObject().AddComponent<TestUnit>();
            var unit2 = new GameObject().AddComponent<TestUnit>();
            battlefieldManager.AddUnit(unit1, 3, 6);
            battlefieldManager.AddUnit(unit2, 2, 4);
            var pattern = Transpose(new bool[,] {
            { false, true, false },
            { true, true, true },
            { false, false, true }
        });
            // Act
            var unitsInPattern = battlefieldManager.GetUnitsInPattern(5, 5, pattern, EDirection.Left);
            // Assert
            CollectionAssert.AreEquivalent(new[] { unit1, unit2 }, unitsInPattern);
        }

        [Test]
        public void GetUnitsInPattern_PatternDirectionUpAndUnitsInPattern_ReturnsCorrectUnits() {
            // Arrange
            var battlefieldManager = new GameObject().AddComponent<BattlefieldManager>();
            var unit1 = new GameObject().AddComponent<TestUnit>();
            var unit2 = new GameObject().AddComponent<TestUnit>();
            battlefieldManager.AddUnit(unit1, 4, 3);
            battlefieldManager.AddUnit(unit2, 6, 2);
            var pattern = Transpose(new bool[,] {
            { false, true, false },
            { true, true, true },
            { false, false, true }
        });
            // Act
            var unitsInPattern = battlefieldManager.GetUnitsInPattern(5, 5, pattern, EDirection.Up);
            // Assert
            CollectionAssert.AreEquivalent(new[] { unit1, unit2 }, unitsInPattern);
        }

        [Test]
        public void GetUnitsInPattern_PatternDirectionDownAndUnitsInPattern_ReturnsCorrectUnits() {
            // Arrange
            var battlefieldManager = new GameObject().AddComponent<BattlefieldManager>();
            var unit1 = new GameObject().AddComponent<TestUnit>();
            var unit2 = new GameObject().AddComponent<TestUnit>();
            battlefieldManager.AddUnit(unit1, 4, 8);
            battlefieldManager.AddUnit(unit2, 6, 7);
            var pattern = Transpose(new bool[,] {
            { false, true, false },
            { true, true, true },
            { false, false, true }
        });
            // Act
            var unitsInPattern = battlefieldManager.GetUnitsInPattern(5, 5, pattern, EDirection.Down);
            // Assert
            CollectionAssert.AreEquivalent(new[] { unit1, unit2 }, unitsInPattern);
        }

        [Test]
        public void GetUnitsInPattern_PatternDirectionCenterAndEvenSizedPattern_ReturnsEmptyCollection() {
            // Arrange
            var battlefieldManager = new GameObject().AddComponent<BattlefieldManager>();
            var unit1 = new GameObject().AddComponent<TestUnit>();
            battlefieldManager.AddUnit(unit1, 5, 5);
            var pattern = new bool[,] {
            { true, true },
            { true, true }
        };
            // Act
            var unitsInPattern = battlefieldManager.GetUnitsInPattern(5, 5, pattern, EDirection.Center);
            // Assert
            CollectionAssert.IsEmpty(unitsInPattern);
        }

        [Test]
        public void GetUnitsInPattern_PatternDirectionCenterAndUnitsInPattern_ReturnsCorrectUnits() {
            // Arrange
            var battlefieldManager = new GameObject().AddComponent<BattlefieldManager>();
            var unit1 = new GameObject().AddComponent<TestUnit>();
            var unit2 = new GameObject().AddComponent<TestUnit>();
            var unit3 = new GameObject().AddComponent<TestUnit>();
            battlefieldManager.AddUnit(unit1, 4, 4);
            battlefieldManager.AddUnit(unit2, 5, 5);
            battlefieldManager.AddUnit(unit3, 6, 6);
            var pattern = new bool[,] {
            { true, false, true },
            { false, true, false },
            { true, false, true }
        };
            // Act
            var unitsInPattern = battlefieldManager.GetUnitsInPattern(5, 5, pattern, EDirection.Center);
            // Assert
            CollectionAssert.AreEquivalent(new[] { unit1, unit2, unit3 }, unitsInPattern);
        }

    }
}
