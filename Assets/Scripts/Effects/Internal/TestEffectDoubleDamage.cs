using AutoBattleCoop.Assets.Scripts;
using AutoBattleCoop.Assets.Scripts.Damage;
using AutoBattleCoop.Assets.Scripts.Effects.Internal;
using UnityEngine;

namespace AutoBattleCoop {
    public class TestEffectDoubleDamage : AbstractEffect, IDamageResolver {

        public int ResolveDamage(int baseDamage, EDamageType damageType, AbstractUnit unit) {
            return damageType switch {
                EDamageType._Test => 0,
                _ => Mathf.RoundToInt(baseDamage * 1.0f),
            };
        }

    }
}
