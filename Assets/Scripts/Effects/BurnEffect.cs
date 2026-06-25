using AutoBattleCoop.Assets.Scripts.Damage;
using AutoBattleCoop.Assets.Scripts.Effects.Internal;
using System;
using UnityEngine;

namespace AutoBattleCoop.Assets.Scripts.Effects {
    public class BurnEffect : AbstractEffect, IDamageResolver {

        public BurnEffect() {
            Type = EEffectType.Burning;
        }

        public int ResolveDamage(int baseDamage, EDamageType damageType, AbstractUnit unit) {
            return damageType switch {
                EDamageType.Ice => Mathf.RoundToInt(baseDamage * -0.5f),
                _ => 0,
            };
        }

        public override Tuple<EEffectResolveType, Type> ResolveEffects(IEffectResolver incomingEffect) {
            return incomingEffect.Type switch {
                EEffectType.Wet => new(EEffectResolveType.Joined, typeof(SteamEffect)),
                EEffectType.Cold => new(EEffectResolveType.Negated, null),
                EEffectType.Frozen => new(EEffectResolveType.Joined, typeof(WetEffect)),
                _ => new(EEffectResolveType.Added, null),
            };
        }

    }
}
