using AutoBattleCoop.Assets.Scripts.Effects.Internal;
using System;

namespace AutoBattleCoop.Assets.Scripts.Effects {
    public class WetEffect : AbstractEffect {

        public WetEffect() {
            Type = EffectType.Wet;
        }

        public override Tuple<EffectResolveType, Type> ResolveEffects(IEffectResolver incomingEffect) {
            if (incomingEffect.Type == EffectType.Cold) {
                return new(EffectResolveType.Joined, typeof(FrozenEffect));
            }
            return new(EffectResolveType.Added, null);
        }

    }
}
