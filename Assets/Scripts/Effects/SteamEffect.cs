using AutoBattleCoop.Assets.Scripts.Damage;
using AutoBattleCoop.Assets.Scripts.Effects.Internal;
using System;
using UnityEngine;

namespace AutoBattleCoop.Assets.Scripts.Effects {
    public class SteamEffect : AbstractEffect, IDamageResolver {

        public SteamEffect() {
            Type = EffectType.Steam;
        }

        public int ResolveDamage(int baseDamage, EDamageType damageType, AbstractUnit unit) {
            return damageType switch {
                EDamageType.Ice => Mathf.RoundToInt(baseDamage * -0.5f),
                EDamageType.Lightning => Mathf.RoundToInt(baseDamage * 0.5f),
                _ => 0,
            };
        }

        public override Tuple<EffectResolveType, Type> ResolveEffects(IEffectResolver incomingEffect) {
            return incomingEffect.Type switch { _ => new(EffectResolveType.Added, null) };
        }

    }
}
