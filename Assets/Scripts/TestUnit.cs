namespace AutoBattleCoop.Assets.Scripts {
    public class TestUnit : AbstractUnit {

        public void RespecTestUnit(int hitPoints, int armor, int initiative, EUnitFaction unitFaction) {
            BaseMaxHitPoints = hitPoints;
            BaseInitiative = initiative;
            Faction = unitFaction;
        }

    }
}
