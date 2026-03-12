using AutoBattleCoop.Assets.Scripts.Effects.Internal;
using System;

namespace AutoBattleCoop.Assets.Scripts.Effects {
    public class TestEffectAdded : AbstractEffect {

        public TestEffectAdded() {
            Type = EffectType._TestEffectAdded;
        }

        public override Tuple<EffectResolveType, Type> ResolveEffects(IEffectResolver incomingEffect) {
            return new(EffectResolveType.Added, null);
        }

    }
}
