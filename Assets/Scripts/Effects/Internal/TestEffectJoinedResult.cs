using AutoBattleCoop.Assets.Scripts.Effects.Internal;
using System;

namespace AutoBattleCoop.Assets.Scripts.Effects {
    public class TestEffectJoinedResult : AbstractEffect {

        public TestEffectJoinedResult() {
            Type = EEffectType._TestEffectJoinedResult;
        }

        public override Tuple<EEffectResolveType, Type> ResolveEffects(IEffectResolver incomingEffect) {
            return new(EEffectResolveType.Added, null);
        }

    }
}
