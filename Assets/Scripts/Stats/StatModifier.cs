using UnityEngine;

namespace AutoBattleCoop.Assets.Scripts.Stats {
    public class StatModifier : MonoBehaviour, IStatModifier {

        [field: SerializeField]
        public int Amount { get; set; }

        [field: SerializeField]
        public EStatType Stat { get; set; }

        public EStatType StatType { get { return this.Stat; } }

        public int ResolveStats() {
            return this.Amount;
        }

    }
}
