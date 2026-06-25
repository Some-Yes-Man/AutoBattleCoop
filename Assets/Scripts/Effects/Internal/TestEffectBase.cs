using AutoBattleCoop.Assets.Scripts.Effects.Internal;
using System;

namespace AutoBattleCoop.Assets.Scripts.Effects {
    public class TestEffectBase : AbstractEffect {

        public TestEffectBase() {
            Type = EEffectType._TestEffectBase;
        }

        public override Tuple<EEffectResolveType, Type> ResolveEffects(IEffectResolver incomingEffect) {
            if (incomingEffect.Type == EEffectType._TestEffectNegatedWithoutRemoval) {
                return new(EEffectResolveType.Negated_Without_Removal, null);
            }
            if (incomingEffect.Type == EEffectType._TestEffectNegated) {
                return new(EEffectResolveType.Negated, null);
            }
            if (incomingEffect.Type == EEffectType._TestEffectJoined) {
                return new(EEffectResolveType.Joined, typeof(TestEffectJoinedResult));
            }
            return new(EEffectResolveType.Added, null);
        }

    }
}
