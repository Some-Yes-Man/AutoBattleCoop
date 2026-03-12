using AutoBattleCoop.Assets.Scripts.Effects.Internal;
using System;

namespace AutoBattleCoop.Assets.Scripts.Effects {
    public class TestEffectNegateWithoutRemoval : AbstractEffect {

        public TestEffectNegateWithoutRemoval() {
            Type = EffectType._TestEffectNegatedWithoutRemoval;
        }

        public override Tuple<EffectResolveType, Type> ResolveEffects(IEffectResolver incomingEffect) {
            if (incomingEffect.Type == EffectType._TestEffectBase) {
                return new(EffectResolveType.Negated_Without_Removal, null);
            }
            return new(EffectResolveType.Added, null);
        }

    }
}
