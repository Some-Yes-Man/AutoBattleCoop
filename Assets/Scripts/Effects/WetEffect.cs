using AutoBattleCoop.Assets.Scripts.Damage;
using AutoBattleCoop.Assets.Scripts.Effects.Internal;
using System;
using UnityEngine;

namespace AutoBattleCoop.Assets.Scripts.Effects {
    public class WetEffect : AbstractEffect, IDamageResolver {

        public WetEffect() {
            Type = EEffectType.Wet;
        }

        public int ResolveDamage(int baseDamage, EDamageType damageType, AbstractUnit unit) {
            return damageType switch {
                EDamageType.Fire => Mathf.RoundToInt(baseDamage * -0.5f),
                EDamageType.Ice => Mathf.RoundToInt(baseDamage * 0.5f),
                EDamageType.Lightning => Mathf.RoundToInt(baseDamage * 1.0f),
                _ => 0,
            };
        }

        public override Tuple<EEffectResolveType, Type> ResolveEffects(IEffectResolver incomingEffect) {
            return incomingEffect.Type switch {
                EEffectType.Cold => new(EEffectResolveType.Joined, typeof(FrozenEffect)),
                EEffectType.Burning => new(EEffectResolveType.Joined, typeof(SteamEffect)),
                _ => new(EEffectResolveType.Added, null),
            };
        }

    }
}
