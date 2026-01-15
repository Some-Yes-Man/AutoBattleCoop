namespace AutoBattleCoop {
    public class TestUnit : AbstractUnit {

        public void RespecTestUnit(int hitPoints, int armor, int initiative, EUnitFaction unitFaction) {
            HitPoints = hitPoints;
            Initiative = initiative;
            Faction = unitFaction;
        }

    }
}
