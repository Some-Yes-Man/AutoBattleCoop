using AutoBattleCoop.Assets.Scripts.Effects.Internal;
using System;

namespace AutoBattleCoop.Assets.Scripts.Effects {
    public class TestEffectJoined : AbstractEffect {

        public TestEffectJoined() {
            Type = EEffectType._TestEffectJoined;
        }

        public override Tuple<EEffectResolveType, Type> ResolveEffects(IEffectResolver incomingEffect) {
            if (incomingEffect.Type == EEffectType._TestEffectBase) {
                return new(EEffectResolveType.Joined, typeof(TestEffectJoinedResult));
            }
            return new(EEffectResolveType.Added, null);
        }

    }
}
