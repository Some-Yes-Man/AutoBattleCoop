using NUnit.Framework;
using UnityEngine;

public class BattlefieldManagerTest {

    [Test]
    public void AddUnit_ValidPosition_ReturnsTrue() {
        // Arrange
        var battlefieldManager = new GameObject().AddComponent<BattlefieldManager>();
        var unit = new GameObject().AddComponent<Unit>();
        // Act
        bool result = battlefieldManager.AddUnit(unit, 5, 5);
        // Assert
        Assert.IsTrue(result);
    }

}
