using AutoBattleCoop.Assets.Scripts.Effects.Internal;
using System;

namespace AutoBattleCoop.Assets.Scripts.Effects {
    public class TestEffectNegateWithoutRemoval : AbstractEffect {

        public TestEffectNegateWithoutRemoval() {
            Type = EEffectType._TestEffectNegatedWithoutRemoval;
        }

        public override Tuple<EEffectResolveType, Type> ResolveEffects(IEffectResolver incomingEffect) {
            if (incomingEffect.Type == EEffectType._TestEffectBase) {
                return new(EEffectResolveType.Negated_Without_Removal, null);
            }
            return new(EEffectResolveType.Added, null);
        }

    }
}
