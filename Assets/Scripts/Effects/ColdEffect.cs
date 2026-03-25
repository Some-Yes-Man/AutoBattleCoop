using AutoBattleCoop.Assets.Scripts.Damage;
using AutoBattleCoop.Assets.Scripts.Effects.Internal;
using System;
using UnityEngine;

namespace AutoBattleCoop.Assets.Scripts.Effects {
    public class ColdEffect : AbstractEffect, IDamageResolver {

        public ColdEffect() {
            Type = EffectType.Cold;
        }

        public int ResolveDamage(int baseDamage, EDamageType damageType, AbstractUnit unit) {
            return damageType switch {
                EDamageType.Fire => Mathf.RoundToInt(baseDamage * -0.5f),
                _ => 0,
            };
        }

        public override Tuple<EffectResolveType, Type> ResolveEffects(IEffectResolver incomingEffect) {
            return incomingEffect.Type switch {
                EffectType.Wet => new(EffectResolveType.Joined, typeof(FrozenEffect)),
                EffectType.Burning => new(EffectResolveType.Negated, null),
                _ => new(EffectResolveType.Added, null),
            };
        }

    }
}
