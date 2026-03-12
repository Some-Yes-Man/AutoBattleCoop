using AutoBattleCoop.Assets.Scripts.Effects.Internal;
using System;

namespace AutoBattleCoop.Assets.Scripts.Effects {
    public class ColdEffect : AbstractEffect {

        public ColdEffect() {
            Type = EffectType.Cold;
        }

        public override Tuple<EffectResolveType, Type> ResolveEffects(IEffectResolver incomingEffect) {
            if (incomingEffect.Type == EffectType.Wet) {
                return new(EffectResolveType.Joined, typeof(FrozenEffect));
            }
            return new(EffectResolveType.Added, null);
        }

    }
}
