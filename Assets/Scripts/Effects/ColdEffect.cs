using AutoBattleCoop.Assets.Scripts.Damage;
using AutoBattleCoop.Assets.Scripts.Effects.Internal;
using System;
using UnityEngine;

namespace AutoBattleCoop.Assets.Scripts.Effects {
    public class ColdEffect : AbstractEffect, IDamageResolver {

        public ColdEffect() {
            Type = EEffectType.Cold;
        }

        public int ResolveDamage(int baseDamage, EDamageType damageType, AbstractUnit unit) {
            return damageType switch {
                EDamageType.Fire => Mathf.RoundToInt(baseDamage * -0.5f),
                _ => 0,
            };
        }

        public override Tuple<EEffectResolveType, Type> ResolveEffects(IEffectResolver incomingEffect) {
            return incomingEffect.Type switch {
                EEffectType.Wet => new(EEffectResolveType.Joined, typeof(FrozenEffect)),
                EEffectType.Burning => new(EEffectResolveType.Negated, null),
                _ => new(EEffectResolveType.Added, null),
            };
        }

    }
}
