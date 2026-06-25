namespace AutoBattleCoop.Assets.Scripts.Stats {
    public class HitPointModifier : IStatModifier {

        public EStatType StatType { get { return EStatType.HitPoints; } }

        public int ResolveStats() {
            return 0;
        }

    }
}
