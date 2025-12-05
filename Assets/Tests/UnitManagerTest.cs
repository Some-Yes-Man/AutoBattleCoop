using NUnit.Framework;
using UnityEngine;

namespace AutoBattleCoop {
    public class UnitManagerTest {

        [Test]
        public void RemoveUnit_When_Unit_is_Removed() {
            UnitManager unitManager = new GameObject().AddComponent<UnitManager>();
            var unit1 = new GameObject().AddComponent<TestUnit>();
            var unit2 = new GameObject().AddComponent<TestUnit>();
            unitManager.AddUnit(unit1);
            unitManager.AddUnit(unit2);
            CollectionAssert.AreEquivalent(new[] { unit1, unit2 }, unitManager.GetAllUnits());
            unitManager.RemoveUnit(unit1);
            CollectionAssert.AreEquivalent(new[] { unit2 }, unitManager.GetAllUnits());
        }

        [Test]
        public void AddUnits_When_Added() {
            UnitManager unitManager = new GameObject().AddComponent<UnitManager>();
            var unit1 = new GameObject().AddComponent<TestUnit>();
            var unit2 = new GameObject().AddComponent<TestUnit>();
            var unit3 = new GameObject().AddComponent<TestUnit>();
            unitManager.AddUnit(unit1);
            unitManager.AddUnit(unit2);
            unitManager.AddUnit(unit3);
            CollectionAssert.AreEquivalent(new[] { unit1, unit2, unit3 }, unitManager.GetAllUnits());
        }

        [Test]
        public void GetUnitsInFraction_When_Fraction() {
            UnitManager unitManager = new GameObject().AddComponent<UnitManager>();
            var unit1 = new GameObject().AddComponent<TestUnit>();
            unit1.RespecTestUnit(0, 0, 0, EUnitFaction.Neutral);
            var unit2 = new GameObject().AddComponent<TestUnit>();
            unit2.RespecTestUnit(0, 0, 0, EUnitFaction.TeamA);
            var unit3 = new GameObject().AddComponent<TestUnit>();
            unit3.RespecTestUnit(0, 0, 0, EUnitFaction.TeamB);
            var unit4 = new GameObject().AddComponent<TestUnit>();
            unit4.RespecTestUnit(0, 0, 0, EUnitFaction.TeamA);
            unitManager.AddUnit(unit1);
            unitManager.AddUnit(unit2);
            unitManager.AddUnit(unit3);
            unitManager.AddUnit(unit4);
            CollectionAssert.AreEquivalent(new[] { unit1 }, unitManager.GetUnitsInFraction(EUnitFaction.Neutral));
            CollectionAssert.AreEquivalent(new[] { unit2, unit4 }, unitManager.GetUnitsInFraction(EUnitFaction.TeamA));
            CollectionAssert.AreEquivalent(new[] { unit3 }, unitManager.GetUnitsInFraction(EUnitFaction.TeamB));
        }

    }
}
