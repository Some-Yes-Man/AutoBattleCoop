using System.Collections;
using DefaultNamespace;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class UnitManagerTest
{
    [Test]
    public void RemoveUnit_When_Unit_is_Removed()
    {
        UnitManager unitManager = new GameObject().AddComponent<UnitManager>();
        var unit1 = new GameObject().AddComponent<Unit>(); 
        var unit2 = new GameObject().AddComponent<Unit>();
        unitManager.AddUnit(unit1); 
        unitManager.AddUnit(unit2);
        CollectionAssert.AreEquivalent(new[] { unit1, unit2 }, unitManager.GetAllUnits());
        unitManager.RemoveUnit(unit1);
        CollectionAssert.AreEquivalent(new[] { unit2 }, unitManager.GetAllUnits());
    }
    
    [Test]
    public void AddUnits_When_Added()
    {
        UnitManager unitManager = new GameObject().AddComponent<UnitManager>();
        var unit1 = new GameObject().AddComponent<Unit>(); 
        var unit2 = new GameObject().AddComponent<Unit>(); 
        var unit3 = new GameObject().AddComponent<Unit>();
        unitManager.AddUnit(unit1); 
        unitManager.AddUnit(unit2);
        unitManager.AddUnit(unit3);
        CollectionAssert.AreEquivalent(new[] { unit1, unit2, unit3 }, unitManager.GetAllUnits());
    }

   [Test]
    public void GetUnitsInFraction_When_Fraction()
    {
        UnitManager unitManager = new GameObject().AddComponent<UnitManager>();
        var unit1 = new GameObject().AddComponent<Unit>();
        unit1.fraction = EUnitFraction.Neutral;
        var unit2 = new GameObject().AddComponent<Unit>(); 
        unit2.fraction = EUnitFraction.TeamA;
        var unit3 = new GameObject().AddComponent<Unit>();
        unit3.fraction = EUnitFraction.TeamB;
        var unit4 = new GameObject().AddComponent<Unit>();
        unit4.fraction = EUnitFraction.TeamA;
        unitManager.AddUnit(unit1); 
        unitManager.AddUnit(unit2);
        unitManager.AddUnit(unit3);
        unitManager.AddUnit(unit4);
        CollectionAssert.AreEquivalent(new[] { unit1 }, unitManager.GetUnitsInFraction(EUnitFraction.Neutral));
        CollectionAssert.AreEquivalent(new[] { unit2, unit4 }, unitManager.GetUnitsInFraction(EUnitFraction.TeamA));
        CollectionAssert.AreEquivalent(new[] { unit3 }, unitManager.GetUnitsInFraction(EUnitFraction.TeamB));
    }
}
