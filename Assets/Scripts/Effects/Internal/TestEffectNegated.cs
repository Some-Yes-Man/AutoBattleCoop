using AutoBattleCoop.Assets.Scripts.Effects.Internal;
using System;

namespace AutoBattleCoop.Assets.Scripts.Effects {
    public class TestEffectNegated : AbstractEffect {

        public TestEffectNegated() {
            Type = EEffectType._TestEffectNegated;
        }

        public override Tuple<EEffectResolveType, Type> ResolveEffects(IEffectResolver incomingEffect) {
            if (incomingEffect.Type == EEffectType._TestEffectBase) {
                return new(EEffectResolveType.Negated, null);
            }
            return new(EEffectResolveType.Added, null);
        }

    }
}
