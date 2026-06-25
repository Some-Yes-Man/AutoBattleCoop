namespace AutoBattleCoop.Assets.Scripts.Stats {
    public class InitiativeModifier : IStatModifier {

        public EStatType StatType { get { return EStatType.HitPoints; } }

        public int ResolveStats() {
            return 0;
        }

    }
}
