using AutoBattleCoop.Assets.Scripts.Effects.Internal;
using System;

namespace AutoBattleCoop.Assets.Scripts.Effects {
    public class TestEffectJoinedResult : AbstractEffect {

        public TestEffectJoinedResult() {
            Type = EffectType._TestEffectJoinedResult;
        }

        public override Tuple<EffectResolveType, Type> ResolveEffects(IEffectResolver incomingEffect) {
            return new(EffectResolveType.Added, null);
        }

    }
}
