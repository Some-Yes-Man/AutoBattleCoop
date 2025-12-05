using NUnit.Framework.Constraints;
using UnityEditor;
using UnityEditor.UI;
using UnityEngine;

namespace AutoBattleCoop  {
    public class TestUnit : Unit {

        public void respecTestUnit(int hitPoints, int armor, int initiative, EUnitFaction unitFaction)
        {
            HitPoints=hitPoints;
            Armor=armor;
            Initiative=initiative;
            Faction=unitFaction;
        }

    }
}
