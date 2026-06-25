namespace AutoBattleCoop.Assets.Scripts.Stats {
    public interface IStatModifier {

        EStatType StatType { get; }

        int ResolveStats();

    }
}
