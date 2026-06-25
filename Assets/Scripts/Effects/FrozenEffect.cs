using AutoBattleCoop.Assets.Scripts.Damage;
using AutoBattleCoop.Assets.Scripts.Effects.Internal;
using System;
using UnityEngine;

namespace AutoBattleCoop.Assets.Scripts.Effects {
    public class FrozenEffect : AbstractEffect, IDamageResolver {

        public FrozenEffect() {
            Type = EEffectType.Frozen;
        }

        public int ResolveDamage(int baseDamage, EDamageType damageType, AbstractUnit unit) {
            return damageType switch {
                EDamageType.Physical => Mathf.RoundToInt(baseDamage * 1.0f),
                EDamageType.Fire => Mathf.RoundToInt(baseDamage * -1.0f),
                EDamageType.Lightning => Mathf.RoundToInt(baseDamage * 0.25f),
                _ => 0,
            };
        }

        public override Tuple<EEffectResolveType, Type> ResolveEffects(IEffectResolver incomingEffect) {
            return incomingEffect.Type switch {
                EEffectType.Burning => new(EEffectResolveType.Joined, typeof(WetEffect)),
                _ => new(EEffectResolveType.Added, null),
            };
        }

    }
}
