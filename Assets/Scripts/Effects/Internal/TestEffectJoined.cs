using AutoBattleCoop.Assets.Scripts.Effects.Internal;
using System;

namespace AutoBattleCoop.Assets.Scripts.Effects {
    public class TestEffectJoined : AbstractEffect {

        public TestEffectJoined() {
            Type = EffectType._TestEffectJoined;
        }

        public override Tuple<EffectResolveType, Type> ResolveEffects(IEffectResolver incomingEffect) {
            if (incomingEffect.Type == EffectType._TestEffectBase) {
                return new(EffectResolveType.Joined, typeof(TestEffectJoinedResult));
            }
            return new(EffectResolveType.Added, null);
        }

    }
}
