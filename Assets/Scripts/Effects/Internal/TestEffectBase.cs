using AutoBattleCoop.Assets.Scripts.Effects.Internal;
using System;

namespace AutoBattleCoop.Assets.Scripts.Effects {
    public class TestEffectBase : AbstractEffect {

        public TestEffectBase() {
            Type = EffectType._TestEffectBase;
        }

        public override Tuple<EffectResolveType, Type> ResolveEffects(IEffectResolver incomingEffect) {
            if (incomingEffect.Type == EffectType._TestEffectNegatedWithoutRemoval) {
                return new(EffectResolveType.Negated_Without_Removal, null);
            }
            if (incomingEffect.Type == EffectType._TestEffectNegated) {
                return new(EffectResolveType.Negated, null);
            }
            if (incomingEffect.Type == EffectType._TestEffectJoined) {
                return new(EffectResolveType.Joined, typeof(TestEffectJoinedResult));
            }
            return new(EffectResolveType.Added, null);
        }

    }
}
