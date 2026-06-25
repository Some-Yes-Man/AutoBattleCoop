using AutoBattleCoop.Assets.Scripts.Damage;
using UnityEngine;

namespace AutoBattleCoop.Assets.Scripts.Effects {
    public class DoubleDamageEffect : IDamageResolver {

        public int ResolveDamage(int baseDamage, EDamageType damageType, AbstractUnit unit) {
            return damageType switch {
                _ => Mathf.RoundToInt(baseDamage * 1.0f)
            };
        }

    }
}
