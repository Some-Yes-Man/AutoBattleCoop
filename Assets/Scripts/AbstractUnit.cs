using UnityEngine;

namespace AutoBattleCoop {
    public abstract class AbstractUnit : MonoBehaviour {

        [field: SerializeField]
        public int HitPoints { get; protected set; }

        [field: SerializeField]
        public int Armor { get; protected set; }

        [field: SerializeField]
        public int Initiative { get; protected set; }

        public EUnitFaction Faction { get; protected set; } = EUnitFaction.Unknown;

    }

}
