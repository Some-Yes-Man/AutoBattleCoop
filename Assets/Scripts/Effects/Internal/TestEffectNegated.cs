using AutoBattleCoop.Assets.Scripts.Effects.Internal;
using System;

namespace AutoBattleCoop.Assets.Scripts.Effects {
    public class TestEffectNegated : AbstractEffect {

        public TestEffectNegated() {
            Type = EffectType._TestEffectNegated;
        }

        public override Tuple<EffectResolveType, Type> ResolveEffects(IEffectResolver incomingEffect) {
            if (incomingEffect.Type == EffectType._TestEffectBase) {
                return new(EffectResolveType.Negated, null);
            }
            return new(EffectResolveType.Added, null);
        }

    }
}
