using AutoBattleCoop.Assets.Scripts.Damage;
using AutoBattleCoop.Assets.Scripts.Effects.Internal;
using System;
using UnityEngine;

namespace AutoBattleCoop.Assets.Scripts.Effects {
    public class BurnEffect : AbstractEffect, IDamageResolver {

        public BurnEffect() {
            Type = EffectType.Burning;
        }

        public int ResolveDamage(int baseDamage, EDamageType damageType, AbstractUnit unit) {
            return damageType switch {
                EDamageType.Ice => Mathf.RoundToInt(baseDamage * -0.5f),
                _ => 0,
            };
        }

        public override Tuple<EffectResolveType, Type> ResolveEffects(IEffectResolver incomingEffect) {
            return incomingEffect.Type switch {
                EffectType.Wet => new(EffectResolveType.Joined, typeof(SteamEffect)),
                EffectType.Cold => new(EffectResolveType.Negated, null),
                EffectType.Frozen => new(EffectResolveType.Joined, typeof(WetEffect)),
                _ => new(EffectResolveType.Added, null),
            };
        }

    }
}
